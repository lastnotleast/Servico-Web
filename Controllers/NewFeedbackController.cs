using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service.Email.DTO;
using Service.Email.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Email.Controllers
{
    [Route("[controller]")]
    public class NewFeedbackController : BaseController
    {
        private readonly ViewRender view;
        private readonly AppSettings _appSettings;

        public NewFeedbackController(ViewRender view, IOptions<AppSettings> appSettings)
        {
            this.view = view;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult Post(string destinatario, NewFeedback model)
        {
            try
            {
                EmailDTO emailDTO = new EmailDTO();

                if (string.IsNullOrEmpty(model.mensagem))
                    throw new Exception("Informe a mensagem do feedback");

                if (string.IsNullOrEmpty(model.assunto))
                    throw new Exception("Informe o assunto do feedback");

                if (string.IsNullOrEmpty(model.nomeUsuario))
                    throw new Exception("Informe o nome do usuário");

                if (model.dataHoraInclusao == null)
                    throw new Exception("Informe a data de inclusão do feedback");

                emailDTO.html = this.view.Render("NewFeedback/Index", model);

                emailDTO.assunto = "Feedback";
                emailDTO.destinatarios.Add(destinatario);

                EnviarEmail(emailDTO, _appSettings);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
