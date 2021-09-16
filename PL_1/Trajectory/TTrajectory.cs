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

            TR(GEO, T, LSERG, L1DATA); //proverit' p1

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
            P1(N, M, H, FI, T, L1TR, GEO, T, VN, LTR, L1TR, L1DATA, L2TR, L3TR, L5TR, LDATA, L1PR);

            if (L6TR)
            {
                L6TR = false;
                goto M1TR;
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

        private void P1(int N, int M, double[] H, double[] FI, double[] Y, bool LS1B1, double[] GEO, double[] T, double[] VN, bool LTR, bool L1TR, int L1DATA, bool L2TR, bool L3TR, bool L5TR, bool LDATA, bool L1PR)
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
                if (J == 1)
                    Y[2 * N + I] = Y[I];
                Y[I] = Y[I] + Y[N + I] * ST;
            }
            goto M1SP1;
        M3SP1:
            LS1B1 = true;
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            double[] P2()
            {
                Func<double, double[], double[], double[], double[], bool, bool, bool,bool, bool, double> F_inc;
                double[] C = new double[9];
                double E = 1E-4;
                double E1 = 1E-1;
                double D1 = 1.4;
                int D2 = 0;
                double D3 = 0.4;
                bool LOG1P2 = true;
                bool L4TR = false;
                L3TR = false;
                L2TR = true;
                L5TR = true;
                double X2;
                double X3;
                double[] Atmosphere;
                double HB;
                double MU = 0;
                if (LOG1P2 || L4TR)
                {

                    HB = T[11];
                    Atmosphere = HelperMethods.SP6B1(VN[5], VN[6], VN[7], MU, HB);
                    VN[5] = Atmosphere[1];
                    VN[6] = Atmosphere[2];
                    VN[7] = Atmosphere[3];
                    MU = Atmosphere[4];
                    VN[8] = VN[4] * Atmosphere[3];
                    VN[9] = 0.12492 * VN[7] * 288.15 / Atmosphere[1];
                    VN[10] = T[9] / Atmosphere[2];
                    VN[11] = VN[9] * T[9] * T[9] / 2;
                    LOG1P2 = false;
                }

                VN[2] = 0;
                T[3] = -4E-3 * Math.Pow((T[1] - 160), 2) + 38 * (T[1] - 160);
                T[11] = T[3];
                VN[13] = -8E-3 * (T[1] - 160) + 38;
                VN[15] = -8E-3;
                HB = T[11];
                Atmosphere = HelperMethods.SP6B1(VN[5], VN[6], VN[7], MU, HB);
                VN[8] = VN[4] * Atmosphere[3];
                VN[9] = 0.12492 * Atmosphere[3] * 288.15 / Atmosphere[1];
                VN[10] = T[9] / Atmosphere[2];
                VN[11] = VN[9] * T[9] * T[9] / 2;
                if (L2TR)
                {
                    T[3] = T[11];
                    VN[12] = VN[1] * VN[13] / T[9];
                    VN[14] = VN[1] * (VN[15] - VN[13] / T[9]) / T[9];
                    if (VN[12] != 0)
                        VN[16] = 1 + 1 / VN[12];
                    if (L5TR)
                    {
                        if (F1(D2, VN, GEO, T, H, L2TR, L3TR, L5TR, LDATA, L1PR) < 0)
                        {
                            VN[27] = D2;
                            goto M1SP8;
                        }
                        X2 = D2;
                        X3 = D3;
                        F_inc = F1;
                        VN[27] = P7(X2, X3, E, E1, F_inc);
                        if (VN[27] == 0)
                            goto M1P2;
                        M1SP8:
                        if (F2(D3, VN, GEO, T, H, L2TR, L3TR, L5TR, LDATA, L1PR) > 0)
                        {
                            VN[28] = D3;
                            goto M2SP8;
                        }
                        X2 = D2;
                        X3 = D3;
                        F_inc = F2;
                        VN[28] = P7(X2, X3, E, E1, F_inc);
                        if (VN[28] == 0)//здесь должно быть условие типо если корней нет, то иди на эту метку, но я пока хз про метод P7
                            goto M1P2;
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
                    {
                        F_inc = F;
                        VN[17] = P7(VN[27], VN[28], E, E1, F_inc);
                        if (VN[17] == 0)
                            goto M2P2;
                    }
                    else
                    {
                        F_inc = F;
                        VN[2] = P7(VN[27], VN[28], E, E1, F_inc);
                        if (VN[2] == 0)
                            goto M1P2;
                    }
                    if (L2TR)
                        goto M3P2;
                    if (L3TR)
                        goto M5P2;
                    M2P2:
                    if (L5TR)
                    {
                        F_inc = F;
                        VN[17] = P7(-VN[28], -VN[27], E, E1, F_inc);
                        if (VN[17] == 0)
                            goto M1P2;
                    }
                    if (L2TR)
                        goto M3P2;
                    if (L3TR)
                        goto M5P2;
                    M5P2:
                    C[1] = 0;
                    C[2] = 0;
                M3P2:
                    VN[29] = VN[1] * ((VN[18] * Math.Cos(VN[17]) - VN[22] * VN[11] / GEO[9]) / (1 - T[16]) - Math.Sin(T[10]));
                    C[1] = 1;
                    C[2] = 0;
                    C[3] = 0;
                    C[4] = (T[9] * Math.Cos(T[10]) * Math.Cos(T[13]) * VN[3] / (VN[3] + T[11])) / VN[29];
                    C[5] = VN[21] * VN[11] * VN[1] / GEO[9] / (1 - T[16]) * Math.Sin(VN[2]) / T[9] / Math.Cos(T[10]) / VN[29];
                    C[6] = 1 / VN[29];
                    C[7] = (T[9] * Math.Cos(T[10]) * Math.Sin(T[13])) / VN[29];
                    C[7] = C[7] * VN[3] / (VN[3] + T[11]);
                    C[8] = C[6] * VN[18] / VN[32];
                }
                if (L3TR || L4TR)
                {
                    if (L3TR)
                    {
                        VN[16] = 1;
                        VN[12] = VN[1] * VN[13] / T[9];
                        VN[14] = VN[1] * (VN[15] - VN[13] / T[9]) / T[9];
                        if (VN[12] != 0)
                            VN[16] = 1 + 1 / VN[12];
                        if (L5TR)
                        {
                            if (F1(D2, VN, GEO, T, H, L2TR, L3TR, L5TR, LDATA, L1PR) < 0)
                            {
                                VN[27] = D2;
                                goto M1SP8;
                            }
                            X2 = D2;
                            X3 = D3;
                            F_inc = F1;
                            VN[27] = P7(X2, X3, E, E1, F_inc);
                            if (VN[27] == 0)
                                goto M1P2;
                            M1SP8:

                            if (F2(D3, VN, GEO, T, H, L2TR, L3TR, L5TR, LDATA, L1PR) > 0)
                            {
                                VN[28] = D3;
                                goto M2SP8;
                            }
                            X2 = D2;
                            X3 = D3;
                            F_inc = F2;
                            VN[28] = P7(X2, X3, E, E1, F_inc);
                            if (VN[28] == 0)
                                goto M1P2;
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
                        {
                            F_inc = F;
                            VN[17] = P7(VN[27], VN[28], E, E1, F_inc);
                            if (VN[17] == 0)
                                goto M2P2;
                        }
                        else
                        {
                            F_inc = F;
                            VN[2] = P7(VN[27], VN[28], E, E1, F_inc);
                            if (VN[2] == 0)
                                goto M1P2;
                        }
                        if (L2TR)
                            goto M3P2;
                        M3P2:
                        VN[29] = VN[1] * ((VN[18] * Math.Cos(VN[17]) - VN[22] * VN[11] / GEO[9]) / (1 - T[16]) - Math.Sin(T[10]));
                        C[1] = 1;
                        C[2] = 0;
                        C[3] = 0;
                        C[4] = (T[9] * Math.Cos(T[10]) * Math.Cos(T[13]) * VN[3] / (VN[3] + T[11])) / VN[29];
                        C[5] = VN[21] * VN[11] * VN[1] / GEO[9] / (1 - T[16]) * Math.Sin(VN[2]) / T[9] / Math.Cos(T[10]) / VN[29];
                        C[6] = 1 / VN[29];
                        C[7] = (T[9] * Math.Cos(T[10]) * Math.Sin(T[13])) / VN[29];
                        C[7] = C[7] * VN[3] / (VN[3] + T[11]);
                        C[8] = C[6] * VN[18] / VN[32];
                        if (L3TR)
                            goto M5P2;
                        M2P2:
                        if (L5TR)
                        {
                            F_inc = F;
                            VN[17] = P7(-VN[28], -VN[27], E, E1, F_inc);
                            if (VN[17] == 0)
                                goto M1P2;
                        }
                        if (L2TR)
                            goto M3P2;
                        if (L3TR)
                            goto M5P2;
                        M5P2:
                        C[1] = 0;
                        C[2] = 0;
                    }
                    if (L4TR)
                    {
                        P9(VN[17], VN, GEO, T, LDATA, L1PR);
                        C[1] = VN[1] * ((VN[18] * Math.Cos(VN[17]) - VN[22] * VN[11] / GEO[9]) / (1 - T[16]) - Math.Sin(T[10]));
                        C[2] = VN[1] * ((VN[18] * Math.Sin(VN[17]) + VN[21] * VN[11] * Math.Cos(VN[2]) / GEO[9]) / (1 - T[16]) - Math.Cos(T[10]) * VN[3] * VN[3] / Math.Pow((VN[3] + T[11]), 2)) / T[9] + T[9] * Math.Cos(T[10]) / (VN[3] + T[11]);
                    }
                    C[3] = T[9] * Math.Sin(T[10]);
                    C[4] = T[9] * Math.Cos(T[10]) * Math.Cos(T[13]) * VN[3] / (VN[3] + T[11]);
                    C[5] = VN[21] * VN[11] * VN[1] / GEO[9] / (1 - T[16]) * Math.Sin(VN[2]) / T[9] / Math.Cos(T[10]);
                    C[6] = 1;
                    C[7] = T[9] * Math.Cos(T[10]) * Math.Sin(T[13]);
                    C[7] = C[7] * VN[3] / (VN[3] + T[11]);
                    C[8] = VN[18] / VN[32];
                }
                for (int z = 1; z <= 8; z++)
                {
                    T[z + 8] = C[z];
                }
                goto M4P2;
            M1P2:
                Console.WriteLine();//что то выводится на консоль
              //goto M2TR; вроде это вывод на печать но пока хз
            M4P2:
                return T;
            }

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            void P3()
            {
                double NX = new double();
                FI[1] = GEO[15] - T[8];
                FI[2] = GEO[16] - T[1];
                NX = (VN[18] * Math.Cos(VN[17]) - VN[22] * VN[11] / GEO[9]) / (1 - T[8]);
                if (LTR && I == L1DATA || LTR && L1TR)
                {
                    Console.WriteLine("T[6]=" + T[6] + "T[3]=" + T[3] / 1000d + "T[1]=" + T[1] + "T(4)=" + T[4] / 1000d + "T[7]=" + T[7] / 1000d + "T[2]=" + T[2] * 57.3d + "T[8]=" + T[8]);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("VN[17]=" + VN[17] * 75.3d + "VN[2]=" + VN[2] * 57.3d + "VN[10]=" + VN[10] + "K=" + VN[21] / VN[22] + "NX=" + NX + "VN[11]=" + VN[11] / 1000d + "VN[33]=" + VN[33]);
                    I = 0;
                }
                I = I + 1;
            }


            double P7(double A, double B, double EPS, double EPS1, Func<double, double[], double[], double[], double[], bool, bool, bool, bool, bool, double> F)
            {
                double X;
                X = A;
                double Y_P7 = new double();
                FF(ref Y_P7);
                if (Math.Abs(Y_P7) <= EPS)
                    goto M2SP7;

                X = B;
                double Z = new double();
                FF(ref Z);
                if (Math.Abs(Z) <= EPS)
                    goto M2SP7;

                if (Math.Sign(Y_P7) == Math.Sign(Z))
                {
                    Console.WriteLine($"Корней нет\n\n{A}");
                    return (X);
                }
            M3SP7:
                X = A / 2f + B / 2f;
                FF(ref Y_P7);
                if (Math.Abs(Y_P7) <= EPS)
                    goto M2SP7;
                if (Math.Sign(Y_P7) == Math.Sign(Z))
                    B = X;
                else
                    A = X;
                if (Math.Abs(A - B) >= EPS1)
                    goto M3SP7;

                void FF(ref double YORZ)
                {
                    YORZ = F(X, VN, GEO, T, H, L2TR, L3TR, L5TR, LDATA, L1PR);
                }
            M2SP7:
                return (X);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Расчет характеристик силовой установки
        /// </summary>
        /// <param name="GEO"></param>
        /// <param name="A4"></param>
        /// <param name="B4"></param>
        /// <returns>Характеристики силовой установки</returns>
        private double[] DU(double[] GEO, double A4, double B4, double C4)
        {
            double[] AB4 = new double[10];
            double[] BB4 = new double[10];
            AB4[1] = A4;
            AB4[2] = B4;
            AB4[3] = C4;
            double[] Atmosphere = HelperMethods.SP6B1(BB4[1], BB4[2], BB4[3], BB4[4], GEO[1]);
            AB4[4] = (1 - (1 - 1 / GEO[23]) * Atmosphere[3]) * GEO[23];
            AB4[5] = AB4[4] * GEO[20] / GEO[21];
            return AB4;
        }
        //------------------------------------------------------------------------------------------------------------

        private double F(double AL0, double[] VN, double[] GEO, double[] T, double[] H, bool L2TR, bool L3TR, bool L5TR, bool LDATA, bool L1PR)
        {
            if (L5TR)
                VN[17] = AL0;
            else
                VN[2] = AL0;
            if (L2TR)
            {
                T[9] = T[9] + 1;
                P9(VN[17], VN, GEO, T, LDATA, L1PR);
                VN[23] = VN[19];
                T[9] = T[9] - 1;
                P9(VN[17], VN, GEO, T, LDATA, L1PR);
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
                P9(VN[17], VN, GEO, T, LDATA, L1PR);
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
                Console.WriteLine("В функции F: L2TR и L3TR оба false, а значит выводится ноль");
                Console.ReadKey();
                return 0;
            }
        }

        private double F1(double AL1, double[] VN, double[] GEO, double[] T, double[] H, bool L2TR, bool L3TR, bool L5TR, bool LDATA, bool L1PR)
        {
            VN[27] = AL1;
            P9(VN[27], VN, GEO, T, LDATA, L1PR);
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

        private double F2(double AL2, double[] VN, double[] GEO, double[] T, double[] H, bool L2TR, bool L3TR, bool L5TR, bool LDATA, bool L1PR)
        {
            VN[28] = AL2;
            P9(VN[28], VN, GEO, T, LDATA, L1PR);
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

        private void P9(double AL, double[] VN, double[] GEO, double[] T, bool LDATA, bool L1PR)
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
    }
}
//проверить в Р9 обращение к не дедовским методам, когда он будет доделан