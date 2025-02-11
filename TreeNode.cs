namespace puzzles
{
    internal class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Parents { get; set; }
        public List<TreeNode<T>> Childs { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Parents = new List<TreeNode<T>>();
            Childs = new List<TreeNode<T>>();
        }

        public void AddParent(TreeNode<T> parent)
        {
            Parents.Add(parent);
            parent.Childs.Add(this);
        }

        public void AddChild(TreeNode<T> child)
        {
            Childs.Add(child);
            child.Parents.Add(this);
        }

        public List<TreeNode<T>> GetLongestFullPath()
        {
            List<TreeNode<T>> rootPath = GetLongestRootPath();

            List<TreeNode<T>> branchPath = GetLongestBranchPath();

            rootPath.Reverse();
            rootPath.AddRange(branchPath.Skip(1));

            return rootPath;
        }

        private List<TreeNode<T>> GetLongestRootPath()
        {
            List<TreeNode<T>> longestRootPath = new List<TreeNode<T>>();
            GetLongestRootPathRecursive(new List<TreeNode<T>>(), ref longestRootPath);
            return longestRootPath;
        }

        private void GetLongestRootPathRecursive(List<TreeNode<T>> currentPath, ref List<TreeNode<T>> longestPath)
        {
            currentPath.Add(this);

            if (Parents.Count == 0)
            {
                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = new List<TreeNode<T>>(currentPath);
                }
            }
            else
            {
                foreach (var parent in Parents)
                {
                    parent.GetLongestRootPathRecursive(currentPath, ref longestPath);
                }
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public List<TreeNode<T>> GetLongestBranchPath()
        {
            List<TreeNode<T>> longestPath = new List<TreeNode<T>>();
            GetLongestBranchPathRecursive(new List<TreeNode<T>>(), ref longestPath);
            return longestPath;
        }

        private void GetLongestBranchPathRecursive(List<TreeNode<T>> currentPath, ref List<TreeNode<T>> longestPath)
        {
            currentPath.Add(this);

            if (Childs.Count == 0)
            {
                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = new List<TreeNode<T>>(currentPath);
                }
            }
            else
            {
                foreach (var child in Childs)
                {
                    child.GetLongestBranchPathRecursive(currentPath, ref longestPath);
                }
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}
