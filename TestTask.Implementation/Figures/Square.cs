using System;
using TestTasks;

namespace TestTask.Implementation.Figures
{
    [Serializable]
    public class Square : CustomFigure
    {
        private double _a;
        /// <summary>
        /// Сторона квадрата
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double A
        {
            get => _a;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Сторона квадрата должна быть положительной");
                }

                _a = value;
            }
        }
        
        /// <summary>
        /// Вычисляет площадь квадрата
        /// </summary>
        /// <returns>Площадь квадрата</returns>
        public override double CalculateSquare()
        {
            return Math.Pow(A, 2);
        }

        public override string ToString()
        {
            return $"Квадрат со стороной: {A}";
        }
    }
}