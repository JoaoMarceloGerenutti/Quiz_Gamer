using QuizGamer.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizGamer.View
{
    public partial class frmListaJogo : Form
    {
        public frmListaJogo()
        {
            InitializeComponent();
        }

        public int QuantidadeDicasSalva { get; set; }
        public int LimiteDicasSalva  { get; set; }

        public int EstrelasGanhasSalva { get; set; }
        public int LimiteEstrelasSalva { get; set; }

        public string[] ListaJogos { get; set; }

        public Bitmap[] ListaImagens { get; set; }

        public List<Bitmap> ListaJogosGanhos { get; set; }

        public int EstrelasGanhasCategoria1 { get; set; }
        public int EstrelasGanhasCategoria2 { get; set; }
        public int EstrelasGanhasCategoria3 { get; set; }
        public int EstrelasGanhasCategoria4 { get; set; }
        public int EstrelasGanhasCategoria5 { get; set; }
        public int EstrelasGanhasCategoria6 { get; set; }
        public int EstrelasGanhasCategoria7 { get; set; }
        public int EstrelasGanhasCategoria8 { get; set; }

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

        private void carregaEstrelasEDicas(frmCategoria Categoria)
        {
            // Carrega a quantidade de estrelas e dicas obtidas para o frmCategoria.
            Categoria.QuantidadeDicas = this.QuantidadeDicasSalva;
            Categoria.LimiteDicas = this.LimiteDicasSalva;

            Categoria.EstrelasGanhas = this.EstrelasGanhasSalva;
            Categoria.LimiteEstrelas = this.LimiteEstrelasSalva;

            // Salvando as estrelas ganhas na categoria dos jogos.
            Categoria.EstrelasGanhasCategoria1 = EstrelasGanhasCategoria1;
            Categoria.EstrelasGanhasCategoria2 = EstrelasGanhasCategoria2;
            Categoria.EstrelasGanhasCategoria3 = EstrelasGanhasCategoria3;
            Categoria.EstrelasGanhasCategoria4 = EstrelasGanhasCategoria4;
            Categoria.EstrelasGanhasCategoria5 = EstrelasGanhasCategoria5;
            Categoria.EstrelasGanhasCategoria6 = EstrelasGanhasCategoria6;
            Categoria.EstrelasGanhasCategoria7 = EstrelasGanhasCategoria7;
            Categoria.EstrelasGanhasCategoria8 = EstrelasGanhasCategoria8;
        }

        private void salvaEstrelasEDicas(frmJogo Jogo)
        {
            // Salva a quantidade de estrelas e dicas obtidas no frmJogo.
            Jogo.QuantidadeDicas = this.QuantidadeDicasSalva;
            Jogo.LimiteDicas = this.LimiteDicasSalva;

            Jogo.EstrelasGanhas = this.EstrelasGanhasSalva;
            Jogo.LimiteEstrelas = this.LimiteEstrelasSalva;

            // Salvando as estrelas ganhas na categoria dos jogos.
            Jogo.EstrelasGanhasCategoria1 = EstrelasGanhasCategoria1;
            Jogo.EstrelasGanhasCategoria2 = EstrelasGanhasCategoria2;
            Jogo.EstrelasGanhasCategoria3 = EstrelasGanhasCategoria3;
            Jogo.EstrelasGanhasCategoria4 = EstrelasGanhasCategoria4;
            Jogo.EstrelasGanhasCategoria5 = EstrelasGanhasCategoria5;
            Jogo.EstrelasGanhasCategoria6 = EstrelasGanhasCategoria6;
            Jogo.EstrelasGanhasCategoria7 = EstrelasGanhasCategoria7;
            Jogo.EstrelasGanhasCategoria8 = EstrelasGanhasCategoria8;
        }

        private void ibVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmCategoria.
                frmCategoria Categoria = new frmCategoria();

                // Chama o metodo para carregar as estrelas e dicas.
                carregaEstrelasEDicas(Categoria);

                // Carrega a lista de jogos ganhos para o frmCategoria.
                Categoria.ListaJogosGanhos = ListaJogosGanhos;

                this.Dispose();
                Categoria.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmListaJogo_Load(object sender, EventArgs e)
        {
            // Carrega as imagens salvas para seus lugares.
            this.ibIndex1.Image = ListaImagens[0];
            this.ibIndex2.Image = ListaImagens[1];
            this.ibIndex3.Image = ListaImagens[2];
            this.ibIndex4.Image = ListaImagens[3];
            this.ibIndex5.Image = ListaImagens[4];
            this.ibIndex6.Image = ListaImagens[5];
            this.ibIndex7.Image = ListaImagens[6];
            this.ibIndex8.Image = ListaImagens[7];
            this.ibIndex9.Image = ListaImagens[8];
            this.ibIndex10.Image = ListaImagens[9];
            this.ibIndex11.Image = ListaImagens[10];
            this.ibIndex12.Image = ListaImagens[11];
            this.ibIndex13.Image = ListaImagens[12];
            this.ibIndex14.Image = ListaImagens[13];
            this.ibIndex15.Image = ListaImagens[14];

            // Verifica se tem algum jogo ganho.
            if (EstrelasGanhasSalva > 0)
            {
                ManipuladorImagem manipuladorImagem = new ManipuladorImagem();

                // Procura se tem algum jogo da categoria atual na lista de jogos ganhos.
                for (int i = 0; i < ListaImagens.Length; i++)
                {
                    for (int j = 0; j < EstrelasGanhasSalva; j++)
                    {
                        // Se achar o jogo na lista, procura qual posicao dele e troca a cor do bcIndex com o metodo mudaCorAcerto.
                        if (manipuladorImagem.comparaImagem(ListaImagens[i], ListaJogosGanhos[j]) == true)
                        {
                            switch (i)
                            {
                                case 0:
                                    mudaCorAcerto(bcIndex1);
                                    break;
                                case 1:
                                    mudaCorAcerto(bcIndex2);
                                    break;
                                case 2:
                                    mudaCorAcerto(bcIndex3);
                                    break;
                                case 3:
                                    mudaCorAcerto(bcIndex4);
                                    break;
                                case 4:
                                    mudaCorAcerto(bcIndex5);
                                    break;
                                case 5:
                                    mudaCorAcerto(bcIndex6);
                                    break;
                                case 6:
                                    mudaCorAcerto(bcIndex7);
                                    break;
                                case 7:
                                    mudaCorAcerto(bcIndex8);
                                    break;
                                case 8:
                                    mudaCorAcerto(bcIndex9);
                                    break;
                                case 9:
                                    mudaCorAcerto(bcIndex10);
                                    break;
                                case 10:
                                    mudaCorAcerto(bcIndex11);
                                    break;
                                case 11:
                                    mudaCorAcerto(bcIndex12);
                                    break;
                                case 12:
                                    mudaCorAcerto(bcIndex13);
                                    break;
                                case 13:
                                    mudaCorAcerto(bcIndex14);
                                    break;
                                case 14:
                                    mudaCorAcerto(bcIndex15);
                                    break;
                            }
                        }
                    }
                }
            }

            frmCategoria Categoria = new frmCategoria();
            FormataQuantidade formataQuantidade = new FormataQuantidade();

            // Carrega a quantidade de dicas e estrelas ganhas, formata e coloca no blblDicas e blblTotalEstrela.
            this.blblDicas.Text = formataQuantidade.converterCampo(QuantidadeDicasSalva, LimiteDicasSalva);
            this.blblTotalEstrela.Text = formataQuantidade.converterCampo(EstrelasGanhasSalva, LimiteEstrelasSalva);
        }

        private void mudaCorAcerto(Bunifu.Framework.UI.BunifuCards nomeCards)
        {
            // Muda a cor do fundo do BunifuCards para verde.
            nomeCards.BackColor = Color.FromArgb(33, 167, 68);
            nomeCards.color = Color.FromArgb(33, 167, 68);
        }

        private void salvaListas(frmJogo Nome)
        {
            // Salvando as imagens atuais.
            Nome.ListaImagens = new Bitmap[15];
            Nome.ListaImagens[0] = ListaImagens[0];
            Nome.ListaImagens[1] = ListaImagens[1];
            Nome.ListaImagens[2] = ListaImagens[2];
            Nome.ListaImagens[3] = ListaImagens[3];
            Nome.ListaImagens[4] = ListaImagens[4];
            Nome.ListaImagens[5] = ListaImagens[5];
            Nome.ListaImagens[6] = ListaImagens[6];
            Nome.ListaImagens[7] = ListaImagens[7];
            Nome.ListaImagens[8] = ListaImagens[8];
            Nome.ListaImagens[9] = ListaImagens[9];
            Nome.ListaImagens[10] = ListaImagens[10];
            Nome.ListaImagens[11] = ListaImagens[11];
            Nome.ListaImagens[12] = ListaImagens[12];
            Nome.ListaImagens[13] = ListaImagens[13];
            Nome.ListaImagens[14] = ListaImagens[14];

            // Salvando a lista de jogos.
            Nome.ListaJogosSalvos = ListaJogos;

            // Salva a lista de jogos ganhos.
            Nome.ListaJogosGanhos = ListaJogosGanhos;
        }

        private void ibIndex1_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o nome do jogo clicado.
                Jogo.NomeJogo = ListaJogos[0];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[0];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibDicas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quantidade de dicas possuida, acerte algum jogo para ganhar 5 dicas!", "Dicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ibIndex2_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[1];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[1];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex3_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[2];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[2];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex4_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[3];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[3];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex5_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[4];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[4];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex6_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[5];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[5];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex7_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[6];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[6];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex8_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[7];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[7];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex9_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[8];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[8];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex10_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[9];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[9];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex11_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[10];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[10];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex12_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[11];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[11];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex13_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[12];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[12];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex14_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[13];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[13];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibIndex15_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmJogo.
                frmJogo Jogo = new frmJogo();

                // Obtem o jogo clicado.
                Jogo.NomeJogo = ListaJogos[14];

                // Setando a imagem do jogo clicado.
                Jogo.Imagem = ListaImagens[14];

                // Chama o metodo para salvar as listas do jogo.
                salvaListas(Jogo);

                // Chama o metodo para salvar as estrelas e dicas obtidas para o frmJogo.
                salvaEstrelasEDicas(Jogo);

                this.Dispose();
                Jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
