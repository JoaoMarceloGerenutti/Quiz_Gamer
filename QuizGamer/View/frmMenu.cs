using QuizGamer.Properties;
using QuizGamer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizGamer
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private string texto = "";
        private int numero = 0;

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            // Abre uma mensagem com os creditos.
            try
            {
                MessageBox.Show("Jogo criado para o trabalho da ATHON. \n" + "Feito por: João Marcelo Gerenutti \n", "Créditos: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibFechar_Click(object sender, EventArgs e)
        {
            try
            {
                // Fecha o programa.
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is Form)
                    {
                        frm.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Mizimiza a tela.
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            // Armazena o conteudo da lblQuiz para a animação.
            texto = lblQuiz.Text;
            lblQuiz.Text = "";
        }

        private void tmrAnimacao_Tick(object sender, EventArgs e)
        {
            // Animação da lblQuiz.
            if (this.numero > this.texto.Length - 1) { this.numero = 0; this.lblQuiz.Text = ""; }
            this.lblQuiz.Text += this.texto.Substring(numero, 1);
            this.numero++;
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre a tela de categoria dos jogo.
                frmCategoria Categoria = new frmCategoria();

                // Setando a quantidade maxima de dicas.
                Categoria.LimiteDicas = 20;

                // Setando a quantidade maxima de estrelas.
                Categoria.LimiteEstrelas = 120;

                // Desativa a animação.
                tmrAnimacao.Enabled = false;

                this.Hide();
                Categoria.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
