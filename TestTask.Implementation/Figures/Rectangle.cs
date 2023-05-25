using System;
using TestTasks;

namespace TestTask.Implementation.Figures
{
    [Serializable]
    public class Rectangle : CustomFigure
    {
        private double _a;
        private double _b;
        /// <summary>
        /// Сторона прямоуголоника
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double A
        {
            get => _a;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Сторона прямоугольника должна быть положительной");
                }
                _a = value;
            }
        }
        /// <summary>
        /// Сторона прямоугольника B
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double B
        {
            get => _b;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Сторона прямоугольника должна быть положительной");
                }
                _b = value;
            }
        }
        /// <summary>
        /// Вычисляет площадь прямоугольника
        /// </summary>
        /// <returns>Площадь прямоугольника</returns>
        public override double CalculateSquare()
        {
            return A * B;
        }

        public override string ToString()
        {
            return $"Прямоугольник со стороной A: {A}, B: {B}";
        }
    }
}