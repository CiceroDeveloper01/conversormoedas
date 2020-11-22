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
                if (string.IsNullOrEmpty(entradaMoedas[i].Moeda))
                    AddNotification("Moeda", $"A {i++}º da Lista não foi informado, por favor informar");
                else if (entradaMoedas[i].Data_Inicio > entradaMoedas[i].Data_Fim)
                    AddNotification("Data Inicio", $"A {i++}º da Lista a Data Inicial: {entradaMoedas[i].Data_Inicio} está maior que a Data Final: {entradaMoedas[i].Data_Fim}, por favor corrigir");
            }
            if (Invalid)
                return false;
            
            return true;
        }
    }
}