using QuizGamer.Model;
using QuizGamer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizGamer.View
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        public int QuantidadeDicas { get; set; }
        public int LimiteDicas { get; set; }

        public int EstrelasGanhas { get; set; }
        public int LimiteEstrelas { get; set; }

        public List<Bitmap> ListaJogosGanhos { get; set; }

        public int EstrelasGanhasCategoria1 { get; set; }
        public int EstrelasGanhasCategoria2 { get; set; }
        public int EstrelasGanhasCategoria3 { get; set; }
        public int EstrelasGanhasCategoria4 { get; set; }
        public int EstrelasGanhasCategoria5 { get; set; }
        public int EstrelasGanhasCategoria6 { get; set; }
        public int EstrelasGanhasCategoria7 { get; set; }
        public int EstrelasGanhasCategoria8 { get; set; }

        private static int limiteEstrelasCategoria = 15;

        private void frmJogo_Load(object sender, EventArgs e)
        {
            FormataQuantidade formataQuantidade = new FormataQuantidade();

            // Obtendo a quantidade maxima de dicas e colocando no blblDicas.
            blblDicas.Text = formataQuantidade.converterCampo(QuantidadeDicas, LimiteDicas);

            // Obtendo a quantidade maxima de estrelas e colocando no blblTotalEstrela.
            blblTotalEstrela.Text = formataQuantidade.converterCampo(EstrelasGanhas, LimiteEstrelas);

            // Obtendo a quantidade de estrelas ganhas na categoria 1 e aumentando a barra de progresso.
            blblEstrelaJogosPopulares.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria1, limiteEstrelasCategoria);
            pbJogosPopulares.Value = EstrelasGanhasCategoria1;

            // Obtendo a quantidade de estrelas ganhas na categoria 2 e aumentando a barra de progresso.
            blblEstrelaPersonagemPrincipal.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria2, limiteEstrelasCategoria);
            pbPersonagemPrincipal.Value = EstrelasGanhasCategoria2;

            // Verifica se a quantidade de estrelas é suficiente para desbloquear a categoria competitivo.
            if (EstrelasGanhas >= Convert.ToInt32(blblEstrelaCompetitivo.Text))
            {
                ibCadeadoCompetitivo.Visible = false;

                // Obtendo a quantidade de estrelas ganhas na categoria 3 e aumentando a barra de progresso.
                blblEstrelaCompetitivo.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria3, limiteEstrelasCategoria);
                pbCompetitivo.Value = EstrelasGanhasCategoria3;
            }

            // Verifica se a quantidade de estrelas é suficiente para desbloquear a categoria mulheres.
            if (EstrelasGanhas >= Convert.ToInt32(blblEstrelaMulheres.Text))
            {
                ibCadeadoMulheres.Visible = false;

                // Obtendo a quantidade de estrelas ganhas na categoria 4 e aumentando a barra de progresso.
                blblEstrelaMulheres.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria4, limiteEstrelasCategoria);
                pbMulheres.Value = EstrelasGanhasCategoria4;
            }

            // Verifica se a quantidade de estrelas é suficiente para desbloquear a categoria animes.
            if (EstrelasGanhas >= Convert.ToInt32(blblEstrelaAnimes.Text))
            {
                ibCadeadoAnimes.Visible = false;

                // Obtendo a quantidade de estrelas ganhas na categoria 5 e aumentando a barra de progresso.
                blblEstrelaAnimes.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria5, limiteEstrelasCategoria);
                pbAnimes.Value = EstrelasGanhasCategoria5;
            }

            // Verifica se a quantidade de estrelas é suficiente para desbloquear a categoria chefes.
            if (EstrelasGanhas >= Convert.ToInt32(blblEstrelaChefes.Text))
            {
                ibCadeadoChefes.Visible = false;

                // Obtendo a quantidade de estrelas ganhas na categoria 6 e aumentando a barra de progresso.
                blblEstrelaChefes.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria6, limiteEstrelasCategoria);
                pbChefes.Value = EstrelasGanhasCategoria6;
            }

            // Verifica se a quantidade de estrelas é suficiente para desbloquear a categoria pixels.
            if (EstrelasGanhas >= Convert.ToInt32(blblEstrelaPixels.Text))
            {
                ibCadeadoChefes.Visible = false;

                // Obtendo a quantidade de estrelas ganhas na categoria 7 e aumentando a barra de progresso.
                blblEstrelaPixels.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria7, limiteEstrelasCategoria);
                pbPixels.Value = EstrelasGanhasCategoria7;
            }

            // Verifica se a quantidade de estrelas é suficiente para desbloquear a categoria secundarios.
            if (EstrelasGanhas >= Convert.ToInt32(blblEstrelaSecundarios.Text))
            {
                ibCadeadoSecundarios.Visible = false;

                // Obtendo a quantidade de estrelas ganhas na categoria 8 e aumentando a barra de progresso.
                blblEstrelaSecundarios.Text = formataQuantidade.converterCampo(EstrelasGanhasCategoria8, limiteEstrelasCategoria);
                pbSecundarios.Value = EstrelasGanhasCategoria8;
            }
        }

        private void ibFechar_Click(object sender, EventArgs e)
        {
            try
            {
                //Exibe uma mensagem ao tentar sair, caso a resposta seja "Sim", fecha o programa.
                if (MessageBox.Show(" Deseja continuar? ",
                    "Confirmação de saida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
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
                        MessageBox.Show("Ocorreu um erro ao sair: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: \n" + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ibDicas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quantidade de dicas possuida, acerte algum jogo para ganhar 5 dicas!", "Dicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void salvaEstrelasEDicas(frmListaJogo ListaJogo)
        {
            // Salva a quantidade de estrelas e dicas obtidas no frmListaJogo.
            ListaJogo.QuantidadeDicasSalva = this.QuantidadeDicas;
            ListaJogo.LimiteDicasSalva = this.LimiteDicas;

            ListaJogo.EstrelasGanhasSalva = this.EstrelasGanhas;
            ListaJogo.LimiteEstrelasSalva = this.LimiteEstrelas;

            // Salvando as estrelas ganhas na categoria dos jogos.
            ListaJogo.EstrelasGanhasCategoria1 = EstrelasGanhasCategoria1;
            ListaJogo.EstrelasGanhasCategoria2 = EstrelasGanhasCategoria2;
            ListaJogo.EstrelasGanhasCategoria3 = EstrelasGanhasCategoria3;
            ListaJogo.EstrelasGanhasCategoria4 = EstrelasGanhasCategoria4;
            ListaJogo.EstrelasGanhasCategoria5 = EstrelasGanhasCategoria5;
            ListaJogo.EstrelasGanhasCategoria6 = EstrelasGanhasCategoria6;
            ListaJogo.EstrelasGanhasCategoria7 = EstrelasGanhasCategoria7;
            ListaJogo.EstrelasGanhasCategoria8 = EstrelasGanhasCategoria8;
        }

        private void salvaListas(frmListaJogo ListaJogo)
        {
            // Salvando a lista de jogos ganhos.
            ListaJogo.ListaJogosGanhos = ListaJogosGanhos;
        }

        private void ibJogosPopulares_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia dos jogos populares.
                frmListaJogo JogosPopulares = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(JogosPopulares);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(JogosPopulares);

                // Listando os jogos da categoria populares.
                JogosPopulares.ListaJogos = new string[15];
                JogosPopulares.ListaJogos[0] = "Kingdom Hearts";
                JogosPopulares.ListaJogos[1] = "Portal";
                JogosPopulares.ListaJogos[2] = "Pokemon";
                JogosPopulares.ListaJogos[3] = "Sonic";
                JogosPopulares.ListaJogos[4] = "Devil May Cry";
                JogosPopulares.ListaJogos[5] = "Mario";
                JogosPopulares.ListaJogos[6] = "The Sims";
                JogosPopulares.ListaJogos[7] = "Borderlands";
                JogosPopulares.ListaJogos[8] = "Assassins Creed";
                JogosPopulares.ListaJogos[9] = "Halo";
                JogosPopulares.ListaJogos[10] = "Final Fantasy XV";
                JogosPopulares.ListaJogos[11] = "Spyro";
                JogosPopulares.ListaJogos[12] = "CSGO";
                JogosPopulares.ListaJogos[13] = "Detroit Become Human";
                JogosPopulares.ListaJogos[14] = "Persona 5";

                // Setando as imagens para a categoria jogos populares.
                JogosPopulares.ListaImagens = new Bitmap[15];
                JogosPopulares.ListaImagens[0] = Resources.Kingdom_Hearts;
                JogosPopulares.ListaImagens[1] = Resources.Portal;
                JogosPopulares.ListaImagens[2] = Resources.Pokemon;
                JogosPopulares.ListaImagens[3] = Resources.Sonic;
                JogosPopulares.ListaImagens[4] = Resources.Devil_May_Cry;
                JogosPopulares.ListaImagens[5] = Resources.Mario;
                JogosPopulares.ListaImagens[6] = Resources.The_Sims;
                JogosPopulares.ListaImagens[7] = Resources.Borderlands;
                JogosPopulares.ListaImagens[8] = Resources.Assassins_Creed;
                JogosPopulares.ListaImagens[9] = Resources.Halo;
                JogosPopulares.ListaImagens[10] = Resources.Final_Fantasy_XV;
                JogosPopulares.ListaImagens[11] = Resources.Spyro;
                JogosPopulares.ListaImagens[12] = Resources.CSGO;
                JogosPopulares.ListaImagens[13] = Resources.Detroit_Become_Human;
                JogosPopulares.ListaImagens[14] = Resources.Persona_5;

                this.Dispose();
                JogosPopulares.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibCompetitivo_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia dos jogos competitivos.
                frmListaJogo JogosCompetitivos = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(JogosCompetitivos);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(JogosCompetitivos);

                // Listando os jogos da categoria competitivos.
                JogosCompetitivos.ListaJogos = new string[15];
                JogosCompetitivos.ListaJogos[0] = "Valorant";
                JogosCompetitivos.ListaJogos[1] = "Fall Guys";
                JogosCompetitivos.ListaJogos[2] = "Overwatch";
                JogosCompetitivos.ListaJogos[3] = "Street Fighter";
                JogosCompetitivos.ListaJogos[4] = "Super Smash Bros";
                JogosCompetitivos.ListaJogos[5] = "PUBG";
                JogosCompetitivos.ListaJogos[6] = "Dota 2";
                JogosCompetitivos.ListaJogos[7] = "Dragon Ball FighterZ";
                JogosCompetitivos.ListaJogos[8] = "Mortal Kombat";
                JogosCompetitivos.ListaJogos[9] = "Hearthstone";
                JogosCompetitivos.ListaJogos[10] = "League of Legends";
                JogosCompetitivos.ListaJogos[11] = "Fortnite";
                JogosCompetitivos.ListaJogos[12] = "Brawlhalla";
                JogosCompetitivos.ListaJogos[13] = "Rocket League";
                JogosCompetitivos.ListaJogos[14] = "Rainbow Six Siege";

                // Setando as imagens para a categoria jogos competitivos.
                JogosCompetitivos.ListaImagens = new Bitmap[15];
                JogosCompetitivos.ListaImagens[0] = Resources.Valorant;
                JogosCompetitivos.ListaImagens[1] = Resources.Fall_Guys;
                JogosCompetitivos.ListaImagens[2] = Resources.Overwatch;
                JogosCompetitivos.ListaImagens[3] = Resources.Street_Fighter;
                JogosCompetitivos.ListaImagens[4] = Resources.Super_Smash_Bros;
                JogosCompetitivos.ListaImagens[5] = Resources.PUBG;
                JogosCompetitivos.ListaImagens[6] = Resources.Dota_2;
                JogosCompetitivos.ListaImagens[7] = Resources.Dragon_Ball_FighterZ;
                JogosCompetitivos.ListaImagens[8] = Resources.Mortal_Kombat;
                JogosCompetitivos.ListaImagens[9] = Resources.Hearthstone;
                JogosCompetitivos.ListaImagens[10] = Resources.League_of_Legends;
                JogosCompetitivos.ListaImagens[11] = Resources.Fortnite;
                JogosCompetitivos.ListaImagens[12] = Resources.Brawlhalla;
                JogosCompetitivos.ListaImagens[13] = Resources.Rocket_League;
                JogosCompetitivos.ListaImagens[14] = Resources.Tom_Clancys_Rainbow_Six_Siege;

                this.Dispose();
                JogosCompetitivos.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibAnimes_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia dos animes.
                frmListaJogo Animes = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(Animes);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(Animes);

                // Listando os jogos da categoria animes.
                Animes.ListaJogos = new string[15];
                Animes.ListaJogos[0] = "Black Clover";
                Animes.ListaJogos[1] = "Haikyuu!!";
                Animes.ListaJogos[2] = "Jujutsu Kaisen";
                Animes.ListaJogos[3] = "Shokugeki no Souma";
                Animes.ListaJogos[4] = "Shingeki no Kyojin";
                Animes.ListaJogos[5] = "No Game No Life";
                Animes.ListaJogos[6] = "Tate no Yuusha";
                Animes.ListaJogos[7] = "Steins Gate";
                Animes.ListaJogos[8] = "Re:Zero";
                Animes.ListaJogos[9] = "Noragami";
                Animes.ListaJogos[10] = "Tensei Shitara Slime";
                Animes.ListaJogos[11] = "Overlord";
                Animes.ListaJogos[12] = "Kimi no Na wa";
                Animes.ListaJogos[13] = "Monogatari";
                Animes.ListaJogos[14] = "Code Geass";

                // Setando as imagens para a categoria animes.
                Animes.ListaImagens = new Bitmap[15];
                Animes.ListaImagens[0] = Resources.Black_Clover;
                Animes.ListaImagens[1] = Resources.Haikyuu__;
                Animes.ListaImagens[2] = Resources.Jujutsu_Kaisen;
                Animes.ListaImagens[3] = Resources.Shokugeki_no_Souma;
                Animes.ListaImagens[4] = Resources.Shingeki_no_Kyojin;
                Animes.ListaImagens[5] = Resources.No_Game_No_Life;
                Animes.ListaImagens[6] = Resources.Tate_no_Yuusha;
                Animes.ListaImagens[7] = Resources.Steins_Gate;
                Animes.ListaImagens[8] = Resources.Re_Zero;
                Animes.ListaImagens[9] = Resources.Noragami;
                Animes.ListaImagens[10] = Resources.Tensei_Shitara_Slime_Datta_Ken;
                Animes.ListaImagens[11] = Resources.Overlord;
                Animes.ListaImagens[12] = Resources.Kimi_no_Na_wa;
                Animes.ListaImagens[13] = Resources.Monogatari;
                Animes.ListaImagens[14] = Resources.Code_Geass;

                this.Dispose();
                Animes.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibPixels_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia dos jogos de pixels.
                frmListaJogo Pixels = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(Pixels);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(Pixels);

                // Listando os jogos da categoria pixels.
                Pixels.ListaJogos = new string[15];
                Pixels.ListaJogos[0] = "Minecraft";
                Pixels.ListaJogos[1] = "Terraria";
                Pixels.ListaJogos[2] = "Dead Cells";
                Pixels.ListaJogos[3] = "Stardew Valley";
                Pixels.ListaJogos[4] = "Starbound";
                Pixels.ListaJogos[5] = "Enter the Gungeon";
                Pixels.ListaJogos[6] = "Undertale";
                Pixels.ListaJogos[7] = "The Bind of Isaac";
                Pixels.ListaJogos[8] = "Fez";
                Pixels.ListaJogos[9] = "Celeste";
                Pixels.ListaJogos[10] = "Shovel Knight";
                Pixels.ListaJogos[11] = "Risk of Rain";
                Pixels.ListaJogos[12] = "Wizard of Legend";
                Pixels.ListaJogos[13] = "Super Meat Boy";
                Pixels.ListaJogos[14] = "Pokemon Ruby E Sapphire";

                // Setando as imagens para categoria jogos de pixels.
                Pixels.ListaImagens = new Bitmap[15];
                Pixels.ListaImagens[0] = Resources.Minecraft;
                Pixels.ListaImagens[1] = Resources.Terraria;
                Pixels.ListaImagens[2] = Resources.Dead_Cells;
                Pixels.ListaImagens[3] = Resources.Stardew_Valley;
                Pixels.ListaImagens[4] = Resources.Starbound;
                Pixels.ListaImagens[5] = Resources.Enter_the_Gungeon;
                Pixels.ListaImagens[6] = Resources.Undertale;
                Pixels.ListaImagens[7] = Resources.The_Bind_of_Isaac;
                Pixels.ListaImagens[8] = Resources.Fez;
                Pixels.ListaImagens[9] = Resources.Celeste;
                Pixels.ListaImagens[10] = Resources.Shovel_Knight;
                Pixels.ListaImagens[11] = Resources.Risk_of_Rain;
                Pixels.ListaImagens[12] = Resources.Wizard_of_Legend;
                Pixels.ListaImagens[13] = Resources.Super_Meat_Boy;
                Pixels.ListaImagens[14] = Resources.Pokemon_Ruby___Sapphire;

                this.Dispose();
                Pixels.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibPersonagemPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia dos personagens principais.
                frmListaJogo PersonagemPrincipal = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(PersonagemPrincipal);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(PersonagemPrincipal);

                // Listando os jogos da categoria personagens principais.
                PersonagemPrincipal.ListaJogos = new string[15];
                PersonagemPrincipal.ListaJogos[0] = "Superhot";
                PersonagemPrincipal.ListaJogos[1] = "Metal Gear Solid";
                PersonagemPrincipal.ListaJogos[2] = "The Last of Us";
                PersonagemPrincipal.ListaJogos[3] = "The Witcher";
                PersonagemPrincipal.ListaJogos[4] = "Pokemon";
                PersonagemPrincipal.ListaJogos[5] = "God of War";
                PersonagemPrincipal.ListaJogos[6] = "Watch Dogs";
                PersonagemPrincipal.ListaJogos[7] = "Life is Strange";
                PersonagemPrincipal.ListaJogos[8] = "Crash";
                PersonagemPrincipal.ListaJogos[9] = "Yandere Simulator";
                PersonagemPrincipal.ListaJogos[10] = "Little Nightmares";
                PersonagemPrincipal.ListaJogos[11] = "Fate Extella";
                PersonagemPrincipal.ListaJogos[12] = "Horizon Zero Dawn";
                PersonagemPrincipal.ListaJogos[13] = "Metroid";
                PersonagemPrincipal.ListaJogos[14] = "Untitled Goose Game";

                // Setando as imagens para categoria personagens principais.
                PersonagemPrincipal.ListaImagens = new Bitmap[15];
                PersonagemPrincipal.ListaImagens[0] = Resources.Superhot;
                PersonagemPrincipal.ListaImagens[1] = Resources.Metal_Gear_Solid;
                PersonagemPrincipal.ListaImagens[2] = Resources.The_Last_of_Us;
                PersonagemPrincipal.ListaImagens[3] = Resources.The_Witcher;
                PersonagemPrincipal.ListaImagens[4] = Resources.Principal_Pokemon;
                PersonagemPrincipal.ListaImagens[5] = Resources.God_of_War;
                PersonagemPrincipal.ListaImagens[6] = Resources.Watch_Dogs;
                PersonagemPrincipal.ListaImagens[7] = Resources.Life_is_Strange;
                PersonagemPrincipal.ListaImagens[8] = Resources.Crash;
                PersonagemPrincipal.ListaImagens[9] = Resources.Yandere_Simulator;
                PersonagemPrincipal.ListaImagens[10] = Resources.Little_Nightmares;
                PersonagemPrincipal.ListaImagens[11] = Resources.Fate_Extella;
                PersonagemPrincipal.ListaImagens[12] = Resources.Horizon_Zero_Dawn;
                PersonagemPrincipal.ListaImagens[13] = Resources.Metroid;
                PersonagemPrincipal.ListaImagens[14] = Resources.Untitled_Goose_Game;

                this.Dispose();
                PersonagemPrincipal.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibChefes_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia dos chefes.
                frmListaJogo Chefes = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(Chefes);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(Chefes);

                // Listando os jogos da categoria chefes.
                Chefes.ListaJogos = new string[15];
                Chefes.ListaJogos[0] = "Soul Eater";
                Chefes.ListaJogos[1] = "Naruto Ninja Storm 3";
                Chefes.ListaJogos[2] = "Portal";
                Chefes.ListaJogos[3] = "Crash";
                Chefes.ListaJogos[4] = "Silent Hill";
                Chefes.ListaJogos[5] = "Five Night at Freddys";
                Chefes.ListaJogos[6] = "Far Cry 3";
                Chefes.ListaJogos[7] = "Batman Arkhan Asylum";
                Chefes.ListaJogos[8] = "Undertale";
                Chefes.ListaJogos[9] = "Super Mario 3D World";
                Chefes.ListaJogos[10] = "Cuphead";
                Chefes.ListaJogos[11] = "Star Wars";
                Chefes.ListaJogos[12] = "Bomberman";
                Chefes.ListaJogos[13] = "Final Fantasy VII";
                Chefes.ListaJogos[14] = "Hollow Knight";

                // Setando as imagens para categoria chefes.
                Chefes.ListaImagens = new Bitmap[15];
                Chefes.ListaImagens[0] = Resources.Soul_Eater;
                Chefes.ListaImagens[1] = Resources.Naruto_Ninja_Storm_3;
                Chefes.ListaImagens[2] = Resources.Chefe_Portal;
                Chefes.ListaImagens[3] = Resources.Chefe_Crash;
                Chefes.ListaImagens[4] = Resources.Silent_Hill;
                Chefes.ListaImagens[5] = Resources.Five_Night_at_Freddys;
                Chefes.ListaImagens[6] = Resources.Far_Cry_3;
                Chefes.ListaImagens[7] = Resources.Batman_Arkhan_Asylum;
                Chefes.ListaImagens[8] = Resources.Chefe_Undertale;
                Chefes.ListaImagens[9] = Resources.Super_Mario_3D_World;
                Chefes.ListaImagens[10] = Resources.Chefe_Cuphead;
                Chefes.ListaImagens[11] = Resources.Star_Wars;
                Chefes.ListaImagens[12] = Resources.Bomberman;
                Chefes.ListaImagens[13] = Resources.Final_Fantasy_VII;
                Chefes.ListaImagens[14] = Resources.Hollow_Knight;

                this.Dispose();
                Chefes.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibMulheres_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia das mulheres.
                frmListaJogo Mulheres = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(Mulheres);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(Mulheres);

                // Listando os jogos da categoria mulheres.
                Mulheres.ListaJogos = new string[15];
                Mulheres.ListaJogos[0] = "Tenki no Ko";
                Mulheres.ListaJogos[1] = "Death Note";
                Mulheres.ListaJogos[2] = "Dragon Ball Z";
                Mulheres.ListaJogos[3] = "Genshin Impact";
                Mulheres.ListaJogos[4] = "Boku no Hero";
                Mulheres.ListaJogos[5] = "Sword Art Online";
                Mulheres.ListaJogos[6] = "Kyoukai no Kanata";
                Mulheres.ListaJogos[7] = "Akame ga Kill";
                Mulheres.ListaJogos[8] = "Highschool DxD";
                Mulheres.ListaJogos[9] = "Fairy Tail";
                Mulheres.ListaJogos[10] = "Darling In The FranXX";
                Mulheres.ListaJogos[11] = "Violet Evergarden";
                Mulheres.ListaJogos[12] = "Nisekoi";
                Mulheres.ListaJogos[13] = "Love is War";
                Mulheres.ListaJogos[14] = "Konosuba";

                // Setando as imagens para categoria mulheres.
                Mulheres.ListaImagens = new Bitmap[15];
                Mulheres.ListaImagens[0] = Resources.Tenki_no_Ko;
                Mulheres.ListaImagens[1] = Resources.Death_Note;
                Mulheres.ListaImagens[2] = Resources.Dragon_Ball_Z;
                Mulheres.ListaImagens[3] = Resources.Genshin_Impact;
                Mulheres.ListaImagens[4] = Resources.Boku_no_Hero;
                Mulheres.ListaImagens[5] = Resources.Sword_Art_Online;
                Mulheres.ListaImagens[6] = Resources.Kyoukai_no_Kanata;
                Mulheres.ListaImagens[7] = Resources.Akame_ga_Kill;
                Mulheres.ListaImagens[8] = Resources.Highschool_DxD;
                Mulheres.ListaImagens[9] = Resources.Fairy_Tail;
                Mulheres.ListaImagens[10] = Resources.Darling_In_The_FranXX;
                Mulheres.ListaImagens[11] = Resources.Violet_Evergarden;
                Mulheres.ListaImagens[12] = Resources.Nisekoi;
                Mulheres.ListaImagens[13] = Resources.Love_is_War;
                Mulheres.ListaImagens[14] = Resources.Konosuba;

                this.Dispose();
                Mulheres.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibSecundarios_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmListaJogo com a instancia dos personagens secundarios.
                frmListaJogo Secundarios = new frmListaJogo();

                // Chama o metodo salvaListas.
                salvaListas(Secundarios);

                // Chama o metodo para salvar as estrelas e as dicas obtidas.
                salvaEstrelasEDicas(Secundarios);

                // Listando os jogos da categoria personagens secundarios.
                Secundarios.ListaJogos = new string[15];
                Secundarios.ListaJogos[0] = "NieR Automata";
                Secundarios.ListaJogos[1] = "Devil May Cry";
                Secundarios.ListaJogos[2] = "Sonic";
                Secundarios.ListaJogos[3] = "The Legend Of Zelda";
                Secundarios.ListaJogos[4] = "Mortal Kombat";
                Secundarios.ListaJogos[5] = "Demon Slayer";
                Secundarios.ListaJogos[6] = "Dr Stone";
                Secundarios.ListaJogos[7] = "My Hero Academia";
                Secundarios.ListaJogos[8] = "One Punch Man";
                Secundarios.ListaJogos[9] = "Attack On Titan";
                Secundarios.ListaJogos[10] = "Death Note";
                Secundarios.ListaJogos[11] = "One Piece";
                Secundarios.ListaJogos[12] = "Bleach";
                Secundarios.ListaJogos[13] = "Fairy Tail";
                Secundarios.ListaJogos[14] = "World Trigger";

                // Setando as imagens para categoria personagens secundarios.
                Secundarios.ListaImagens = new Bitmap[15];
                Secundarios.ListaImagens[0] = Resources.Secundario_NieR_Automata;
                Secundarios.ListaImagens[1] = Resources.Secundario_Devil_May_Cry;
                Secundarios.ListaImagens[2] = Resources.Secundario_Sonic;
                Secundarios.ListaImagens[3] = Resources.The_Legend_Of_Zelda;
                Secundarios.ListaImagens[4] = Resources.Secundario_Mortal_Kombat;
                Secundarios.ListaImagens[5] = Resources.Demon_Slayer;
                Secundarios.ListaImagens[6] = Resources.Dr_Stone;
                Secundarios.ListaImagens[7] = Resources.My_Hero_Academia;
                Secundarios.ListaImagens[8] = Resources.One_Punch_Man;
                Secundarios.ListaImagens[9] = Resources.Attack_On_Titan;
                Secundarios.ListaImagens[10] = Resources.Secundario_Death_Note;
                Secundarios.ListaImagens[11] = Resources.One_Piece;
                Secundarios.ListaImagens[12] = Resources.Bleach;
                Secundarios.ListaImagens[13] = Resources.Secundario_Fairy_Tail;
                Secundarios.ListaImagens[14] = Resources.World_Trigger;

                this.Dispose();
                Secundarios.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
