using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class Vector3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D Difference(Vector3D vector)
        {
            return new Vector3D(X - vector.X, Y - vector.Y, Z - vector.Z);
        }

        public bool IsParallel(Vector3D vector)
        {
            return vector.X == X && vector.Y == Y && vector.Z == Z;
        }
    }
}
