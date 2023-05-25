using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TestTask.Implementation.Figures;
using TestTasks;

namespace TestTask.Implementation
{
    public class Test4 : ITest4
    {
        private Random _random = new Random();
        /// <summary>
        /// Создает случайную фигуру размеры сторон, которой от 0 до 100
        /// </summary>
        /// <returns>Случайная фигура</returns>
        public CustomFigure CreateRandomFigure()
        {
            var randomIndex = _random.Next(3);
            CustomFigure customFigure;
            switch (randomIndex)
            {
                case 0: // Создаем круг
                    customFigure = new Circle()
                    {
                        R = _random.NextDouble() * 100 // Случайная длина от 0 до 100
                    };
                    break;
                case 1: // Создаем квадрат
                    customFigure = new Rectangle()
                    {
                        A = _random.NextDouble() * 100 // Случайная длина от 0 до 100
                    };
                    break;
                default:  // Создаем прямоугольник
                    customFigure = new Rectangle()
                    {
                        A = _random.NextDouble() * 100, // Случайная длина от 0 до 100
                        B = _random.NextDouble() * 100 // Случайная длина от 0 до 100
                    };
                    break;
            }
            return customFigure;
        }
        
        /// <summary>
        /// Сохраняет фигуру в массив байт
        /// </summary>
        /// <param name="figure"></param>
        /// <returns>Массив байт</returns>
        public byte[] SaveToBinary(CustomFigure figure)
        {
            using var memoryStream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, figure);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Восстановливает фигуру из массива байт.
        /// </summary>
        /// <typeparam name="T">Тип фигуры</typeparam>
        /// <param name="binary"></param>
        /// <returns>Фигуру</returns>                
        public CustomFigure TryLoadFromBinary(byte[] binaryArr)
        {
            using var memoryStream = new MemoryStream(binaryArr);
            var binaryFormatter = new BinaryFormatter();
            var figure = (CustomFigure)binaryFormatter.Deserialize(memoryStream);
            return figure;
        }

        /// <summary>
        /// Восстановливает фигуру из массива байт.
        /// </summary>
        /// <typeparam name="T">Тип фигуры</typeparam>
        /// <param name="binary">Массив байт для дессериализации</param>
        /// <returns>Фигуру</returns>  
        public T TryLoadFromBinary<T>(byte[] binary) 
        {
            using var memoryStream = new MemoryStream(binary);
            var binaryFormatter = new BinaryFormatter();
            var result = (T)binaryFormatter.Deserialize(memoryStream);
            return result;
        }
    }
}