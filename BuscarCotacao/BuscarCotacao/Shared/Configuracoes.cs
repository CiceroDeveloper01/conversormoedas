using System;
using System.Collections.Generic;
using System.Text;

namespace BuscarCotacao.Shared
{
    public static class Configuracoes
    {
        public static string UrlApi { get; set; }
        public static string CaminhoCSVMoedasDataCotacoes { get; set; }
        public static string CaminhoCSVGravacaoResultadoCotacoes { get; set; }
        public static string CaminhoCSVMoedasValorCotaoes { get; set; }
        public static string CaminhoCSVMoedasCotacoes { get; set; }
        public static string CaminhoLog { get; set; }
        public static string NomePadraoArquivoLog { get; set; }
    }
}
