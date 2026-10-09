using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
namespace SistemaEscolar
{
	class PesquisarAluno_Form : Form
	{
		Panel painelSuperior;
		Panel painelInfeiror;
		Panel painelCentral;
		TextBox caixaDePesquisa;
		Button botaoPesquisar;
		Button botaoVoltar;
		Label titulo;
		Label resultadoNome;
		Label resultadoIdade;
		Label resultadoCurso;
		
		public PesquisarAluno_Form()
		{
			Text = "Pesquisar Aluno";
			Size = new Size(600, 500);
			StartPosition = FormStartPosition.CenterScreen;
			BackColor = Color.FromArgb(245, 247, 250);
			
			painelSuperior = new Panel();
			painelSuperior.Dock = DockStyle.Top;
			painelSuperior.Height = 100;
			Controls.Add(painelSuperior);
			
			caixaDePesquisa = new TextBox();
			caixaDePesquisa.Top = 70;
			caixaDePesquisa.Width = 400;
			caixaDePesquisa.Height = 30;
			caixaDePesquisa.Left = (((this.ClientSize.Width - caixaDePesquisa.Width)/2) - 70);
			painelSuperior.Controls.Add(caixaDePesquisa);
			
			botaoPesquisar = new Button();
			botaoPesquisar.Text = "Pesquisar";
			botaoPesquisar.Top = 68;
			botaoPesquisar.Height = 30;
			botaoPesquisar.Width = 120;
			botaoPesquisar.Left = caixaDePesquisa.Left + caixaDePesquisa.Width + 20;
			botaoPesquisar.FlatStyle = FlatStyle.Flat;
			botaoPesquisar.BackColor = Color.FromArgb(37, 99, 235);
			botaoPesquisar.ForeColor = Color.FromArgb(255, 255, 255);
			botaoPesquisar.FlatAppearance.BorderColor = Color.FromArgb(20, 60, 130);
			painelSuperior.Controls.Add(botaoPesquisar);
			
			titulo = new Label();
			titulo.Text = "Digite o ID do estudante que deseja pesquisar";
			titulo.Font = new Font("Arial", 12);
			titulo.Top = 40;
			titulo.Width = this.ClientSize.Width;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			titulo.AutoSize = false;
			titulo.ForeColor = Color.FromArgb(30, 58, 95);
			painelSuperior.Controls.Add(titulo);
			
			painelInfeiror = new Panel();
			painelInfeiror.Dock = DockStyle.Bottom;
			painelInfeiror.BackColor = Color.FromArgb(215, 217, 220);
			painelInfeiror.Height = 40;
			Controls.Add(painelInfeiror);
			
			botaoVoltar = new Button();
			botaoVoltar.Text = "Voltar";
			botaoVoltar.Width = 120;
			botaoVoltar.Height = painelInfeiror.Height - 5;
			botaoVoltar.Left = this.ClientSize.Width - 140;
			botaoVoltar.BackColor = Color.FromArgb(30, 58, 95);
			botaoVoltar.ForeColor = Color.FromArgb(245, 247, 250);
			painelInfeiror.Controls.Add(botaoVoltar);
			
			painelCentral = new Panel();
			painelCentral.Height = painelSuperior.Height - painelInfeiror.Height;
			painelCentral.Dock = DockStyle.Fill;
			Controls.Add(painelCentral);
			
			Resize += CentralizarPesquisarAluno;
			botaoPesquisar.Click += PesquisarAluno_Click;
			botaoVoltar.Click += BotaoVoltar_Click;
		}
		private void CentralizarPesquisarAluno(object sender, EventArgs e)
		{
			titulo.Width = this.ClientSize.Width;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			caixaDePesquisa.Left = (((this.ClientSize.Width - caixaDePesquisa.Width)/2) - 70);
			botaoPesquisar.Left = caixaDePesquisa.Left + caixaDePesquisa.Width + 20;
			botaoVoltar.Left = this.ClientSize.Width - 140;
		}
		private void PesquisarAluno_Click(object sender, EventArgs e)
		{
			painelCentral.Controls.Clear();
			int ID = -1;
			int.TryParse(caixaDePesquisa.Text, out ID);
			
			Banco banco = new Banco();
			Aluno aluno = new Aluno();
			aluno = banco.PesquisarAluno(ID);
			
			if(aluno == null){
				Label alunoNaoEncontrado = new Label();
				alunoNaoEncontrado.Text = "Aluno não encontrado!";
				alunoNaoEncontrado.Width = 110;
				alunoNaoEncontrado.Height = 20;
				alunoNaoEncontrado.ForeColor = Color.Red;
				alunoNaoEncontrado.Left = (this.ClientSize.Width - alunoNaoEncontrado.Width)/2;
				alunoNaoEncontrado.Top = (this.painelCentral.ClientSize.Height - alunoNaoEncontrado.Height)/2;
				painelCentral.Controls.Add(alunoNaoEncontrado);
			}
			else{
				resultadoNome = new Label();
				resultadoNome.Text = "Aluno(a): "+ aluno.Nome;
				AlinharResultados(resultadoNome, 200);
				painelCentral.Controls.Add(resultadoNome);
				
				resultadoIdade = new Label();
				resultadoIdade.Text = "Idade: "+ aluno.Idade.ToString();
				AlinharResultados(resultadoIdade, 240);
				painelCentral.Controls.Add(resultadoIdade);
				
				resultadoCurso = new Label();
				resultadoCurso.Text = "Curso: "+ aluno.Curso;
				AlinharResultados(resultadoCurso, 280);
				painelCentral.Controls.Add(resultadoCurso);
			}
		}
		
		private void AlinharResultados(Label resultado, int top)
		{			
			resultado.Width = 200;
			resultado.Height = 20;
			resultado.Top = top;
			resultado.Left = 50;
			resultado.Font = new Font("Arial", 10, FontStyle.Bold);
			resultado.ForeColor = Color.FromArgb(30, 58, 95);
		}
		
		private void BotaoVoltar_Click (object sender, EventArgs e)
		{
			this.Close();
		}
	
	}
}
