using MySql.Data.MySqlClient;
using ScheduleMedicControl.Business;
using ScheduleMedicControl.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.DATA.Repositorio
{
    public class AgendamentoRepositorio : RepositorioAbstrato<Agendamento, int>
    {
        public override void Atualiza(Agendamento agendamento)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                string sql = $@"update agendamento set agendamentoSituacao = @agendamentoSituacao, agendamentoData = @agendamentoData,
                                agendamentoClinicaId = @agendamentoClinicaId, agendamentoClienteId = @agendamentoClienteId,
                                where agendamentoId = {agendamento.Id}";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@agendamentoSituacao", agendamento.Situacao);
                cmd.Parameters.AddWithValue("@agendamentoData", agendamento.Data);
                cmd.Parameters.AddWithValue("@agendamentoClinicaId", agendamento.ClinicaId);
                cmd.Parameters.AddWithValue("@agendamentoClienteId", agendamento.ClienteId);

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

        public override void Delete(Agendamento entidade)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = $"delete from cliente where agendamentoId = @agendamentoId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@agendamentoId", entidade.Id);
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
                var sql = $"delete from agendamento where agendamentoId = @agendamentoId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@agendamentoId", id);
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

        public override void Insira(Agendamento agendamento)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = @"insert into agendamento(agendamentoSituacao,agendamentoData,agendamentoClinicaId,agendamentoClienteId)
                            values(@agendamentoSituacao,@agendamentoData,@agendamentoClinicaId,@agendamentoClienteId)";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@agendamentoSituacao", agendamento.Situacao);
                cmd.Parameters.AddWithValue("@agendamentoData", agendamento.Data);
                cmd.Parameters.AddWithValue("@agendamentoClinicaId", agendamento.ClinicaId);
                cmd.Parameters.AddWithValue("@agendamentoClienteId", agendamento.ClienteId);

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

        public override Agendamento ObtenhaPeloId(int id)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = @"select * from agendamento
                         inner join cliente on clienteId = agendamentoClienteId
                         inner join clinica on clinicaId = agendamentoClinicaId
                         where agendamentoId = @agendamentoId
                         order by agendamentoId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@agendamentoId", id);

                var agendamento = new Agendamento();

                try
                {
                    con.Open();
                    using (var leitor = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (leitor.Read())
                        {
                            agendamento.Id = (int)leitor["agendamentoId"];
                            agendamento.Situacao = (int)leitor["agendamentoSituacao"];
                            agendamento.Data = (DateTime)leitor["agendamentoData"];
                            agendamento.ClienteId = (int)leitor["clienteId"];
                            agendamento.ClinicaId = (int)leitor["clinicaId"];
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return agendamento;
            }
        }

        public override List<Agendamento> ObtenhaTodos()
        {
            var sql = $@"select * from agendamento
                         inner join cliente on clienteId = agendamentoClienteId
                         inner join clinica on clinicaId = agendamentoClinicaId
                         order by agendamentoId";

            using (var con = new MySqlConnection(StringConnection))
            {
                var cmd = new MySqlCommand(sql, con);
                var agendamentos = new List<Agendamento>();

                try
                {
                    con.Open();
                    using (var leitor = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (leitor.Read())
                        {
                            var agendamento = new Agendamento
                            {
                                Id = (int)leitor["agendamentoId"],
                                Data = (DateTime)leitor["agendamentoData"],
                                Situacao = (int)leitor["agendamentoSituacao"],
                                ClienteId = (int)leitor["clienteId"],
                                ClinicaId = (int)leitor["clinicaId"],
                            };
                            agendamentos.Add(agendamento);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return agendamentos;
            }
        }
    }
}
