using System;
using System.Windows.Forms;
using System.Drawing;
namespace SistemaEscolar
{
	class ActualizarAluno_Form : Form
	{
		Panel painelSuperior;
		Panel painelCentral;
		Panel painelInferior;
		Label titulo;
		Label resultadoDaPesquisa;
		Label resultadoFinal;
		TextBox novoNomeBox;
		ComboBox comboIdade;
		TextBox novoCursoBox;
		TextBox caixaDePesquisa;
		Button botaoPesquisar;
		Button actualizarAluno;
		Button botaoVoltar;
		int IdAluno = -1;
		
		public ActualizarAluno_Form()
		{
			Text = "Actualizar Aluno";
			this.Size = new Size(600, 500);
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
			titulo.Text = "Digite o ID do estudante que deseja Actualizar";
			titulo.Font = new Font("Arial", 12);
			titulo.Top = 40;
			titulo.Width = this.ClientSize.Width;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			titulo.AutoSize = false;
			titulo.ForeColor = Color.FromArgb(30, 58, 95);
			painelSuperior.Controls.Add(titulo);
			
			painelCentral = new Panel();
			painelCentral.Dock = DockStyle.Fill;
			painelCentral.Height = 380;
			painelCentral.Width = this.ClientSize.Width;
			Controls.Add(painelCentral);
			
			resultadoDaPesquisa = new Label();
			resultadoDaPesquisa.Width = this.ClientSize.Width;
			resultadoDaPesquisa.TextAlign = ContentAlignment.MiddleCenter;
			resultadoDaPesquisa.Font = new Font("Arial", 10);
			resultadoDaPesquisa.Height = 20;
			resultadoDaPesquisa.Top = painelSuperior.Height + 50;
			painelCentral.Controls.Add(resultadoDaPesquisa);
			
			
			novoNomeBox = new TextBox();
			OrganizarTextBox(novoNomeBox, 200);
			
			comboIdade = new ComboBox();
			comboIdade.Top = 240;
			comboIdade.Left = novoNomeBox.Left;
			comboIdade.Width = 150;
			comboIdade.Font = new Font("Arial", 10);
			comboIdade.FlatStyle = FlatStyle.Flat;
			//comboIdade.DropDownStyle = ComboBoxStyle.DropDownList;
			//comboIdade.SelectedIndex = -1;
			comboIdade.FlatStyle = FlatStyle.Flat;
			for(int idade = 3; idade < 100; idade++){
				comboIdade.Items.Add(idade);
			}
			
			novoCursoBox = new TextBox();
			OrganizarTextBox(novoCursoBox, 280);
			
			actualizarAluno = new Button();
			actualizarAluno.Text = "Actualizar Aluno";
			actualizarAluno.Height = 40;
			actualizarAluno.Width = 120;
			actualizarAluno.Left = (this.ClientSize.Width - actualizarAluno.Width)/2;
			actualizarAluno.Top = painelSuperior.Height + 220;
			actualizarAluno.BackColor = Color.FromArgb(30, 58, 95);
			actualizarAluno.FlatStyle = FlatStyle.Flat;
			actualizarAluno.FlatAppearance.BorderColor = Color.FromArgb(20, 60, 130);
			
			resultadoFinal = new Label();
			resultadoFinal.Width = this.ClientSize.Width;
			resultadoFinal.Top = painelSuperior.Height + 280;
			resultadoFinal.TextAlign = ContentAlignment.MiddleCenter;
			resultadoFinal.Font = new Font("Arial", 10);
			
			painelInferior = new Panel();
			painelInferior.Dock = DockStyle.Bottom;
			painelInferior.BackColor = Color.FromArgb(215, 217, 220);
			painelInferior.Height = 50;
			Controls.Add(painelInferior);
			
			botaoVoltar = new Button();
			botaoVoltar.Text = "Voltar";
			botaoVoltar.Width = 120;
			botaoVoltar.Top = 5;
			botaoVoltar.Height = painelInferior.Height - 10;
			botaoVoltar.Left = this.ClientSize.Width - 140;
			botaoVoltar.BackColor = Color.FromArgb(30, 58, 95);
			botaoVoltar.ForeColor = Color.FromArgb(245, 247, 250);
			painelInferior.Controls.Add(botaoVoltar);
			
			painelCentral.Controls.Add(actualizarAluno);
			painelCentral.Controls.Add(novoNomeBox);
			painelCentral.Controls.Add(comboIdade);
			painelCentral.Controls.Add(novoCursoBox);
			
			botaoPesquisar.Click += botaoPesquisar_Click;
			actualizarAluno.MouseEnter += PassarMouse;
			actualizarAluno.MouseLeave += LeaveMouse;
			actualizarAluno.Click += ActualizarAluno_Click;
			
			// No construtor, após adicionar aos painéis:
			Resize += ReajustarElementos;
			novoNomeBox.Visible = false;
			comboIdade.Visible = false;
			novoCursoBox.Visible = false;
			actualizarAluno.Visible = false;
			painelCentral.Controls.Add(resultadoFinal);
			botaoVoltar.Click += botaoVoltar_Click;
		}
		private void ReajustarElementos(object sender, EventArgs e)
		{
			painelSuperior.Dock = DockStyle.Top;
			caixaDePesquisa.Left = (((this.ClientSize.Width - caixaDePesquisa.Width)/2) - 70);
			botaoPesquisar.Left = caixaDePesquisa.Left + caixaDePesquisa.Width + 20;
			titulo.Width = this.ClientSize.Width;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			painelCentral.Dock = DockStyle.Fill;
			painelCentral.Width = this.ClientSize.Width;
			resultadoDaPesquisa.Width = this.ClientSize.Width;
			resultadoDaPesquisa.TextAlign = ContentAlignment.MiddleCenter;
			actualizarAluno.Left = (this.ClientSize.Width - actualizarAluno.Width)/2;
			resultadoFinal.Width = this.ClientSize.Width;
			resultadoFinal.TextAlign = ContentAlignment.MiddleCenter;
			painelInferior.Dock = DockStyle.Bottom;
			botaoVoltar.Left = this.ClientSize.Width - 140;
			OrganizarTextBox(novoNomeBox, 200);
			OrganizarTextBox(novoCursoBox, 280);
			comboIdade.Left = novoNomeBox.Left;
		}
		private void botaoVoltar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void botaoPesquisar_Click(object sender, EventArgs e)
		{
			Banco banco = new Banco();
			int ID = -1;
			int.TryParse(caixaDePesquisa.Text, out ID);
			Aluno aluno = banco.PesquisarAluno(ID);
			
			if(aluno != null)
			{	
				IdAluno = aluno.ID;
				painelCentral.BackColor = Color.LightSlateGray;
				resultadoDaPesquisa.ForeColor = Color.FromArgb(240, 245, 247);
				resultadoDaPesquisa.Text = "ID: "+ aluno.ID +" | Nome: "+ aluno.Nome +" | Idade: "+ aluno.Idade +" | Curso: "+ aluno.Curso;
				novoNomeBox.Text = aluno.Nome;
				comboIdade.Text = aluno.Idade.ToString();
				novoCursoBox.Text = aluno.Curso;
				novoNomeBox.Visible = true;
				comboIdade.Visible = true;
				novoCursoBox.Visible = true;
				actualizarAluno.Visible = true;
			}
			else{
				painelCentral.BackColor = this.BackColor;
				novoNomeBox.Visible = false;
				comboIdade.Visible = false;
				novoCursoBox.Visible = false;
				actualizarAluno.Visible = false;
				resultadoDaPesquisa.Text = "Aluno não encontrado!";
				resultadoDaPesquisa.ForeColor = Color.Red;
			}
			resultadoDaPesquisa.Visible = true;
		}
		private void ActualizarAluno_Click(object sender, EventArgs e)
		{
			int Idade = 0;
			Aluno novoAluno = new Aluno();
			Banco banco = new Banco();
			AlunoService service = new AlunoService(banco);
			novoAluno.Nome = novoNomeBox.Text;
			novoAluno.Curso = novoCursoBox.Text;
			int.TryParse(comboIdade.Text, out Idade);
			novoAluno.Idade = Idade;
			novoAluno.ID = IdAluno;
			
			if(service.ValidarNome(novoAluno.Nome) && service.ValidarIdade(novoAluno.Idade)
			  && service.ValidarNome(novoAluno.Curso)){
				banco.ActualizarAluno(novoAluno);
				resultadoDaPesquisa.Text = "ID: "+ novoAluno.ID +" | Nome: "+ novoAluno.Nome +" | Idade: "+ novoAluno.Idade +" | Curso: "+ novoAluno.Curso;
				resultadoFinal.Text = "Aluno actualizado!";
				resultadoFinal.ForeColor = Color.Green;
			}
			else
			{
				resultadoFinal.Text = "Aluno não actualizado!";
				resultadoFinal.ForeColor = Color.Red;
			}
		}	
		private void PassarMouse(object sender, EventArgs e)
		{
			actualizarAluno.ForeColor = Color.FromArgb(30, 58, 95);
			actualizarAluno.BackColor = Color.FromArgb(0, 250, 154);
			actualizarAluno.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255);
		}
		private void LeaveMouse(object sender, EventArgs e)
		{
			actualizarAluno.ForeColor = Color.White;
			actualizarAluno.BackColor = Color.FromArgb(30, 58, 95);
			actualizarAluno.FlatAppearance.BorderColor = Color.FromArgb(20, 60, 130);
		}
		private void OrganizarTextBox(TextBox box, int top)
		{
			box.Font = new Font("Arial", 11);
			box.Height = 20;
			box.Width = this.ClientSize.Width * 3/4;
			box.Top = top;
			box.Left = (this.ClientSize.Width - box.Width)/2;
		}
	}
}
