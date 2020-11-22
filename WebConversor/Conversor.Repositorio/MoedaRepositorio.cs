using Conversor.Dominio.DTO.Entrada;
using Conversor.Dominio.DTO.Saida;
using Conversor.Dominio.Interface;
using Conversor.Entidades;
using System;
using System.Collections.Generic;

namespace Conversor.Repositorio
{
    public class MoedaRepositorio : IRepositorio<Moedas, SaidaMoeda>
    {
        public List<SaidaMoeda> GetRetorno()
        {
            throw new NotImplementedException();
        }

        public void Salvar(List<Moedas> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
