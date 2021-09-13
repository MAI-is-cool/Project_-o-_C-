//Геометрические и аэродинамические характеристики ЛА
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********************************************************
namespace StandartHelperLibrary.MathHelper
{
    /// <summary>
    /// Геометрические и аэродинамические характеристики ЛА
    /// </summary>
    class TGeometricAerodynamicCharacteristics
    {
//--------------------------------------------------------------------
        /// <summary>
        /// Геометрические характеристики ЛА
        /// </summary>
        /// <returns>Геометрические характеристики ЛА</returns>
        public static double[] GeomertyCharacteristics()
        {
            double[] GEO = new double[200];
            GEO[71] = -1.0000E+01;
            GEO[72] = 4.50000E+01;
            GEO[73] = 9.99999E-02;
            GEO[74] = 1.49999E-01;
            GEO[75] = 1.65999E+00;
            GEO[76] = 6.00000E+00;
            GEO[77] = 0.00000E+00;
            GEO[78] = 1.00000E+00;
            GEO[79] = 2.30999E-01;
            GEO[80] = 5.19999E+00;
            GEO[81] = 1.09999E-01;
            GEO[82] = 9.99999E-07;
            GEO[83] = 4.00000E+01;
            GEO[84] = 1.39999E+00;
            GEO[85] = 2.80000E+01;
            GEO[86] = 1.20000E+01;
            GEO[87] = 3.50000E+01;
            GEO[88] = 5.99999E-02;
            GEO[89] = 7.99999E-02;
            GEO[90] = 3.00000E+01;
            GEO[91] = 3.50000E+00;
            GEO[92] = 4.00000E+01;
            GEO[93] = 2.50000E+01;
            GEO[94] = 1.00000E+00;
            GEO[95] = 5.07999E+00;
            GEO[96] = 2.99999E-01;
            GEO[97] = 5.99999E-01;
            GEO[98] = 6.99999E-02;
            GEO[99] = -5.00000E+00;
            GEO[100] = 0.00000E+00;
            GEO[180] = 0.8;
            return GEO;
        }
//---------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Углы атаки ЛА
        /// </summary>
        /// <returns>Углы атаки ЛА</returns>
        public static double[] AttackAngle()
        {
            double[] Alfa = new double[6];
            Alfa[1] = 0;
            Alfa[2] = 5;
            Alfa[3] = 10;
            Alfa[4] = 15;
            Alfa[5] = 20;
            for (int i = 1; i < Alfa.Length; i++)
                Alfa[i] = Alfa[i] / 57.3;
            return Alfa;
        }
//--------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Числа махов ЛА
        /// </summary>
        /// <returns>Числа махов ЛА</returns>
        public static double[] Mach()
        {
            double[] M = new double[13];
            M[1] = 0.5;
            M[2] = 0.75;
            M[3] = 1;
            M[4] = 1.25;
            M[5] = 1.5;
            M[6] = 2;
            M[7] = 2.5;
            M[8] = 3;
            M[9] = 3;
            M[10] = 4;
            M[11] = 5;
            M[12] = 6;
            return M;
        }
    }
}
