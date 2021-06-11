using QuizGamer.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizGamer.View
{
    public partial class frmJogo : Form
    {
        public frmJogo()
        {
            InitializeComponent();
        }

        public int EstrelasGanhasCategoria1 { get; set; }
        public int EstrelasGanhasCategoria2 { get; set; }
        public int EstrelasGanhasCategoria3 { get; set; }
        public int EstrelasGanhasCategoria4 { get; set; }
        public int EstrelasGanhasCategoria5 { get; set; }
        public int EstrelasGanhasCategoria6 { get; set; }
        public int EstrelasGanhasCategoria7 { get; set; }
        public int EstrelasGanhasCategoria8 { get; set; }


        // Carrega a lista de jogos salvos.
        public List<Bitmap> ListaJogosGanhos { get; set; }

        // Carregando as dicas e as estrelas para esse formulario.
        public int QuantidadeDicas { get; set; }
        public int LimiteDicas { get; set; }

        public int EstrelasGanhas { get; set; }
        public int LimiteEstrelas { get; set; }

        // Carregando a lista de nomes dos jogos da categoria selecionada.
        public string[] ListaJogosSalvos { get; set; }

        // Carregando o nome do jogo escolhido.
        public string NomeJogo { get; set; }

        // Carregando a imagem do jogo escolhido.
        public Bitmap Imagem { get; set; }

        // Carregando as imagens dos jogos para esse formulario.
        public Bitmap[] ListaImagens { get; set; }

        // Quantidade maxima possivel de dicas ganhas por acerto.
        private static int quantidadeDicasGanha = 5;

        // Salvando a posicao do botao clicado.
        Point[] SalvaPosicaoBotao = new Point[27];

        // Verificacao do click dos botoes.
        bool fbtnLetra1Clicado = false;
        bool fbtnLetra2Clicado = false;
        bool fbtnLetra3Clicado = false;
        bool fbtnLetra4Clicado = false;
        bool fbtnLetra5Clicado = false;
        bool fbtnLetra6Clicado = false;
        bool fbtnLetra7Clicado = false;
        bool fbtnLetra8Clicado = false;
        bool fbtnLetra9Clicado = false;
        bool fbtnLetra10Clicado = false;
        bool fbtnLetra11Clicado = false;
        bool fbtnLetra12Clicado = false;
        bool fbtnLetra13Clicado = false;
        bool fbtnLetra14Clicado = false;
        bool fbtnLetra15Clicado = false;
        bool fbtnLetra16Clicado = false;
        bool fbtnLetra17Clicado = false;
        bool fbtnLetra18Clicado = false;
        bool fbtnLetra19Clicado = false;
        bool fbtnLetra20Clicado = false;
        bool fbtnLetra21Clicado = false;
        bool fbtnLetra22Clicado = false;
        bool fbtnLetra23Clicado = false;
        bool fbtnLetra24Clicado = false;
        bool fbtnLetra25Clicado = false;
        bool fbtnLetra26Clicado = false;
        bool fbtnLetra27Clicado = false;

        // Salva a posicao das letras (back-end).
        int posicaoLetraBotao1 = 0;
        int posicaoLetraBotao2 = 0;
        int posicaoLetraBotao3 = 0;
        int posicaoLetraBotao4 = 0;
        int posicaoLetraBotao5 = 0;
        int posicaoLetraBotao6 = 0;
        int posicaoLetraBotao7 = 0;
        int posicaoLetraBotao8 = 0;
        int posicaoLetraBotao9 = 0;
        int posicaoLetraBotao10 = 0;
        int posicaoLetraBotao11 = 0;
        int posicaoLetraBotao12 = 0;
        int posicaoLetraBotao13 = 0;
        int posicaoLetraBotao14 = 0;
        int posicaoLetraBotao15 = 0;
        int posicaoLetraBotao16 = 0;
        int posicaoLetraBotao17 = 0;
        int posicaoLetraBotao18 = 0;
        int posicaoLetraBotao19 = 0;
        int posicaoLetraBotao20 = 0;
        int posicaoLetraBotao21 = 0;
        int posicaoLetraBotao22 = 0;
        int posicaoLetraBotao23 = 0;
        int posicaoLetraBotao24 = 0;
        int posicaoLetraBotao25 = 0;
        int posicaoLetraBotao26 = 0;
        int posicaoLetraBotao27 = 0;

        // Posicao da letra (back-end).
        int posicaoLetra = 0;

        // Lista das posicoes das letras tiradas (back-end).
        List<int> posicoesLetrasTiradas = new List<int>();

        // Lista de letras (back-end).
        string[] listaLetras;

        // Usado para posicionar os botoes no lugar certo.
        int X = 17;
        int Y = 265;
        int maximoEsquerda;

        // Cria uma lista de posicoes de botoes tirados.
        List<Point> listaPosicoesTiradas = new List<Point>();

        // Usado para calcular onde posiciona os botoes quando tem espaco.
        int quantidadeLetras = 0;
        int quantidadeEspaco = 0;

        // Usado para obter a palavra do jogo sem espaco.
        string nomeJogoSemEspaco;

        // Usado para verificar se o jogo ja foi ganho alguma vez.
        bool JogoGanho = false;

        // Usado para guardar os numeros aleatorios gerados para a dica.
        List<int> numerosDicas = new List<int>();

        private void frmJogo_Load(object sender, EventArgs e)
        {
            // Carrega a imagem do jogo clicado.
            ibJogo.Image = Imagem;

            // Verifica se algum jogo ja foi ganho.
            if (EstrelasGanhas > 0)
            {
                ManipuladorImagem manipuladorImagem = new ManipuladorImagem();

                // Procura se a imagem do jogo esta na lista de imagens de jogos ganhos.
                for (int i = 0; i < EstrelasGanhas; i++)
                {
                    // Se achar o jogo na lista, desativa o aumento das estrelas ao acertar e chama o metodo mudaCorAcerto.
                    if (manipuladorImagem.comparaImagem(Imagem, ListaJogosGanhos[i]) == true)
                    {
                        JogoGanho = true;
                        mudaCorAcerto();
                    }
                }
            }

            // Chama o metodo para atualizar as estrelas e dicas.
            atualizaEstrelasEDicas();

            // Chama o metodo para criar os campos das letras.
            criarJogo(NomeJogo);

            // Chama o metodo para gerar 27 letras aleatorias e coloca nos 27 botoes.
            string[] letrasGeradas = new string[27];
            geraLetras(letrasGeradas);

            fbtnLetra1.Text = letrasGeradas[0];
            fbtnLetra2.Text = letrasGeradas[1];
            fbtnLetra3.Text = letrasGeradas[2];
            fbtnLetra4.Text = letrasGeradas[3];
            fbtnLetra5.Text = letrasGeradas[4];
            fbtnLetra6.Text = letrasGeradas[5];
            fbtnLetra7.Text = letrasGeradas[6];
            fbtnLetra8.Text = letrasGeradas[7];
            fbtnLetra9.Text = letrasGeradas[8];
            fbtnLetra10.Text = letrasGeradas[9];
            fbtnLetra11.Text = letrasGeradas[10];
            fbtnLetra12.Text = letrasGeradas[11];
            fbtnLetra13.Text = letrasGeradas[12];
            fbtnLetra14.Text = letrasGeradas[13];
            fbtnLetra15.Text = letrasGeradas[14];
            fbtnLetra16.Text = letrasGeradas[15];
            fbtnLetra17.Text = letrasGeradas[16];
            fbtnLetra18.Text = letrasGeradas[17];
            fbtnLetra19.Text = letrasGeradas[18];
            fbtnLetra20.Text = letrasGeradas[19];
            fbtnLetra21.Text = letrasGeradas[20];
            fbtnLetra22.Text = letrasGeradas[21];
            fbtnLetra23.Text = letrasGeradas[22];
            fbtnLetra24.Text = letrasGeradas[23];
            fbtnLetra25.Text = letrasGeradas[24];
            fbtnLetra26.Text = letrasGeradas[25];
            fbtnLetra27.Text = letrasGeradas[26];

            // Retira o espaco do nome do jogo selecionado.
            nomeJogoSemEspaco = NomeJogo;
            nomeJogoSemEspaco = nomeJogoSemEspaco.Replace(" ", String.Empty);

            // Salva o limite da tela a esquerda.
            maximoEsquerda = X;

            // Cria uma lista de letras do tamanho do nome do jogo sem espaco.
            listaLetras = new string[nomeJogoSemEspaco.Length];

            // Chama o metodo geraNumerosDicas.
            geraNumerosDicas();
        }

        private void geraNumerosDicas()
        {
            // Gera numeros referente as posicoes das letras do nome do jogo e adiciona na lista numerosDicas.
            for (int i = 0; i < nomeJogoSemEspaco.Length; i++)
            {
                numerosDicas.Add(i);
            }
        }

        private void verificaVitoria()
        {
            string letrasMontada = montaPalavra(listaLetras);

            if (letrasMontada.Length == nomeJogoSemEspaco.Length)
            {
                // Verifica se o usuario acertou o nome do jogo.
                if (letrasMontada == nomeJogoSemEspaco.ToUpper())
                {
                    // Verifica se o jogo ja foi ganho alguma vez.
                    if (JogoGanho == false)
                    {
                        // Aumenta a quantidade de estrelas totais em +1.
                        this.EstrelasGanhas += 1;

                        // Verifica se a quantidade de dicas e maior que 20, se não for, aumenta a quantidade de dicas.
                        if (QuantidadeDicas < 20)
                        {
                            this.QuantidadeDicas += quantidadeDicasGanha;
                        }

                        // Adiciona a imagem do jogo na lista de jogos ganhos.
                        if (EstrelasGanhas > 1)
                        {
                            List<Bitmap> ListaJogosGanhosSalvos = new List<Bitmap>(ListaJogosGanhos);
                            ListaJogosGanhosSalvos.Add(Imagem);

                            ListaJogosGanhos = new List<Bitmap>(ListaJogosGanhosSalvos);
                        }
                        else
                        {
                            ListaJogosGanhos = new List<Bitmap>();
                            ListaJogosGanhos.Add(Imagem);
                        }

                        // Verificando de qual categoria o jogo pertence e aumenta a quantidade de estrelas obtidas na categoria.
                        if (ListaJogosSalvos[0] == "Kingdom Hearts")
                        {
                            EstrelasGanhasCategoria1 += 1;
                        }
                        else if (ListaJogosSalvos[0] == "Superhot")
                        {
                            EstrelasGanhasCategoria2 += 1;
                        }
                        else if (ListaJogosSalvos[0] == "Valorant")
                        {
                            EstrelasGanhasCategoria3 += 1;
                        }
                        else if (ListaJogosSalvos[0] == "Tenki no Ko")
                        {
                            EstrelasGanhasCategoria4 += 1;
                        }
                        else if (ListaJogosSalvos[0] == "Black Clover")
                        {
                            EstrelasGanhasCategoria5 += 1;
                        }
                        else if (ListaJogosSalvos[0] == "Soul Eater")
                        {
                            EstrelasGanhasCategoria6 += 1;
                        }
                        else if (ListaJogosSalvos[0] == "Minecraft")
                        {
                            EstrelasGanhasCategoria7 += 1;
                        }
                        else if (ListaJogosSalvos[0] == "NieR Automata")
                        {
                            EstrelasGanhasCategoria8 += 1;
                        }

                        // Seta o jogo ganho para verdadeiro.
                        JogoGanho = true;
                    }

                    // Chama o metodo mudaCorAcerto.
                    mudaCorAcerto();

                    // Indicativo sonoro de acerto.
                    System.Media.SoundPlayer tocaSom = new System.Media.SoundPlayer(QuizGamer.Properties.Resources.Acerto);
                    tocaSom.Play();

                    // Chama o metodo para atualizar as estrelas e dicas.
                    atualizaEstrelasEDicas();
                }
                else
                {
                    // Indicativo sonoro de erro.
                    System.Media.SoundPlayer tocaSom = new System.Media.SoundPlayer(QuizGamer.Properties.Resources.Erro);
                    tocaSom.Play();
                }
            }
        }

        private void salvaListas(frmListaJogo ListaJogo)
        {
            // Retornando os nomes dos jogos para o frmListaJogo.
            ListaJogo.ListaJogos = ListaJogosSalvos;

            // Retornando as imagens salvas para o formulario frmListaJogo.
            ListaJogo.ListaImagens = new Bitmap[15];
            ListaJogo.ListaImagens[0] = ListaImagens[0];
            ListaJogo.ListaImagens[1] = ListaImagens[1];
            ListaJogo.ListaImagens[2] = ListaImagens[2];
            ListaJogo.ListaImagens[3] = ListaImagens[3];
            ListaJogo.ListaImagens[4] = ListaImagens[4];
            ListaJogo.ListaImagens[5] = ListaImagens[5];
            ListaJogo.ListaImagens[6] = ListaImagens[6];
            ListaJogo.ListaImagens[7] = ListaImagens[7];
            ListaJogo.ListaImagens[8] = ListaImagens[8];
            ListaJogo.ListaImagens[9] = ListaImagens[9];
            ListaJogo.ListaImagens[10] = ListaImagens[10];
            ListaJogo.ListaImagens[11] = ListaImagens[11];
            ListaJogo.ListaImagens[12] = ListaImagens[12];
            ListaJogo.ListaImagens[13] = ListaImagens[13];
            ListaJogo.ListaImagens[14] = ListaImagens[14];

            // Salva a lista de jogos ganhos no frmListaJogo.
            ListaJogo.ListaJogosGanhos = ListaJogosGanhos;
        }

        private void ibVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o formulario frmCategoria.
                frmListaJogo ListaJogo = new frmListaJogo();

                // Chama o metodo para carregar as estrelas e dicas salvas no frmListaJogo.
                carregaEstrelasEDicas(ListaJogo);

                // Chama o metodo para salvar as listas para o frmListaJogo.
                salvaListas(ListaJogo);

                this.Dispose();
                ListaJogo.Show();
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

        private void carregaEstrelasEDicas(frmListaJogo ListaJogo)
        {
            // Carrega a quantidade de estrelas e dicas obtidas para o frmCategoria.
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

        private string[] geraLetras(string[] nomeLista)
        {
            // Gera um numero aleatorio e transforma em uma letra e depois guarda em uma lista de letras geradas.
            Random aleatorio = new Random();
            int[] numerosAleatorios = new int[nomeLista.Length];
            for (int i = 0; i < numerosAleatorios.Length; i++)
            {
                // Gera um numero correspondente a letra do alfabeto.
                numerosAleatorios[i] = aleatorio.Next(0, 25);
            }

            // Troca a numero gerado por uma letra correspondente do alfabeto.
            for (int j = 0; j < nomeLista.Length; j++)
            {
                switch (numerosAleatorios[j])
                {
                    case 0:
                        nomeLista[j] = "A";
                        break;
                    case 1:
                        nomeLista[j] = "B";
                        break;
                    case 2:
                        nomeLista[j] = "C";
                        break;
                    case 3:
                        nomeLista[j] = "D";
                        break;
                    case 4:
                        nomeLista[j] = "E";
                        break;
                    case 5:
                        nomeLista[j] = "F";
                        break;
                    case 6:
                        nomeLista[j] = "G";
                        break;
                    case 7:
                        nomeLista[j] = "H";
                        break;
                    case 8:
                        nomeLista[j] = "I";
                        break;
                    case 9:
                        nomeLista[j] = "J";
                        break;
                    case 10:
                        nomeLista[j] = "K";
                        break;
                    case 11:
                        nomeLista[j] = "L";
                        break;
                    case 12:
                        nomeLista[j] = "M";
                        break;
                    case 13:
                        nomeLista[j] = "N";
                        break;
                    case 14:
                        nomeLista[j] = "O";
                        break;
                    case 15:
                        nomeLista[j] = "P";
                        break;
                    case 16:
                        nomeLista[j] = "Q";
                        break;
                    case 17:
                        nomeLista[j] = "R";
                        break;
                    case 18:
                        nomeLista[j] = "S";
                        break;
                    case 19:
                        nomeLista[j] = "T";
                        break;
                    case 20:
                        nomeLista[j] = "U";
                        break;
                    case 21:
                        nomeLista[j] = "V";
                        break;
                    case 22:
                        nomeLista[j] = "W";
                        break;
                    case 23:
                        nomeLista[j] = "X";
                        break;
                    case 24:
                        nomeLista[j] = "Y";
                        break;
                    case 25:
                        nomeLista[j] = "Z";
                        break;
                }
            }

            Random random = new Random();

            int sorteado;
            int[] verificador = new int[NomeJogo.Length];

            // Cria numeros aleatorios.
            for (int k = 0; k < verificador.Length; k++)
            {
            Inicio:
                sorteado = random.Next(0, 26);

                // Verifica se o numero sorteado já foi sorteado antes.
                for (int l = 0; l < verificador.Length; l++)
                {
                    if (verificador[l] == sorteado)
                    {
                        // Caso o numero ja tenha sido sorteado, sorteia um novo.
                        goto Inicio;
                    }
                }

                // Salva os numeros que passaram a verificacao.
                verificador[k] = sorteado;

                // Troca a posicao do numero aleatorio por uma letra na posicao (k) do nome do jogo.
                if (!String.IsNullOrWhiteSpace(NomeJogo[k].ToString()))
                {
                    nomeLista[sorteado] = char.ToUpper(NomeJogo[k]).ToString();
                }
            }
            return nomeLista;
        }

        private void criarJogo(string nomeJogo)
        {
            // Cria a quantidade de letras do jogo escolhido.
            int localizacaoX = 17;
            int localizacaoY = 265;
            for (int i = 0; i < NomeJogo.Length; i++)
            {
                var btnLetra = new Bunifu.Framework.UI.BunifuFlatButton();
                this.Controls.Add(btnLetra);

                btnLetra.Enabled = false;
                btnLetra.DisabledColor = Color.Gray;
                btnLetra.Textcolor = Color.White;
                btnLetra.TextAlign = ContentAlignment.MiddleCenter;
                btnLetra.Iconimage = global::QuizGamer.Properties.Resources.Trasparente;
                btnLetra.Cursor = DefaultCursor;

                btnLetra.Location = new Point(localizacaoX, localizacaoY);
                btnLetra.Size = new Size(40, 40);

                localizacaoX += 46;

                if (i == 8 || i == 17)
                {
                    localizacaoY += 46;
                    localizacaoX = 17;
                }

                // Verifica se e um espaço vazio e esconde o botão.
                if (NomeJogo[i].ToString() == " ")
                {
                    btnLetra.Visible = false;
                }
            }
        }

        private void atualizaEstrelasEDicas()
        {
            // Carrega a quantidade de dicas e estrelas ganhas, formata e coloca no blblDicas e blblTotalEstrela.
            FormataQuantidade formataQuantidade = new FormataQuantidade();
            this.blblDicas.Text = formataQuantidade.converterCampo(QuantidadeDicas, LimiteDicas);
            this.blblTotalEstrela.Text = formataQuantidade.converterCampo(EstrelasGanhas, LimiteEstrelas);
        }

        private string converteTextoBotao(Bunifu.Framework.UI.BunifuFlatButton nomeBotao)
        {
            // Pega o texto do botao passado.
            return nomeBotao.Text;
        }

        private void colocaBotoes(Bunifu.Framework.UI.BunifuFlatButton nomeBotao)
        {
            // Verifica se tem espaco na direita, caso não tenha, quebra o texto para baixo e reseta a posicao para esquerda.
            if (X == 431)
            {
                X = maximoEsquerda;
                Y += 46;
            }

            // Verifica se a lista tem algum item.
            if (listaPosicoesTiradas.Count > 0)
            {
                
                // Procura qual é o botao mais acima e salva no Y do menorXY.
                int posicaoMenor = 0;
                Point menorXY = new Point(1000, 1000);
                for (int i = 0; i < listaPosicoesTiradas.Count; i++)
                {
                    if (listaPosicoesTiradas[i].Y < menorXY.Y)
                    {
                        menorXY.Y = listaPosicoesTiradas[i].Y;
                    }
                }

                // Procura qual é a posicao que é igual ao menor Y, e procura qual é o menor X.
                for (int j = 0; j < listaPosicoesTiradas.Count; j++)
                {
                    if (listaPosicoesTiradas[j].Y == menorXY.Y)
                    {
                        if (listaPosicoesTiradas[j].X < menorXY.X)
                        {
                            // Salva a posicao do menor X na lista e seta o menor para o achado.
                            menorXY.X = listaPosicoesTiradas[j].X;
                            posicaoMenor = j;
                        }
                    }
                }

                // Coloca o botao na primeiro espaco que encontrar da esquerda e retira a posicao da lista.
                nomeBotao.Location = listaPosicoesTiradas[posicaoMenor];
                listaPosicoesTiradas.RemoveAt(posicaoMenor);
            }
            else
            {
                // Verifica se tem um espaço na posicao atual.
                if (Char.IsWhiteSpace(NomeJogo[quantidadeLetras + quantidadeEspaco]))
                {
                    // Coloca o botao correspondendo o espaco do nome.
                    int XComEspaco = X + 46;
                    nomeBotao.Location = new Point(XComEspaco, Y);
                    X = XComEspaco + 46;

                    quantidadeEspaco += 1;
                }
                else
                {
                    // Coloca o botao na posicao padrao e incrementa o valor padrao.
                    nomeBotao.Location = new Point(X, Y);
                    X += 46;
                }

                // Verifica se tem um espaco no lugar da quebra do nome.
                if (X == 477)
                {
                    X = maximoEsquerda;
                    Y += 46;

                    nomeBotao.Location = new Point(X, Y);

                    X += 46;
                }
            }
            quantidadeLetras += 1;
        }

        private void retiraBotoes(Bunifu.Framework.UI.BunifuFlatButton nomeBotao)
        {
            // Adiciona a localizacao do botao na lista listaPosicoesTiradas.
            listaPosicoesTiradas.Add(nomeBotao.Location);

            quantidadeLetras -= 1;
        }

        private void mudaCorAcerto()
        {
            // Muda a cor de fundo para verde.
            bcJogo.BackColor = Color.FromArgb(33, 167, 68);
            bcJogo.color = Color.FromArgb(33, 167, 68);
        }

        private string montaPalavra(string[] listaLetras)
        {
            // Monta a palavra com as letras que o usuario esta clicando.
            string palavraMontada = "";
            foreach (var letra in listaLetras)
            {
                palavraMontada += letra;
            }
            return palavraMontada;
        }

        private void adicionaLetraPalavra(int posicao, string letra)
        {
            // Adiciona a letra na posicao.
            listaLetras[posicao] = letra;

            // Remove o numero na lista referente a posicao da letra colocada.
            numerosDicas.Remove(posicao);
        }

        private void removeLetraPalavra(int posicao)
        {
            // Remove a letra da posicao.
            listaLetras[posicao] = "";

            // Adiciona o numero na lista referente a posicao da letra retirada.
            numerosDicas.Insert(0, posicao);
        }

        private void fbtnLetra1_Click(object sender, EventArgs e)
        {
            if (fbtnLetra1Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[0] = fbtnLetra1.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao1 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao1 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao1, converteTextoBotao(fbtnLetra1));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra1);

                    fbtnLetra1Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao1);
                removeLetraPalavra(posicaoLetraBotao1);

                // Chama o metodo 
                retiraBotoes(fbtnLetra1);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra1.Location = SalvaPosicaoBotao[0];

                fbtnLetra1Clicado = false;
            }
        }

        private void fbtnLetra2_Click(object sender, EventArgs e)
        {
            if (fbtnLetra2Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[1] = fbtnLetra2.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao2 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao2 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao2, converteTextoBotao(fbtnLetra2));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra2);

                    fbtnLetra2Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao2);
                removeLetraPalavra(posicaoLetraBotao2);

                // Chama o metodo 
                retiraBotoes(fbtnLetra2);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra2.Location = SalvaPosicaoBotao[1];

                fbtnLetra2Clicado = false;
            }
        }

        private void fbtnLetra3_Click(object sender, EventArgs e)
        {
            if (fbtnLetra3Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[2] = fbtnLetra3.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao3 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao3 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao3, converteTextoBotao(fbtnLetra3));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra3);

                    fbtnLetra3Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao3);
                removeLetraPalavra(posicaoLetraBotao3);

                // Chama o metodo 
                retiraBotoes(fbtnLetra3);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra3.Location = SalvaPosicaoBotao[2];

                fbtnLetra3Clicado = false;
            }
        }

        private void fbtnLetra4_Click(object sender, EventArgs e)
        {
            if (fbtnLetra4Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[3] = fbtnLetra4.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao4 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao4 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao4, converteTextoBotao(fbtnLetra4));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra4);

                    fbtnLetra4Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao4);
                removeLetraPalavra(posicaoLetraBotao4);

                // Chama o metodo 
                retiraBotoes(fbtnLetra4);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra4.Location = SalvaPosicaoBotao[3];

                fbtnLetra4Clicado = false;
            }
        }

        private void fbtnLetra5_Click(object sender, EventArgs e)
        {
            if (fbtnLetra5Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[4] = fbtnLetra5.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao5 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao5 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao5, converteTextoBotao(fbtnLetra5));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra5);

                    fbtnLetra5Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao5);
                removeLetraPalavra(posicaoLetraBotao5);

                // Chama o metodo 
                retiraBotoes(fbtnLetra5);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra5.Location = SalvaPosicaoBotao[4];

                fbtnLetra5Clicado = false;
            }
        }

        private void fbtnLetra6_Click(object sender, EventArgs e)
        {
            if (fbtnLetra6Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[5] = fbtnLetra6.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao6 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao6 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao6, converteTextoBotao(fbtnLetra6));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra6);

                    fbtnLetra6Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao6);
                removeLetraPalavra(posicaoLetraBotao6);

                // Chama o metodo 
                retiraBotoes(fbtnLetra6);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra6.Location = SalvaPosicaoBotao[5];

                fbtnLetra6Clicado = false;
            }
        }

        private void fbtnLetra7_Click(object sender, EventArgs e)
        {
            if (fbtnLetra7Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[6] = fbtnLetra7.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao7 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao7 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao7, converteTextoBotao(fbtnLetra7));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra7);

                    fbtnLetra7Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao7);
                removeLetraPalavra(posicaoLetraBotao7);

                // Chama o metodo 
                retiraBotoes(fbtnLetra7);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra7.Location = SalvaPosicaoBotao[6];

                fbtnLetra7Clicado = false;
            }
        }

        private void fbtnLetra8_Click(object sender, EventArgs e)
        {
            if (fbtnLetra8Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[7] = fbtnLetra8.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao8 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao8 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao8, converteTextoBotao(fbtnLetra8));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra8);

                    fbtnLetra8Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao8);
                removeLetraPalavra(posicaoLetraBotao8);

                // Chama o metodo 
                retiraBotoes(fbtnLetra8);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra8.Location = SalvaPosicaoBotao[7];

                fbtnLetra8Clicado = false;
            }
        }

        private void fbtnLetra9_Click(object sender, EventArgs e)
        {
            if (fbtnLetra9Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[8] = fbtnLetra9.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao9 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao9 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao9, converteTextoBotao(fbtnLetra9));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra9);

                    fbtnLetra9Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao9);
                removeLetraPalavra(posicaoLetraBotao9);

                // Chama o metodo 
                retiraBotoes(fbtnLetra9);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra9.Location = SalvaPosicaoBotao[8];

                fbtnLetra9Clicado = false;
            }
        }

        private void fbtnLetra10_Click(object sender, EventArgs e)
        {
            if (fbtnLetra10Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[9] = fbtnLetra10.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao10 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao10 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao10, converteTextoBotao(fbtnLetra10));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra10);

                    fbtnLetra10Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao10);
                removeLetraPalavra(posicaoLetraBotao10);

                // Chama o metodo 
                retiraBotoes(fbtnLetra10);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra10.Location = SalvaPosicaoBotao[9];

                fbtnLetra10Clicado = false;
            }
        }

        private void fbtnLetra11_Click(object sender, EventArgs e)
        {
            if (fbtnLetra11Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[10] = fbtnLetra11.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao11 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao11 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao11, converteTextoBotao(fbtnLetra11));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra11);

                    fbtnLetra11Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao11);
                removeLetraPalavra(posicaoLetraBotao11);

                // Chama o metodo 
                retiraBotoes(fbtnLetra11);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra11.Location = SalvaPosicaoBotao[10];

                fbtnLetra11Clicado = false;
            }
        }

        private void fbtnLetra12_Click(object sender, EventArgs e)
        {
            if (fbtnLetra12Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[11] = fbtnLetra12.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao12 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao12 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao12, converteTextoBotao(fbtnLetra12));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra12);

                    fbtnLetra12Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao12);
                removeLetraPalavra(posicaoLetraBotao12);

                // Chama o metodo 
                retiraBotoes(fbtnLetra12);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra12.Location = SalvaPosicaoBotao[11];

                fbtnLetra12Clicado = false;
            }
        }

        private void fbtnLetra13_Click(object sender, EventArgs e)
        {
            if (fbtnLetra13Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[12] = fbtnLetra13.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao13 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao13 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao13, converteTextoBotao(fbtnLetra13));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra13);

                    fbtnLetra13Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao13);
                removeLetraPalavra(posicaoLetraBotao13);

                // Chama o metodo 
                retiraBotoes(fbtnLetra13);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra13.Location = SalvaPosicaoBotao[12];

                fbtnLetra13Clicado = false;
            }
        }

        private void fbtnLetra14_Click(object sender, EventArgs e)
        {
            if (fbtnLetra14Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[13] = fbtnLetra14.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao14 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao14 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao14, converteTextoBotao(fbtnLetra14));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra14);

                    fbtnLetra14Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao14);
                removeLetraPalavra(posicaoLetraBotao14);

                // Chama o metodo 
                retiraBotoes(fbtnLetra14);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra14.Location = SalvaPosicaoBotao[13];

                fbtnLetra14Clicado = false;
            }
        }

        private void fbtnLetra15_Click(object sender, EventArgs e)
        {
            if (fbtnLetra15Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[14] = fbtnLetra15.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao15 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao15 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao15, converteTextoBotao(fbtnLetra15));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra15);

                    fbtnLetra15Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao15);
                removeLetraPalavra(posicaoLetraBotao15);

                // Chama o metodo 
                retiraBotoes(fbtnLetra15);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra15.Location = SalvaPosicaoBotao[14];

                fbtnLetra15Clicado = false;
            }
        }

        private void fbtnLetra16_Click(object sender, EventArgs e)
        {
            if (fbtnLetra16Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[15] = fbtnLetra16.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao16 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao16 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao16, converteTextoBotao(fbtnLetra16));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra16);

                    fbtnLetra16Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao16);
                removeLetraPalavra(posicaoLetraBotao16);

                // Chama o metodo 
                retiraBotoes(fbtnLetra16);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra16.Location = SalvaPosicaoBotao[15];

                fbtnLetra16Clicado = false;
            }
        }

        private void fbtnLetra17_Click(object sender, EventArgs e)
        {
            if (fbtnLetra17Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[16] = fbtnLetra17.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao17 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao17 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao17, converteTextoBotao(fbtnLetra17));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra17);

                    fbtnLetra17Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao17);
                removeLetraPalavra(posicaoLetraBotao17);

                // Chama o metodo 
                retiraBotoes(fbtnLetra17);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra17.Location = SalvaPosicaoBotao[16];

                fbtnLetra17Clicado = false;
            }
        }

        private void fbtnLetra18_Click(object sender, EventArgs e)
        {
            if (fbtnLetra18Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[17] = fbtnLetra18.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao18 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao18 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao18, converteTextoBotao(fbtnLetra18));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra18);

                    fbtnLetra18Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao18);
                removeLetraPalavra(posicaoLetraBotao18);

                // Chama o metodo 
                retiraBotoes(fbtnLetra18);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra18.Location = SalvaPosicaoBotao[17];

                fbtnLetra18Clicado = false;
            }
        }

        private void fbtnLetra19_Click(object sender, EventArgs e)
        {
            if (fbtnLetra19Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[18] = fbtnLetra19.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao19 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao19 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao19, converteTextoBotao(fbtnLetra19));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra19);

                    fbtnLetra19Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao19);
                removeLetraPalavra(posicaoLetraBotao19);

                // Chama o metodo 
                retiraBotoes(fbtnLetra19);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra19.Location = SalvaPosicaoBotao[18];

                fbtnLetra19Clicado = false;
            }
        }

        private void fbtnLetra20_Click(object sender, EventArgs e)
        {
            if (fbtnLetra20Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[19] = fbtnLetra20.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao20 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao20 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao20, converteTextoBotao(fbtnLetra20));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra20);

                    fbtnLetra20Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao20);
                removeLetraPalavra(posicaoLetraBotao20);

                // Chama o metodo 
                retiraBotoes(fbtnLetra20);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra20.Location = SalvaPosicaoBotao[19];

                fbtnLetra20Clicado = false;
            }
        }

        private void fbtnLetra21_Click(object sender, EventArgs e)
        {
            if (fbtnLetra21Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[20] = fbtnLetra21.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao21 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao21 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao21, converteTextoBotao(fbtnLetra21));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra21);

                    fbtnLetra21Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao21);
                removeLetraPalavra(posicaoLetraBotao21);

                // Chama o metodo 
                retiraBotoes(fbtnLetra21);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra21.Location = SalvaPosicaoBotao[20];

                fbtnLetra21Clicado = false;
            }
        }

        private void fbtnLetra22_Click(object sender, EventArgs e)
        {
            if (fbtnLetra22Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[21] = fbtnLetra22.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao22 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao22 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao22, converteTextoBotao(fbtnLetra22));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra22);

                    fbtnLetra22Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao22);
                removeLetraPalavra(posicaoLetraBotao22);

                // Chama o metodo 
                retiraBotoes(fbtnLetra22);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra22.Location = SalvaPosicaoBotao[21];

                fbtnLetra22Clicado = false;
            }
        }

        private void fbtnLetra23_Click(object sender, EventArgs e)
        {
            if (fbtnLetra23Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[22] = fbtnLetra23.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao23 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao23 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao23, converteTextoBotao(fbtnLetra23));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra23);

                    fbtnLetra23Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao23);
                removeLetraPalavra(posicaoLetraBotao23);

                // Chama o metodo 
                retiraBotoes(fbtnLetra23);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra23.Location = SalvaPosicaoBotao[22];

                fbtnLetra23Clicado = false;
            }
        }

        private void fbtnLetra24_Click(object sender, EventArgs e)
        {
            if (fbtnLetra24Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[23] = fbtnLetra24.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao24 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao24 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao24, converteTextoBotao(fbtnLetra24));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra24);

                    fbtnLetra24Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao24);
                removeLetraPalavra(posicaoLetraBotao24);

                // Chama o metodo 
                retiraBotoes(fbtnLetra24);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra24.Location = SalvaPosicaoBotao[23];

                fbtnLetra24Clicado = false;
            }
        }

        private void fbtnLetra25_Click(object sender, EventArgs e)
        {
            if (fbtnLetra25Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[24] = fbtnLetra25.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao25 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao25 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao25, converteTextoBotao(fbtnLetra25));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra25);

                    fbtnLetra25Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao25);
                removeLetraPalavra(posicaoLetraBotao25);

                // Chama o metodo 
                retiraBotoes(fbtnLetra25);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra25.Location = SalvaPosicaoBotao[24];

                fbtnLetra25Clicado = false;
            }
        }

        private void fbtnLetra26_Click(object sender, EventArgs e)
        {
            if (fbtnLetra26Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[25] = fbtnLetra26.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao26 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao26 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao26, converteTextoBotao(fbtnLetra26));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra26);

                    fbtnLetra26Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao26);
                removeLetraPalavra(posicaoLetraBotao26);

                // Chama o metodo 
                retiraBotoes(fbtnLetra26);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra26.Location = SalvaPosicaoBotao[25];

                fbtnLetra26Clicado = false;
            }
        }

        private void fbtnLetra27_Click(object sender, EventArgs e)
        {
            if (fbtnLetra27Clicado == false)
            {
                // Verifica se a quantidade de letras colocadas ultrapassou o tamanho do nome e bloqueia colocar mais letras.
                if (quantidadeLetras < nomeJogoSemEspaco.Length)
                {
                    // Salva a posicao do botao para retornar na lista de letras.
                    SalvaPosicaoBotao[26] = fbtnLetra27.Location;

                    // Verifica se tem alguma letra na lista de letras tiradas.
                    if (posicoesLetrasTiradas.Count > 0)
                    {
                        // Verifica qual é a posicao da menor letra.
                        int menor = 1000;
                        int posicaoMenor = 0;
                        for (int i = 0; i < posicoesLetrasTiradas.Count; i++)
                        {
                            if (posicoesLetrasTiradas[i] < menor)
                            {
                                // Salva a posicao da menor letra e o indice da menor letra.
                                menor = posicoesLetrasTiradas[i];
                                posicaoMenor = i;
                            }
                        }
                        // Salva a posicao do menor e remove ele da lista de letras tiradas pelo indice.
                        posicoesLetrasTiradas.RemoveAt(posicaoMenor);
                        posicaoLetraBotao27 = menor;
                    }
                    else
                    {
                        // Salva o index da posicao colocada.
                        posicaoLetraBotao27 = posicaoLetra;
                        posicaoLetra++;
                    }

                    // Chama o metodo adicionaLetraPalavra, passando a posicao atual dessa letra e o texto da letra.
                    adicionaLetraPalavra(posicaoLetraBotao27, converteTextoBotao(fbtnLetra27));

                    // Chama o metodo colocaBotoes.
                    colocaBotoes(fbtnLetra27);

                    fbtnLetra27Clicado = true;

                    // Chama o metodo para verificar a vitoria.
                    verificaVitoria();
                }
            }
            else
            {
                // Chama o metodo para remover uma letra da palavra na posicao passada e adiciona na lista de letras removidas.
                posicoesLetrasTiradas.Add(posicaoLetraBotao27);
                removeLetraPalavra(posicaoLetraBotao27);

                // Chama o metodo 
                retiraBotoes(fbtnLetra27);

                // Volta o botao na posicao salva da lista de letras.
                fbtnLetra27.Location = SalvaPosicaoBotao[26];

                fbtnLetra27Clicado = false;
            }
        }

        private void ibUsarDicas_Click(object sender, EventArgs e)
        {
            if (QuantidadeDicas > 0 && JogoGanho == false)
            {
                // Deixa o nome do jogo sem espaco maiusculo.
                string nomeJogoSemEspacoMaiusculo = nomeJogoSemEspaco.ToUpper();

                // Transforma o numero aleatorio em uma letra do nome do jogo e chama o metodo verificaBotoes.
                string letra = nomeJogoSemEspacoMaiusculo[numerosDicas[0]].ToString();
                verficaBotoes(letra, sender, e);
            }
        }

        private void verficaBotoes(string letra, object sender, EventArgs e)
        {
            // Verifica qual botao tem o mesmo texto passado e chama o metodo click dele.
            bool achado = false;
            if (fbtnLetra1.Text == letra && achado == false && fbtnLetra1Clicado == false)
            {
                fbtnLetra1_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra2.Text == letra && achado == false && fbtnLetra2Clicado == false)
            {
                fbtnLetra2_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra3.Text == letra && achado == false && fbtnLetra3Clicado == false)
            {
                fbtnLetra3_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra4.Text == letra && achado == false && fbtnLetra4Clicado == false)
            {
                fbtnLetra4_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra5.Text == letra && achado == false && fbtnLetra5Clicado == false)
            {
                fbtnLetra5_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra6.Text == letra && achado == false && fbtnLetra6Clicado == false)
            {
                fbtnLetra6_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra7.Text == letra && achado == false && fbtnLetra7Clicado == false)
            {
                fbtnLetra7_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra8.Text == letra && achado == false && fbtnLetra8Clicado == false)
            {
                fbtnLetra8_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra9.Text == letra && achado == false && fbtnLetra9Clicado == false)
            {
                fbtnLetra9_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra10.Text == letra && achado == false && fbtnLetra10Clicado == false)
            {
                fbtnLetra10_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra11.Text == letra && achado == false && fbtnLetra11Clicado == false)
            {
                fbtnLetra11_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra12.Text == letra && achado == false && fbtnLetra12Clicado == false)
            {
                fbtnLetra12_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra13.Text == letra && achado == false && fbtnLetra13Clicado == false)
            {
                fbtnLetra13_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra14.Text == letra && achado == false && fbtnLetra14Clicado == false)
            {
                fbtnLetra14_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra15.Text == letra && achado == false && fbtnLetra15Clicado == false)
            {
                fbtnLetra15_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra16.Text == letra && achado == false && fbtnLetra16Clicado == false)
            {
                fbtnLetra16_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra17.Text == letra && achado == false && fbtnLetra17Clicado == false)
            {
                fbtnLetra17_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra18.Text == letra && achado == false && fbtnLetra18Clicado == false)
            {
                fbtnLetra18_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra19.Text == letra && achado == false && fbtnLetra19Clicado == false)
            {
                fbtnLetra19_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra20.Text == letra && achado == false && fbtnLetra20Clicado == false)
            {
                fbtnLetra20_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra21.Text == letra && achado == false && fbtnLetra21Clicado == false)
            {
                fbtnLetra21_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra22.Text == letra && achado == false && fbtnLetra22Clicado == false)
            {
                fbtnLetra22_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra23.Text == letra && achado == false && fbtnLetra23Clicado == false)
            {
                fbtnLetra23_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra24.Text == letra && achado == false && fbtnLetra24Clicado == false)
            {
                fbtnLetra24_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra25.Text == letra && achado == false && fbtnLetra25Clicado == false)
            {
                fbtnLetra25_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra26.Text == letra && achado == false && fbtnLetra26Clicado == false)
            {
                fbtnLetra26_Click(sender, e);
                achado = true;
            }

            if (fbtnLetra27.Text == letra && achado == false && fbtnLetra27Clicado == false)
            {
                fbtnLetra27_Click(sender, e);
                achado = true;
            }

            // Verifica se achou alguma letra nos botoes.
            if (achado == true)
            {
                // Diminui a quantidade de dicas e chama o metodo para atualizar as dicas.
                QuantidadeDicas -= 1;
                atualizaEstrelasEDicas();
            }
        }

        private void removerBotoes(object sender, EventArgs e)
        {
            // Verificando quais botoes foram clicados e removendo o click.
            if (fbtnLetra1Clicado == true)
            {
                fbtnLetra1_Click(sender, e);
            }

            if (fbtnLetra2Clicado == true)
            {
                fbtnLetra2_Click(sender, e);
            }

            if (fbtnLetra3Clicado == true)
            {
                fbtnLetra3_Click(sender, e);
            }

            if (fbtnLetra4Clicado == true)
            {
                fbtnLetra4_Click(sender, e);
            }

            if (fbtnLetra5Clicado == true)
            {
                fbtnLetra5_Click(sender, e);
            }

            if (fbtnLetra6Clicado == true)
            {
                fbtnLetra6_Click(sender, e);
            }

            if (fbtnLetra7Clicado == true)
            {
                fbtnLetra7_Click(sender, e);
            }

            if (fbtnLetra8Clicado == true)
            {
                fbtnLetra8_Click(sender, e);
            }

            if (fbtnLetra9Clicado == true)
            {
                fbtnLetra9_Click(sender, e);
            }

            if (fbtnLetra10Clicado == true)
            {
                fbtnLetra10_Click(sender, e);
            }

            if (fbtnLetra11Clicado == true)
            {
                fbtnLetra11_Click(sender, e);
            }

            if (fbtnLetra12Clicado == true)
            {
                fbtnLetra12_Click(sender, e);
            }

            if (fbtnLetra13Clicado == true)
            {
                fbtnLetra13_Click(sender, e);
            }

            if (fbtnLetra14Clicado == true)
            {
                fbtnLetra14_Click(sender, e);
            }

            if (fbtnLetra15Clicado == true)
            {
                fbtnLetra15_Click(sender, e);
            }

            if (fbtnLetra16Clicado == true)
            {
                fbtnLetra16_Click(sender, e);
            }

            if (fbtnLetra17Clicado == true)
            {
                fbtnLetra17_Click(sender, e);
            }

            if (fbtnLetra18Clicado == true)
            {
                fbtnLetra18_Click(sender, e);
            }

            if (fbtnLetra19Clicado == true)
            {
                fbtnLetra19_Click(sender, e);
            }

            if (fbtnLetra20Clicado == true)
            {
                fbtnLetra20_Click(sender, e);
            }

            if (fbtnLetra21Clicado == true)
            {
                fbtnLetra21_Click(sender, e);
            }

            if (fbtnLetra22Clicado == true)
            {
                fbtnLetra22_Click(sender, e);
            }

            if (fbtnLetra23Clicado == true)
            {
                fbtnLetra23_Click(sender, e);
            }

            if (fbtnLetra24Clicado == true)
            {
                fbtnLetra24_Click(sender, e);
            }

            if (fbtnLetra25Clicado == true)
            {
                fbtnLetra25_Click(sender, e);
            }

            if (fbtnLetra26Clicado == true)
            {
                fbtnLetra26_Click(sender, e);
            }

            if (fbtnLetra27Clicado == true)
            {
                fbtnLetra27_Click(sender, e);
            }
        }

        private void ibRemover_Click(object sender, EventArgs e)
        {
            // Chama o metodo para remover os botoes.
            removerBotoes(sender, e);
        }
    }
}
