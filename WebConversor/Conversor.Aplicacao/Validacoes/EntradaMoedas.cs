using Conversor.Shared.Command;
using System.Collections.Generic;
using FluentValidator;
using Conversor.Dominio.DTO.Entrada;

namespace Conversor.Aplicacao.Validacoes
{
    public class EntradaMoedas : Notifiable, IComandoBase
    {
        public List<EntradaMoeda> entradaMoedas { get; set; }

        public bool Valid()
        {
            for (int i = 0; i < entradaMoedas.Count; i++)
            {
                int itemLista = i + 1;
                if (string.IsNullOrEmpty(entradaMoedas[i].Moeda))
                    AddNotification("Moeda", $"O {itemLista}º item da Lista não foi informado o nome, por favor corrigir");
                
                if (entradaMoedas[i].Data_Inicio > entradaMoedas[i].Data_Fim)
                    AddNotification("Data Inicio", $"O {itemLista}º da Lista a Data Inicial: {entradaMoedas[i].Data_Inicio} está maior que a Data Final: {entradaMoedas[i].Data_Fim}, por favor corrigir");
            }
            if (Invalid)
                return false;
            
            return true;
        }
    }
}