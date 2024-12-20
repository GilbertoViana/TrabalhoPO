using Newtonsoft.Json;
using projetoForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projetoForms
{
    public partial class FormAlojamentos : Form
    {
        private List<Alojamento> alojamentos;
        private Alojamento alojamentoSelecionado;
        private List<Reserva> reservas = new List<Reserva>();
        private int ultimoId;
        private const string caminhoArquivoReservas = @"C:\Users\Utilizador\Desktop\TrabalhoPO\projetoForms\projetoForms\reservas.json"; // Caminho absoluto


        public FormAlojamentos()
        {
            InitializeComponent();

        }

        private void FormAlojamentos_Load(object sender, EventArgs e)
        {
            // Criar alojamentos
            alojamentos = new List<Alojamento>
            {
                new Alojamento { Id = 1, Nome = "Casa da Serra", Endereco = "Rua da Serra, 123", Capacidade = 6, PrecoPorNoite = 120.50m },
                new Alojamento { Id = 2, Nome = "Villa Mar", Endereco = "Avenida do Mar, 45", Capacidade = 8, PrecoPorNoite = 200.00m },
                new Alojamento { Id = 3, Nome = "Apartamento Centro", Endereco = "Praça Central, 10", Capacidade = 4, PrecoPorNoite = 90.00m },
                new Alojamento { Id = 4, Nome = "Quinta do Vale", Endereco = "Estrada do Vale, 89", Capacidade = 10, PrecoPorNoite = 300.00m },
                new Alojamento { Id = 5, Nome = "Chalé das Flores", Endereco = "Caminho das Flores, 77", Capacidade = 5, PrecoPorNoite = 150.00m }
            };
            // Mostra os dados de forma detalhada
            listView1.View = View.Details; // Define a exibição como detalhes (colunas)
            listView1.FullRowSelect = true; // Permite selecionar a linha inteira ao invés de apenas o item

            // Adiciona as colunas na ListView para mostrar os dados
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Nome", 150);
            listView1.Columns.Add("Endereço", 200);
            listView1.Columns.Add("Capacidade", 100);
            listView1.Columns.Add("Preço por Noite", 120);

            // Para cada alojamento
            foreach (var alojamento in alojamentos)
            {
                ListViewItem item = new ListViewItem(alojamento.Id.ToString());

                // Adiciona as subcolunas com os respetivos dados
                item.SubItems.Add(alojamento.Nome);
                item.SubItems.Add(alojamento.Endereco);
                item.SubItems.Add(alojamento.Capacidade.ToString());
                item.SubItems.Add(alojamento.PrecoPorNoite.ToString("C")); 
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica se um alojamento foi selecionado
            if (alojamentoSelecionado == null)
            {
                MessageBox.Show("Nenhum alojamento selecionado. Por favor, selecione um da lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Carrega as reservas já feitas
            CarregarReservasDoArquivo();

            // Datas de início e fim da reserva
            DateTime dataInicio = dateTimePicker1.Value;
            DateTime dataFim = dateTimePicker2.Value;

            // Verifica se a data de fim é posterior à data de início
            if (dataFim <= dataInicio)
            {
                MessageBox.Show("A data de fim deve ser posterior à data de início.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar se já existe uma reserva para o alojamento nas mesmas datas
            if (VerificarReservaExistente(alojamentoSelecionado, dataInicio, dataFim))
            {
                MessageBox.Show("Já existe uma reserva para este alojamento nas datas selecionadas. Por favor, escolha outra data.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtém a sessão do utilizador (singleton)
            var sessao = SessaoUtilizador.ObterInstancia();

            var cliente = new Pessoas { Id = sessao.IdUtilizador, Nome = sessao.NomeUtilizador, Email = sessao.Email, Password = "", Telefone = sessao.Telefone };

            // Cria a nova reserva, incrementando o 'ultimoId'
            var reserva = new Reserva(++ultimoId)
            {
                DataInicio = dataInicio,
                DataFim = dataFim,
                Cliente = cliente,
                Alojamento = alojamentoSelecionado,
                ValorTotal = (decimal)(dataFim - dataInicio).TotalDays * alojamentoSelecionado.PrecoPorNoite
            };

            // Adiciona a nova reserva à lista de reservas
            reservas.Add(reserva);

            // Guarda as reservas
            SalvarReservasNoArquivo();


            MessageBox.Show($"Reserva feita com sucesso!\n\n" +
                            $"Cliente: {reserva.Cliente.Nome}\n" +
                            $"Alojamento: {reserva.Alojamento.Nome}\n" +
                            $"Data Início: {reserva.DataInicio.ToShortDateString()}\n" +
                            $"Data Fim: {reserva.DataFim.ToShortDateString()}\n" +
                            $"Valor Total: {reserva.ValorTotal:C}", "Reserva Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listView1.SelectedItems.Clear();
            alojamentoSelecionado = null;
        }

        private bool VerificarReservaExistente(Alojamento alojamento, DateTime dataInicio, DateTime dataFim)
        {
            foreach (var reserva in reservas)
            {
                // Verifica se as datas se sobrepõem
                if (reserva.Alojamento.Id == alojamento.Id &&
                    ((dataInicio >= reserva.DataInicio && dataInicio < reserva.DataFim) ||
                     (dataFim > reserva.DataInicio && dataFim <= reserva.DataFim) ||
                     (dataInicio <= reserva.DataInicio && dataFim >= reserva.DataFim)))
                {
                    return true; // Já existe uma reserva no intervalo
                }
            }
            return false; // Não existe sobreposição
        }

        private void SalvarReservasNoArquivo()
        {
            try
            {
                string json = JsonConvert.SerializeObject(reservas, Formatting.Indented);

                File.WriteAllText(caminhoArquivoReservas, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar reservas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // ID do alojamento selecionado a partir do texto da primeira coluna
                int idSelecionado = int.Parse(listView1.SelectedItems[0].Text);

                alojamentoSelecionado = alojamentos.FirstOrDefault(a => a.Id == idSelecionado);

                // Verifica se o alojamento foi encontrado
                if (alojamentoSelecionado != null)
                {
                    MessageBox.Show($"Alojamento selecionado: {alojamentoSelecionado.Nome}", "Alojamento Selecionado");
                }
            }

        }

        private void verReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Painel visivel
            panel1.Visible = true;

            // Botão "remover" invisivel
            RemoverReserva.Visible = false;

            CarregarReservasDoArquivo();
        }

        private void CarregarReservasDoArquivo()
        {
            try
            {
                if (File.Exists(caminhoArquivoReservas))
                {
                    // Lê o conteúdo do arquivo JSON
                    string json = File.ReadAllText(caminhoArquivoReservas);

                    // Desserializa o JSON para a lista de reservas
                    reservas = JsonConvert.DeserializeObject<List<Reserva>>(json) ?? new List<Reserva>();

                    // Atualiza o ultimoId após carregar as reservas
                    if (reservas.Any())
                    {
                        ultimoId = reservas.Max(r => r.Id); // Pega o maior ID da lista de reservas
                    }

                    // Após carregar as reservas, atualize a ListView com as reservas
                    CarregarReservasNaListView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar reservas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarReservasNaListView()
        {
            listView2.Items.Clear(); // Limpa a ListView antes de adicionar os novos itens

            if (listView2.Columns.Count == 0)
            {
                // Configura as colunas da ListView para mostrar dados
                listView2.View = View.Details;
                listView2.FullRowSelect = true;

                // Adiciona as colunas à ListView
                listView2.Columns.Add("ID Reserva", 100);
                listView2.Columns.Add("Cliente", 150);
                listView2.Columns.Add("Alojamento", 150);
                listView2.Columns.Add("Data Início", 100);
                listView2.Columns.Add("Data Fim", 100);
                listView2.Columns.Add("Valor Total", 120);
            }

            // Dados da sessão do utilizador logado
            var sessao = SessaoUtilizador.ObterInstancia();
            int idUtilizadorLogado = sessao.IdUtilizador;

            
            var reservasDoUtilizador = sessao.IsAdmin
        ? reservas  // Mostra todas as reservas se for admin
        : reservas.Where(r => r.Cliente.Id == idUtilizadorLogado).ToList();  // Mostra só as reservas do utilizador


            // Adiciona as reservas do utilizador na ListView
            foreach (var reserva in reservasDoUtilizador)
            {
                ListViewItem item = new ListViewItem(reserva.Id.ToString());
                item.SubItems.Add(reserva.Cliente.Nome);
                item.SubItems.Add(reserva.Alojamento.Nome);
                item.SubItems.Add(reserva.DataInicio.ToShortDateString());
                item.SubItems.Add(reserva.DataFim.ToShortDateString());
                item.SubItems.Add(reserva.ValorTotal.ToString("C"));

                listView2.Items.Add(item);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Painel invisivel
            panel1.Visible = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                // Id da reserva selecionada
                int idReservaSelecionada = int.Parse(listView2.SelectedItems[0].Text);

                // Utilizador logado
                var sessao = SessaoUtilizador.ObterInstancia();
                int idUtilizadorLogado = sessao.IdUtilizador;

                // Procurar a reserva associada ao utilizador logado
                var reservaParaRemover = reservas.FirstOrDefault(r => r.Id == idReservaSelecionada && r.Cliente.Id == idUtilizadorLogado);

                // Se a reserva for encontrada e pertencer ao utilizador logado
                if (reservaParaRemover != null)
                {
                    var confirmacao = MessageBox.Show(
                        "Tem certeza de que deseja remover esta reserva?",
                        "Confirmar Remoção",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Se o utilizador confirmar a remoção
                    if (confirmacao == DialogResult.Yes)
                    {
                        // Remove a reserva da lista
                        reservas.Remove(reservaParaRemover);

                        // Guarda as alterações no arquivo
                        SalvarReservasNoArquivo();

                        // Atualiza a ListView
                        CarregarReservasNaListView();

                        MessageBox.Show("Reserva removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Oculta o botão após a remoção
                        RemoverReserva.Visible = false;
                    }
                }
                else
                {
                    // Caso a reserva não pertença ao utilizador logado ou não seja encontrada
                    MessageBox.Show(
                        "Você não tem permissão para remover esta reserva ou a reserva não foi encontrada.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show("Nenhuma reserva selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar se há itens selecionados na listView2
            if (listView2.SelectedItems.Count > 0)
            {
                // Mostra o botão RemoverReserva
                RemoverReserva.Visible = true;
            }
            else
            {
                // Ocultar o botão RemoverReserva se nada estiver selecionado
                RemoverReserva.Visible = false;
            }
        }
    }
}

            