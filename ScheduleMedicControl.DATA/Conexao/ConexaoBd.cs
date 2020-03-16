using MySql.Data.MySqlClient;
using System;
using System.Web.Configuration;

namespace ScheduleMedicControl.DATA.Conexao
{
    public class ConexaoBd
    {
        protected MySqlConnection Con;

        protected MySqlCommand Cmd;

        protected MySqlDataReader Dr;
        protected void AbrirConexao()
        {
            try
            {
                Con = new MySqlConnection(WebConfigurationManager.ConnectionStrings["controleagendamento"].ConnectionString);
                Con.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir a conexão: " + e.Message);
            }
        }
        protected void FecharConexao()
        {
            try
            {
                if (Con != null)
                {
                    Con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao fechar a conexão: " + e.Message);
            }
        }
    }
}
