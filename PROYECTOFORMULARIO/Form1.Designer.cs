namespace PROYECTOFORMULARIO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtcodigo = new TextBox();
            lstSimbolos = new ListBox();
            txtJSON = new TextBox();
            lstErrores = new ListBox();
            btnAnalizar = new Button();
            btnLimpiar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnDescargarJson = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ScrollBar;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(663, 12);
            label1.Name = "label1";
            label1.Size = new Size(190, 26);
            label1.TabIndex = 0;
            label1.Text = "DE C++ A .JSON";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // txtcodigo
            // 
            txtcodigo.AccessibleName = "";
            txtcodigo.Location = new Point(14, 81);
            txtcodigo.Margin = new Padding(3, 4, 3, 4);
            txtcodigo.Multiline = true;
            txtcodigo.Name = "txtcodigo";
            txtcodigo.Size = new Size(327, 511);
            txtcodigo.TabIndex = 1;
            txtcodigo.TextChanged += textBox1_TextChanged;
            // 
            // lstSimbolos
            // 
            lstSimbolos.FormattingEnabled = true;
            lstSimbolos.Location = new Point(360, 81);
            lstSimbolos.Margin = new Padding(3, 4, 3, 4);
            lstSimbolos.Name = "lstSimbolos";
            lstSimbolos.Size = new Size(316, 504);
            lstSimbolos.TabIndex = 2;
            // 
            // txtJSON
            // 
            txtJSON.Location = new Point(1139, 81);
            txtJSON.Margin = new Padding(3, 4, 3, 4);
            txtJSON.Multiline = true;
            txtJSON.Name = "txtJSON";
            txtJSON.ReadOnly = true;
            txtJSON.Size = new Size(297, 511);
            txtJSON.TabIndex = 3;
            txtJSON.TextChanged += txtJSON_TextChanged;
            // 
            // lstErrores
            // 
            lstErrores.FormattingEnabled = true;
            lstErrores.Location = new Point(683, 81);
            lstErrores.Margin = new Padding(3, 4, 3, 4);
            lstErrores.Name = "lstErrores";
            lstErrores.Size = new Size(449, 504);
            lstErrores.TabIndex = 4;
            // 
            // btnAnalizar
            // 
            btnAnalizar.BackColor = SystemColors.ScrollBar;
            btnAnalizar.Location = new Point(663, 627);
            btnAnalizar.Margin = new Padding(3, 4, 3, 4);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new Size(168, 31);
            btnAnalizar.TabIndex = 5;
            btnAnalizar.Text = "TRANSFORMAR";
            btnAnalizar.UseVisualStyleBackColor = false;
            btnAnalizar.Click += btnAnalizar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ScrollBar;
            btnLimpiar.Location = new Point(299, 624);
            btnLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(86, 31);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(117, 57);
            label2.Name = "label2";
            label2.Size = new Size(152, 20);
            label2.TabIndex = 7;
            label2.Text = "INTRODUCIR TEXTO";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(453, 57);
            label3.Name = "label3";
            label3.Size = new Size(159, 20);
            label3.TabIndex = 8;
            label3.Text = "TABLA DE SIMBOLOS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(863, 57);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 9;
            label4.Text = "LISTA DE ERRORES";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(1250, 57);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 10;
            label5.Text = "CODIGO JSON";
            // 
            // btnDescargarJson
            // 
            btnDescargarJson.BackColor = SystemColors.ScrollBar;
            btnDescargarJson.Location = new Point(1213, 627);
            btnDescargarJson.Margin = new Padding(3, 4, 3, 4);
            btnDescargarJson.Name = "btnDescargarJson";
            btnDescargarJson.Size = new Size(95, 31);
            btnDescargarJson.TabIndex = 11;
            btnDescargarJson.Text = "DESCARGAR";
            btnDescargarJson.UseVisualStyleBackColor = false;
            btnDescargarJson.Click += btnDescargarJson_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1450, 688);
            Controls.Add(btnDescargarJson);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnLimpiar);
            Controls.Add(btnAnalizar);
            Controls.Add(lstErrores);
            Controls.Add(txtJSON);
            Controls.Add(lstSimbolos);
            Controls.Add(txtcodigo);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "C++ --> JSON";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtcodigo;
        private ListBox lstSimbolos;
        private TextBox txtJSON;
        private ListBox lstErrores;
        private Button btnAnalizar;
        private Button btnLimpiar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnDescargarJson;
    }
}
