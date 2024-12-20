using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPoo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obter os valores introduzidos nos campos de texto
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Verificar as credenciais (exemplo simples com "admin" e "1234")
            if (username == "admin" && password == "1234")
            {
                // Se o login for bem-sucedido
                MessageBox.Show("Login efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ocultar o formulário de login
                //this.Hide();

                // Abrir o formulário principal (pode ser substituído por outro formulário que tenhas)
                //MainForm mainForm = new MainForm();
                //mainForm.Show();
            }
            else
            {
                // Se as credenciais estiverem erradas, mostrar uma mensagem de erro
                MessageBox.Show("Nome de utilizador ou palavra-passe incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpar os campos de entrada
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
