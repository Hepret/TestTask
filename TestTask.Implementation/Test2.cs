using System;
using System.Collections.Generic;
using TestTasks;

namespace TestTask.Implementation
{
    public class Test2 : ITest2
    {
        private readonly HashSet<string> _usersHashSetCase1 = new HashSet<string>();
        private readonly HashSet<string> _serialNumbersCase2 = new HashSet<string>();
        private readonly Dictionary<string, int> _usersLoginCounterCase3 = new Dictionary<string, int>();
        private readonly Queue<int> _commandsCase4 = new Queue<int>();
        private readonly Stack<string> _contextCase5 = new Stack<string>();

        /// <summary>
        /// Добавляет в систему нового пользователя
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <exception cref="ArgumentException">Выкидывает ошибку, если пользователь с таким именем уже зарегистрирован</exception>
        public void Case1_NotifyUserRegistered(string userName)
        {
            var result = _usersHashSetCase1.Add(userName);
            if (!result) throw new ArgumentException("This userAlreadyExist");
        }

        /// <summary>
        /// Возвращает общее число зарегистрированных пользователей
        /// </summary>
        /// <returns></returns>
        public int Case1_GetRegisteredUsersCount()
        {
            var registeredUsersCount = _usersHashSetCase1.Count;
            return registeredUsersCount;
        }
        /// <summary>
        /// Уведомить об обнаружении нового устройства 
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns></returns>
        public string Case2_NotifyMeter(string serialNumber)
        {
            var result = _serialNumbersCase2.Add(serialNumber);
            if (!result) return $"Устройство с серийным номером {serialNumber} - обнаружено";
            return $"Добавлено новое устройство с серийным номером  {serialNumber}";
        }

        /// <summary>
        /// Проверяет, обнаружено ли указанное устройство
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns>true - устройство уже есть в коллекции</returns>
        public bool Case2_MeterAlreadyExists(string serialNumber)
        {
            return _serialNumbersCase2.Contains(serialNumber);
        }

        public void Case3_NotifyUserSecurityEvent(string userName, bool userLoggedIn)
        {
            if (userLoggedIn)
            {
                // Пользователь вошел в систему
                if (_usersLoginCounterCase3.ContainsKey(userName))
                {
                    _usersLoginCounterCase3[userName]++;
                }
                else
                {
                    _usersLoginCounterCase3[userName] = 1;
                }
            }
            else
            {
                if (!_usersLoginCounterCase3.ContainsKey(userName)) return;
                _usersLoginCounterCase3[userName]--;
                if (_usersLoginCounterCase3[userName] <= 0)
                {
                    _usersLoginCounterCase3.Remove(userName);
                }
            }
        }

        public int Case3_GetUserLoggedInCount(string userName)
        {
            return _usersLoginCounterCase3.TryGetValue(userName, out var count) ? count : 0;
        }
        
        /// <summary>
        /// Уведомляет о появлении новой команды для выполнения
        /// </summary>
        /// <param name="commandCode">Код команды</param>
        /// <returns></returns>
        public void Case4_NotifyCommand(int commandCode)
        {
            _commandsCase4.Enqueue(commandCode);
        }
        // <summary>
        /// Извлекает очередную команду из принятых по правилу FIFO 
        /// (более новые команды будут извлекаться последними).
        /// Извлеченная команда попутно удаляется из коллекции.
        /// </summary>
        /// <returns>Код команды или null, если команды закончились</returns>
        public int? Case4_TryExtractNextCommand()
        {
            return _commandsCase4.Count == 0 
                ? (int?)null 
                : _commandsCase4.Dequeue();
        }

        /// <summary>
        /// Уведомляет о смене текущего контекста 
        /// </summary>
        /// <param name="contextDescription">Новый описатель текущего контекста 
        /// (не важно, что это, какое-то строковое описание текущего окружения)</param>
        public void Case5_PushContext(string contextDescription)
        {
            _contextCase5.Push(contextDescription);
        }

        /// <summary>
        /// Извлекает контекст по правилу LIFO
        /// То есть должен вернуться самый "верхний" контекст, самый свежеполученный.
        /// Извлеченный контекст попутно удаляется из коллекции
        /// </summary>
        /// <returns>Последний принятый контекст или null, если извлекать больше нечего</returns>
        public string Case5_PopContext()
        {
            return _contextCase5.Count == 0 
                ? null 
                : _contextCase5.Pop();
        }
    }
}