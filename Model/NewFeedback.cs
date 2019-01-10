using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Email.Model
{
    public class NewFeedback
    {
        public string nomeUsuario { get; set; }

        public string assunto { get; set; }

        public string mensagem { get; set; }

        public DateTime? dataHoraInclusao { get; set; }
    }
}
