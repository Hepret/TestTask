using System;
using TestTasks;

namespace TestTask.Implementation.Figures
{
    [Serializable]
    public class Circle : CustomFigure
    {
        private double _r;

        /// <summary>
        /// Радиус круга
        /// </summary>
        public double R
        {
            get => _r;
            set
            {
                if (value < 0)
                {
                    throw new AggregateException("Радиус должен быть положительным");
                }
                _r = value;
            }
        }

        /// <summary>
        /// Вычисляет площадь круга
        /// </summary>
        /// <returns>Площадь круга</returns>
        public override double CalculateSquare()
        {
            return Math.PI * Math.Pow(R, 2);
        }

        public override string ToString()
        {
            return $"Круг c радиусом {R}";
        }
    }
}