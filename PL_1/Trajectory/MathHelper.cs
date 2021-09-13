//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********************************************************************************************************
namespace StandartHelperLibrary.MathHelper
{
    /// <summary>
    /// 
    /// </summary>
    class MathHelper
    {
        //----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Решение алегбраических уравнений методом деления интервала пополам
        /// </summary>
        /// <param name="A">Левая граница</param>
        /// <param name="B">Правая граница</param>
        /// <param name="EPS">Какая-то точность</param>
        /// <param name="EPS1">Какая-то тоночть</param>
        /// <param name="F"></param>
        /// <returns>Решение алегбраических уравнений</returns>
        public static double SP7B1(double A, double B, double EPS, double EPS1, Func<double, double> F)
        {
            double X;
            X = A;
            double Y = new double();
            FF(ref Y);
            if (Math.Abs(Y) <= EPS)
                goto M2SP7;

            X = B;
            double Z = new double();
            FF(ref Z);
            if (Math.Abs(Z) <= EPS)
                goto M2SP7;

            if (Math.Sign(Y) == Math.Sign(Z))
            {
                Console.WriteLine($"Корней нет\n\n{A}");
                return (X);
            }
        M3SP7:
            X = A / 2f + B / 2f;
            FF(ref Y);
            if (Math.Abs(Y) <= EPS)
                goto M2SP7;
            if (Math.Sign(Y) == Math.Sign(Z))
                B = X;
            else
                A = X;
            if (Math.Abs(A - B) >= EPS1)
                goto M3SP7;

            void FF(ref double YORZ)
            {
                YORZ = F(X);
            }
        M2SP7:
            return (X);
        }
        //---------------------------------------------------------------------------------------------------------------------------
    }
}
