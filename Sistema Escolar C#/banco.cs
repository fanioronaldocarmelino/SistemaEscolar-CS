using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;
namespace SistemaEscolar
{
	class Banco
	{
		private string conexao = "Data Source=SistemaEscolar.db";
		
		private SqliteConnection CriarConexao()
		{
			return new SqliteConnection(conexao);
		}
		
		public List<Aluno> ListarAlunos()
		{
			List<Aluno> Estudantes = new List<Aluno>();
			
			SqliteConnection conexao = CriarConexao();
			
			conexao.Open();
			string sql = "SELECT * FROM ALUNOS";
			using(SqliteCommand comando = new SqliteCommand(sql, conexao))
			{
				using(SqliteDataReader leitor = comando.ExecuteReader())
				{
					while(leitor.Read())
					{
						Aluno Estudante = new Aluno();
						Estudante.ID = Convert.ToInt32(leitor["ID"]);
						Estudante.Nome = leitor["Nome"].ToString();
						Estudante.Idade = Convert.ToInt32(leitor["Idade"]);
						Estudante.Curso = leitor["Curso"].ToString();
						
						Estudantes.Add(Estudante);
					}
				}
			}
			return Estudantes;
		}
		
		public bool CadastrarAluno(Aluno aluno)
		{
			int Resultado = 0;
			using(SqliteConnection conexao = CriarConexao())
			{
				conexao.Open();
				string sql = @"INSERT INTO Alunos(Nome, Idade, Curso) VALUES(@Nome, @Idade, @Curso)";
				using(SqliteCommand comando = new SqliteCommand(sql, conexao))
				{
					comando.Parameters.AddWithValue("@Nome", aluno.Nome);
					comando.Parameters.AddWithValue("@Idade", aluno.Idade);
					comando.Parameters.AddWithValue("@Curso", aluno.Curso);
					
					Resultado = comando.ExecuteNonQuery();
					
					if(Resultado > 0)
						return true;
					else
						return false;
				}
			}
		}
		
		public Aluno PesquisarAluno(int ID)
		{
			using(SqliteConnection conexao = CriarConexao())
			{
			conexao.Open();
			Aluno aluno = new Aluno();
			
			string sql = "SELECT * FROM Alunos WHERE ID=@ID";
			using(SqliteCommand comando = new SqliteCommand(sql, conexao))
			{
				comando.Parameters.AddWithValue("@id", ID);
				
				using(SqliteDataReader leitor = comando.ExecuteReader())
				{
					if(leitor.Read())
					{
						aluno.ID = Convert.ToInt32(leitor["ID"]);
						aluno.Nome = leitor["Nome"].ToString();
						aluno.Idade = Convert.ToInt32(leitor["Idade"]);
						aluno.Curso = leitor["Curso"].ToString();
						return aluno;
					}
				}
			}
			}
			return null;
		}
		
		public void ActualizarAluno(Aluno aluno)
		{
			using(SqliteConnection conexao = CriarConexao())
			{
				conexao.Open();
				
				string sql = @"UPDATE Alunos SET Nome=@nome, Idade=@idade, Curso=@curso WHERE ID=@id";
				using(SqliteCommand comando = new SqliteCommand(sql, conexao))
				{
					comando.Parameters.AddWithValue("@nome", aluno.Nome);
					comando.Parameters.AddWithValue("@idade", aluno.Idade);
					comando.Parameters.AddWithValue("@curso", aluno.Curso);
					comando.Parameters.AddWithValue("@id", aluno.ID);
					comando.ExecuteNonQuery();
				}
			}
		}
		
		public bool ExcluirAluno (int ID)
		{
			using(SqliteConnection conexao = CriarConexao())
			{
				conexao.Open();
				
				string sql = "DELETE FROM Alunos WHERE ID=@id";
				SqliteCommand comando = new SqliteCommand(sql, conexao);
				comando.Parameters.AddWithValue("@id", ID);
				
				int linhasAlteradas = comando.ExecuteNonQuery();
				
				return linhasAlteradas > 0;
			}
		}
		
	}
}
