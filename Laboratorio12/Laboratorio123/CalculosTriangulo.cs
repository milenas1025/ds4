using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio123
{
    internal class CalculosTriangulo
    {
        private double lado1;
        private double lado2;
        private double lado3;

        public void setLados(double l1, double l2, double l3)
        {
            lado1 = l1;
            lado2 = l2;
            lado3 = l3;
        }

        public double getSemiperimetro()
        {
            return (lado1 + lado2 + lado3) / 2;
        }

        public double getArea()
        {
            double s = getSemiperimetro();
            return Math.Sqrt(s * (s - lado1) * (s - lado2) * (s - lado3));
        }
    }
}
