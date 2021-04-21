using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6Demo
{
    public class Complex
    {
        public Complex(float real, float imag)
        {
            this.Real = real;
            this.Imag = imag;
        }
        public float Real { get; set; }
        public float Imag { get; set; }

        public override string ToString()
        {
            return $"{Real}+{Imag}i";
        }

        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex(x.Real + y.Real, x.Imag + y.Imag);
        }


        //static public Complex operator +(Complex a, Complex b)
        //{
        //    return new Complex(a.Real + b.Real, a.Imag + b.Imag);
        //}
    }
}
