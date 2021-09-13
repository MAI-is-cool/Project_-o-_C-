﻿using System;
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
            double L1DATA = new double();
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

            TR(GEO, T, PR, DU, SP1B1, LSERG, M3TR);

            //конец SERG
            //реализовать альтернативу работы метки M3TR и M2TR, которые переводят в конец метода SERG
        }
        

        private void DATA(ref double[] Y, ref double[] GEO, ref bool LSERG, ref double L1DATA)
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


        private void TR(double[] GEO, double[] T, bool LTR/*, M2TR = M3TR - метка завершения всего серга*/)
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

            }

            void P8()
            {

            }

            void F()
            {

            }

            void F1()
            {

            }

            void F2()
            {

            }

            void P9()
            {

            }

            void P10()
            {

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
    }
}
