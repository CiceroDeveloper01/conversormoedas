using Conversor.Aplicacao.Validacoes;
using Conversor.Dominio.DTO.Entrada;
using Conversor.Dominio.DTO.Saida;
using Conversor.Dominio.Interface;
using Conversor.Entidades;
using Conversor.Shared.Command;
using Conversor.Shared.ObjetoResultado;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Conversor.Aplicacao.Handler
{
    public class MoedaHandler : Notifiable, IComando<EntradaMoedas>
    {
        private readonly IRepositorio<Moedas, SaidaMoeda> _repositorioMoeda;
        public MoedaHandler(IRepositorio<Moedas, SaidaMoeda> repositorioMoeda)
        {
            _repositorioMoeda = repositorioMoeda;
        }
        public IComandoResultado Handle(EntradaMoedas command)
        {
           if (command.Valid())
           {
                var moedasGravar = CriarListaMoedaGravar(command);
                _repositorioMoeda.Salvar(moedasGravar);
                return new ObjetoResultado(true, "Lista de Moedas Gravada Com Sucesso", null);
            }
           else
           {
                return new ObjetoResultado(false, "Não foi possível efetuar a gravação", command.Notifications);
           }
        }
        private List<Moedas> CriarListaMoedaGravar(EntradaMoedas listaentradaMoedas)
        {
            DateTime dataGravacao = DateTime.Now;
            var moedasGravar = new List<Moedas>();
            for (int i =0; i < listaentradaMoedas.entradaMoedas.Count; i++)
            {
                moedasGravar.Add(
                    new Moedas
                    (
                        listaentradaMoedas.entradaMoedas[i].Moeda,
                        listaentradaMoedas.entradaMoedas[i].Data_Inicio,
                        listaentradaMoedas.entradaMoedas[i].Data_Fim,
                        dataGravacao
                    ));
            }
            return moedasGravar;
        }
    }
}