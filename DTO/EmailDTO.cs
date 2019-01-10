using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Email.DTO
{
    public class EmailDTO
    {

        public EmailDTO()
        {
            destinatarios = new List<string>();
            anexos = new List<string>();
        }

        /// <summary>
        /// Emails do destinatario
        /// </summary>
        public List<string> destinatarios { get; set; }

        /// <summary>
        /// Assunto do email
        /// </summary>
        public string assunto { get; set; }

        /// <summary>
        /// Html do corpo do email
        /// </summary>
        public string html { get; set; }

        public List<string> anexos { get; set; }
    }
}
