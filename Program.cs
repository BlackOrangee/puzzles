
using puzzles;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "source.txt";

        List<Puzzl> puzzles = ReadPuzzlesFromFile(filePath);

        bool leftToRight = false;
        int depth = puzzles.Count;

        Menu(ref leftToRight, ref depth);

        List<TreeNode<Puzzl>> root = TreeBuilder.BuildTree(puzzles, leftToRight, depth);

        PrintPuzzles(root);

        Console.ReadLine();
    }

    private static List<Puzzl> ReadPuzzlesFromFile(string filePath)
    {
        List<Puzzl> puzzles = new List<Puzzl>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length != 6)
                    {
                        Console.WriteLine("Invalid line length.");
                        continue;
                    }

                    string key1 = line.Substring(0, 2);
                    string value = line.Substring(2, 2);
                    string key2 = line.Substring(4, 2);

                    puzzles.Add(new Puzzl(key1, key2, value));
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return puzzles;
    }

    private static void Menu(ref bool leftToRight, ref int depth)
    {
        bool start = false;
        while (!start)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - Start");
            Console.WriteLine("2 - Set searchable depth");
            Console.WriteLine("3 - Set direction\n");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        start = true;
                        break;
                    case 2:
                        Console.WriteLine("Enter searchable depth:");
                        depth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Searchable depth set to {depth}\n");
                        break;
                    case 3:
                        Console.WriteLine("Enter direction: default is right to left.");
                        Console.WriteLine("1 - Left to right");
                        Console.WriteLine("2 - Right to left\n");
                        int input = Convert.ToInt32(Console.ReadLine());
                        string direction = input == 1 ? "left to right" : "right to left";

                        if (input == 1)
                        {
                            leftToRight = true;
                        }
                        else if (input == 2)
                        {
                            leftToRight = false;
                        }

                        Console.WriteLine($"Direction set to {direction}\n");
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.\n");
            }
        }
    }

    private static void PrintPuzzles(List<TreeNode<Puzzl>> root)
    {
        int depthCount = 0;
        string completedPuzzles = "";
        root.ForEach(node =>
        {
            Console.WriteLine($"Depth: {++depthCount} - {node.Value.getPuzzl()}");
            if (depthCount == 1)
            {
                completedPuzzles = node.Value.getPuzzlLikeFirst();
            }
            else
            {
                completedPuzzles += node.Value.getPuzzlLikeSecond();
            }
        });

        Console.WriteLine(completedPuzzles);
    }
}