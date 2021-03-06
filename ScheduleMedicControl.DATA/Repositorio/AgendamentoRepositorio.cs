﻿using MySql.Data.MySqlClient;
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
                                agendamentoClinicaId = @agendamentoClinicaId, agendamentoClienteId = @agendamentoClienteId
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
                var sql = $"delete from agendamento where agendamentoId = @agendamentoId";
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
                var clinica = new Clinica();
                var cliente = new Cliente();

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
                            agendamento.Cliente = new Cliente()
                            {
                                Id = (int)leitor["clienteId"],
                                Nome = leitor["clienteNome"].ToString(),
                                Cpf = leitor["clienteCpf"].ToString(),
                                Email = leitor["clienteEmail"].ToString(),
                                NomeConvenio = leitor["clienteNomeConvenio"].ToString(),
                                NumeroConvenio = leitor["clienteNumeroConvenio"].ToString(),
                                Telefone = leitor["clienteTelefone"].ToString(),
                                TemConvenio = (bool)leitor["clienteTemConvenio"],
                            };
                            agendamento.Clinica = new Clinica()
                            {
                                Id = (int)leitor["clinicaId"],
                                Nome = leitor["clinicaNome"].ToString(),
                                CNPJ = leitor["clinicaCnpj"].ToString(),
                                Telefone = leitor["clinicaTelefone"].ToString(),
                                Endereco = leitor["clinicaEndereco"].ToString(),
                            };
                            agendamento.SituacaoAgendamento = EnumeradorSituacaoAgendamento.ObtenhaPorId<EnumeradorSituacaoAgendamento>((int)leitor["agendamentoSituacao"]);
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
                                Cliente = new Cliente
                                {
                                    Id = (int)leitor["clienteId"],
                                    Nome = leitor["clienteNome"].ToString()
                                },
                                Clinica = new Clinica
                                {
                                    Id = (int)leitor["clinicaId"],
                                    Nome = leitor["clinicaNome"].ToString()
                                },
                                SituacaoAgendamento = EnumeradorSituacaoAgendamento.ObtenhaPorId<EnumeradorSituacaoAgendamento>((int)leitor["agendamentoSituacao"])
                            };
                            agendamentos.Add(agendamento);
                            agendamento.Agendamentos = agendamentos;
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
