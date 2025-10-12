using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Infrastructure.RabbitMQ
{
    public class RabbitMQSettings
    {
        /// <summary>
        /// Хост и порт подключения к RabbitMQ
        /// Пример: rabbitmq://localhost:5672
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Имя пользователя для подключения
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль для подключения
        /// </summary>
        public string Password { get; set; }

    }
}
