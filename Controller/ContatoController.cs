using System.Collections.Generic;
using AgendaUsuariosMVC.Model;

namespace AgendaUsuariosMVC.Controller
{
    public class ContatoController
    {
        private List<Contato> contatos = new List<Contato>();

        public void AdicionarContato(string nome, string whatsapp, string email)
        {
            contatos.Add(new Contato(nome, whatsapp, email));
        }

        public List<Contato> ObterContatos()
        {
            return contatos;
        }
    }
}
