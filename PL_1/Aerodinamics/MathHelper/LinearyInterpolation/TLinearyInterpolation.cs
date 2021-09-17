// Интерполирование массивов
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//***********************************************************************************
namespace StandartHelperLibrary.MathHelper
{
    public class TLinearyInterpolation
    {
        //----------------------------------------------------------------------------------
        // Копировать массив
        private static float[] CopyArray(float[,] M, int Index, int CountX1)
        {
            float[] Buffer = new float[CountX1];
            for (int n = 0; n < CountX1; n++)
            {
                Buffer[CountX1] = M[Index, n];
            }
            return Buffer;
        }
        //----------------------------------------------------------------------------------
        // Копировать массив
        private static double[] CopyArray(double[,] M, int Index, int CountX1)
        {
            double[] Buffer = new double[CountX1];
            for (int n = 0; n < CountX1; n++)
            {
                Buffer[CountX1] = M[Index, n];
            }
            return Buffer;
        }
        //-----------------------------------------------------------------------------------
        // Получить ур-е линни с коэффициентами и найти по X соответсвующий У
        public static float LINO(float X1, float Y1, float X2, float Y2, float X)
        {
            // Проверить на деление на 0
            if ((X1 - X2) == 0)
                MessageBox.Show("Ошибка TLinearyInterpolation 101. X не является последовательностью. X1-X2=0");
            // Найти коэффициенты ур-е
            float A = (Y1 - Y2) / (X1 - X2);
            float B = Y1 - X1 * (Y1 - Y2) / (X1 - X2);
            // Вычислить У
            return X * A + B;
        }
        //-----------------------------------------------------------------------------------
        // Получить ур-е линни с коэффициентами и найти по X соответсвующий У
        public static double LINO(double X1, double Y1, double X2, double Y2, double X)
        {
            // Проверить на деление на 0
            if ((X1 - X2) == 0)
                MessageBox.Show("Ошибка TLinearyInterpolation 101. X не является последовательностью. X1-X2=0");
            // Найти коэффициенты ур-е
            double A = (Y1 - Y2) / (X1 - X2);
            double B = Y1 - X1 * (Y1 - Y2) / (X1 - X2);
            // Вычислить У
            return X * A + B;
        }
        //------------------------------------------------------------------------------
        /// <summary>
        /// Провести линейную интерполяцию по одному параметру
        /// </summary>
        /// <param name="MassivX">Массив значений Х</param>
        /// <param name="MassivY">Массив Значений У</param>
        /// <param name="CountX">Кол-во значений в массивах</param>
        /// <param name="X">Интерполируемый параметр</param>
        /// <returns>Значение полученное интерполяцией</returns>
        public static float Interpolate(float[] MassivX, float[] MassivY, int CountX, float X)
        {
            try
            {
                // Поиск по сетке ключевой точки
                for (int n = 0; n < CountX - 1; n++)
                {
                    // Выбрать направление для сравнения
                    if (MassivX[n] < MassivX[n + 1])
                    {
                        if ((MassivX[n] <= X) && (X < (MassivX[n + 1])))
                            return LINO(MassivX[n], MassivY[n], MassivX[n + 1], MassivY[n + 1], X);
                    }
                    else
                    {
                        if ((MassivX[n] >= X) && (X > (MassivX[n + 1])))
                            return LINO(MassivX[n], MassivY[n], MassivX[n + 1], MassivY[n + 1], X);
                    }
                }
                //
                if (X < MassivX[0])
                    return MassivY[0];
                else
                    return MassivY[CountX - 1];
            }
            catch
            {
                MessageBox.Show("Ошибка TLinearyInterpolation 102. Ошибка в процессе линейной интерполяции.");
                return 0;
            }
        }
        //------------------------------------------------------------------------------
        /// <summary>
        /// Провести линейную интерполяцию по одному параметру
        /// </summary>
        /// <param name="MassivX">Массив значений Х</param>
        /// <param name="MassivY">Массив Значений У</param>
        /// <param name="CountX">Кол-во значений в массивах</param>
        /// <param name="X">Интерполируемый параметр</param>
        /// <returns>Значение полученное интерполяцией</returns>
        public static double Interpolate(double[] MassivX, double[] MassivY, int CountX, double X)
        {
            try
            {
                // Поиск по сетке ключевой точки
                for (int n = 0; n < CountX - 1; n++)
                {
                    // Выбрать направление для сравнения
                    if (MassivX[n] < MassivX[n + 1])
                    {
                        if ((MassivX[n] <= X) && (X < (MassivX[n + 1])))
                            return LINO(MassivX[n], MassivY[n], MassivX[n + 1], MassivY[n + 1], X);
                    }
                    else
                    {
                        if ((MassivX[n] >= X) && (X > (MassivX[n + 1])))
                            return LINO(MassivX[n], MassivY[n], MassivX[n + 1], MassivY[n + 1], X);
                    }
                }
                //
                if (X < MassivX[0])
                    return MassivY[0];
                else
                    return MassivY[CountX - 1];
            }
            catch
            {
                MessageBox.Show("Ошибка TLinearyInterpolation 103. Ошибка в процессе линейной интерполяции.");
                return 0;
            }
        }
        //----------------------------------------------------------------------------------
        /// <summary>
        ///  Провести линейную интерполяцию по двум параметрам
        /// </summary>
        /// <param name="MassivX">Массив значений Х</param>
        /// <param name="MassiveZ">Массив значений Z</param>
        /// <param name="MassivY">Массив значений У</param>
        /// <param name="CountX">Кол-во значений в массиве Х</param>
        /// <param name="CountZ">Кол-во значений в массиве Z</param>
        /// <param name="X">Интерполируемый параметр 1</param>
        /// <param name="Z">Интерполируемый параметр 2</param>
        /// <returns>Значение полученное интерполяцией</returns>
        public static float Interpolate(float[] MassivX, float[] MassiveZ, float[,] MassivY, int CountX, int CountZ, float X, float Z)
        {
            float B1 = 0;
            float B2 = 0;
            // 1. Найти в интерполяционной сетке точку
            for (int n = 0; n < CountZ - 1; n++)
            {
                if (MassiveZ[n] > MassiveZ[n + 1])
                {
                    if (MassiveZ[n] < Z && Z < MassiveZ[n + 1])
                    {
                        B1 = Interpolate(MassivX, CopyArray(MassivY, n, CountX), CountX, X);
                        B2 = Interpolate(MassivX, CopyArray(MassivY, n + 1, CountX), CountX, X);
                        //
                        return B1 + ((Z - MassiveZ[n]) / Math.Abs(MassiveZ[n] - MassiveZ[n + 1])) * (B2 - B1);
                    }
                }
                else
                {
                    if (MassiveZ[n] > Z && Z > MassiveZ[n + 1])
                    {
                        B1 = Interpolate(MassivX, CopyArray(MassivY, n, CountX), CountX, X);
                        B2 = Interpolate(MassivX, CopyArray(MassivY, n + 1, CountX), CountX, X);
                        //
                        return B1 + ((Z - MassiveZ[n]) / Math.Abs(MassiveZ[n] - MassiveZ[n + 1])) * (B2 - B1);
                    }
                }
            }
            // 2. Если точка не найдена
            return Interpolate(MassivX, CopyArray(MassivY, 0, CountX), CountX, X);
        }
        //----------------------------------------------------------------------------------
        /// <summary>
        ///  Провести линейную интерполяцию по двум параметрам
        /// </summary>
        /// <param name="MassivX">Массив значений Х</param>
        /// <param name="MassiveZ">Массив значений Z</param>
        /// <param name="MassivY">Массив значений У</param>
        /// <param name="CountX">Кол-во значений в массиве Х</param>
        /// <param name="CountZ">Кол-во значений в массиве Z</param>
        /// <param name="X">Интерполируемый параметр 1</param>
        /// <param name="Z">Интерполируемый параметр 2</param>
        /// <returns>Значение полученное интерполяцией</returns>
        public static double Interpolate(double[] MassivX, double[] MassiveZ, double[,] MassivY, int CountX, int CountZ, double X, double Z)
        {
            double B1 = 0;
            double B2 = 0;
            // 1. Найти в интерполяционной сетке точку
            for (int n = 0; n < CountZ - 1; n++)
            {
                if (MassiveZ[n] > MassiveZ[n + 1])
                {
                    if (MassiveZ[n] < Z && Z < MassiveZ[n + 1])
                    {
                        B1 = Interpolate(MassivX, CopyArray(MassivY, n, CountX), CountX, X);
                        B2 = Interpolate(MassivX, CopyArray(MassivY, n + 1, CountX), CountX, X);
                        //
                        return B1 + ((Z - MassiveZ[n]) / Math.Abs(MassiveZ[n] - MassiveZ[n + 1])) * (B2 - B1);
                    }
                }
                else
                {
                    if (MassiveZ[n] > Z && Z > MassiveZ[n + 1])
                    {
                        B1 = Interpolate(MassivX, CopyArray(MassivY, n, CountX), CountX, X);
                        B2 = Interpolate(MassivX, CopyArray(MassivY, n + 1, CountX), CountX, X);
                        //
                        return B1 + ((Z - MassiveZ[n]) / Math.Abs(MassiveZ[n] - MassiveZ[n + 1])) * (B2 - B1);
                    }
                }
            }
            // 2. Если точка не найдена
            return Interpolate(MassivX, CopyArray(MassivY, 0, CountX), CountX, X);
        }
    }
    //----------------------------------------------------------------------------------
}