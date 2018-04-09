namespace RS_Tauro
{
    partial class DescargaBalsamo
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
            this.components = new System.ComponentModel.Container();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblMensaje2 = new System.Windows.Forms.Label();
            this.rbPrimer = new System.Windows.Forms.RadioButton();
            this.rbSegundo = new System.Windows.Forms.RadioButton();
            this.rbTercero = new System.Windows.Forms.RadioButton();
            this.rbCuarto = new System.Windows.Forms.RadioButton();
            this.rbQuinto = new System.Windows.Forms.RadioButton();
            this.rbSexto = new System.Windows.Forms.RadioButton();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnDescargar
            // 
            this.btnDescargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.Location = new System.Drawing.Point(181, 12);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(120, 50);
            this.btnDescargar.TabIndex = 0;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(27, 118);
            this.lblMensaje.MinimumSize = new System.Drawing.Size(450, 50);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(450, 50);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblMensaje2
            // 
            this.lblMensaje2.AutoSize = true;
            this.lblMensaje2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje2.Location = new System.Drawing.Point(27, 168);
            this.lblMensaje2.MinimumSize = new System.Drawing.Size(450, 50);
            this.lblMensaje2.Name = "lblMensaje2";
            this.lblMensaje2.Size = new System.Drawing.Size(450, 50);
            this.lblMensaje2.TabIndex = 2;
            this.lblMensaje2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbPrimer
            // 
            this.rbPrimer.AutoSize = true;
            this.rbPrimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPrimer.Location = new System.Drawing.Point(15, 75);
            this.rbPrimer.Name = "rbPrimer";
            this.rbPrimer.Size = new System.Drawing.Size(75, 17);
            this.rbPrimer.TabIndex = 3;
            this.rbPrimer.TabStop = true;
            this.rbPrimer.Text = "1° Grupo";
            this.rbPrimer.UseVisualStyleBackColor = true;
            this.rbPrimer.CheckedChanged += new System.EventHandler(this.rbPrimer_CheckedChanged);
            // 
            // rbSegundo
            // 
            this.rbSegundo.AutoSize = true;
            this.rbSegundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSegundo.Location = new System.Drawing.Point(96, 75);
            this.rbSegundo.Name = "rbSegundo";
            this.rbSegundo.Size = new System.Drawing.Size(75, 17);
            this.rbSegundo.TabIndex = 4;
            this.rbSegundo.TabStop = true;
            this.rbSegundo.Text = "2° Grupo";
            this.rbSegundo.UseVisualStyleBackColor = true;
            this.rbSegundo.CheckedChanged += new System.EventHandler(this.rbSegundo_CheckedChanged);
            // 
            // rbTercero
            // 
            this.rbTercero.AutoSize = true;
            this.rbTercero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTercero.Location = new System.Drawing.Point(177, 75);
            this.rbTercero.Name = "rbTercero";
            this.rbTercero.Size = new System.Drawing.Size(75, 17);
            this.rbTercero.TabIndex = 5;
            this.rbTercero.TabStop = true;
            this.rbTercero.Text = "3° Grupo";
            this.rbTercero.UseVisualStyleBackColor = true;
            this.rbTercero.CheckedChanged += new System.EventHandler(this.rbTercero_CheckedChanged);
            // 
            // rbCuarto
            // 
            this.rbCuarto.AutoSize = true;
            this.rbCuarto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCuarto.Location = new System.Drawing.Point(258, 75);
            this.rbCuarto.Name = "rbCuarto";
            this.rbCuarto.Size = new System.Drawing.Size(75, 17);
            this.rbCuarto.TabIndex = 6;
            this.rbCuarto.TabStop = true;
            this.rbCuarto.Text = "4° Grupo";
            this.rbCuarto.UseVisualStyleBackColor = true;
            this.rbCuarto.CheckedChanged += new System.EventHandler(this.rbCuarto_CheckedChanged);
            // 
            // rbQuinto
            // 
            this.rbQuinto.AutoSize = true;
            this.rbQuinto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbQuinto.Location = new System.Drawing.Point(339, 75);
            this.rbQuinto.Name = "rbQuinto";
            this.rbQuinto.Size = new System.Drawing.Size(75, 17);
            this.rbQuinto.TabIndex = 7;
            this.rbQuinto.TabStop = true;
            this.rbQuinto.Text = "5° Grupo";
            this.rbQuinto.UseVisualStyleBackColor = true;
            this.rbQuinto.CheckedChanged += new System.EventHandler(this.rbQuinto_CheckedChanged);
            // 
            // rbSexto
            // 
            this.rbSexto.AutoSize = true;
            this.rbSexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSexto.Location = new System.Drawing.Point(420, 75);
            this.rbSexto.Name = "rbSexto";
            this.rbSexto.Size = new System.Drawing.Size(75, 17);
            this.rbSexto.TabIndex = 8;
            this.rbSexto.TabStop = true;
            this.rbSexto.Text = "6° Grupo";
            this.rbSexto.UseVisualStyleBackColor = true;
            this.rbSexto.CheckedChanged += new System.EventHandler(this.rbSexto_CheckedChanged);
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodo.Location = new System.Drawing.Point(402, 31);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(54, 17);
            this.rbTodo.TabIndex = 9;
            this.rbTodo.TabStop = true;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // DescargaBalsamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 227);
            this.Controls.Add(this.rbTodo);
            this.Controls.Add(this.rbSexto);
            this.Controls.Add(this.rbQuinto);
            this.Controls.Add(this.rbCuarto);
            this.Controls.Add(this.rbTercero);
            this.Controls.Add(this.rbSegundo);
            this.Controls.Add(this.rbPrimer);
            this.Controls.Add(this.lblMensaje2);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnDescargar);
            this.Name = "DescargaBalsamo";
            this.Text = "Tauro Autopartes - Balsamo API";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblMensaje2;
        private System.Windows.Forms.RadioButton rbPrimer;
        private System.Windows.Forms.RadioButton rbSegundo;
        private System.Windows.Forms.RadioButton rbTercero;
        private System.Windows.Forms.RadioButton rbCuarto;
        private System.Windows.Forms.RadioButton rbQuinto;
        private System.Windows.Forms.RadioButton rbSexto;
        private System.Windows.Forms.RadioButton rbTodo;
    }
}

