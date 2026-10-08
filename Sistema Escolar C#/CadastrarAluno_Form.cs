using System;
using System.Drawing;
using System.Windows.Forms;
namespace SistemaEscolar
{
	class CadastrarAluno_Form : Form
	{
		Panel painelSuperior;
		Panel painelInferior;
		Panel painelCentral;
		Label titulo;
		Label informacoes;
		Label nomeAluno;
		Label idadeAluno;
		Label cursoAluno;
		Label alunoNome;	
		TextBox nomeAlunoText;
		ComboBox comboIdade;
		TextBox cursoAlunoText;
		Button btnCadastrar;
		Button voltar;
		
		public CadastrarAluno_Form()
		{
			Text = "Cadastrar Aluno";
			Size = new Size(600, 600);
			StartPosition = FormStartPosition.CenterScreen;
			BackColor = Color.FromArgb(245, 247, 250);
			
			painelSuperior = new Panel();
			painelSuperior.Dock = DockStyle.Top;
			painelSuperior.Height = 120;
			Controls.Add(painelSuperior);
			
			titulo = new Label();
			titulo.Text = "CADASTRAR ALUNO";
			titulo.Font = new Font("Arial", 14, FontStyle.Bold);
			titulo.ForeColor = Color.FromArgb(30, 58, 95);
			titulo.Height = 30;
			titulo.Width = this.ClientSize.Width;
			titulo.Top = (painelSuperior.Height - titulo.Height)/2;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			painelSuperior.Controls.Add(titulo);
			
			informacoes = new Label();
			informacoes.Text = "Informe o nome, idade e curso do novo aluno";
			informacoes.Size = new Size(this.ClientSize.Width, 20);
			informacoes.Top = painelSuperior.Height - informacoes.Height;
			informacoes.AutoSize = false;
			informacoes.Font = new Font("Arial", 10);
			informacoes.ForeColor = Color.FromArgb(30, 58, 95);
			informacoes.TextAlign = ContentAlignment.MiddleCenter;
			painelSuperior.Controls.Add(informacoes);
			
			painelCentral = new Panel();
			painelCentral.Dock = DockStyle.Fill;
			Controls.Add(painelCentral);
			
			nomeAluno = new Label();
			OrganizarLabel(nomeAluno, "Nome:", 20);
			painelCentral.Controls.Add(nomeAluno);
			
			nomeAlunoText = new TextBox();
			OrganizarTextBox(nomeAlunoText, 20);
			painelCentral.Controls.Add(nomeAlunoText);
			
			idadeAluno = new Label();
			OrganizarLabel(idadeAluno, "Idade:", 60);
			painelCentral.Controls.Add(idadeAluno);
			
			comboIdade = new ComboBox();
			comboIdade.Left = nomeAlunoText.Left;
			comboIdade.Top = idadeAluno.Top;
			comboIdade.Width = 150;
			comboIdade.Font = new Font("Arial", 10);
			comboIdade.FlatStyle = FlatStyle.Flat;
			for(int idade = 3; idade < 100; idade++){
				comboIdade.Items.Add(idade);
			}
			comboIdade.DropDownStyle = ComboBoxStyle.DropDownList;
			comboIdade.SelectedIndex = -1;
			painelCentral.Controls.Add(comboIdade);
			
			cursoAluno = new Label();
			OrganizarLabel(cursoAluno, "Curso:", 100);
			painelCentral.Controls.Add(cursoAluno);
			
			cursoAlunoText = new TextBox();
			OrganizarTextBox(cursoAlunoText, 100);
			painelCentral.Controls.Add(cursoAlunoText);
			
			alunoNome = new Label();
			
			btnCadastrar = new Button();
			btnCadastrar.Text = "Cadastrar";
			btnCadastrar.Size = new Size(120, 40);
			btnCadastrar.Left = (this.ClientSize.Width - btnCadastrar.Width)/2;
			btnCadastrar.Top = (painelCentral.Height - btnCadastrar.Height)/2;
			btnCadastrar.BackColor = Color.FromArgb(30, 58, 95);
			btnCadastrar.FlatStyle = FlatStyle.Flat;
			btnCadastrar.FlatAppearance.BorderColor = Color.FromArgb(20, 60, 130);
			painelCentral.Controls.Add(btnCadastrar);
			
			painelInferior = new Panel();
			painelInferior.Dock = DockStyle.Bottom;
			painelInferior.Width = this.ClientSize.Width;
			painelInferior.Height = 40;
			Controls.Add(painelInferior);	
			
			voltar = new Button();
			voltar.Text = "Voltar";
			voltar.Size = new Size(120, painelInferior.Height - 5);
			voltar.Left = this.ClientSize.Width - 125;
			voltar.BackColor = Color.FromArgb(30, 58, 95);
			voltar.ForeColor = Color.FromArgb(245, 247, 250);
			painelInferior.Controls.Add(voltar);
			
			btnCadastrar.MouseEnter += PassarMouse;
			btnCadastrar.MouseLeave += LeaveMouse;
			btnCadastrar.Click += btnCadastrar_Click;
			voltar.Click += voltar_Click;
			Resize += CentralizarPainel;
		}
		private void voltar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void PassarMouse(object sender, EventArgs e)
		{
			btnCadastrar.ForeColor = Color.FromArgb(30, 58, 95);
			btnCadastrar.BackColor = Color.FromArgb(0, 250, 154);
			btnCadastrar.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255);
		}
		private void LeaveMouse(object sender, EventArgs e)
		{
			btnCadastrar.ForeColor = Color.White;
			btnCadastrar.BackColor = Color.FromArgb(30, 58, 95);
			btnCadastrar.FlatAppearance.BorderColor = Color.FromArgb(20, 60, 130);
		}
		
		private void btnCadastrar_Click(object sender, EventArgs e)
		{
			Banco banco = new Banco();
			AlunoService validar = new AlunoService(banco);
			Aluno aluno = new Aluno();
			int idade = 0;
			idade = Convert.ToInt32(comboIdade.SelectedItem);

				alunoNome.Width = this.ClientSize.Width;
				alunoNome.TextAlign = ContentAlignment.MiddleCenter;
				alunoNome.Height = 40;
				alunoNome.Top = btnCadastrar.Top + alunoNome.Height + 15;
				alunoNome.Font = new Font("Arial", 10);
			
			aluno.Nome = nomeAlunoText.Text;
			aluno.Idade = idade;
			aluno.Curso = cursoAlunoText.Text;
			if(validar.ValidarNome(aluno.Nome) && validar.ValidarIdade(aluno.Idade) 
			&& validar.ValidarNome(aluno.Curso))
			{
				if(banco.CadastrarAluno(aluno))
				{
					alunoNome.Text = "Aluno "+ aluno.Nome +" cadastrado com sucesso!";
					alunoNome.ForeColor = Color.Green;
					painelCentral.Controls.Add(alunoNome);
				}
				else
				{
					alunoNome.Text = "Erro crítico ao cadastrar o aluno!";
					alunoNome.ForeColor = Color.Red;
					painelCentral.Controls.Add(alunoNome);
					return;
				}
			}
			else
			{
				alunoNome.Text = "Dados inválidos!";
				alunoNome.ForeColor = Color.Red;
				painelCentral.Controls.Add(alunoNome);
			}
		}
		private void CentralizarPainel(object sender, EventArgs e)
		{
			informacoes.Size = new Size(this.ClientSize.Width, 20);
			informacoes.TextAlign = ContentAlignment.MiddleCenter;
			
			titulo.Width = this.ClientSize.Width;
			titulo.Top = (painelSuperior.Height - titulo.Height)/2;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			
			nomeAlunoText.Width = this.ClientSize.Width * 4/5;
			comboIdade.Width = this.ClientSize.Width * 4/5;
			cursoAlunoText.Width = this.ClientSize.Width * 4/5;
			
			alunoNome.Width = this.ClientSize.Width;
			alunoNome.TextAlign = ContentAlignment.MiddleCenter;
			voltar.Left = this.ClientSize.Width - 125;
			
			btnCadastrar.Left = (this.ClientSize.Width - btnCadastrar.Width)/2;
			comboIdade.Width = 150;
		}
		private void OrganizarLabel(Label label, string texto, int top)
		{
			label.Text = texto;
			label.Font = new Font("Arial", 12, FontStyle.Bold);
			label.Height = 20;
			label.Width = 55;
			label.Top = painelSuperior.Height + top;
			label.Left = 20;
			label.ForeColor = Color.FromArgb(30, 58, 95);
		}
		private void OrganizarTextBox(TextBox box, int top)
		{
			box.Font = new Font("Arial", 11);
			box.Height = 20;
			box.Width = this.ClientSize.Width * 4/5;
			box.Top = painelSuperior.Height + top;
			box.Left = 20 + 55 + 10;
		}
		
	}
}
