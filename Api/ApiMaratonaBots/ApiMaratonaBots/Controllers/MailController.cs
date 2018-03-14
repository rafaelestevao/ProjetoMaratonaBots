using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiMaratonaBots.Models;
using ApiMaratonaBots.Repository;

namespace ApiMaratonaBots.Controllers
{
    [Produces("application/json")]
    [Route("api/Mail")]
    public class MailController : Controller
    {
        // GET: api/Mail
        [HttpPost]
        public string Send([FromBody]MailModel value)
        {
            if (SendMail._SendMail(value))
                return "Email enviado com sucesso!";
            else
                return "Erro ao enviar email.";
        }
        
    }
}
