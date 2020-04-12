using MySql.Data.MySqlClient;
using ScheduleMedicControl.Business;
using ScheduleMedicControl.Business.Models;
using System;
using System.Collections.Generic;

namespace ScheduleMedicControl.DATA.Repositorio
{
    public class ClinicaRepositorio : RepositorioAbstrato<Clinica, int>
    {
        public override void Atualiza(Clinica clinica)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                string sql = $@"update clinica set clinicaNome = @clinicaNome, clinicaCnpj = @clinicaCnpj,
                                clinicaTelefone = @clinicaTelefone, clinicaEndereco = @clinicaEndereco where clinicaId = {clinica.Id}";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clinicaNome", clinica.Nome);
                cmd.Parameters.AddWithValue("@clinicaCnpj", clinica.CNPJ);
                cmd.Parameters.AddWithValue("@clinicaTelefone", clinica.Telefone);
                cmd.Parameters.AddWithValue("@clinicaEndereco", clinica.Endereco);

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

        public void AtualizaQuantidadeDeVagas(int clinicaId, int vagas)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                string sql = $@"update clinica set clinicaVagas = @clinicaVagas where clinicaId = {clinicaId}";



                var cmd = new MySqlCommand(sql, con);

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


        public override void Delete(Clinica clinica)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = $"delete from clinica where clinicaId = @clinicaId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clinicaId", clinica.Id);
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
                var sql = $"delete from clinica where clinicaId = @clinicaId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clinicaId", id);
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

        public override Clinica ObtenhaPeloId(int id)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = "select * from clinica where clinicaId = @clinicaId";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clinicaId", id);

                var clinica = new Clinica();

                try
                {
                    con.Open();
                    using (var leitor = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (leitor.Read())
                        {
                            clinica.Nome = leitor["clinicaNome"].ToString();
                            clinica.CNPJ = leitor["clinicaCnpj"].ToString();
                            clinica.Telefone = leitor["clinicaTelefone"].ToString();
                            clinica.Endereco = leitor["clinicaEndereco"].ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return clinica;
            }
        }

        public override List<Clinica> ObtenhaTodos()
        {
            var sql = @"select * from clinica order by clinicaNome";

            using (var con = new MySqlConnection(StringConnection))
            {
                var cmd = new MySqlCommand(sql, con);
                var clinicas = new List<Clinica>();

                try
                {
                    con.Open();
                    using (var leitor = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (leitor.Read())
                        {
                            var clinica = new Clinica
                            {
                                Id = (int)leitor["clinicaId"],
                                Nome = leitor["clinicaNome"].ToString(),
                                CNPJ = leitor["clinicaCnpj"].ToString(),
                                Telefone = leitor["clinicaTelefone"].ToString(),
                                Endereco = leitor["clinicaEndereco"].ToString(),
                            };
                            clinicas.Add(clinica);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return clinicas;
            }
        }

        public override void Insira(Clinica clinica)
        {
            using (var con = new MySqlConnection(StringConnection))
            {
                var sql = @"insert into clinica(clinicaNome,clinicaCnpj,clinicaTelefone,clinicaEndereco) values(@clinicaNome,@clinicaCnpj,
                            @clinicaTelefone,@clinicaEndereco)";

                var cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@clinicaNome", clinica.Nome);
                cmd.Parameters.AddWithValue("@clinicaTelefone", clinica.Telefone);
                cmd.Parameters.AddWithValue("@clinicaCnpj", clinica.CNPJ);
                cmd.Parameters.AddWithValue("@clinicaEndereco", clinica.Endereco);

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
