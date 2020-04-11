using MySql.Data.MySqlClient;
using ScheduleMedicControl.Business.Models;
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
                string sql = $@"update cliente set clienteNome = @clienteNome, clienteTelefone = @clienteTelefone,
                                clienteCpf = @clienteCpf, clienteEmail = @clienteEmail, clienteTemConvenio = @clienteTemconvenio,
                                clienteNumeroConvenio = @clienteNumeroConvenio, clienteNomeConvenio = @clienteNomeConvenio
                                where clienteId = {cliente.Id}";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clienteNome", cliente.Nome);
                cmd.Parameters.AddWithValue("@clienteTelefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@clienteCpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@clienteEmail", cliente.Email);
                cmd.Parameters.AddWithValue("@clienteTemConvenio", cliente.TemConvenio);
                cmd.Parameters.AddWithValue("@clienteNumeroConvenio", cliente.NumeroConvenio);
                cmd.Parameters.AddWithValue("@clienteNomeConvenio", cliente.NomeConvenio);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void Delete(Cliente cliente)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = $"delete from cliente where clienteId = @clienteId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clienteId", cliente.Id);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void DeletePorId(int id)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = $"delete from cliente where clienteId = @clienteId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clienteId", id);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override Cliente ObtenhaPeloId(int id)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = "select * from cliente where clienteId = @clienteId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clienteId", id);

                var cliente = new Cliente();

                try
                {
                    con.Open();
                    using (var leitor = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (leitor.Read())
                        {
                            cliente.Id = (int)leitor["clienteId"];
                            cliente.Nome = leitor["clienteNome"].ToString();
                            cliente.Cpf = leitor["clienteCpf"].ToString();
                            cliente.Email = leitor["clienteEmail"].ToString();
                            cliente.NomeConvenio = leitor["clienteNomeConvenio"].ToString();
                            cliente.NumeroConvenio = leitor["clienteNumeroConvenio"].ToString();
                            cliente.Telefone = leitor["clienteTelefone"].ToString();
                            cliente.TemConvenio = (bool)leitor["clienteTemConvenio"];
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return cliente;
            }
        }

        public override List<Cliente> ObtenhaTodos()
        {
            var sql = "select * from cliente order by clienteNome";

            using (var con = new MySqlConnection(StringConnection))
            {
                var cmd = new MySqlCommand(sql, con);
                var clientes = new List<Cliente>();

                try
                {
                    con.Open();
                    using (var leitor = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (leitor.Read())
                        {
                            var cliente = new Cliente
                            {
                                Id = (int)leitor["clienteId"],
                                Nome = leitor["clienteNome"].ToString(),
                                Cpf = leitor["clienteCpf"].ToString(),
                                Email = leitor["clienteEmail"].ToString(),
                                NomeConvenio = leitor["clienteNomeConvenio"].ToString(),
                                NumeroConvenio = leitor["clienteNumeroConvenio"].ToString(),
                                Telefone = leitor["clienteTelefone"].ToString(),
                                TemConvenio = (bool)leitor["clienteTemConvenio"]
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return clientes;
            }
        }

        public override void Insira(Cliente cliente)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = @"insert into cliente(clienteNome,clienteTelefone,clienteCpf,clienteEmail,clienteTemConvenio,
                            clienteNumeroConvenio,clienteNomeConvenio) values(@clienteNome,@clienteTelefone,
                            @clienteCpf,@clienteEmail,@clienteTemConvenio,@clienteNumeroConvenio,@clienteNomeConvenio)";

                var cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@clienteNome", cliente.Nome);
                cmd.Parameters.AddWithValue("@clienteTelefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@clienteCpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@clienteEmail", cliente.Email);
                cmd.Parameters.AddWithValue("@clienteTemConvenio", cliente.TemConvenio);
                cmd.Parameters.AddWithValue("@clienteNumeroConvenio", cliente.NumeroConvenio);
                cmd.Parameters.AddWithValue("@clienteNomeConvenio", cliente.NomeConvenio);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
    }
}
