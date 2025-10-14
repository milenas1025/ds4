using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio12
{
    public class CalculoDistancia
    {
        private double velocidad;
        private double tiempo;


        public void setVelocidad(double v)
        {
            velocidad = v;
        }

        public void setTiempo(double t)
        {
            tiempo = t;
        }

        public double getVelocidad()
        {
            return velocidad;
        }

        public double getTiempo()
        {
            return tiempo;
        }

        // Método para calcular la distancia
        public double CalcularDistancia()
        {
            return velocidad * tiempo;
        }
    }
}
