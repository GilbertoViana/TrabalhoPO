namespace projetoForms.Models
{
    public class SessaoUtilizador
    {
        //Singleton - Variável estática que mantém a única instância da classe
        private static SessaoUtilizador instancia;

        public int IdUtilizador { get; private set; }
        public string NomeUtilizador { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public bool IsAdmin {  get; private set; }

        // Construtor privado para impedir instâncias diretas
        private SessaoUtilizador() {}

        // Método estático para obter a única instância da classe
        public static SessaoUtilizador ObterInstancia()
        {
            // Se a instância ainda não foi criada, cria uma nova instância
            if (instancia == null)
            {
                instancia = new SessaoUtilizador();
            }
            return instancia;
        }

        // Método para iniciar sessão
        public void IniciarSessao(int id, string nome, string email, string telefone, bool Admin)
        {
            IdUtilizador = id;
            NomeUtilizador = nome;
            Email = email;
            Telefone = telefone;
            IsAdmin = Admin;
        }

        // Método para limpar a sessão
        public void TerminarSessao()
        {
            IdUtilizador = 0;
            NomeUtilizador = null;
            Email = null;
            Telefone = null;
            IsAdmin = false;
        }
    }
}
