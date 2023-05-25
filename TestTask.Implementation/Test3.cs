using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TestTasks;

namespace TestTask.Implementation
{
    public class Test3 : ITest3
    {
        private List<Car> _cars;
        private object _locker;

        public Test3()
        {
            _cars = new List<Car>();
            _locker = new object();
        }

        /// <summary>
        /// Добавляет информацию об автомобиле.
        /// </summary>
        /// <param name="car">Информация об автомобиле</param>
        public void RegisterCar(Car car)
        {
            lock (_locker)
            {
                _cars.Add(car);
            }
        }

        /// <summary>
        /// Вернуть информацию о количестве всех автомобилей указанного цвета.
        /// Метод должен работать максимально быстро.
        /// Учесть, что вызов возможен из отдельного потока параллельно RegisterCar()
        /// </summary>
        /// <param name="color">Требуемый цвет</param>
        /// <returns name="result">Количество всех автомобилей указанного цвет</returns>
        public int GetCountByColor(Color color)
        {
            lock (_locker)
            {
                var result = _cars.Count(car => car.Color == color);
                return result;
            }
        }
        
        /// <summary>
        /// Вернуть массив всех автомобилей указанного цвета и указанной модели.
        /// Метод должен работать максимально быстро.
        /// </summary>
        /// <param name="color">Требуемый цвет</param>
        /// <param name="model">Требуемая модель</param>
        /// <returns name="result">Массив всех автомобилей указанного цвета и указанной модели</returns>
        public Car[] GetCarsByColorAndModel(Color color, string model)
        {
            lock (_locker)
            {
                var cars = _cars
                    .Where(car => car.Color == color & car.Model == model)
                    .ToArray();
                return cars;
            }
        }
        
        /// <summary>
        /// Перечисляет все автомобили, выпущенные в указанный период (включительно)
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns name="cars">Перечисление автомобилей в указанный период (включительноы)</returns>
        public IEnumerable<Car> EnumAllReleasedBetween(DateTime dt1, DateTime dt2)
        {
            lock (_locker)
            {
                var cars = _cars.Where(car => dt1 >= car.ReleaseDt & car.ReleaseDt <= dt2);
                return cars;
            }
        }
    }
}