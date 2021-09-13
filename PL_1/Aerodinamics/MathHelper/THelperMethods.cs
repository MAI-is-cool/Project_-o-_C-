//Впомогательные методы для расчета коэффициента подъемной силы  и  аэродинамического сопротивления ЛА
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//**********************************************************
namespace StandartHelperLibrary.MathHelper
{
    class HelperMethods
    {
//-------------------------------------------------------------------
        /// <summary>
        /// Расчет стандартов атмосферы
        /// </summary>
        /// <param name="T">Температура</param>
        /// <param name="AA">Скорость звука</param>
        /// <param name="P">Давление</param>
        /// <param name="MM">Молярная масса</param>
        /// <param name="HH">Высота</param>
        /// <returns>Массив стандартов атмосферы</returns>
        public static double[] SP6B1(double T, double AA, double P, double MM, double HH)
        {
            double[] Atmosphere = new double[6];
            double I, L, S, R, G = new double();
            double[,] K = new double[16, 3];
            bool LS6B1 = new bool();
            R = 6371210f;
            G = 0.03416487f;
            MM = 28.966f;
            I = 1f;
            K[1, 1] = -2E+3;
            K[2, 1] = 0;
            K[3, 2] = 0;
            K[5, 2] = 0;
            K[7, 2] = 0;
            K[3, 1] = 11E+3;
            K[4, 1] = 25E+3;
            K[5, 1] = 46E+3;
            K[6, 1] = 54E+3;
            K[7, 1] = 8E+4;
            K[8, 1] = 95E+3;
            K[9, 1] = 11E+4;
            K[10, 1] = 12E+4;
            K[11, 1] = 15E+4;
            K[12, 1] = 16E+4;
            K[13, 1] = 2E+5;
            K[14, 1] = 31E+4;
            K[15, 1] = 31E+4;
            K[1, 2] = -0.00652;
            K[2, 2] = -0.00651;
            K[4, 2] = 0.00276098;
            K[6, 2] = -0.00349544;
            K[8, 2] = 0.005;
            K[9, 2] = 0.00801741;
            K[10, 2] = 0.02346357;
            K[11, 2] = 0.01987408;
            K[12, 2] = 0.003084;
            K[13, 2] = 0.00362;
            P = 1.26119;
            T = 301.19;
            if (HH <= -2E+3)
                goto M1SP6;

            if (HH > 3E+5f)
            {
                T = 1657;
                P = 1E-10;
                goto M1SP6;
            }
            LS6B1 = true;
        M2SP6:
            I = I + 1;
            if (HH >= K[(int)I, 1])
            {
                S = (R / (R + K[(int)I, 1])) * (R / (R + K[(int)I - 1, 1])) * (K[(int)I, 1] - K[(int)I - 1, 1]);
                L = T;
                T = T + K[(int)I - 1, 2] * S;
                if (Math.Abs(K[(int)I - 1, 2]) < 1E-5f)
                    P = P / Math.Exp(G * S / T);
                else
                    P = P / Math.Pow(T / L, G / K[(int)I - 1, 2]);
                if (((int)I < 16) && (LS6B1))
                    goto M2SP6;
            }
            if (LS6B1)
            {
                K[(int)I, 1] = HH;
                I = I - 1;
                LS6B1 = false;
                goto M2SP6;
            }
            if ((HH > 95E+3) && (HH <= 11E+4))
                MM = 23 + 5.966 * (float)Math.Sqrt(1 - ((HH - 95E+3) / 145E+3) * ((HH - 95E+3) / 145E+3));
            if (HH > 11E+4f)
                MM = 28.934 - 0.2066E-4 * (HH - 11E+4) - 0.3f * (float)Math.Pow((double)((HH - 137E+3) * 1E-5), 3d);
            M1SP6:
            AA = 20.0463 * (float)Math.Sqrt(T);
            Atmosphere[1] = T;
            Atmosphere[2] = AA;
            Atmosphere[3] = P;
            Atmosphere[4] = MM;
            Atmosphere[5] = HH;
            return Atmosphere;
        }
//-------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Расчет подъемной силы фюзеляжа 
        /// </summary>
        /// <param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="GEO">Геометрические характеристики ЛА</param>
        /// <returns>Подъемная сила фюзеляжа</returns>
        public static double VM1(double[] VN, double[] GEO)
        {
            double Y;
            if (GEO[79] == 0)
                Y = 0;
            else
                Y = (VN[16] + VN[19]) * Math.Sin(2 * VN[3]) / 2 * 57.3 + VN[20];
            return Y;
        }
//-------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Расчет индуктивного соправтивления ЛА при относительной ширине фюзеляжа = 0
        /// </summary>
        /// <param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="GEO">Геометрические характеристики ЛА</param>
        /// <param name="AER">Массив фэродинамических парматров</param>
        /// <returns>Индуктивного соправтивления ЛА при относительной ширине фюзеляжа = 0</returns>
        public static double VM2(double[] VN, double[] GEO, double[] AER)
        {
            double Y = 0;
            if (GEO[79] == 0)
            {
                AER[5] = 0;
                VN[51] = 0;
                Y = VM3(VN, GEO, AER);
            }
            return Y;
        }
//-------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Расчет индуктивного соправтивления ЛА
        /// </summary>
        /// <param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="GEO">Геометрические характеристики ЛА</param>
        /// <param name="AER">Массив фэродинамических парматров</param>
        /// <returns>Индуктивного соправтивления ЛА</returns>
        public static double VM3(double[] VN, double[] GEO, double[] AER)
        {
            double Y = 0;
            if (VN[2] <= 1 || VN[2] > 1 && VN[12] > 1)
                Y = AER[1] * VN[21] * VN[22] * Math.Tan(VN[3]) + VN[51] * GEO[81];
            return Y;
        }
//---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Определение коэфициента трения крыла
        /// </summary>
        /// <param name="X">Мах</param>
        /// <param name="Z">Параметр средней аэродинамической хорды</param>
        /// <param name="U">Средняя относительная толщина профиля крыла</param>
        /// <param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="GEO">Геометрические характеристики ЛА</param>
        /// <returns>Коэффициент трения крыла</returns>
        public static double CVM1(double X, double Z, double U, double[] VN, double[] GEO)
        {
            VN[33] = CVM3(X, Z, VN, GEO);
            double Y = 2 * 0.925 * VN[33] * (1 + 3 * U);
            return Y;
        }
//--------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Расчет коэффициента трения пластины 
        /// </summary>
        /// <param name="X">Мах</param>
        /// <param name="Z">Параметр средней аэродинамической хорды</param>
        /// <param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="GEO">Геометрические характеристики ЛА</param>
        /// <returns>Коэффициент трения пластины</returns>
        public static double CVM3(double X, double Y, double[] VN, double[] GEO)
        {
            VN[28] = X * VN[24] * Y / VN[27];
            if (VN[28] > 1E+7)
                VN[29] = 0;
            else
            {
                VN[30] = 5 + (1.3 + 0.6 * X * Math.Pow((1 - 0.25 * X), 2)) * Math.Sqrt(1 - Math.Pow(((Math.Log10(GEO[82] * VN[28]) - 1) / (2.2 + 0.08 * Math.Pow(X, 2) / (1 + 0.312 * Math.Pow(X, 2)))), 2));
                VN[29] = Math.Exp(VN[30] * Math.Log(10) - Math.Log(VN[28]));
            }
            if (VN[29] > 1)
                VN[29] = 1;
            VN[31] = 1.372 / (Math.Sqrt(VN[28]) * Math.Pow((1 + 0.1 * Math.Pow(X, 2)), 0.125));
            VN[32] = 0.455 / (Math.Pow((1 + 0.1 * Math.Pow(X, 2)), 0.667) * Math.Pow((Math.Log10(VN[28])), 2.58));
            double Z = VN[31] * VN[29] + VN[32] * (1 - VN[29]);
            return Z;
        }
//--------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Определение коэфициента трения фюзеляжа
        /// </summary>
        /// <param name="X">Мах</param>
        /// <param name="Z">Длина фюзеляжа</param>
        ///<param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="GEO">Геометрические характеристики ЛА</param>
        /// <returns>Коэффициент трения фюзеляжа</returns>
        public static double CVM4(double X, double Z, double[] VN, double[] GEO)
        {
            VN[33] = CVM3(X, Z, VN, GEO);
            if (X < 1)
                VN[41] = 1 + Math.Exp(-0.3 * GEO[76]);
            else
                VN[41] = 1 + 2 / GEO[76];
            double Y = VN[33] * VN[41] * GEO[85];
            return Y;

        }
//-----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Определение коэффициентов лобового сопративления консолей крыла и оперения
        /// </summary>
        /// <param name="S1">Геометрический параметр</param>
        /// <param name="S2">Геометрический параметр</param>
        /// <param name="S3">Геометрический параметр</param>
        /// <param name="S4">Геометрический параметр</param>
        /// <param name="S5">Геометрический параметр</param>
        /// <param name="S6">Геометрический параметр</param>
        /// <param name="S7">Геометрический параметр</param>
        ///<param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="GEO">Геометрические характеристики ЛА</param>
        /// <returns>Коэффициенты лобового сопративления консолей крыла и оперения</returns>
        public static double CVM5(double S1, double S2, double S3, double S4, double S5, double S6, double S7, double[] VN, double[] GEO)
        {
            VN[36] = 4 * (S3 - 1) / ((Math.Tan(S4 / 57.3) - Math.Tan(S5 / 57.3)) * (S3 + 1));
            VN[37] = 1;
            VN[38] = 6.283 * VN[36] * Math.Pow(S1, 2) * Math.Pow(Math.Cos(S2 / 57.3), 2) / (2 + VN[36] * Math.Pow(S1, 0.333) * Math.Pow(Math.Cos(S2 / 57.3), 1.667));
            if (VN[2] < VN[35])
                VN[39] = 0;
            if (VN[2] >= VN[35] && VN[2] < VN[37])
                VN[39] = VN[38] * Math.Pow(((VN[2] - VN[35]) / (VN[37] - VN[35])), 3) * (4 - 3 * (VN[2] - VN[35]) / (VN[37] - VN[35]));
            if (VN[2] >= VN[37] & VN[2] < 1.5)
            {
                VN[40] = 1.5;
                VN[41] = CVM2(VN, VN[40], S1, S2, S6);
                VN[39] = VN[38] - (VN[38] - VN[41]) * (VN[2] - VN[37]) / (1.5 - VN[37]);
            }
            if (VN[2] >= 1.5 & VN[2] < 5)
                VN[39] = CVM2(VN, VN[2], S1, S2, S6);
            if (VN[2] >= 5)
            {
                VN[40] = 5;
                VN[39] = CVM2(VN, VN[40], S1, S2, S6);
            }
            if (VN[2] < 5)
                VN[34] = CVM1(VN[2], S7, S1, VN, GEO);
            else
            {
                VN[40] = 5;
                VN[34] = CVM1(VN[40], S7, S1, VN, GEO);
            }
            double S8 = VN[34] + VN[39];

            return S8;
        }
//------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Определения коэффициента волнового сопративления крыла 
        /// </summary>
        ///<param name="VN">Массив аэродинамических характеристик ЛА</param>
        /// <param name="X">Мах</param>
        /// <param name="S1">Геометрический параметр</param>
        /// <param name="S2">Геометрический параметр</param>
        /// <param name="S6">Геометрический параметр</param>
        /// <returns>Коэффициент волнового сопративления крыла</returns>
        public static double CVM2(double[] VN, double X, double S1, double S2, double S6)
        {
            double[] BSP2 = new double[10];
            BSP2[1] = Math.Sqrt(Math.Pow(X, 2) - 1) / Math.Tan(S2 / 57.3);
            if (BSP2[1] > 1)
                BSP2[2] = 0.16 * Math.Pow(VN[36], 2) * Math.Pow((Math.Sqrt(Math.Pow(X, 2) - 1) - Math.Tan(S2 / 57.3)), 2) / (1 + 0.16 * Math.Pow(VN[36], 2) * Math.Pow((Math.Sqrt(Math.Pow(X, 2) - 1) - Math.Tan(S2 / 57.3)), 2));
            else BSP2[2] = 0;
            BSP2[3] = 4 * Math.Pow(S1, 2) * (1 + (S6 - 1) * BSP2[2]) / Math.Sqrt(Math.Pow(X, 2) - 1);
            double Y = BSP2[3];
            return Y;
        }
    }
}


