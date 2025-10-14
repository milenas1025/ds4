using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio122
{
    public class CalculoPromedio
    {
        private double nota1;
        private double nota2;
        private double nota3;

        public void setNotas(double n1, double n2, double n3)
        {
            nota1 = n1;
            nota2 = n2;
            nota3 = n3;
        }

        public double CalcularPromedio()
        {
            return (nota1 + nota2 + nota3) / 3;
        }
    }
}