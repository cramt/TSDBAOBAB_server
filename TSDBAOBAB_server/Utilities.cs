using System.Numerics;

namespace TSDBAOBAB_server {
    public static class Utilities {
        public static Vector3 ToVector3(this float[] f) {
            return new Vector3(f[0], f[1], f[2]);
        }
        public static Quaternion ToQuaternion(this float[] f) {
            return new Quaternion(f[0], f[1], f[2], f[3]);
        }
        public static float[] ToFloatArray(this Vector3 v) {
            return new float[] { v.X, v.Y, v.Z };
        }
        public static float[] ToFloatArray(this Quaternion q) {
            return new float[] { q.X, q.Y, q.Z, q.W };
        }
    }
}
