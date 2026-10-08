using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace SistemaEscolar
{
class Form1 : Form
{
	Label titulo;
	Label rodape;
	Panel painelDosBotoes;
	Button CadastrarAluno;
	Button ListarAlunos;
	Button PesquisarAluno;
	Button ActualizarAluno;
	Button ExcluirAluno;
	
	public Form1()
	{
		Text = "SISTEMA ESCOLAR";
		Width = 900;
		Height = 550;
		StartPosition = FormStartPosition.CenterScreen;
		BackColor = Color.FromArgb(245, 247, 250);	//LightSlateGray;
		
		titulo = new Label();
		titulo.Text = "SISTEMA ESCOLAR";
		titulo.Height = 40;
		titulo.Top = 50;
		titulo.Width = this.ClientSize.Width;
		titulo.AutoSize = false;
		titulo.Left = (this.ClientSize.Width - titulo.Width)/2;
		titulo.ForeColor = Color.FromArgb(30, 58, 95);
		titulo.Font = new Font("Arial", 24, FontStyle.Bold);
		titulo.TextAlign = ContentAlignment.MiddleCenter;
		Controls.Add(titulo);
		
		rodape = new Label();
		rodape.Text = "Fânio Carmelino - Todos os direitos reservados!";
		rodape.Font = new Font("Arial", 10, FontStyle.Bold);
		rodape.ForeColor = Color.FromArgb(30, 58, 95);
		rodape.Top = 480;
		rodape.Width = this.ClientSize.Width;
		rodape.Height = 20;
		rodape.AutoSize = false;
		rodape.TextAlign = ContentAlignment.MiddleCenter;
		Controls.Add(rodape);
		
		painelDosBotoes = new Panel();
		painelDosBotoes.Width = 800;
		painelDosBotoes.Height = 450;
		painelDosBotoes.Top = (this.ClientSize.Height - painelDosBotoes.Height)/2;
		painelDosBotoes.Left = (this.ClientSize.Width - painelDosBotoes.Width)/2;
		Controls.Add(painelDosBotoes);
		Resize += CentralizarPainel;
		
		CadastrarAluno = new Button();
		CadastrarAluno.Left = 50;
		PadraoDosBotoes(CadastrarAluno, "Cadastrar Aluno");
		painelDosBotoes.Controls.Add(CadastrarAluno);
		
		ListarAlunos = new Button();
		ListarAlunos.Left = 50 + 120 + 30;
		PadraoDosBotoes(ListarAlunos, "Listar Aluno");
		painelDosBotoes.Controls.Add(ListarAlunos);
		
		PesquisarAluno = new Button();
		PesquisarAluno.Left = ListarAlunos.Left + 30 + 120;
		PadraoDosBotoes(PesquisarAluno, "Pesquisar Aluno");
		painelDosBotoes.Controls.Add(PesquisarAluno);
		
		ActualizarAluno = new Button();
		ActualizarAluno.Left = 30 + 120 + PesquisarAluno.Left;
		PadraoDosBotoes(ActualizarAluno, "Actualizar Aluno");
		painelDosBotoes.Controls.Add(ActualizarAluno);
		
		ExcluirAluno = new Button();
		ExcluirAluno.Left = 30 + 120 + ActualizarAluno.Left;
		PadraoDosBotoes(ExcluirAluno, "Excluir Aluno");
		painelDosBotoes.Controls.Add(ExcluirAluno);
		
		ActualizarAluno.Click += ActualizarAluno_Click;
		CadastrarAluno.Click += CadastrarAluno_Click;
		ListarAlunos.Click += ListarAlunos_Click;
		PesquisarAluno.Click += PesquisarAluno_Click;
		ExcluirAluno.Click += ExcluirAluno_Click;
		
	}
	private void ExcluirAluno_Click(object sender, EventArgs e)
	{
		ExcluirAluno_Form tela = new ExcluirAluno_Form();
		tela.Show();
	}
	private void ActualizarAluno_Click (object sender, EventArgs e){
		ActualizarAluno_Form tela = new ActualizarAluno_Form();
		tela.Show();
	}
	private void CadastrarAluno_Click(object sender, EventArgs e)
	{
		CadastrarAluno_Form tela = new CadastrarAluno_Form();
		tela.Show();
	}
	private void ListarAlunos_Click(object sender, EventArgs e)
	{
		FormListar tela = new FormListar();
		tela.Show();
	}
	
	private void PesquisarAluno_Click (object sender, EventArgs e)
	{
		PesquisarAluno_Form tela = new PesquisarAluno_Form();
		tela.Show();
	}
	
	private void PadraoDosBotoes (Button botao, string nomeBotao)
	{
		botao.Text = nomeBotao;
		botao.Height = 80;
		botao.Width = 120;
		botao.Top = 200;
		botao.BackColor = Color.FromArgb(37, 99, 235);
		botao.ForeColor = Color.White;
		botao.FlatStyle = FlatStyle.Flat;
		botao.FlatAppearance.BorderColor = Color.FromArgb(20, 60, 130);
	}
	
	private void CentralizarPainel(object sender, EventArgs e)
	{
		painelDosBotoes.Top = (this.ClientSize.Height - painelDosBotoes.Height)/2;
		painelDosBotoes.Left = (this.ClientSize.Width - painelDosBotoes.Width)/2;
		rodape.Width = this.ClientSize.Width;
		rodape.TextAlign = ContentAlignment.MiddleCenter;
		titulo.Width = this.ClientSize.Width;
		titulo.TextAlign = ContentAlignment.MiddleCenter;
	}
}

	class FormListar : Form
	{
		DataGridView tabela;
		Panel painelTopo;
		Panel painelInfeiror;
		Label titulo;
		Button voltar;
		public FormListar()
		{
			Text = "Listar Alunos";
			Size = new Size(800, 500);
			StartPosition = FormStartPosition.CenterScreen;
			
			tabela = new DataGridView();
			tabela.Dock = DockStyle.Fill;
			tabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			tabela.BackgroundColor = Color.FromArgb(215, 217, 220);
			tabela.BorderStyle = BorderStyle.None;
			tabela.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
			tabela.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			tabela.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
			tabela.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
			tabela.DefaultCellStyle.Font = new Font("Arial", 10);
			tabela.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
			tabela.DefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
			tabela.RowTemplate.Height = 30;
			tabela.RowHeadersVisible = false;
			tabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			tabela.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			Controls.Add(tabela);
			
			painelTopo = new Panel();
			painelTopo.Height = 70;
			painelTopo.Dock = DockStyle.Top;
			painelTopo.BackColor = Color.White;
			Controls.Add(painelTopo);
		
			titulo = new Label();
			titulo.Text = "LISTA DE ALUNOS";
			titulo.ForeColor = Color.FromArgb(30, 58, 95);
			titulo.Font = new Font("Arial", 20, FontStyle.Bold);
			titulo.Dock = DockStyle.Fill;
			titulo.TextAlign = ContentAlignment.MiddleCenter;
			painelTopo.Controls.Add(titulo);
			
			tabela.Columns.Add("ID", "ID");
			tabela.Columns.Add("Nome", "Nome");
			tabela.Columns.Add("Idade", "Idade");
			tabela.Columns.Add("Curso", "Curso");
			tabela.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.Columns["Idade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.Columns["Curso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			tabela.ReadOnly = true;
			tabela.AllowUserToAddRows = false;
			
			ListarAlunos_Form();	
			
			painelInfeiror = new Panel();
			painelInfeiror.Dock = DockStyle.Bottom;
			painelInfeiror.Height = 40;
			painelInfeiror.BackColor = Color.FromArgb(215, 217, 220);
			Controls.Add(painelInfeiror);
			
			voltar = new Button();
			voltar.Text = "Voltar";
			voltar.Height = painelInfeiror.Height - 5;
			voltar.Width = 120;
			voltar.Left = this.ClientSize.Width - 140;
			voltar.BackColor = Color.FromArgb(30, 58, 95);
			voltar.ForeColor = Color.FromArgb(245, 247, 250);
			painelInfeiror.Controls.Add(voltar);
			
			Resize += AlinharBtnVoltar;
			this.Shown += FormListar_Shown;
			voltar.Click += VoltarTelaPrincipal;
		}
		private void FormListar_Shown(object sender, EventArgs e)
		{
			tabela.ClearSelection();
			tabela.CurrentCell = null;
		}
		private void AlinharBtnVoltar(object sender, EventArgs e)
		{
			voltar.Left = this.ClientSize.Width - 90;
		}
		private void VoltarTelaPrincipal(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void ListarAlunos_Form ()
		{
			Banco banco = new Banco();
			List<Aluno> alunos = banco.ListarAlunos();
			foreach(Aluno estudante in alunos)
			{
				tabela.Rows.Add(estudante.ID, estudante.Nome, estudante.Idade, estudante.Curso);
			}
		}
	} 
	
	class Program
	{
	static void Main()
	{
		Application.Run(new Form1());
	}
	}
}
