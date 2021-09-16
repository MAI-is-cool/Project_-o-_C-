//Расчет коэффициента подъемной силы  и  аэродинамического сопротивления ЛА
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********************************************************
namespace StandartHelperLibrary.MathHelper
{
    class TDeterminationLiftingCoefficient
    {
        //---------------------------------------------------------------------------------
        /// <summary>
        /// Расчет коэффициента подъемной силы и аэродинамического сопративления ЛА
        /// </summary>
        /// <returns>Коэффициент подъемной силы ЛА</returns>
        public static double[] СalculationLiftingForceCoefficient(double[] GEO, double H, double M, double Alfa, bool LOG2)
        {
            double[] AER = new double[10];
            double[] VN = new double[100];
            VN[1] = H;

            VN[3] = Alfa;
            VN[2] = M;
            if (VN[2] <= 0.8)
                VN[4] = 1;
            if (VN[2] > 0.8 && VN[2] <= 1)
                VN[4] = 1.5 * (1 - VN[2]) + 0.7;
            if (VN[2] > 1)
                VN[4] = 0.7;
            VN[5] = (1 - Math.Tan(GEO[71] / 57.3) / Math.Tan(GEO[72] / 57.3)) / Math.Tan(GEO[72] / 57.3) * 4;
            VN[3] = VN[3] + GEO[99] / 57.3;
            if (VN[3] == 0)
                VN[8] = VN[2] * Math.Cos(GEO[72] / 57.3);
            else
            {
                VN[7] = Math.Atan(Math.Tan(VN[3]) / Math.Cos(GEO[72] / 57.3));
                VN[8] = VN[2] * Math.Sin(VN[3]) / Math.Sin(VN[7]);
            }
            if (VN[2] <= 1.2)
                VN[9] = Math.Sqrt(1.528 / (VN[8] * VN[8]) - 0.695) / (1 + Math.Sqrt(2 / GEO[73] / GEO[74]));
            else
                VN[9] = 0;
            VN[10] = Math.Atan(Math.Tan(VN[9]) * Math.Cos(GEO[72] / 57.3));
            if (VN[2] < 1)
            {
                VN[6] = 3.14 * (VN[5] / 4) * Math.Sin(2 * VN[3]) * (1 - 0.09 * Math.Sqrt(1 - VN[2] * VN[2])) * (1 - Math.Pow(Math.Cos(GEO[72] / 57.3), 2) * Math.Sqrt(1 - VN[2] * VN[2])) * Math.Cos(VN[3]);
                if (VN[3] >= VN[10])
                    VN[11] = 3.14 * (Math.Pow(Math.Sin(VN[3] - VN[10]), 2)) / (Math.Pow(Math.Sin(GEO[72] / 57.3), 2)) * (1 - Math.Pow(Math.Cos(GEO[72] / 57.3), 2) * Math.Sqrt(1 - VN[2] * VN[2])) * Math.Cos(VN[3]);
                else
                    VN[11] = 0;
                AER[1] = (VN[6] + VN[11]) * VN[4];
            }
            VN[12] = Math.Sqrt(Math.Abs(VN[2] * VN[2] - 1)) / Math.Tan(GEO[72] / 57.3);
            if (VN[2] >= 1)
            {
                if (VN[12] <= 0.06)
                    VN[13] = 1;
                if (VN[12] > 0.06)
                    VN[13] = 1 - 0.19 * (VN[12] - 0.06);
                VN[6] = 3.14 * 0.91 * (VN[5] / 4) * Math.Sin(2 * VN[3]) * VN[13] * Math.Cos(VN[3]);
                if (VN[3] >= VN[10] && VN[12] <= 1)
                    VN[11] = 3.14 * (Math.Pow(Math.Sin(VN[3] - VN[10]), 2) / Math.Pow(Math.Sin(GEO[72] / 57.3), 2)) * VN[13] * VN[13] * Math.Sqrt(1 - VN[12] * VN[12]) * Math.Cos(VN[3]);
                else
                    VN[11] = 0;
                AER[1] = (VN[6] + VN[11]) * VN[4];
                if (VN[2] == 1)
                    VN[14] = 40;
                else
                    VN[14] = 4 / Math.Sqrt(VN[2] * VN[2] - 1);
                VN[15] = 0.9;
                VN[33] = Math.Max(VN[14], VN[15]) * Math.Sin(2 * VN[3]) / 2;
                if (AER[1] > 0.45 * Math.Sin(2 * VN[3]))
                    AER[1] = Math.Min(VN[33], AER[1]);
                else
                    AER[1] = 0.45 * Math.Sin(2 * VN[3]);
            }
            AER[1] = (21.4 * Math.Pow(GEO[98], 2.1) + 1) * AER[1];
            if (GEO[98] > 0.15)
                AER[1] = 1.415 * AER[1];
            VN[3] = VN[3] - GEO[99] / 57.3;
            VN[3] = VN[3] + GEO[100] / 57.3;
            if (GEO[79] == 0)
            {
                AER[2] = HelperMethods.VM1(VN, GEO);
            }
            VN[14] = Math.Sqrt(Math.Abs(1 - VN[2] * VN[2])) / GEO[75];
            if (VN[2] < 1)
            {
                VN[15] = (GEO[76] - GEO[75] - GEO[77]) / GEO[75];
                if (VN[14] >= 0 && VN[14] < 0.4)
                {
                    if (VN[15] == 0)
                        VN[16] = 0.05;
                    else
                        VN[16] = 0.0166 * VN[14] * VN[14] - 0.0191 * VN[14] + 0.055;
                }
                else
                    VN[16] = 0.05;
            }
            else
            {
                VN[17] = 0.025 * VN[14] + 0.055;
                if (VN[14] >= 0.2 && VN[14] < 1.55)
                    VN[17] = -0.00833 * VN[14] * VN[14] + 0.02503 * VN[14] + 0.0533;
                if (VN[14] > 1.55)
                    VN[17] = 0.0741;
                if (VN[14] < 1.55)
                    VN[18] = 0.01616 * Math.Sqrt(VN[15]) + 0.00435 * (1.55 - VN[14]) + 0.045;
                else
                    VN[18] = 0.01616 * Math.Sqrt(VN[15]) + 0.045;
                VN[16] = Math.Min(VN[17], VN[18]);
            }
            VN[16] = VN[16] + 0.0492 * (0.593 - GEO[180]);
            VN[19] = -0.006 * (1 - GEO[78] * GEO[78]);
            VN[20] = 1.2 * (GEO[76] - GEO[75]) * Math.Pow(Math.Sin(2 * VN[3]), 2) / 3.14;
            AER[2] = HelperMethods.VM1(VN, GEO);
            VN[3] = VN[3] - GEO[100] / 57.3;
            VN[56] = (GEO[80] - GEO[79]) / (1 - GEO[79]);
            VN[35] = 1 + 2 * Math.Pow(GEO[73], 1.33) / Math.Pow(Math.Cos(GEO[83] / 57.3), 1.333) - 1.79 * Math.Pow(GEO[73], 0.667) / Math.Pow(Math.Cos(GEO[83] / 57.3), 0.667);
            if (VN[2] < 1)
                VN[21] = Math.Pow((1 + GEO[79]), 2) - 0.1;
            if (VN[2] > 1 && VN[2] < 5)
                VN[21] = (1.1 - Math.Pow((1 + GEO[79]), 2)) * (VN[2] - 1) / 4 + Math.Pow((1 + GEO[79]), 2) - 0.1;
            if (VN[2] >= 5)
                VN[21] = 1;
            VN[22] = (1 - (VN[56] - 1) * GEO[79] / (VN[56] + 1)) * (1 - GEO[79]);
            if (GEO[79] == 0)
                VN[21] = 1;
            AER[3] = VN[21] * AER[1] * VN[22] * 1 + AER[2] * GEO[81];
            double[] Atmosphere = HelperMethods.SP6B1(VN[23], VN[24], VN[25], VN[26], VN[1]);
            VN[27] = 2.7781E-2 * 7.41673E-9 * Atmosphere[2] * Atmosphere[1] * Atmosphere[1] / (Atmosphere[1] + 110.4) / Atmosphere[3];
            VN[24] = Atmosphere[2];
            AER[7] = HelperMethods.CVM5(GEO[89], GEO[90], GEO[91], GEO[92], GEO[93], GEO[94], GEO[95], VN, GEO);
            AER[4] = HelperMethods.CVM5(GEO[73], GEO[83], GEO[80], GEO[72], GEO[71], GEO[84], GEO[86], VN, GEO);
            if (GEO[79] == 0)
            {
                AER[6] = HelperMethods.VM2(VN, GEO, AER);
            }
            if (VN[2] < 5)
                VN[42] = HelperMethods.CVM4(VN[2], GEO[87], VN, GEO);
            else
            {
                VN[40] = 5;
                VN[42] = HelperMethods.CVM4(VN[40], GEO[87], VN, GEO);
            }
            if (VN[2] > 1 && VN[2] < 1.5)
                VN[43] = 0.8 / GEO[75] + 0.014 * GEO[75];
            if (VN[2] >= 1.5)
            {
                VN[44] = Math.Atan(0.5 * (1 - GEO[88]) / (GEO[75] - GEO[88])) * 57.3;
                if (VN[2] >= 1.5 && VN[2] < 5)
                {
                    VN[45] = (0.0016 + 0.002 / (VN[2] * VN[2])) * Math.Pow(VN[44], 1.7) * (1 - (196 * GEO[75] * GEO[75] - 16) / (14 * (VN[2] + 18) * GEO[75] * GEO[75]));
                }
                if (VN[2] >= 5)
                    VN[45] = 0.00168 * Math.Pow(VN[44], 1.7) * (1 - (196 * GEO[75] * GEO[75] - 16) / (322 * GEO[75] * GEO[75]));
                if (GEO[77] == 0)
                    VN[46] = 0;
                else
                    VN[46] = Math.Atan(0.5 * (1 - GEO[78] / 57.3) / (GEO[77])) * 57.3;
                if (VN[2] >= 1.5 && VN[2] < 5)
                    VN[47] = 0.4 * (0.0016 + 0.002 / (VN[2] * VN[2])) * Math.Pow(VN[46], 1.7) * (1 - 2.41 * Math.Pow(GEO[78], 2.667) * (1 - 0.49 * GEO[78] + 0.056 * GEO[78] * GEO[78] - 0.151 * Math.Pow(GEO[78], 3)));
                if (VN[2] >= 5)
                    VN[47] = 0.672E-3 * Math.Pow(VN[46], 1.7) * (1 - 2.41 * Math.Pow(GEO[78], 2.667) * (1 - 0.49 * GEO[78] + 0.056 * GEO[78] * GEO[78] - 0.151 * Math.Pow(GEO[78], 3)));
                VN[43] = VN[45] + VN[47];
            }
            if (VN[2] < 1)
                VN[43] = 0;
            if (VN[2] < 1)
            {
                VN[48] = 0.029 * Math.Pow(GEO[78], 3) / Math.Sqrt(VN[33]);
            }
            else
            {
                if (VN[2] < 5)
                {
                    VN[49] = VN[2] * Math.Pow(GEO[78], 2) / GEO[76];
                    if (VN[49] <= 1)
                    {
                        VN[48] = 1.144 * VN[49] * (2 - VN[49]) * Math.Pow(GEO[78], 2) / (VN[2] * VN[2]);
                    }
                    else VN[48] = 1.43 * Math.Pow(GEO[78], 2) / Math.Pow(VN[2], 2);
                }
                else VN[48] = 0.057 * Math.Pow(GEO[78], 2);
            }
            if (LOG2)
                VN[48] = 0;
            AER[6] = HelperMethods.VM2(VN, GEO, AER);
            AER[5] = VN[42] + VN[43] + VN[48];
            if (VN[2] < 0.2)
                VN[50] = -0.2;
            if (VN[2] >= 0.2 && VN[2] < 1.2)
                VN[50] = (1.5 / (1 + GEO[75]) + 0.2) * VN[2] - 0.2 * (1.5 / (1 + GEO[75]) + 1.2);
            if (VN[2] >= 1.2)
                VN[50] = 1.5 / (1 + GEO[75]);
            VN[51] = (1 + VN[50]) * (57.3 * VN[16] - 0.4 * (1 - Math.Pow(GEO[78], 2))) * Math.Pow(VN[3], 2);
            AER[6] = HelperMethods.VM3(VN, GEO, AER);
            if (VN[2] > 1 && VN[12] < 1)
            {
                if (VN[3] < 0)
                    VN[54] = 0;
                else
                {
                    VN[52] = AER[1] * VN[21];
                    if (VN[52] >= 0 && VN[52] < 0.2)
                        VN[53] = -VN[52] + 0.8;
                    if (VN[52] >= 0.2 && VN[52] < 0.5)
                        VN[53] = -1.33 * (VN[52] - 0.2) + 0.6;
                    if (VN[52] >= 0.5 && VN[52] < 0.6)
                        VN[53] = -0.5 * (VN[52] - 0.5) + 0.2;
                    if (VN[52] >= 0.6)
                        VN[53] = 0.15;
                    VN[54] = VN[53] * VN[52] * VN[52] / 12.56 * Math.Sqrt(1 - VN[2] * VN[2] * Math.Pow(Math.Cos(GEO[72] / 57.3), 2)) / Math.Cos(GEO[72] / 57.3);
                }
                AER[6] = (AER[1] * VN[21] * Math.Tan(VN[3]) - VN[54]) * VN[22] + VN[51] * GEO[81];
            }
            VN[57] = (GEO[91] - GEO[96]) / (1 - GEO[96]);
            VN[55] = 0.5 * (1 - (VN[57] - 1) * GEO[96] / (VN[57] + 1)) * (1 - GEO[96]);
            AER[8] = 1.1 * (AER[4] * (1 - GEO[97] * (1 - VN[22])) + AER[5] * GEO[81] + 0.9 * AER[7] * VN[55]) + AER[6];
            return AER;
        }
    }
}