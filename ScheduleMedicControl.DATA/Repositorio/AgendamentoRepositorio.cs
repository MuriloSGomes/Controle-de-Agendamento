using MySql.Data.MySqlClient;
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
                cmd.Parameters.AddWithValue("@agendamentoSituacao", agendamento.SituacaoAgendamento);
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
            throw new NotImplementedException();
        }

        public override void DeletePorId(int id)
        {
            throw new NotImplementedException();
        }

        public override void Insira(Agendamento agendamento)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = @"insert into agendamento(agendamentoSituacao,agendamentoData,agendamentoClinicaId,agendamentoClienteId,
                            values(@agendamentoSituacao,@agendamentoData,@agendamentoClinicaId,@agendamentoClienteId)";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@agendamentoSituacao", agendamento.SituacaoAgendamento);
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
            throw new NotImplementedException();
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
                                SituacaoAgendamento = (int)leitor["agendamentoSituacao"],
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
