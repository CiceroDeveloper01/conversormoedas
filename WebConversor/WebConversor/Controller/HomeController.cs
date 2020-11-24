using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebConversor.Controller
{
    
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        // [Route("clientes")] // Listar todos os clientes
        // [Route("clientes/2587")] // Listar o cliente 2587
        // [Route("clientes/2587/pedidos")] // Pedidos do cliente 2587
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }

        [HttpGet]
        [Route("error")]
        public string Error()
        {
            throw new Exception("Algum erro ocorreu");
            return "erro";
        }
    }
}