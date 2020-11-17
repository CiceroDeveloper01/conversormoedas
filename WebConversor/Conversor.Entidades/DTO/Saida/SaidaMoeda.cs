using System;
using System.Collections.Generic;
using System.Text;

namespace Conversor.Dominio.DTO.Saida
{
    public class SaidaMoeda
    {
        public string Moeda { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }
    }
}
