using Ovotan.EndPointManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Ovotan.Shell.RabbitMQ.Models
{
    public class ConnectionListItem
    {
        /// <summary>
        /// get,set - Подробна информация о клиенте создавшего подключение.
        /// </summary>
        public ConnectionClientProperties ClientProperties { get; set; }

        /// <summary>
        /// get - Название соединения (ip:port)
        /// </summary>
        [JsonIgnore]
        [DataGridDocument(displayName:"Name")]
        public string PeerName
        {
            get
            {
                return $"{PeerHost}:{PeerPort}";
            }
        }

        /// <summary>
        /// get,set - Логин пользователя.
        /// </summary>
        [DataGridDocument(displayName: "User name")]
        public string User { get; set; }

        /// <summary>
        /// get,set - Статус подключения.
        /// </summary>
        public ConnectionState State { get; set; }

        /// <summary>
        /// get,set - Прокотол соединения.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// get,set - Количество открытых каналов в подключении.
        /// </summary>
        public int Channels { get; set; }
        /// <summary>
        /// get,set - Максимально доступное каналов подключении.
        /// </summary>
        [DataGridDocument(displayName: "Channel Max")]
        public int ChannelMax { get; set; }

        /// <summary>
        /// get, set - Размер в байтах максимально допустимого кадра для соединения. 0 означает отсутствие ограничений.
        /// </summary>
        /// <remarks>
        [DataGridDocument(displayName: "Frame Max")]
        public int FrameMax { get; set; }

        /// <summary>
        /// Механизм авторизатиции.
        /// </summary>
        [JsonPropertyName("auth_mechanism")]
        [DataGridDocument(displayName: "SASL auth mechanismSASL")]
        public string auth_mechanism { get; set; }

        /// <summary>
        /// get - Сердцебиение.
        /// </summary>
        [JsonIgnore]
        [DataGridDocument(displayName:"Heartbeat")]
        public string FullTimeout
        {
            get
            {
                return $"{Timeout}s";
            }
        }

        /// <summary>
        /// get,set - Дата подключения.
        /// </summary>
        public DateTime ConnectedAt { get; set; }




        public int Timeout { get; set; }

        public int PeerPort { get; set; }

        public string PeerHost { get; set; }



        /// <summary>
        /// Simple Authentication and Security Layer
        /// </summary>
        /// <remarks>
        /// «EXTERNAL», используется, когда аутентификация отделена от передачи данных (например, когда протоколы уже используют IPsec или TLS);
        /// «ANONYMOUS», для аутентификации гостевого доступа(RFC 4505);
        /// «PLAIN», простой механизм передачи паролей открытым текстом.PLAIN является заменой устаревшему LOGIN ;
        /// «OTP», механизм одноразовых паролей.OTP заменяет устаревший механизм SKEY;
        /// «SKEY», система одноразовых паролей(устаревший);
        /// «CRAM-MD5»;
        /// «DIGEST-MD5»;
        /// «NTLM»;
        /// «GSSAPI»;
        /// GateKeeper(& GateKeeperPassport), разработана Microsoft для MSN Chat;
        /// «KERBEROS IV» (устаревший).
        /// </remarks>



    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConnectionState
    {
        Running,
    }
}
