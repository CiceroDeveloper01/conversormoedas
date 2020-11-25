using System;

namespace Conversor.Dominio.DTO.Entrada
{  
    public class EntradaMoeda
    {
        public string Moeda { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }
    }
}
