using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    // 扩展方法的应用
    public static class ExtensionTest
    {
        public static int ToInt(this string str)
            => int.Parse(str);

        public static void SetVectorX(this VectorPos sv, int x)
        {
            sv.SetVector(x, sv.GetPosY(), sv.GetPosZ());
        }
    }

    public struct PointPosition
    {
        public int X;
        public int Y;
        public int Z;
    }

    public class VectorPos
    {
        private PointPosition _pointPos;
        
        public VectorPos()
        {
            _pointPos.X = 0;
            _pointPos.Y = 0;
            _pointPos.Z = 0;
        }

        public VectorPos(int x, int y, int z)
        {
            SetVector(x, y, z);
        }

        public string Position
        {
            get => $"{_pointPos.X}, {_pointPos.Y}, {_pointPos.Z}"; 
        }

        public int GetPosX()
        {
            return this._pointPos.X;
        }

        public int GetPosY()
        {
            return this._pointPos.Y;
        }

        public int GetPosZ()
        {
            return this._pointPos.Z;
        }

        public void SetVector(int x, int y, int z)
        {
            _pointPos.X = x;
            _pointPos.Y = y;
            _pointPos.Z = z;
        }

    }
    
}
