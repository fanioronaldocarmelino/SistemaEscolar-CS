using System;
using System.Collections.Generic;
using static System.Console;
namespace SistemaEscolar
{
	class AlunoService
	{
		private Banco banco;
		
		public AlunoService(Banco banco)
		{
			this.banco = banco;
		}
		
		public bool ValidarNome(string nome)
		{
			if(string.IsNullOrWhiteSpace(nome)){
				return false;
			}
			return true;
		}
		
		public bool ValidarIdade(int idade)
		{
			if(idade < 3 || idade > 120){
				return false;
			}
			return true;
		}
		
		/*public void CadastrarAluno(string nome, int idade, string curso)
		{
			if(!(ValidarNome(nome)) || !ValidarIdade(idade) || !ValidarNome(curso))
				return;
			
			Aluno aluno = new Aluno();
			aluno.Nome = nome;
			aluno.Idade = idade;
			aluno.Curso = curso;
			banco.CadastrarAluno(aluno);
		}
		*/
		public void ListarAlunos()
		{
			List<Aluno> listaDeAlunos = banco.ListarAlunos();
			ForegroundColor = ConsoleColor.White;
			foreach(Aluno estudante in listaDeAlunos){
				WriteLine($"{estudante.ID} -> {estudante.Nome} -> {estudante.Idade}anos -> {estudante.Curso}");
			}
			WriteLine("Prima [ENTER] para voltar");
			ReadLine();
			ResetColor();
		}
		
		public void PesquisarAluno(int ID)
		{
			Aluno aluno = banco.PesquisarAluno(ID);
			if(aluno == null){
				WriteLine("Aluno não encontrado!");
				return;
			}
			WriteLine($"{aluno.Nome} -> {aluno.Idade}anos -> {aluno.Curso}");
		}
		
		public bool ActualizarAluno(Aluno aluno)
		{
			if(!ValidarNome(aluno.Nome) || !ValidarIdade(aluno.Idade) || !ValidarNome(aluno.Curso)){
				return false;
			} 
			else{
				banco.ActualizarAluno(aluno);
				return true;
			}
		}
		
		public void ExcluirAluno(int ID){
			bool alunoExcluido = banco.ExcluirAluno(ID);
			if(alunoExcluido)
				WriteLine("Aluno excluido com sucesso!");
			else
				WriteLine("Aluno não excluido!");
		}
	}
}
