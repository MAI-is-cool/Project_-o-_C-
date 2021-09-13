//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using StandartHelperLibrary.MathHelper;
//***********************************************************
namespace PL_1
{
    class Program
    {
//----------------------------------------------------------
        static void Main(string[] args)
        {
            //Console.WriteLine("Вычисление диффур с невязками");
            //TDifferentialSolver.Debug(TDifferentialSolver.Example_dN_Residual());
            //TDifferentialSolver.Debug(TDifferentialSolver.Example_dXdYdZ());
            //Console.WriteLine("Блок аэродинамика");
            //Console.WriteLine("Получить плотность от высоты 13050м");
            //Console.WriteLine(TResultAtmospheric.GetAirDensityFromHeight(13050)); 
            //Console.WriteLine("Получить высоту по плотности 0.019883 со стандартными условиями");
            //Console.WriteLine(TResultAtmospheric.GetHeightFromDensity(0.019883)); 
            //Console.WriteLine("Получить высоту по температуре 270 в Кельвинах за бортом для МСА");
            //Console.WriteLine(TResultAtmospheric.GetHeightFromAirTemperatureOfKelvin(270)); 
            //TDeterminationLiftingCoefficient.СalculationLiftingForceCoefficient();

            //TPointSystemDifferential PointSystemDifferentialInitial = new TPointSystemDifferential();
            //double [] F = PointSystemDifferentialInitial.Result;


            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(F[i]);
            //}
            double[] T = TDifferentialSolver.Equation_dN(9);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(T[i]);
            }

            //TSystemResultDifferential R = TDifferentialSolver.Example_dN();
            //double[] BalanceRes = new double[6];
            //BalanceRes = R.SystemPoints.ElementAt(9).Result;
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(BalanceRes[i]);
            //}


            //List<TPointSystemDifferential> P = R.SystemPoints;

            Console.ReadKey();
        }
//----------------------------------------------------------
    }
}
