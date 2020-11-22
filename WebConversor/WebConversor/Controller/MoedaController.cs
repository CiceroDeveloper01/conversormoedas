using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conversor.Aplicacao.Handler;
using Conversor.Dominio.DTO.Entrada;
using Conversor.Dominio.DTO.Saida;
using Conversor.Dominio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebConversor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoedaController : ControllerBase
    {
        private readonly IRepositorio<EntradaMoeda, SaidaMoeda> _repositorioMoeda;
        private readonly MoedaHandler _moedaHandler;
        public MoedaController(IRepositorio<EntradaMoeda, SaidaMoeda> repositorioMoeda, MoedaHandler moedaHandler)
        {
            _repositorioMoeda = repositorioMoeda;
            _moedaHandler = moedaHandler;
        }


    }
}