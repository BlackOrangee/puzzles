
namespace puzzles
{
    internal class Puzzl
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Value { get; set; }

        public Puzzl(string key1, string key2, string value)
        {
            Key1 = key1;
            Key2 = key2;
            Value = value;
        }

        public string getPuzzl()
        {
            return $"{Key1} {Value} {Key2}";
        }

        public string getPuzzlLikeFirst()
        {
            return $"{Key1}{Value}{Key2}";
        }

        public string getPuzzlLikeSecond()
        {
            return $"{Value}{Key2}";
        }
    }
}
