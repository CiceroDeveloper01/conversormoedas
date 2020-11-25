using System;
using System.Collections.Generic;
using System.Text;

namespace BuscarCotacao.Entidades
{
    public class CotacoesRealizadas
    {
        public string Moeda { get; set; }
        public DateTime DataCotacao { get; set; }
        public Decimal ValorCotacao { get; set; }
    }
}
