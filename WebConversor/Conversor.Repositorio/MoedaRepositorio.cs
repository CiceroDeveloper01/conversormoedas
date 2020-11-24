using Conversor.Dominio.DTO.Entrada;
using Conversor.Dominio.DTO.Saida;
using Conversor.Dominio.Interface;
using Conversor.Entidades;
using Conversor.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Conversor.Repositorio
{
    public class MoedaRepositorio : IRepositorio<Moedas, SaidaMoeda>
    {
        public void AtualizarMoedas()
        {
            StringBuilder comandoUpdate = new StringBuilder();
            comandoUpdate.Append("UPDATE Moedas                    ");
            comandoUpdate.Append("   SET Status = 0                ");
            comandoUpdate.Append(" WHERE Data_Criacao              ");
            comandoUpdate.Append("    IN(                          ");
            comandoUpdate.Append("        SELECT Max(Data_Criacao) ");
            comandoUpdate.Append("          FROM Moedas            ");
            comandoUpdate.Append("       )                         "); 
            using (var db = new SqlConnection(Settings.ConnectionString))
            {
                db.Execute(comandoUpdate.ToString());
            }
        }

        public List<SaidaMoeda> RetornaMoedas()
        {
            string comandoSelect ;
            comandoSelect = "SELECT Moeda, Data_Inicio, Data_Fim FROM Moedas WHERE Status = 1";
            using (var db = new SqlConnection(Settings.ConnectionString))
            {
                return db.Query<SaidaMoeda>(comandoSelect).ToList();
            }
        }

        public void Salvar(List<Moedas> entidades)
        {
            StringBuilder comandoInsert = new StringBuilder();
            comandoInsert.Append("INSERT INTO     ");
            comandoInsert.Append("Moedas(         ");
            comandoInsert.Append("  Moeda,        ");
            comandoInsert.Append("  Data_Inicio,   ");
            comandoInsert.Append("  Data_Fim,      ");
            comandoInsert.Append("  Data_Criacao,  ");
            comandoInsert.Append("  Status        ");
            comandoInsert.Append("  )             ");
            comandoInsert.Append("Values(         ");
            comandoInsert.Append("  @Moeda,       ");
            comandoInsert.Append("  @Data_Inicio,  ");
            comandoInsert.Append("  @Data_Fim,     ");
            comandoInsert.Append("  @Data_Criacao, ");
            comandoInsert.Append("  @Status       ");
            comandoInsert.Append("  )             ");
            using (var db = new SqlConnection(Settings.ConnectionString))
            {
                db.Execute(comandoInsert.ToString(), entidades);
            }
        }
    }
}
