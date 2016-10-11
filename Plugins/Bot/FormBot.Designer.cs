namespace ElectronicObserver.Window {
    partial class FormBot {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.buttonGetHWND = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textHWND = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGetHWND
            // 
            this.buttonGetHWND.Location = new System.Drawing.Point(12, 12);
            this.buttonGetHWND.Name = "buttonGetHWND";
            this.buttonGetHWND.Size = new System.Drawing.Size(96, 33);
            this.buttonGetHWND.TabIndex = 0;
            this.buttonGetHWND.Text = "获取句柄";
            this.buttonGetHWND.UseVisualStyleBackColor = true;
            this.buttonGetHWND.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonGetHWND_MouseDown);
            this.buttonGetHWND.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonGetHWND_MouseUp);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(114, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(96, 33);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(216, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(96, 33);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textHWND
            // 
            this.textHWND.Location = new System.Drawing.Point(12, 51);
            this.textHWND.Name = "textHWND";
            this.textHWND.ReadOnly = true;
            this.textHWND.Size = new System.Drawing.Size(87, 21);
            this.textHWND.TabIndex = 3;
            // 
            // FormBot
            // 
            this.AutoHidePortion = 150D;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(375, 280);
            this.Controls.Add(this.textHWND);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonGetHWND);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HideOnClose = true;
            this.Name = "FormBot";
            this.Text = "FormBot";
            this.Load += new System.EventHandler(this.FormBot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetHWND;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textHWND;
    }
}