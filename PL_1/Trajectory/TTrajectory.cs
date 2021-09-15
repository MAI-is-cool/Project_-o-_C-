using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartHelperLibrary.MathHelper
{
    class TTrajectory
    {
        public void SERG()//SERG УСЛОВНО = MAIN
        {
            bool LSERG = true;
            int L1DATA = new int();
            double[] GEO = new double[201];//увелчено на 1 для совместимости
            double[] T = new double[25];//увелчено на 1 для совместимости

            //возможность вызова  PR, DU, SP1B1

            double[] Y = new double[31]//увелчено на 1 для совместимости
            {
                0d,          //проставка для работы с увеличенным размером массива(проставка для работы другой проставки)
                -1.0000E+01,
                4.50000E+01,
                9.99999E-02,
                1.49999E-01,
                1.65999E+00,
                6.00000E+00,
                0.00000E+00,
                1.00000E+00,
                2.30999E-01,
                5.19999E+00,
                1.09999E-01,
                9.99999E-07,
                4.00000E+01,
                1.39999E+00,
                2.80000E+01,
                1.20000E+01,
                3.50000E+01,
                5.99999E-02,
                7.99999E-02,
                3.00000E+01,
                3.50000E+00,
                4.00000E+01,
                2.50000E+01,
                1.00000E+00,
                5.07999E+00,
                2.99999E-01,
                5.99999E-01,
                6.99999E-02,
                -5.00000E+00,
                0.00000E+00
            };

            GEO[180] = 0.8d;

            DATA(ref Y, ref GEO, ref LSERG, ref L1DATA);

            TR(GEO, T, PR, DU, P1, LSERG, M3TR, L1DATA);

            //конец SERG
            //реализовать альтернативу работы метки M3TR и M2TR, которые переводят в конец метода SERG
        }
        

        private void DATA(ref double[] Y, ref double[] GEO, ref bool LSERG, ref int L1DATA)
        {
            for (int z = 1; z < 31; z++)//смещенный массив для совместимости
                GEO[70 + z] = Y[z];
            GEO[1] = 160d;
            GEO[2] = 0d;
            GEO[3] = 0d;
            GEO[4] = 0d;
            GEO[5] = 0d;
            GEO[6] = 0d;
            GEO[7] = 0d;
            GEO[8] = 0d;
            GEO[9] = 1500d;
            GEO[10] = 1.43d;
            GEO[11] = 5d;
            GEO[12] = 0.001d;
            GEO[13] = 1d;
            GEO[14] = 3d;
            GEO[15] = 0.6d;
            GEO[16] = 3000d;
            GEO[23] = 1.43d;
            LSERG = true;
            L1DATA = 20;
        }


        private void TR(double[] GEO, double[] T, bool LTR, int L1DATA/*, M2TR = M3TR - метка завершения всего серга*/)
        {
            bool LDATA = new bool();
            bool L2DATA = new bool();
            bool L1PR = new bool();
            bool LOG1P2 = new bool();
            LOG1P2 = true;
            double[] VN = new double[41];//увелчено на 1 для совместимости
            double[] C = new double[10];//увелчено на 1 для совместимости
            double[] H = new double[4];//увелчено на 1 для совместимости
            double[] FI = new double[5];//увелчено на 1 для совместимости
            bool L1TR = new bool();
            bool L2TR = new bool();
            bool L5TR = new bool();
            bool L2PR = new bool();
            bool L3TR = new bool();
            bool L4TR = new bool();
            bool L6TR = new bool();

            //=========возможно инты
            int I = new int();
            int K = new int();
            int M = new int();
            int N = new int();
            //==========

            double D1 = new double();
            double D2 = new double();
            double D3 = new double();
            double X1 = new double();
            double X2 = new double();
            double X3 = new double();
            double E = new double();
            double E1 = new double();

            VN[1] = 9.81d;
            VN[3] = 63.7121E+5d;
            VN[4] = 10332.3d;

            N = 8;
            M = 2;
            E = 1E-4;
            E1 = 1E-3;

            for(K = 1; K < 9; K++)
            {
                T[K] = GEO[K];
            }

            H[1] = GEO[11];
            H[2] = GEO[12];
            H[3] = GEO[13];

            L6TR = true;

            M1TR:
            P1(N, M, H, FI, T, P2, P3, L1TR);

            if(L6TR)
            {
                L6TR = false;
                goto M1TR;
            }

            void P2()
            {
              
            }

            void P3()
            {
                double NX = new double();
                FI[1] = GEO[15] - T[8];
                FI[2] = GEO[16] - T[1];
                NX = (VN[18] * Math.Cos(VN[17]) - VN[22] * VN[11] / GEO[9]) / (1 - T[8]);
                if( LTR && I == L1DATA || LTR && L1TR)
                {
                    Console.WriteLine("T[6]=" + T[6] + "T[3]=" + T[3] / 1000d + "T[1]=" + T[1] + "T(4)=" + T[4] / 1000d + "T[7]=" + T[7] / 1000d + "T[2]=" + T[2] * 57.3d + "T[8]=" + T[8]);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine( A+ F[6, 1]+ X[3]+ A+ F[6, 2]+ X[3]+ A+ F[6, 1]+ X[3]+ A+ F[7, 1]+ X[3]+ A+ F[6, 1]+ X[3]+ A+ F[5, 2]+ X[3]+ A+ F[5, 3]);
                    Console.WriteLine("VN[17]=" + VN[17] * 75.3d + "VN[2]=" + VN[2] * 57.3d + "VN[10]=" + VN[10] + "K=" + VN[21] / VN[22] + "NX=" + NX + "VN[11]=" + VN[11] / 1000d + "VN[33]=" + VN[33]);
                    Console.WriteLine(A + F[5, 1] + X[2] + A + F[6, 3] + X[2] + A + F[5, 2] + X[2] + A + F[6, 2] + X[7] + A + F[6, 2] + X[5] + A + F[5, 2] + X[1] + A + F[4, 2]);
                    I = 0;
                }
                I = I + 1;
            }

            void P8()
            {
               
            }

            double F(double AL0)
            {
                if (L5TR)
                    VN[17] = AL0;
                else
                    VN[2] = AL0;
                if (L2TR)
                {
                    T[9] = T[9] + 1;
                    P9(VN[17]);
                    VN[23] = VN[19];
                    T[9] = T[9] - 1;
                    P9(VN[17]);
                    VN[24] = VN[23] - VN[19];
                    VN[25] = VN[12] * VN[19] / (1 + VN[12]);
                    if (Math.Abs(VN[25]) >= 1)
                        T[2] = 1.57;
                    else
                        T[2] = Math.Atan(VN[25] / Math.Sqrt(1 - Math.Pow(VN[25], 2)));
                    T[10] = T[2];
                }
                else if (L3TR)
                {
                    P9(VN[17]);
                    T[1] = T[9];
                    T[2] = Math.Atan(VN[19] / Math.Sqrt(1 - Math.Pow(VN[19], 2)));
                    VN[24] = VN[19] / (1 - T[16]) * VN[18] / VN[32];
                    T[10] = T[2];
                }
                if (L2TR)
                    return (((1 + VN[12]) * VN[12] * VN[24] + VN[14] * VN[19]) / (Math.Pow((1 + VN[12]), 2) * Math.Cos(T[10])) - (1 + VN[12]) * (VN[20] + Math.Cos(T[10]) * (Math.Pow(T[9], 2) / (VN[1] * (VN[3] + T[11])) - 1)) / (T[9] * VN[19]));
                else if (L3TR)
                    return (VN[24] / Math.Cos(T[10]) - VN[1] / T[9] * (VN[26] * Math.Cos(T[10]) * (Math.Pow(T[9], 2) / (VN[1] * (VN[3] + T[11])) - 1)));
                else
                {
                    Console.WriteLine("В функции FVN: L2TR и L3TR оба false, а значит выводится ноль");
                    Console.ReadKey();
                    return 0;
                }
            }

            double F1(double AL1)
            {
                VN[27] = AL1;
                P9(VN[27]);
                if (VN[12] == 0)
                {
                    if (H[1] > 0)
                        return -VN[19];
                    else
                        return VN[19];
                }
                else
                {
                    if (VN[12] > 0)
                    {
                        if (H[1] > 0)
                            return VN[19] - VN[16];
                        else
                            return VN[19];
                    }
                    else
                    {
                        if (H[1] > 0)
                            return VN[19];
                        else
                            return VN[19] - VN[16];
                    }
                }
            }

            double F2(double AL2)
            {
                VN[28] = AL2;
                P9(VN[28]);
                if (VN[12] == 0)
                {
                    if (H[1] > 0)
                        return VN[19];
                    else
                        return -VN[19];
                }
                else
                {
                    if (VN[12] > 0)
                    {
                        if (H[1] > 0)
                            return VN[19];
                        else
                            return VN[19] + VN[16];
                    }
                    else
                    {
                        if (H[1] > 0)
                            return VN[19] + VN[16];
                        else
                            return VN[19];
                    }
                }
            }

            void P9(double AL)
            {
                VN[30] = AL;
                VN[10] = T[9] / VN[6];
                double[] AER = TDeterminationLiftingCoefficient.СalculationLiftingForceCoefficient(GEO, T[11], VN[10], VN[30], L1PR);//вызов программы расчета аэродинамических характеристик
                VN[21] = AER[3];
                VN[22] = AER[8];
                double[] AB4 = DU(GEO, T[11], VN[10], VN[30]);//вызов программы расчета характеристик силовой установки
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
            }
            
            void P10()
            {
                L1PR = false;
                L2PR = true;
                L5TR = true;
                LDATA = true;
                L2DATA = false;
                VN[2] = 0d;
                L2TR = true;
                L3TR = false;
                L4TR = false;
                T[3] = -4E-3 * Math.Pow((T[1] - 160), 2) + 38 * (T[1] - 160);
                T[11] = T[3];
                VN[13] = -8E-3 * (T[1] - 160) + 38;
                VN[15] = -8E-3;
            }
        }

        private void P1(int N, int M, double[] H, double[] FI, double[] Y, P2, P3, bool LS1B1)
        {
            //double[] FI = new double[21];//увелчено на 1 для совместимости
            double KMIN = new double();

            //---------internal---------
            int I = new int();
            int J = new int();
            double R = new double();
            double ST = new double();
            double HPR = new double();
            double CINT = new double();
            double CST = new double();
            bool LS2B1 = new bool();
            bool LS3B1 = new bool();
            //---------internal-END-----

            LS2B1 = false;
            LS3B1 = false;
            ST = H[1];

        M1SP1:
            J = 1;
            for (I = 1; I < N + 1; I++)
            {
                Y[N + I] = Y[I];
            }

        M2SP1:
            P2();

            if (J == 1)
            {
                P3();
                if (LS3B1)
                    ST = H[1];
                LS3B1 = true;
                if (LS1B1)
                    goto M3SP1;
                if (LS2B1)
                {
                    KMIN = 1;
                    LS1B1 = false;
                    for (I = 1; I < M + 1; I++)
                    {
                        if (Math.Abs(FI[I]) < Math.Abs(H[I + 1]))
                            goto M3SP1;
                        R = FI[M + I] - FI[I];
                        if (Math.Abs(FI[I]) < Math.Abs(R))
                        {
                            for (I = 1; I < N + 1; I++)
                                Y[I] = Y[2 * N + I];
                            ST = HPR * (1 + KMIN);
                            goto M1SP1;
                        }
                        else
                            R = FI[I] / R;
                        KMIN = R;
                        if (KMIN < 0)
                        {
                            LS2B1 = false;
                            LS3B1 = false;
                            ST = HPR * KMIN;
                        }
                    }
                    for (I = 1; I < M + 1; I++)
                        FI[M + I] = FI[I];
                }
                HPR = ST;
                LS2B1 = true;
            }
            CINT = ST / 3;
            CST = ST / 2;
            if (J == 1 || J == 4)
                CINT = ST / 6;
            else if (J == 3)
                CST = ST;
            for (I = 1; I < N + 1; I++)
            {
                if(J == 1)
                    Y[2 * N + I]= Y[I];
                Y[I] = Y[I] + Y[N + I] * ST;
            }
            goto M1SP1;
        M3SP1:
            LS1B1 = true;
        }
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
        public static double[] P6(double T, double AA, double P, double MM, double HH)
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
        private double P7(double A, double B, double EPS, double EPS1, Func<double, double> F)
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
        /// <summary>
        /// Расчет характеристик силовой установки
        /// </summary>
        /// <param name="GEO"></param>
        /// <param name="A4"></param>
        /// <param name="B4"></param>
        /// <returns>Характеристики силовой установки</returns>
        public static double[] DU(double[] GEO, double A4, double B4, double C4)
        {
            double[] AB4 = new double[10];
            double[] BB4 = new double[10];
            AB4[1] = A4;
            AB4[2] = B4;
            AB4[3] = C4;
            double[] Atmosphere = P6(BB4[1], BB4[2], BB4[3], BB4[4], GEO[1]);
            AB4[4] = (1 - (1 - 1 / GEO[23]) * Atmosphere[3]) * GEO[23];
            AB4[5] = AB4[4] * GEO[20] / GEO[21];
            return AB4;
        }
        //------------------------------------------------------------------------------------------------------------
    }
}
//проверить в Р9 обращение к не дедовским методам, когда он будет доделан