using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaUsuariosMVC.Controller;
using System.Text.RegularExpressions;

namespace AgendaUsuariosMVC
{
    public partial class Form1 : Form
    {
        private ContatoController controller = new ContatoController();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string whatsapp = txtWhatsapp.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Validação de nome (não pode conter números)
            if (Regex.IsMatch(nome, @"\d"))
            {
                MessageBox.Show("O nome não pode conter números!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação de WhatsApp (somente números e 10 ou 11 dígitos)
            if (!Regex.IsMatch(whatsapp, @"^\d{10,11}$"))
            {
                MessageBox.Show("O número de WhatsApp deve conter apenas 10 ou 11 dígitos numéricos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação de E-mail (padrão simples)
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Informe um e-mail válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            controller.AdicionarContato(nome, whatsapp, email);
            AtualizarGrid();
            LimparCampos();
        }

        private void AtualizarGrid()
        {
            dataGridViewContatos.DataSource = null;
            dataGridViewContatos.DataSource = controller.ObterContatos();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtWhatsapp.Clear();
            txtEmail.Clear();
            txtNome.Focus();
        }
    }
}
