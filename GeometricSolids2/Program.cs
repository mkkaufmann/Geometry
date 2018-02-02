using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Michael Kaufmann
 * 1/24/18
 * practices interfaces and constructor handling
 */

namespace GeometricSolids2
{
    interface IGeometricSolid
    {
        double getVolume();
        double getMass();
        double getSA();
    }
    class Cube : IGeometricSolid
    {
        private double s = -1;
        private double d = -1;
        public Cube(double _s, double _d)
        {
            S = _s;
            D = _d;
            string errorMessage = "";
            if(d == -1)
            {
                errorMessage += " could not set d";
            }
            if (s == -1)
            {
                errorMessage += " could not set s";
            }
            if (errorMessage != "")
            {
                throw new Exception("incorrect input" + errorMessage);
            }
        }
        public double S
        {
            get { return s; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("cannot have negative side length");
                }
                else
                {
                    s = value;
                }
            }
        }


        public double D
        {
            get { return d; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("cannot have negative density");
                }
                else
                {
                    d = value;
                }
            }
        }
        public double getVolume()
        {
            return Math.Pow(s,3);
        }
        public double getMass()
        {
            return d*this.getVolume();
        }
        public double getSA()
        {
            return Math.Pow(s,2)*6;
        }
        public override string ToString()
        {
            return ("Side length: "+S+",Density: "+D+", Mass: "+getMass()+", Surface Area: "+getSA()+", Volume: "+getVolume());
        }

        public static bool operator ==(Cube c1,Cube c2)
        {
            if (c1.S == c2.S && c1.D == c2.D)
                return true;
            return false;
        }
        public static bool operator !=(Cube c1, Cube c2)
        {
            if (!(c1.S == c2.S && c1.D == c2.D))
                return true;
            return false;
        }
    }
    class ColorCube : Cube
    {
        private string color = "";
        public ColorCube(double _s, double _d, string _color):base(_s, _d)
        {
            color = _color;
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
            }
        }
        
        public override string ToString()
        {
            return ("Side length: " + S + ",Density: " + D + ", Mass: " + getMass() + ", Surface Area: " + getSA() + ", Volume: " + getVolume()+", Color: "+Color);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cube c1 = null;
            Cube c2 = null;
            try
            {
                c1 = new Cube(1, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                c2 = new Cube(1, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (c1 == c2)
            {
                StringBuilder sb = new StringBuilder("c1");
                sb.Append(" & c2 are =");
                Console.WriteLine(sb);
            }

        }
    }
}
