using Conversor.Shared.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conversor.Shared.ObjetoResultado
{
    public class ObjetoResultado : IComandoResultado
    {
        public ObjetoResultado(bool successo, string mensagem, object resultadoobtido)
        {
            Sucesso = successo;
            Mensagem = mensagem;
            ResultadoObtido = resultadoobtido;
        }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object ResultadoObtido { get; set; }
    }
}
