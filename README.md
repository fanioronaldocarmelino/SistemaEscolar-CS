# SistemaEscolar-CS

## Sistema de gestão escolar (Windows Forms)

Aplicação desktop completa para linux para gestão de alunos

## Funcionalidades:
- **Cadastrar Aluno:** Permite registar nome, idade e curso.
- **Listar Alunos:** Permite exibir todos os alunos em uma tabela(`DataGridView`).
- **Pesquisar Aluno:** Encontre o aluno por ID.
- **Actualizar Aluno:** Actualize dados dos alunos (nome, idade, curso).
- **Excluir Aluno:** Remove registos do banco de dados com confirmação.

## Tecnologias Utilizadas:
-**Linguagem:** C# (.Net Framework / mono).
-**Interface gráfica:** Windows Forms (`System.Windows.Forms`).
- **Banco de Dados:** SQLite (`Mono.Data.Sqlite`).

## Para compilar:
mcs WinForm.cs banco.cs AlunoService.cs Alunos.cs PesquisarAluno_Form.cs CadastrarAluno_Form.cs ActualizarAluno_Form.cs ExcluirAluno_Form.cs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:System.Data -r:Mono.Data.Sqlite

## Outras informaçãoes:
-**Autor:** Fânio Carmelino.
-**Ambiente usado:** Linux / Geany.
-**Compilador usado:** Mono JIT compiler version 4.6.2
