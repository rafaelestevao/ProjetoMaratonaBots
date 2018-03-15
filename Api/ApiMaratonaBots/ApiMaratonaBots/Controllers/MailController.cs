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
    [Route("api/mail")]
    public class MailController : Controller
    {
        [HttpPost]
        [Route("sendmail")]
        public JsonResult Post([FromBody]MailModel value)
        {
            //string key = 

            if (SendMail._SendMail(value))
                return Json("Email enviado com sucesso!");
            else
                return Json("Erro ao enviar email.");
        }
        
    }
}
