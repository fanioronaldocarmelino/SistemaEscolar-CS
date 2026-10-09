using System;
using System.Windows.Forms;
using System.Drawing;
namespace SistemaEscolar
{
	class ExcluirAluno_Form : Form
	{
		int ID_Inserido = -1;
		string nomeAluno;
		Panel painelSuperior;
		Panel painelInferior;
		Panel painelCentral;
		Label titulo;
		Label resultadoDaPesquisa;
		Label resultado;
		public TextBox caixaDePesquisa;
		Button botaoPesquisar;
		Button botaoExcluir;
		Button botaoCancelar;
		Button botaoVoltar;
		DataGridView tabela;
		
		public ExcluirAluno_Form()
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
			caixaDePesquisa.Size = new Size(400, 30);
			caixaDePesquisa.Top = 70;
			painelSuperior.Controls.Add(caixaDePesquisa);
			
			botaoPesquisar = new Button();
			PadraoBotaoPesquisar();
			painelSuperior.Controls.Add(botaoPesquisar);
			
			titulo = new Label();
			titulo.Text = "Informe o ID do estudante";
			titulo.Font = new Font("Arial", 12);
			titulo.Top = 40;
			titulo.ForeColor = Color.FromArgb(30, 58, 95);
			painelSuperior.Controls.Add(titulo);
			
			painelCentral = new Panel();
			painelCentral.Dock = DockStyle.Fill;
			painelCentral.Height = 380;
			Controls.Add(painelCentral);
			
			tabela = new DataGridView();
			tabela.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
			tabela.Top = (this.ClientSize.Height - tabela.Height)/2;
			tabela.BackgroundColor = Color.FromArgb(245, 247, 250);
			tabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			tabela.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
			tabela.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(245, 247, 250);
			tabela.DefaultCellStyle.ForeColor = Color.FromArgb(30, 58, 95);
			tabela.DefaultCellStyle.Font = new Font("Arial", 10);
			tabela.RowTemplate.Height = 30;
			tabela.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 247, 250);
			tabela.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 95);
			tabela.RowHeadersVisible = false;
			tabela.ReadOnly = true;
			tabela.AllowUserToAddRows = false;
			tabela.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			tabela.BorderStyle = BorderStyle.None;
			tabela.ClearSelection();
			tabela.CurrentCell = null;
			painelCentral.Controls.Add(tabela);
			
			resultadoDaPesquisa = new Label();
			resultadoDaPesquisa.Font = new Font("Arial", 10);
			resultadoDaPesquisa.Top = 140;
			painelCentral.Controls.Add(resultadoDaPesquisa);
			
			botaoExcluir = new Button(); 	
			botaoExcluir.Text = "Excluir";
			botaoExcluir.Size = new Size(120, 40);
			botaoExcluir.Top = tabela.Top + tabela.Height;
			botaoExcluir.BackColor = Color.Red;
			botaoExcluir.ForeColor = Color.FromArgb(240, 245, 247);
			botaoExcluir.FlatStyle = FlatStyle.Flat;
			botaoExcluir.FlatAppearance.BorderColor = this.BackColor;
			painelCentral.Controls.Add(botaoExcluir);
			
			botaoCancelar = new Button();
			botaoCancelar.Text = "Cancelar";
			botaoCancelar.BackColor = Color.FromArgb(30, 58, 95);
			botaoCancelar.Top = botaoExcluir.Top;
			botaoCancelar.Width = botaoExcluir.Width;
			botaoCancelar.Height = botaoExcluir.Height;
			botaoCancelar.FlatAppearance.BorderColor = this.BackColor;
			botaoCancelar.FlatStyle = FlatStyle.Flat;
			painelCentral.Controls.Add(botaoCancelar);
			
			resultado = new Label();
			resultado.Text = "Resultado: ";
			resultado.Top = botaoCancelar.Top + 60;
			resultado.Font = new Font("Arial", 11);
			painelCentral.Controls.Add(resultado);
			
			painelInferior = new Panel();
			painelInferior.Dock = DockStyle.Bottom;
			painelInferior.Height = 50;
			painelInferior.BackColor = this.BackColor;
			Controls.Add(painelInferior);
			
			botaoVoltar = new Button();
			botaoVoltar.Text = "Voltar";
			botaoVoltar.Width = 120;
			botaoVoltar.Height = 40;
			botaoVoltar.BackColor = Color.FromArgb(30, 58, 95);
			painelInferior.Controls.Add(botaoVoltar);
			
			tabela.Visible = false;
			resultadoDaPesquisa.Visible = false;
			botaoExcluir.Visible = false;
			botaoCancelar.Visible = false;
			
			//caixaDePesquisa.KeyDown += caixaDePesquisa_KeyDown;
			botaoPesquisar.Click += BotaoPesquisar_Click;
			botaoCancelar.Click += BotaoCancelar_Click;
			botaoExcluir.Click += ExcluirAlunoTela;
			botaoVoltar.Click += botaoVoltar_Click;
			AjustarPosicoes();
			TabelaPadrao();
		}
		/*private void caixaDePesquisa_KeyDown(object sender, EventArgs e)
		{
			if(Keys.Enter)
				BotaoPesquisar_Click;
		}*/
		private void botaoVoltar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void BotaoCancelar_Click(object sender, EventArgs e)
		{
			caixaDePesquisa.Text = "";
			botaoExcluir.Visible = false;
			tabela.Rows.Clear();
			tabela.Visible = false;
			botaoCancelar.Visible = false;
		}
		private void ExcluirAlunoTela (object sender, EventArgs e)
		{
			TelaExcluir tela = new TelaExcluir(ID_Inserido, nomeAluno, this);
			tela.Show();
		}
		public void LimparTela()
		{
			botaoExcluir.Visible = false;
			tabela.Rows.Clear();
			tabela.Visible = false;
			botaoCancelar.Visible = false;
			caixaDePesquisa.Text = "";
		}
		private void ExcluirAluno_Click(object sender, EventArgs e)
		{
			bool excluido = false;
			
			if(ID_Inserido <= 0)
				return;
				
			Banco banco = new Banco();
			excluido = banco.ExcluirAluno(ID_Inserido);
			
			botaoExcluir.Visible = false;
			tabela.Rows.Clear();
			tabela.Visible = false;
			botaoCancelar.Visible = false;
			
			if(excluido)
			{
				resultado.Text = "Aluno excluído";
				resultado.ForeColor = Color.Green;
			}
			else
			{
				resultado.Text = "Aluno não excluído";
				resultado.ForeColor = Color.Red;
			}
		}
		private void BotaoPesquisar_Click(object sender, EventArgs e)
		{
			int ID = -1;
			int.TryParse(caixaDePesquisa.Text, out ID);
			Banco banco = new Banco();
			Aluno aluno = banco.PesquisarAluno(ID);
			
			if(aluno != null)
			{
				resultadoDaPesquisa.Visible = false;
				ID_Inserido = ID;
				nomeAluno = aluno.Nome;
				botaoExcluir.Visible = true;
				botaoCancelar.Visible = true;
				tabela.Rows.Clear();
				tabela.Rows.Add(aluno.ID, aluno.Nome, aluno.Idade, aluno.Curso);
				tabela.Visible = true;
			}
			else
			{
				botaoCancelar.Visible = false;
				botaoExcluir.Visible = false;
				tabela.Rows.Clear();
				tabela.Visible = false;
				resultadoDaPesquisa.Text = "Aluno não encontrado!";
				resultadoDaPesquisa.ForeColor = Color.Red;
				resultadoDaPesquisa.Visible = true;
			}
			
		}
		
		private void AjustarPosicoes()
		{
			caixaDePesquisa.Left = (((this.ClientSize.Width - caixaDePesquisa.Width)/2) - 70);
			botaoPesquisar.Left = caixaDePesquisa.Left + caixaDePesquisa.Width + 20;
			titulo.Width = this.ClientSize.Width;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			titulo.AutoSize = false;
			tabela.Width = this.ClientSize.Width;
			resultadoDaPesquisa.Width = this.ClientSize.Width;
			resultadoDaPesquisa.Top = (this.ClientSize.Height - resultadoDaPesquisa.Height)/2;
			resultadoDaPesquisa.TextAlign = ContentAlignment.MiddleCenter;
			botaoExcluir.Left = (this.ClientSize.Width - botaoExcluir.Width)/2 + 60;
			botaoCancelar.Left = (this.ClientSize.Width - botaoCancelar.Width)/2 - 80;
			painelInferior.Width = this.ClientSize.Width;
			botaoVoltar.Left = this.ClientSize.Width - 140;
			resultado.Width = this.ClientSize.Width;
			resultado.TextAlign = ContentAlignment.MiddleCenter;
		}
		private void PadraoBotaoPesquisar ()
		{
			botaoPesquisar.Text = "Pesquisar";
			botaoPesquisar.Top = 68;
			botaoPesquisar.Height = 30;
			botaoPesquisar.Width = 120;
			botaoPesquisar.FlatStyle = FlatStyle.Flat;
			botaoPesquisar.BackColor = Color.FromArgb(37, 99, 235);
			botaoPesquisar.ForeColor = Color.FromArgb(255, 255, 255);
			botaoPesquisar.FlatAppearance.BorderColor = Color.FromArgb(20, 60, 130);
		}
		private void TabelaPadrao ()
		{
			tabela.Columns.Add("ID", "ID");
			tabela.Columns.Add("Nome", "Nome");
			tabela.Columns.Add("Idade", "Idade");
			tabela.Columns.Add("Curso", "Curso");
			tabela.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.Columns["Idade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.Columns["Curso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
	}
	class TelaExcluir : Form
	{
		Label informacao;
		Button botaoCancelar;
		Button botaoExcluir;
		Button botaoVoltar;
		int ID_Inserido;
		string NomeAluno;
		ExcluirAluno_Form TelaPrincipal;
		
		public TelaExcluir(int ID, string nomeAluno, ExcluirAluno_Form telaPrincipal)
		{
			this.TelaPrincipal = telaPrincipal;
			ID_Inserido = ID;
			NomeAluno = nomeAluno;
			Text = "Excluir Aluno";
			this.Size = new Size(400, 250);
			StartPosition = FormStartPosition.CenterScreen;
			BackColor = Color.LightSlateGray;
			
			informacao = new Label();
			informacao.Text = NomeAluno +" será removido permanentemente! Continuar?";
			informacao.Font = new Font("Arial", 11);
			informacao.Top = 10;
			informacao.Width = this.ClientSize.Width;
			informacao.TextAlign = ContentAlignment.MiddleCenter;
			informacao.ForeColor = Color.Red;
			informacao.BackColor = Color.Black;
			Controls.Add(informacao);
			
			botaoCancelar = new Button();
			botaoCancelar.Text = "Cancelar";
			botaoCancelar.BackColor = Color.FromArgb(30, 58, 95);
			botaoCancelar.Size = new Size(120, 40);
			botaoCancelar.Location = new Point(60, 150);
			Controls.Add(botaoCancelar);
			
			botaoVoltar = new Button();
			botaoVoltar.Text = "Voltar";
			botaoVoltar.Width = 120;
			botaoVoltar.Height = 40;
			botaoVoltar.BackColor = botaoCancelar.BackColor;
			Controls.Add(botaoVoltar);
			botaoVoltar.Visible = false;
			
			botaoExcluir = new Button();
			botaoExcluir.Text = "Excluir";
			botaoExcluir.Size = botaoCancelar.Size;
			botaoExcluir.Location = new Point(220, 150);
			Controls.Add(botaoExcluir);
			
			botaoCancelar.Click += botaoCancelar_Click;
			botaoExcluir.Click += botaoExcluir_Click;
			botaoVoltar.Click += botaoVoltar_Click;
		}
		private void botaoVoltar_Click(object sender, EventArgs e)
		{
			Controls.Clear();
			this.Close();
		}
		private void botaoCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void botaoExcluir_Click(object sender, EventArgs e)
		{
			Banco banco = new Banco();
			bool excluido = banco.ExcluirAluno(ID_Inserido);
			TelaPrincipal.LimparTela();
			if(excluido)
			{
				informacao.Text = "Aluno excluído!";
			}
			else
			{
				informacao.Text = "Aluno não excluído!";
			}
			MostrarAlunoExcluido();
		}
		private void MostrarAlunoExcluido()
		{
			informacao.ForeColor = Color.FromArgb(245, 247, 250);
			informacao.Width = this.ClientSize.Width;
			informacao.BackColor = Color.LightSlateGray;
			informacao.TextAlign = ContentAlignment.MiddleCenter;
			informacao.Top = (this.ClientSize.Height - informacao.Height)/2 - 10;
			botaoExcluir.Visible = false;
			botaoCancelar.Visible = false;
			botaoVoltar.Visible = true;
			botaoVoltar.Left = (this.ClientSize.Width - botaoVoltar.Width)/2;
			botaoVoltar.Top = this.ClientSize.Height - botaoVoltar.Height - 20;
		}
	}
}
