using System;
using System.IO;
using System.Linq;
using TestTasks;

namespace TestTask.Implementation
{
    public class Test0 : ITest0
    {
        /// <summary>
        /// Проверяет, является ли число четным
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Определяет, сколько секунд между двумя моментами времени
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public int GetSecondsBetweenDates(DateTime dt1, DateTime dt2)
        {
            TimeSpan timeSpan = dt2 - dt1;
            return (int)timeSpan.TotalSeconds;
        }

        /// <summary>
        /// Из строки полного имени человека в формате "Фамилия Имя Отчество"
        /// возвращает Имя
        /// </summary>
        /// <param name="fullName">ФИО</param>
        /// <returns></returns>
        public string ExtractFirstName(string fullName)
        {
            var nameParts = fullName.Split(' ');
            if (nameParts.Length >= 2)
            {
                return nameParts[1];
            }

            throw new ArgumentException("Неправельный формат сторки");
        }
        
        /// <summary>
        /// Возвращает массив байт с элементами, расположенными в обратном порядке 
        /// </summary>
        /// <param name="value">Исходный массив байт</param>
        /// <returns></returns>
        public byte[] Reverse(byte[] value)
        {
            var reversedArray = value.Reverse().ToArray();
            return reversedArray;
        }
        /// <summary>
        /// Сохраняет строку в файл
        /// </summary>
        /// <param name="textToSave"></param>
        /// <param name="fileName"></param>
        public void WriteText(string textToSave, string fileName)
        {
            using StreamWriter writer = new StreamWriter(fileName);
            writer.Write(textToSave);
        }

        /// <summary>
        /// Читает содержимое текстового файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadText(string fileName)
        {
            using StreamReader reader = new StreamReader(fileName);
            var text =reader.ReadToEnd();
            return text;
        }

        /// <summary>
        /// Проверяет, является ли массив пустым или равным null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsArrayEmpty(int[] value)
        {
            return value == null || value.Length == 0;
        }
    }
}