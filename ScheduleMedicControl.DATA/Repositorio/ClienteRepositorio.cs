using MySql.Data.MySqlClient;
using ScheduleMedicControl.Business.Models;
using ScheduleMedicControl.DATA.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.DATA.Repositorio
{
    public class ClienteRepositorio : RepositorioAbstrato<Cliente, int>
    {
        public override void Atualiza(Cliente cliente)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                string sql = "update cliente "
            }
        }

        public override void Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public override void DeletePorId(int id)
        {
            throw new NotImplementedException();
        }

        public override Cliente ObtenhaPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> ObtenhaTodos()
        {
            throw new NotImplementedException();
        }

        public override void Salva(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
