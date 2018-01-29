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
        double s = -1;
        double d = -1;
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
        double S
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


        double D
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cube y = null;
            Cube x = null;
            Cube h = null;
            Cube d = null;
            try
            {
                y = new Cube(1, 2);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                x = new Cube(-1, -1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                h = new Cube(-1, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                d = new Cube(1, -2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (y != null)
            {
                Console.WriteLine(y.ToString());
            }
            if (h != null)
            {
                Console.WriteLine(h.ToString());
            }
            if (d != null)
            {
                Console.WriteLine(d.ToString());
            }


        }
    }
}
