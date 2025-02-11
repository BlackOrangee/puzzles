namespace puzzles
{
    internal class TreeBuilder
    {
        public static List<TreeNode<Puzzl>> BuildTree(List<Puzzl> puzzles, bool leftToRight, int serchableDepth)
        {
            List<TreeNode<Puzzl>> longestPath = new List<TreeNode<Puzzl>>();
            int count = 0;

            foreach (var puzzl in puzzles)
            {
                List<Puzzl> remaining = new List<Puzzl>(puzzles);
                remaining.Remove(puzzl);

                TreeNode<Puzzl> root = new TreeNode<Puzzl>(puzzl);
                int maxDepth = 0;

                BuildBranchRecursive(root, puzzl, remaining, 1, ref maxDepth, leftToRight);

                if (maxDepth > longestPath.Count)
                {
                    longestPath = root.GetLongestFullPath();
                }

                Console.WriteLine($"{++count} of {puzzles.Count} || Depth: {maxDepth}, Max Depth: {longestPath.Count}");

                if (longestPath.Count >= serchableDepth)
                {
                    break;
                }
            }

            return longestPath;
        }

        private static void BuildBranchRecursive(TreeNode<Puzzl> node, Puzzl puzzl, List<Puzzl> remainingPuzzles, 
                                                 int currentDepth, ref int maxDepth, bool leftToRight)
        {
            if (currentDepth > maxDepth)
            {
                maxDepth = currentDepth;
            }

            foreach (var next in remainingPuzzles.Where(p => leftToRight ? p.Key1 == puzzl.Key2 : p.Key2 == puzzl.Key1))
            {
                List<Puzzl> nextRemaining = new List<Puzzl>(remainingPuzzles);
                nextRemaining.Remove(next);

                TreeNode<Puzzl> nextNode = new TreeNode<Puzzl>(next);

                if (leftToRight)
                {
                    node.AddChild(nextNode);
                }
                else
                {
                    node.AddParent(nextNode);
                }

                BuildBranchRecursive(nextNode, next, nextRemaining, currentDepth + 1, ref maxDepth, leftToRight);
            }
        }
    }
}
