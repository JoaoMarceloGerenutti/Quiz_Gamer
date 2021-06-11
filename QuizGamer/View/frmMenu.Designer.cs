
namespace QuizGamer
{
    partial class frmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.lblGamer = new System.Windows.Forms.Label();
            this.btnCreditos = new System.Windows.Forms.Button();
            this.btnJogar = new System.Windows.Forms.Button();
            this.lblQuiz = new System.Windows.Forms.Label();
            this.bcCabecalho = new Bunifu.Framework.UI.BunifuCards();
            this.ibMinimizar = new Bunifu.Framework.UI.BunifuImageButton();
            this.ibFechar = new Bunifu.Framework.UI.BunifuImageButton();
            this.blblCabecalho = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btbtnImagemCabecalho = new Bunifu.Framework.UI.BunifuTileButton();
            this.tmrAnimacao = new System.Windows.Forms.Timer(this.components);
            this.Controle = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bcCabecalho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGamer
            // 
            this.lblGamer.AutoSize = true;
            this.lblGamer.BackColor = System.Drawing.Color.Transparent;
            this.lblGamer.Font = new System.Drawing.Font("Palatino Linotype", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.lblGamer.Location = new System.Drawing.Point(-3, 51);
            this.lblGamer.Margin = new System.Windows.Forms.Padding(0);
            this.lblGamer.Name = "lblGamer";
            this.lblGamer.Size = new System.Drawing.Size(289, 87);
            this.lblGamer.TabIndex = 6;
            this.lblGamer.Text = "GAMER";
            // 
            // btnCreditos
            // 
            this.btnCreditos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnCreditos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnCreditos.Location = new System.Drawing.Point(64, 278);
            this.btnCreditos.Name = "btnCreditos";
            this.btnCreditos.Size = new System.Drawing.Size(135, 58);
            this.btnCreditos.TabIndex = 5;
            this.btnCreditos.Text = "CRÉDITOS";
            this.btnCreditos.UseVisualStyleBackColor = false;
            this.btnCreditos.Click += new System.EventHandler(this.btnCreditos_Click);
            // 
            // btnJogar
            // 
            this.btnJogar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnJogar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnJogar.Location = new System.Drawing.Point(51, 204);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(161, 58);
            this.btnJogar.TabIndex = 4;
            this.btnJogar.Text = "COMEÇAR!";
            this.btnJogar.UseVisualStyleBackColor = false;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // lblQuiz
            // 
            this.lblQuiz.AutoSize = true;
            this.lblQuiz.BackColor = System.Drawing.Color.Transparent;
            this.lblQuiz.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuiz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(177)))), ((int)(((byte)(56)))));
            this.lblQuiz.Location = new System.Drawing.Point(123, 118);
            this.lblQuiz.Margin = new System.Windows.Forms.Padding(0);
            this.lblQuiz.Name = "lblQuiz";
            this.lblQuiz.Size = new System.Drawing.Size(156, 65);
            this.lblQuiz.TabIndex = 7;
            this.lblQuiz.Text = "QUIZ";
            // 
            // bcCabecalho
            // 
            this.bcCabecalho.BackColor = System.Drawing.Color.Maroon;
            this.bcCabecalho.BorderRadius = 5;
            this.bcCabecalho.BottomSahddow = true;
            this.bcCabecalho.color = System.Drawing.Color.Maroon;
            this.bcCabecalho.Controls.Add(this.ibMinimizar);
            this.bcCabecalho.Controls.Add(this.ibFechar);
            this.bcCabecalho.Controls.Add(this.blblCabecalho);
            this.bcCabecalho.Controls.Add(this.btbtnImagemCabecalho);
            this.bcCabecalho.LeftSahddow = false;
            this.bcCabecalho.Location = new System.Drawing.Point(-2, -6);
            this.bcCabecalho.Name = "bcCabecalho";
            this.bcCabecalho.RightSahddow = true;
            this.bcCabecalho.ShadowDepth = 20;
            this.bcCabecalho.Size = new System.Drawing.Size(281, 54);
            this.bcCabecalho.TabIndex = 8;
            // 
            // ibMinimizar
            // 
            this.ibMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.ibMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibMinimizar.Image = global::QuizGamer.Properties.Resources.Minimizar;
            this.ibMinimizar.ImageActive = null;
            this.ibMinimizar.InitialImage = null;
            this.ibMinimizar.Location = new System.Drawing.Point(193, 14);
            this.ibMinimizar.Name = "ibMinimizar";
            this.ibMinimizar.Size = new System.Drawing.Size(28, 28);
            this.ibMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibMinimizar.TabIndex = 72;
            this.ibMinimizar.TabStop = false;
            this.ibMinimizar.Zoom = 20;
            this.ibMinimizar.Click += new System.EventHandler(this.ibMinimizar_Click);
            // 
            // ibFechar
            // 
            this.ibFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibFechar.BackColor = System.Drawing.Color.Transparent;
            this.ibFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibFechar.Image = global::QuizGamer.Properties.Resources.Fechar;
            this.ibFechar.ImageActive = null;
            this.ibFechar.InitialImage = null;
            this.ibFechar.Location = new System.Drawing.Point(236, 14);
            this.ibFechar.Name = "ibFechar";
            this.ibFechar.Size = new System.Drawing.Size(28, 28);
            this.ibFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibFechar.TabIndex = 71;
            this.ibFechar.TabStop = false;
            this.ibFechar.Zoom = 20;
            this.ibFechar.Click += new System.EventHandler(this.ibFechar_Click);
            // 
            // blblCabecalho
            // 
            this.blblCabecalho.AutoSize = true;
            this.blblCabecalho.Enabled = false;
            this.blblCabecalho.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blblCabecalho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(177)))), ((int)(((byte)(56)))));
            this.blblCabecalho.Location = new System.Drawing.Point(42, 13);
            this.blblCabecalho.Name = "blblCabecalho";
            this.blblCabecalho.Size = new System.Drawing.Size(98, 31);
            this.blblCabecalho.TabIndex = 70;
            this.blblCabecalho.Text = "MENU";
            // 
            // btbtnImagemCabecalho
            // 
            this.btbtnImagemCabecalho.BackColor = System.Drawing.Color.Transparent;
            this.btbtnImagemCabecalho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btbtnImagemCabecalho.color = System.Drawing.Color.Transparent;
            this.btbtnImagemCabecalho.colorActive = System.Drawing.Color.Transparent;
            this.btbtnImagemCabecalho.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btbtnImagemCabecalho.Enabled = false;
            this.btbtnImagemCabecalho.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btbtnImagemCabecalho.ForeColor = System.Drawing.Color.Transparent;
            this.btbtnImagemCabecalho.Image = global::QuizGamer.Properties.Resources.Gamer;
            this.btbtnImagemCabecalho.ImagePosition = 0;
            this.btbtnImagemCabecalho.ImageZoom = 60;
            this.btbtnImagemCabecalho.LabelPosition = 0;
            this.btbtnImagemCabecalho.LabelText = "";
            this.btbtnImagemCabecalho.Location = new System.Drawing.Point(-8, 11);
            this.btbtnImagemCabecalho.Margin = new System.Windows.Forms.Padding(6);
            this.btbtnImagemCabecalho.Name = "btbtnImagemCabecalho";
            this.btbtnImagemCabecalho.Size = new System.Drawing.Size(60, 36);
            this.btbtnImagemCabecalho.TabIndex = 69;
            // 
            // tmrAnimacao
            // 
            this.tmrAnimacao.Enabled = true;
            this.tmrAnimacao.Interval = 500;
            this.tmrAnimacao.Tick += new System.EventHandler(this.tmrAnimacao_Tick);
            // 
            // Controle
            // 
            this.Controle.Fixed = true;
            this.Controle.Horizontal = true;
            this.Controle.TargetControl = this.bcCabecalho;
            this.Controle.Vertical = true;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(274, 362);
            this.Controls.Add(this.bcCabecalho);
            this.Controls.Add(this.lblQuiz);
            this.Controls.Add(this.lblGamer);
            this.Controls.Add(this.btnCreditos);
            this.Controls.Add(this.btnJogar);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.bcCabecalho.ResumeLayout(false);
            this.bcCabecalho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGamer;
        private System.Windows.Forms.Button btnCreditos;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Label lblQuiz;
        private Bunifu.Framework.UI.BunifuCards bcCabecalho;
        private Bunifu.Framework.UI.BunifuTileButton btbtnImagemCabecalho;
        private Bunifu.Framework.UI.BunifuCustomLabel blblCabecalho;
        private Bunifu.Framework.UI.BunifuImageButton ibMinimizar;
        private Bunifu.Framework.UI.BunifuImageButton ibFechar;
        private System.Windows.Forms.Timer tmrAnimacao;
        private Bunifu.Framework.UI.BunifuDragControl Controle;
    }
}

