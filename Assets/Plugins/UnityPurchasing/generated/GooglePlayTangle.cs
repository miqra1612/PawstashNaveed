#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("6MRgCoibQzJd8DKSQw9w+uGKN3oPjIKNvQ+Mh48PjIyNTOERV743aIOQ6naIzO6tnie+rYZs6n/3hk0OYel0g2os1n3ex2IwL1UfhYThZbiRBBrYZ+4vrfqK3yPbTdqevKG7QFaEIgEL1NeE1BLQw750VZ/PeuEuVOQ6E24/mhKFOMcTJ7ixOWfmS8a9D4yvvYCLhKcLxQt6gIyMjIiNjimvIj6zFIjQHits/VVgCtDBtOVvWLJS/4VPsiPFyh82yqy7JiatKWGdaHqmukeraLi9tiZQv6C+Eu9d3u/ZED3ABKv00PgujEGLG8AIYe2YTScXmqrlYzxI50ZK2yPPoa5tQ/qNXdokXfut2MuUGNuQ5ZYCOhxjV4yck+enhAIi1o+OjI2M");
        private static int[] order = new int[] { 13,1,9,11,5,9,12,13,12,10,12,11,12,13,14 };
        private static int key = 141;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
