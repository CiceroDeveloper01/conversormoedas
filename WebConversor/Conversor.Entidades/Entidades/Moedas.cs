using System;

namespace Conversor.Entidades
{
    public class Moedas
    {
        public string Moeda { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }
        public DateTime Data_Criacao { get; private set; }

        public Moedas(string moeda, DateTime data_inicio, DateTime data_fim)
        {
            Moeda = moeda;
            Data_Inicio = data_inicio;
            Data_Fim = data_fim;
            Data_Criacao = DateTime.Now;
        }
    }
}



