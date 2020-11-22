using System;

namespace Conversor.Entidades
{
    public class Moedas
    {
        public string Moeda { get; private set; }
        public DateTime Data_Inicio { get; private set; }
        public DateTime Data_Fim { get; private set; }
        public DateTime Data_Criacao { get; private set; }

        public Moedas(string moeda, DateTime data_inicio, DateTime data_fim, DateTime data_criacao)
        {
            Moeda = moeda;
            Data_Inicio = data_inicio;
            Data_Fim = data_fim;
            Data_Criacao = data_criacao;
        }
    }
}



