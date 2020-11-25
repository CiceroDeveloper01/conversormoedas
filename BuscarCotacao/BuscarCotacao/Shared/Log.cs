using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuscarCotacao.Shared
{
    public static class Log
    {
        public static void WriterLog(string Processo, string Evento = "", string MensagemErro = "")
        {
            string CaminhoLog = $"{Configuracoes.CaminhoLog}\\LogOrquestrador_#data#.txt";
            string Data = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
            Processo = Data + " >> " + Processo;
            Evento = Data + " >> " + Evento;
            using (StreamWriter writer = new StreamWriter(CaminhoLog.Replace("#data#", DateTime.Now.Date.ToString("yyyyMMdd")), true))
            {
                writer.WriteLine(Processo);
                writer.WriteLine(Evento);
                if (MensagemErro != "")
                {
                    Processo = Data + " >> Processo :" + Processo;
                    Processo = Data + " >> Evento :" + Processo;
                    writer.WriteLine("##### Erro de Processamento ##################");
                    writer.WriteLine(Processo);
                    writer.WriteLine(Evento);
                    writer.WriteLine(MensagemErro);
                    writer.WriteLine("##############################################");
                }
                writer.Close();
            }
        }
    }
}
