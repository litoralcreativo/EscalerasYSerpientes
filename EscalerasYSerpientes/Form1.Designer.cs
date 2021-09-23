
namespace EscalerasYSerpientes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelGraficos = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnMover = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGanados4 = new System.Windows.Forms.Label();
            this.lblGanados1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGanados3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDado1 = new System.Windows.Forms.Panel();
            this.lblGanados2 = new System.Windows.Forms.Label();
            this.panelDado2 = new System.Windows.Forms.Panel();
            this.panelDado3 = new System.Windows.Forms.Panel();
            this.panelDado4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbRegistro = new System.Windows.Forms.ListBox();
            this.btnSimular = new System.Windows.Forms.Button();
            this.btnDemo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGraficos
            // 
            this.panelGraficos.Location = new System.Drawing.Point(12, 12);
            this.panelGraficos.Name = "panelGraficos";
            this.panelGraficos.Size = new System.Drawing.Size(601, 601);
            this.panelGraficos.TabIndex = 0;
            this.panelGraficos.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(619, 585);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 28);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnMover
            // 
            this.btnMover.Location = new System.Drawing.Point(9, 70);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(75, 23);
            this.btnMover.TabIndex = 1;
            this.btnMover.Text = "Jugar";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGanados4);
            this.groupBox1.Controls.Add(this.lblGanados1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblGanados3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnMover);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panelDado1);
            this.groupBox1.Controls.Add(this.lblGanados2);
            this.groupBox1.Controls.Add(this.panelDado2);
            this.groupBox1.Controls.Add(this.panelDado3);
            this.groupBox1.Controls.Add(this.panelDado4);
            this.groupBox1.Location = new System.Drawing.Point(619, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 148);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jugador";
            // 
            // lblGanados4
            // 
            this.lblGanados4.AutoSize = true;
            this.lblGanados4.Location = new System.Drawing.Point(412, 117);
            this.lblGanados4.Name = "lblGanados4";
            this.lblGanados4.Size = new System.Drawing.Size(13, 13);
            this.lblGanados4.TabIndex = 13;
            this.lblGanados4.Text = "0";
            // 
            // lblGanados1
            // 
            this.lblGanados1.AutoSize = true;
            this.lblGanados1.Location = new System.Drawing.Point(127, 117);
            this.lblGanados1.Name = "lblGanados1";
            this.lblGanados1.Size = new System.Drawing.Size(13, 13);
            this.lblGanados1.TabIndex = 8;
            this.lblGanados1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Partidos Ganados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "COM 3";
            // 
            // lblGanados3
            // 
            this.lblGanados3.AutoSize = true;
            this.lblGanados3.Location = new System.Drawing.Point(310, 117);
            this.lblGanados3.Name = "lblGanados3";
            this.lblGanados3.Size = new System.Drawing.Size(13, 13);
            this.lblGanados3.TabIndex = 11;
            this.lblGanados3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "COM 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(110, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Humano";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "COM 1";
            // 
            // panelDado1
            // 
            this.panelDado1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDado1.BackgroundImage")));
            this.panelDado1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDado1.Location = new System.Drawing.Point(110, 57);
            this.panelDado1.Name = "panelDado1";
            this.panelDado1.Size = new System.Drawing.Size(50, 50);
            this.panelDado1.TabIndex = 3;
            // 
            // lblGanados2
            // 
            this.lblGanados2.AutoSize = true;
            this.lblGanados2.Location = new System.Drawing.Point(220, 117);
            this.lblGanados2.Name = "lblGanados2";
            this.lblGanados2.Size = new System.Drawing.Size(13, 13);
            this.lblGanados2.TabIndex = 9;
            this.lblGanados2.Text = "0";
            // 
            // panelDado2
            // 
            this.panelDado2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDado2.BackgroundImage")));
            this.panelDado2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDado2.Location = new System.Drawing.Point(202, 57);
            this.panelDado2.Name = "panelDado2";
            this.panelDado2.Size = new System.Drawing.Size(50, 50);
            this.panelDado2.TabIndex = 3;
            // 
            // panelDado3
            // 
            this.panelDado3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDado3.BackgroundImage")));
            this.panelDado3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDado3.Location = new System.Drawing.Point(293, 57);
            this.panelDado3.Name = "panelDado3";
            this.panelDado3.Size = new System.Drawing.Size(50, 50);
            this.panelDado3.TabIndex = 3;
            // 
            // panelDado4
            // 
            this.panelDado4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDado4.BackgroundImage")));
            this.panelDado4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDado4.Location = new System.Drawing.Point(392, 57);
            this.panelDado4.Name = "panelDado4";
            this.panelDado4.Size = new System.Drawing.Size(50, 50);
            this.panelDado4.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(619, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 60);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Jugadores virtuales";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(89, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Partidos Ganados:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Partidos Ganados:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Partidos Ganados:";
            // 
            // lbRegistro
            // 
            this.lbRegistro.Font = new System.Drawing.Font("NSimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistro.FormattingEnabled = true;
            this.lbRegistro.Location = new System.Drawing.Point(619, 237);
            this.lbRegistro.Name = "lbRegistro";
            this.lbRegistro.Size = new System.Drawing.Size(467, 329);
            this.lbRegistro.TabIndex = 6;
            this.lbRegistro.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbRegistro_DrawItem);
            // 
            // btnSimular
            // 
            this.btnSimular.Enabled = false;
            this.btnSimular.Location = new System.Drawing.Point(1011, 583);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(75, 28);
            this.btnSimular.TabIndex = 7;
            this.btnSimular.Text = "Simular";
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // btnDemo
            // 
            this.btnDemo.Enabled = false;
            this.btnDemo.Location = new System.Drawing.Point(700, 585);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(305, 28);
            this.btnDemo.TabIndex = 1;
            this.btnDemo.Text = "DEMO";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 627);
            this.Controls.Add(this.btnSimular);
            this.Controls.Add(this.lbRegistro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDemo);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panelGraficos);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGraficos;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Panel panelDado1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDado2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDado4;
        private System.Windows.Forms.Panel panelDado3;
        private System.Windows.Forms.ListBox lbRegistro;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.Label lblGanados1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGanados4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblGanados3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblGanados2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDemo;
    }
}

