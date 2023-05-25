﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks
{
    /// <summary>
    /// Тест на навыки работы с состояниями (конечные автоматы)
    /// Предположим, есть модем, который умеет по команде дозваниваться до нужного номера, 
    /// в случае успешного дозвона позволяет обмениваться с удаленным устройством данными, 
    /// а также обрывает соединение по команде, когда соединение больше не требуется.
    ///
    /// Необходимо реализовать логику выдачи команд модему таким образом, чтобы "выполнился" успешный 
    /// опрос устройства. Успешным считаетя опрос, при котором:
    /// - модем был настроен;
    /// - модем набрал номер;
    /// - произошла серия обменов запрос-ответ с устройством (пусть это будет серия из 5 успешных пар запрос-ответ;
    /// - модем положил трубку по команде.
    /// 
    /// Следует учесть, что:
    /// - номер может не набраться;
    /// - установленное соединение может разорваться;
    /// - модем может зависнуть и не набирать номер, отвечая ошибкой, в этом случае поможет только перезагрузка модема 
    /// (на команду перезагрузки модем отреагирует всегда)
    /// 
    /// Перед самым первым вызовом модем бездействует, трубка положена.
    /// Все вызовы выполняются в одном потоке.
    /// </summary>
    public interface ITest9
    {
        /// <summary>
        /// Дать очередную команду модему
        /// </summary>
        /// <returns></returns>
        ModemCommand GetModemCommand();

        /// <summary>
        /// Получить ответ со стороны модема
        /// </summary>
        /// <param name="answer"></param>
        void NotifyModemAnswer(ModemAnswer answer);
    }

    /// <summary>
    /// Команды, отдаваемые модему
    /// </summary>
    public enum ModemCommand
    {
        /// <summary>
        /// Отправить модем в перезагрузку. 
        /// Команда применяется, когда не удалось набрать номер более 5 раз подряд из-за ошибки
        /// (случай, когда линия абонента занята, ошибкой не является!)
        /// </summary>
        Restart,

        /// <summary>
        /// Выполнить настройку модема.
        /// Обязательна при первом использовании и после перезагрузки модема.
        /// </summary>
        Setup,

        /// <summary>
        /// Набрать номер
        /// </summary>
        Call,

        /// <summary>
        /// Отправить запрос к устройству
        /// </summary>
        SendRequest,

        /// <summary>
        /// Повесить трубку
        /// </summary>
        HangUp
    }

    /// <summary>
    /// Варианты ответа от модема
    /// </summary>
    public enum ModemAnswer
    {
        /// <summary>
        /// Команда успешно выполнена
        /// </summary>
        Ok,

        /// <summary>
        /// Не удалось набрать номер, т.к. линия абонента занята
        /// (вероятно, устройство опрашивается кем-то другим)
        /// </summary>
        Buzy,

        /// <summary>
        /// Пришел ответ от устройства
        /// </summary>
        Response,

        /// <summary>
        /// Произошел сбой (не выполнилась команда или произошел разрыв соединения)
        /// </summary>
        Error
    }
}