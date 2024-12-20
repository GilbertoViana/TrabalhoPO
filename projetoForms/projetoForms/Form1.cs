using projetoForms.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projetoForms
{
    public partial class Form1 : Form
    {
        // Lista para armazenar os utilizadores
        private List<Pessoas> pessoas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pessoas = new List<Pessoas>
            {
                new Pessoas { Id = 1, Nome = "João", Email = "joao@gmail.com", Password = "1234", Telefone = "912345678", Admin = false},
                new Pessoas { Id = 2, Nome = "Maria", Email = "maria@gmail.com", Password = "1234", Telefone = "923456789", Admin = false},
                new Pessoas { Id = 3, Nome = "Pedro", Email = "pedro@gmail.com", Password = "1234", Telefone = "934567890", Admin = false},
                new Pessoas { Id = 4, Nome = "Ana", Email = "ana@gmail.com", Password = "1234", Telefone = "945678901", Admin = false},
                new Pessoas { Id = 5, Nome = "Lucas", Email = "lucas@gmail.com", Password = "1234", Telefone = "956789012", Admin = true}
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Email e a senha inseridos pelo utilizador
            string emailInserido = textBoxEmail.Text;
            string passwordInserida = textBoxPassword.Text;

            // Procura um utilizador na lista 'pessoas' que tenha o mesmo email e senha
            var utilizadorEncontrado = pessoas.FirstOrDefault(p => p.Email == emailInserido && p.Password == passwordInserida);

            if (utilizadorEncontrado != null)
            {
                MessageBox.Show($"Bem-vindo(a), {utilizadorEncontrado.Nome}!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SessaoUtilizador.ObterInstancia().IniciarSessao(
                           utilizadorEncontrado.Id,
                           utilizadorEncontrado.Nome,
                           utilizadorEncontrado.Email,
                           utilizadorEncontrado.Telefone,
                           utilizadorEncontrado.Admin
                       );
                
                {
                    // Esconde o formulário de login e abre o formulário de Alojamentos
                    this.Hide();
                    FormAlojamentos sistema = new FormAlojamentos();
                    sistema.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Email ou palavra-passe inválidos. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
