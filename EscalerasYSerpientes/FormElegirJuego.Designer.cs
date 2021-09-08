
namespace EscalerasYSerpientes
{
    partial class FormElegirJuego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLvl3 = new System.Windows.Forms.RadioButton();
            this.rbLvl2 = new System.Windows.Forms.RadioButton();
            this.rbLvl1 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSimulacion = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLvl3);
            this.groupBox1.Controls.Add(this.rbLvl2);
            this.groupBox1.Controls.Add(this.rbLvl1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dificultad";
            // 
            // rbLvl3
            // 
            this.rbLvl3.AutoSize = true;
            this.rbLvl3.Location = new System.Drawing.Point(7, 66);
            this.rbLvl3.Name = "rbLvl3";
            this.rbLvl3.Size = new System.Drawing.Size(100, 17);
            this.rbLvl3.TabIndex = 2;
            this.rbLvl3.Text = "Nivel Avanzado";
            this.rbLvl3.UseVisualStyleBackColor = true;
            this.rbLvl3.CheckedChanged += new System.EventHandler(this.rbLvl3_CheckedChanged);
            // 
            // rbLvl2
            // 
            this.rbLvl2.AutoSize = true;
            this.rbLvl2.Location = new System.Drawing.Point(7, 43);
            this.rbLvl2.Name = "rbLvl2";
            this.rbLvl2.Size = new System.Drawing.Size(101, 17);
            this.rbLvl2.TabIndex = 1;
            this.rbLvl2.Text = "Nivel Intermedio";
            this.rbLvl2.UseVisualStyleBackColor = true;
            this.rbLvl2.CheckedChanged += new System.EventHandler(this.rbLvl2_CheckedChanged);
            // 
            // rbLvl1
            // 
            this.rbLvl1.AutoSize = true;
            this.rbLvl1.Checked = true;
            this.rbLvl1.Location = new System.Drawing.Point(7, 20);
            this.rbLvl1.Name = "rbLvl1";
            this.rbLvl1.Size = new System.Drawing.Size(84, 17);
            this.rbLvl1.TabIndex = 0;
            this.rbLvl1.TabStop = true;
            this.rbLvl1.Text = "Nivel Basico";
            this.rbLvl1.UseVisualStyleBackColor = true;
            this.rbLvl1.CheckedChanged += new System.EventHandler(this.rbLvl1_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Location = new System.Drawing.Point(147, 53);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(148, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbSimulacion
            // 
            this.cbSimulacion.AutoSize = true;
            this.cbSimulacion.Checked = true;
            this.cbSimulacion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSimulacion.Location = new System.Drawing.Point(163, 27);
            this.cbSimulacion.Name = "cbSimulacion";
            this.cbSimulacion.Size = new System.Drawing.Size(77, 17);
            this.cbSimulacion.TabIndex = 4;
            this.cbSimulacion.Text = "Simulacion";
            this.cbSimulacion.UseVisualStyleBackColor = true;
            // 
            // FormElegirJuego
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(269, 114);
            this.Controls.Add(this.cbSimulacion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormElegirJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Juego";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.RadioButton rbLvl3;
        public System.Windows.Forms.RadioButton rbLvl2;
        public System.Windows.Forms.RadioButton rbLvl1;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.CheckBox cbSimulacion;
    }
}