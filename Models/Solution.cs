namespace AssignmentConsole.Model {
    public class Solution {
        public static int Add(int n, int m) {
            return n + m;
        }

        public static int Minimum(int x, int y, int z) {
            return x < y && x < z ? x : (y < z) ? y : z;
        }

        public static string GetFirstTwoChars(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            else if (s.Length == 1) return s.Substring(0, 1);
            return s.Substring(0, 2);
        }

        public static List<int> GetEvens(ICollection<int> nums) {
            if (nums.Count == 0) return null;
            var list = new List<int>();
            foreach (int x in nums)
                if (x % 2 == 0)
                    list.Add(x);
            return list;
        }

        public static string Minimum(string[] s) {
            s = s.OrderBy(x => x.Length).ToArray();
            return s[0];
        }
    }
}
