using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conversor.Aplicacao.Handler;
using Conversor.Aplicacao.Validacoes;
using Conversor.Dominio.DTO.Entrada;
using Conversor.Dominio.DTO.Saida;
using Conversor.Dominio.Interface;
using Conversor.Entidades;
using Conversor.Shared.Enums;
using Conversor.Shared.ObjetoResultado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebConversor.Controller
{
    [ApiController]
    public class MoedaController : ControllerBase
    {
        private readonly IRepositorio<Moedas, SaidaMoeda> _repositorioMoeda;
        private readonly MoedaHandler _moedaHandler;
        public MoedaController(IRepositorio<Moedas, SaidaMoeda> repositorioMoeda, MoedaHandler moedaHandler)
        {
            _repositorioMoeda = repositorioMoeda;
            _moedaHandler = moedaHandler;
        }

        [HttpPost]
        [Route("v1/AddItemFila")]
        public IActionResult Post([FromBody]EntradaMoedas entradaMoedas)
        {
            try
            {
                var result = (ObjetoResultado)_moedaHandler.Handle(entradaMoedas);
                if (result.Sucesso)
                    return Ok(result);
                else
                    return StatusCode((int)ERetornoApi.NotAcceptable, result);
            }
            catch (Exception ex)
            {
                var comandoResultadoError = new ObjetoResultado(false, "Sistema temporáriamente fora do ar", new { ErroInterno = "Tente Novamente Mais Tarde" });
                return StatusCode((int)ERetornoApi.InternalServerError, comandoResultadoError);
            }
        }

        [HttpGet]
        [Route("v1/GetItemFila")]
        public IActionResult Get()
        {
            try
            {
                var lista = _repositorioMoeda.RetornaMoedas();
                if (lista.Count > 0)
                {
                    _repositorioMoeda.AtualizarMoedas();
                    return Ok(lista);
                }
                else
                {
                    var comandoResultadoSemDados = new ObjetoResultado(false, "Não foram localizados registros", null);
                    return StatusCode((int)ERetornoApi.NotFind, comandoResultadoSemDados);
                }
            }
            catch (Exception ex)
            {
                var comandoResultadoError = new ObjetoResultado(false, "Sistema temporáriamente fora do ar", new { ErroInterno = "Tente Novamente Mais Tarde" });
                return StatusCode((int)ERetornoApi.InternalServerError, comandoResultadoError);
            }
        }



    }
}