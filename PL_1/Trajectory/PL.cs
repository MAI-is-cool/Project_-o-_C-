// Опредление летно - технических характеристик
using System;
using System.Collections.Generic;
using System.Text;
//**********************************************************
namespace StandartHelperLibrary.MathHelper
{
    class HelperMethodsForTrajectory
    {
        //---------------------------------------------------------
        /// <summary>
        /// Исходные данные
        /// </summary>
        /// <returns></returns>
        public static double[] DATA()
        {
            // дополнение массива GEO из аэродинамики
            double[] Y = new double[19]; // тоже самое что и GEO
            Y[1] = 160;
            Y[2] = 0;
            Y[3] = 0;
            Y[4] = 0;
            Y[5] = 0;
            Y[6] = 0;
            Y[7] = 0;
            Y[8] = 0;
            Y[9] = 1500;
            //тяговооруженость
            Y[10] = 1.43;
            Y[23] = 1.43;
            //
            Y[11] = 5;
            //соответствующие точности приближения к конечным значениям
            Y[12] = 0.001;
            Y[13] = 1;
            //Соответствующая величина ограничения для условия дросселирования
            Y[14] = 3;
            //конечные значения величин
            Y[15] = 0.6;
            Y[16] = 3000;
            Y[22] = 340;//R удельная
            //GEO[17]  ?

            //геометрические характерсистики ЛА (GEO[])
            //Y[71] = -1.0000E+01;
            //Y[72] = 4.50000E+01;
            //Y[73] = 9.99999E-02;
            //Y[74] = 1.49999E-01;
            //Y[75] = 1.65999E+00;
            //Y[76] = 6.00000E+00;
            //Y[77] = 0.00000E+00;
            //Y[78] = 1.00000E+00;
            //Y[79] = 2.30999E-01;
            //Y[80] = 5.19999E+00;
            //Y[81] = 1.09999E-01;
            //Y[82] = 9.99999E-07;
            //Y[83] = 4.00000E+01;
            //Y[84] = 1.39999E+00;
            //Y[85] = 2.80000E+01;
            //Y[86] = 1.20000E+01;
            //Y[87] = 3.50000E+01;
            //Y[88] = 5.99999E-02;
            //Y[89] = 7.99999E-02;
            //Y[90] = 3.00000E+01;
            //Y[91] = 3.50000E+00;
            //Y[92] = 4.00000E+01;
            //Y[93] = 2.50000E+01;
            //Y[94] = 1.00000E+00;
            //Y[95] = 5.07999E+00;
            //Y[96] = 2.99999E-01;
            //Y[97] = 5.99999E-01;
            //Y[98] = 6.99999E-02;
            //Y[99] = 0.00000E+00;
            //Y[100] = 0.00000E+00;
            //??
            Y[180] = 0.8;
            return Y;
        }
        bool LSERG = true;
        int L1DATA = 20;
        //-----------------------------------------------------------------------
        /// <summary>
        /// Блок расчета летно-технических характеристик
        /// </summary>
        /// <param name="L1DATA">Логический оператор</param>
        public static void TR(int L1DATA)
        {
            double[] H = new double[4];
            double[] GEO = DATA();
            double[] T = new double[24];
            double[] VN = new double[40];
            bool LOG1P2 = true;
            VN[1] = 9.81;
            VN[3] = 63.7121E+5;
            VN[4] = 10332.3;
            double N = 8;
            double M = 2;
            double E = 1E-4;
            double E1 = 1E-1;
            double I = L1DATA;
            double D1 = 1.4;
            double D2 = 0;
            double D3 = 0.4;
            bool L1TR = false;
            for (int k = 1; k <= 8; k++)
            {
                T[k] = GEO[k];
            }
            H[1] = GEO[11];
            //соответствующие тоности приближения к конечным значениям
            H[2] = GEO[12];
            H[3] = GEO[13];
            bool L6TR = true;
        M1TR:
            //SP1B1(); надо вставить диффуры!!!!!!!!!!!!!!!!!!!!! + SP3B1 невязки
            //Блок TR объеденяет все описанные ниже методы, надо подумать ка кэто сделать  в Шарпе
            if (L6TR)
            {
                L6TR = false;
                goto M1TR;
            }
        }
        //-------------------------------------------------------------------------------------------

        public static void SP2B1()
        {

            bool L4TR = true;// Задала значения рандомно, пока непонятно откуда они  берутся
            bool L3TR = true;
            //if (LOG1P2 || L4TR)// не понятно пока откуда берутся эти логические операторы
            //{

            double HB = T[11];
            double MU = 0;


            double[] Atmosphere = TResultAtmospheric.GetAtmosphericCaracteristicFromHight(HB);
            VN[8] = VN[4] * Atmosphere[3];
            VN[9] = 0.12492 * VN[7] * 288.15 / Atmosphere[1];
            VN[10] = T[9] / Atmosphere[2];
            VN[11] = VN[9] * T[9] * T[9] / 2;
            bool LOG1P2 = false;
            //}
            //Call P10; // еще не написана
            HB = T[11];
            Atmosphere = TResultAtmospheric.GetAtmosphericCaracteristicFromHight(HB);
            VN[8] = VN[4] * Atmosphere[3];
            VN[9] = 0.12492 * Atmosphere[3] * 288.15 / Atmosphere[1];
            VN[10] = T[9] / Atmosphere[2];
            VN[11] = VN[9] * T[9] * T[9] / 2;
            //if (L2TR)не понятно пока откуда берутся эти логические операторы
            //{
            T[3] = T[11];
        //call SP8B1 (M1P2, M3P2, M5P2);еще не написана
        M3P2:
            VN[29] = VN[1] * ((VN[18] * Math.Cos(VN[17]) - VN[22] * VN[11] / GEO[9]) / (1 - T[16]) - Math.Sin(T[10]));
            C[1] = 1;
            //ОДНА ФОРМУЛА РАСПЕЧАТАНА ПЛОХО НАДО ПОСМТРЕТЬ ЕЕ  У ДЕДА, Я ЕЕ ПРОПУСКАЮ СЕЙЧАС C[2] = .....
            C[4] = (T[9] * Math.Cos(T[10]) * Math.Cos(T[13]) * VN[3] / (VN[3] + T[11])) / VN[29];
            C[5] = VN[21] * VN[11] * VN[1] / GEO[9] / (1 - T[16]) * Math.Sin(VN[2]) / T[9] / Math.Cos(T[10]) / VN[29];
            C[6] = 1 / VN[29];
            C[7] = C[7] * VN[3] / (VN[3] + T[11]);
            C[8] = C[6] * VN[18] / VN[32];
            //}
            if (L3TR || L4TR) //не понятно пока откуда берутся эти логические операторы
            {
                if (L3TR)
                {
                    VN[16] = 1;
                //Call P8(M1P2, M3P2, M5P2);еще не написана
                M5P2:
                    C[1] = 0;
                    C[2] = 0;
                }
                if (L4TR)
                {
                    //call P9(VN[17]);
                    C[1] = VN[1] * ((VN[18] * Math.Cos(VN[17]) - VN[22] * VN[11] / GEO[9]) / (1 - T[16]) - Math.Sin(T[10]));
                    C[2] = VN[1] * ((VN[18] * Math.Sin(VN[17]) + VN[21] * VN[11] * Math.Cos(VN[2]) / GEO[9]) / (1 - T[16]) - Math.Cos(T[10]) * VN[3] * VN[3] / Math.Pow((VN[3] + T[11]), 2)) / T[9] + T[9] * Math.Cos(T[10]) / (VN[3] + T[11]);
                }
                C[3] = T[9] * Math.Sin(T[10]);
                C[4] = T[9] * Math.Cos(T[10]) * Math.Cos(T[13]) * VN[3] / (VN[3] + T[11]);
                C[5] = VN[21] * VN[11] * VN[1] / GEO[9] / (1 - T[16]) * Math.Sin(VN[2]) / T[9] / Math.Cos(T[10]);
                C[6] = 1;
                C[7] = C[7] * VN[3] / (VN[3] + T[11]);
                C[8] = VN[18] / VN[32];
            }
            for (int z = 1; z <= 8; z++)
            {
                T[z + 8] = C[z];
            }
            //goto M4P2;
            //M1P2:PUT SKIP (2) DATA (VN);    //Пока хз как это и что это
            //goto M2TR;
            //M4P2:END  SP2B1;
        }
        //-----------------------------------------------------------------------------------
        ////-------------------------------------------------------------------------------------------
        //public static double[] SP6B1(double T, double AA, double P, double MM, double HH)
        //{
        //    double[] Atmosphere = new double[6];
        //    double I, L, S, R, G = new double();
        //    double[,] K = new double[16, 3];
        //    bool LS6B1 = new bool();
        //    R = 6371210f;
        //    G = 0.03416487f;
        //    MM = 28.966f;
        //    I = 1f;
        //    K[1, 1] = -2E+3;
        //    K[2, 1] = 0;
        //    K[3, 2] = 0;
        //    K[5, 2] = 0;
        //    K[7, 2] = 0;
        //    K[3, 1] = 11E+3;
        //    K[4, 1] = 25E+3;
        //    K[5, 1] = 46E+3;
        //    K[6, 1] = 54E+3;
        //    K[7, 1] = 8E+4;
        //    K[8, 1] = 95E+3;
        //    K[9, 1] = 11E+4;
        //    K[10, 1] = 12E+4;
        //    K[11, 1] = 15E+4;
        //    K[12, 1] = 16E+4;
        //    K[13, 1] = 2E+5;
        //    K[14, 1] = 31E+4;
        //    K[15, 1] = 31E+4;
        //    K[1, 2] = -0.00652;
        //    K[2, 2] = -0.00651;
        //    K[4, 2] = 0.00276098;
        //    K[6, 2] = -0.00349544;
        //    K[8, 2] = 0.005;
        //    K[9, 2] = 0.00801741;
        //    K[10, 2] = 0.02346357;
        //    K[11, 2] = 0.01987408;
        //    K[12, 2] = 0.003084;
        //    K[13, 2] = 0.00362;
        //    P = 1.26119;
        //    T = 301.19;
        //    if (HH <= -2E+3)
        //        goto M1SP6;

        //    if (HH > 3E+5f)
        //    {
        //        T = 1657;
        //        P = 1E-10;
        //        goto M1SP6;
        //    }
        //    LS6B1 = true;
        //M2SP6:
        //    I = I + 1;
        //    if (HH >= K[(int)I, 1])
        //    {
        //        S = (R / (R + K[(int)I, 1])) * (R / (R + K[(int)I - 1, 1])) * (K[(int)I, 1] - K[(int)I - 1, 1]);
        //        L = T;
        //        T = T + K[(int)I - 1, 2] * S;
        //        if (Math.Abs(K[(int)I - 1, 2]) < 1E-5f)
        //            P = P / Math.Exp(G * S / T);
        //        else
        //            P = P / Math.Pow(T / L, G / K[(int)I - 1, 2]);
        //        if (((int)I < 16) && (LS6B1))
        //            goto M2SP6;
        //    }
        //    if (LS6B1)
        //    {
        //        K[(int)I, 1] = HH;
        //        I = I - 1;
        //        LS6B1 = false;
        //        goto M2SP6;
        //    }
        //    if ((HH > 95E+3) && (HH <= 11E+4))
        //        MM = 23 + 5.966 * (float)Math.Sqrt(1 - ((HH - 95E+3) / 145E+3) * ((HH - 95E+3) / 145E+3));
        //    if (HH > 11E+4f)
        //        MM = 28.934 - 0.2066E-4 * (HH - 11E+4) - 0.3f * (float)Math.Pow((double)((HH - 137E+3) * 1E-5), 3d);
        //    M1SP6:
        //    AA = 20.0463 * (float)Math.Sqrt(T);
        //    Atmosphere[1] = T;
        //    Atmosphere[2] = AA;
        //    Atmosphere[3] = P;
        //    Atmosphere[4] = MM;
        //    Atmosphere[5] = HH;
        //    return Atmosphere;
        //}

        /// <summary>
        ///  Определение управления траекторией
        /// </summary>
        /// <param name="VN"></param>
        /// <param name="T"></param>
        /// <param name="D1"></param>
        /// <param name="D2"></param>
        /// <param name="D3"></param>
        /// <param name="E1"></param>
        /// <param name="E"></param>
        /// <param name="F"></param>
        /// <param name="F1"></param>
        /// <param name="F2"></param>
        public static void SP8B1(double[] VN, double[] T, int D1, int D2, int D3, double E1, double E)
        {
            Func<double, double> FVN1 = FVN1(E1);
            bool L3TR = true;
            bool L2TR = true;
            bool L5TR = true;
            int X2;
            int X3;
            VN[12] = VN[1] * VN[13] / T[9];
            VN[14] = VN[1] * (VN[15] - VN[13] / T[9]) / T[9];
            if (VN[12] == 0)
                VN[16] = 1 + 1 / VN[12];
            if (L5TR)
            {
                if (F1[D2] < 0)
                {
                    VN[27] = D2;
                    goto M1SP8;
                }
                X2 = D2;
                X3 = D3;
                VN[27] = MathHelper.SP7B1(X2, X3, E, E1, FVN1/*, M1P2*/);
            M1SP8:
                if (MathHelper.FVN2[D3] > 0)
                {
                    VN[28] = D3;
                    goto M2SP8;
                }
                X2 = D2;
                X3 = D3;
                VN[28] = MathHelper.SP7B1(X2, X3, E, E1, FVN2/*, M1P2*/);
            M2SP8:
                VN[27] = VN[27] + E1;
                VN[28] = VN[28] - E1;
            }
            else
            {
                VN[27] = D2;
                VN[28] = D1;
            }
            if (L5TR)
                VN[17] = MathHelper.SP7B1(VN[27], VN[28], E, E1, FVN, M2P2);
            else
                VN[2] = MathHelper.SP7B1(VN[27], VN[28], E, E1, FVN());
            if (L2TR)
                goto M3P2;
            if (L3TR)
                goto M5P2;
            M2P2:
            if (L5TR)
                VN[17] = MathHelper.SP7B1(-VN[28], -VN[27], E, E1, FVN, M1P2);
            if (L2TR)
                goto M3P2;
            if (L3TR)
                goto M5P2;
        }
        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// "Подготовительная" процедура к решению уравнений в случае v= const и полете по программе "H-V"
        /// </summary>
        /// <param name="AL0"></param>
        /// <param name="VN"></param>
        /// <param name="GEO"></param>
        /// <param name="T"></param>
        /// <returns>Решение уравнений в случае v= const и полете по программе "H-V"</returns>
        public static double FVN(/*double AL0, double[] VN, double[] GEO, double[] T*/)
        {
            double Equation = 0;
            bool L2TR = true;
            bool L3TR = true;
            bool L5TR = true;
            if (L5TR)
                VN[17] = AL0;
            else
                VN[2] = AL0;
            if (L2TR)
            {
                T[9] = T[9] + 1;
                SP9B1(VN[17], VN, T, GEO);
                VN[23] = VN[19];
                T[9] = T[9] - 1;
                SP9B1(VN[17], VN, T, GEO);
                VN[24] = VN[23] - VN[19];
                VN[25] = VN[12] * VN[19] / (1 + VN[12]);
                if (Math.Abs(VN[25]) >= 1)
                    T[2] = 1.57;
                else
                    T[2] = Math.Atan(VN[25] / Math.Sqrt(1 - Math.Pow(VN[25], 2)));
                T[10] = T[2];
                if (L3TR)
                {
                    SP9B1(VN[17], VN, T, GEO);
                    T[1] = T[9];
                    T[2] = Math.Atan(VN[19] / Math.Sqrt(1 - Math.Pow(VN[19], 2)));
                    VN[24] = VN[19] / (1 - T[16]) * VN[18] / VN[32];
                    T[10] = T[2];
                }
                if (L2TR)
                    Equation = (((1 + VN[12]) * VN[12] * VN[24] + VN[14] * VN[19]) / (Math.Pow((1 + VN[12]), 2) * Math.Cos(T[10])) - (1 + VN[12]) * (VN[20] + Math.Cos(T[10]) * (Math.Pow(T[9], 2) / (VN[1] * (VN[3] + T[11])) - 1)) / (T[9] * VN[19]));
                if (L3TR)
                    Equation = (VN[24] / Math.Cos(T[10]) - VN[1] / T[9] * (VN[26] * Math.Cos(T[10]) * (Math.Pow(T[9], 2) / (VN[1] * (VN[3] + T[11])) - 1)));
            }
            return Equation;
        }
        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Определение границ области существования управления
        /// </summary>
        /// <param name="AL1"></param>
        /// <param name="VN"></param>
        /// <param name="T"></param>
        /// <param name="GEO"></param>
        /// <param name="H"></param>
        /// <returns>Границы области существования управления</returns>
        public static double FVN1(double AL1/*, double[] VN, double[] T, double[] GEO, double[] H*/)
        {
            double Equation = 0;
            VN[27] = AL1;
            SP9B1(VN[27], VN, T, GEO);
            if (VN[12] == 0)
            {
                if (H[1] > 0)
                    Equation = -VN[19];
                else
                    Equation = VN[19];
            }
            else
            {
                if (VN[12] > 0)
                {
                    if (H[1] > 0)
                        Equation = VN[19] - VN[16];
                    else
                        Equation = VN[19];
                }
                else
                {
                    if (H[1] > 0)
                        Equation = VN[19];
                    else
                        Equation = VN[19] - VN[16];
                }
            }
            return Equation;
        }
        //---------------------------------------------------------------------------------------------
        /// <summary>
        /// Определение границ области существования управления
        /// </summary>
        /// <param name="AL2"></param>
        /// <param name="VN"></param>
        /// <param name="T"></param>
        /// <param name="GEO"></param>
        /// <param name="H"></param>
        /// <returns>Границы области существования управления</returns>
        public static double FVN2(double AL2, double[] VN, double[] T, double[] GEO, double[] H)
        {
            double Equation = 0;
            VN[28] = AL2;
            SP9B1(VN[28], VN, T, GEO);
            if (VN[12] == 0)
            {
                if (H[1] > 0)
                    Equation = VN[19];
                else
                    Equation = -VN[19];
            }
            else
            {
                if (VN[12] > 0)
                {
                    if (H[1] > 0)
                        Equation = VN[19];
                    else
                        Equation = VN[19] + VN[16];
                }
                else
                {
                    if (H[1] > 0)
                        Equation = VN[19] + VN[16];
                    else
                        Equation = VN[19];
                }
            }
            return Equation;
        }
        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Расчет необходимой степени дросселирования
        /// </summary>
        /// <param name="AL"></param>
        /// <param name="VN"></param>
        /// <param name="T"></param>
        /// <param name="GEO"></param>
        /// <returns>Необходимая степень дросселирования</returns>
        public static double SP9B1(double AL, double[] VN, double[] T, double[] GEO)
        {
            bool L1PR = false;
            bool LDATA = true;//надо проверить какая будет эта переменная
            VN[30] = AL;
            VN[10] = T[9] / VN[6];
            //вызов программы расчета аэродинамических характеристик
            double[] AER = TDeterminationLiftingCoefficient.СalculationLiftingForceCoefficient(GEO, T[11], VN[10], VN[30], L1PR);
            VN[21] = AER[3];
            VN[22] = AER[8];
            //вызов программы расчета характеристик силовой установки
            double[] AB4 = DU(GEO, T[11], VN[10], VN[30]);
            VN[31] = AB4[4];
            VN[32] = AB4[5];

            if (LDATA)
                VN[28] = GEO[10] * VN[31];
            else
                VN[18] = GEO[23] * VN[31];
            VN[19] = (VN[18] * Math.Cos(VN[30]) - VN[22] * VN[9] * Math.Pow(T[9], 2) / 2 / GEO[9]) / (1 - T[16]);
            VN[26] = (VN[18] * Math.Sin(VN[30]) + VN[21] * VN[11] * Math.Cos(VN[2]) / GEO[9]) / (1 - T[16]);
            if (VN[19] > GEO[14])
                VN[18] = (GEO[14] * (1 - T[16]) + VN[22] * VN[9] * Math.Pow(T[9], 2) / 2 / GEO[9]) / Math.Cos(VN[30]);
            if (GEO[10] == 0 || GEO[23] == 0)
                VN[33] = 0;
            else
            {
                if (LDATA)
                    VN[33] = VN[18] / (GEO[10] * VN[31]);
                else VN[33] = VN[18] / (GEO[23] * VN[31]);
            }
            return VN[33];
        }
        //---------------------------------------------------------------------------
        /// <summary>
        /// Процедура задания программы движения 
        /// </summary>
        /// <param name="VN"></param>
        /// <param name="T"></param>
        public static void SP10B1(double[] VN, double[] T)
        {
            bool L1PR = false;
            bool L5TR = true;
            bool LDATA = true;
            bool L2DATA = false;
            VN[2] = 0;
            bool L2TR = true;
            bool L3TR = false;
            bool L4TR = false;
            T[3] = -4E-3 * Math.Pow((T[1] - 160), 2) + 38 * (T[1] - 160);
            T[11] = T[3];
            VN[13] = -8E-3 * (T[1] - 160) + 38;
            VN[15] = -8E-3;
        }
//--------------------------------------------------------------------------------------------------
        /// <summary>
        /// Расчет характеристик силовой установки
        /// </summary>
        /// <param name="GEO"></param>
        /// <param name="A4">T[11] - высота в текущий момент</param>
        /// <param name="B4">VN[10]</param>
        /// <param name="C4">VN[30]</param>
        /// <returns>массив характеристик силовой установки</returns>
        public static double[] DU(double[] GEO, double A4, double B4, double C4)
        {
            double[] AB4 = new double[6];
            AB4[1] = A4;
            AB4[2] = B4;
            AB4[3] = C4;
            double Pressure = TResultAtmospheric.GetPressureFromHeight(A4);
            AB4[4] = (1 - (1 - 1 / GEO[23]) * Pressure) * GEO[23];
            AB4[5] = AB4[4] * GEO[22] / GEO[23];
            return AB4;
        }
    }
}
