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
            this.pictureBoxTest = new System.Windows.Forms.PictureBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.textBoxBottom = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.buttonTestDiff = new System.Windows.Forms.Button();
            this.pictureBoxTest2 = new System.Windows.Forms.PictureBox();
            this.textBoxExpendition2 = new System.Windows.Forms.TextBox();
            this.textBoxExpendition3 = new System.Windows.Forms.TextBox();
            this.textBoxExpendition4 = new System.Windows.Forms.TextBox();
            this.buttonExpenditionSet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest2)).BeginInit();
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
            // pictureBoxTest
            // 
            this.pictureBoxTest.Location = new System.Drawing.Point(198, 140);
            this.pictureBoxTest.Name = "pictureBoxTest";
            this.pictureBoxTest.Size = new System.Drawing.Size(141, 104);
            this.pictureBoxTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTest.TabIndex = 4;
            this.pictureBoxTest.TabStop = false;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Location = new System.Drawing.Point(12, 159);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(80, 21);
            this.textBoxLeft.TabIndex = 5;
            this.textBoxLeft.Text = "111";
            // 
            // textBoxTop
            // 
            this.textBoxTop.Location = new System.Drawing.Point(48, 132);
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.Size = new System.Drawing.Size(80, 21);
            this.textBoxTop.TabIndex = 6;
            this.textBoxTop.Text = "111";
            // 
            // textBoxRight
            // 
            this.textBoxRight.Location = new System.Drawing.Point(98, 159);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(80, 21);
            this.textBoxRight.TabIndex = 7;
            this.textBoxRight.Text = "222";
            // 
            // textBoxBottom
            // 
            this.textBoxBottom.Location = new System.Drawing.Point(48, 186);
            this.textBoxBottom.Name = "textBoxBottom";
            this.textBoxBottom.Size = new System.Drawing.Size(80, 21);
            this.textBoxBottom.TabIndex = 8;
            this.textBoxBottom.Text = "222";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(88, 213);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(60, 23);
            this.buttonTest.TabIndex = 9;
            this.buttonTest.Text = "test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(88, 250);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(59, 18);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(12, 78);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(114, 21);
            this.textBoxFilename.TabIndex = 11;
            this.textBoxFilename.Text = "1.png";
            // 
            // buttonTestDiff
            // 
            this.buttonTestDiff.Location = new System.Drawing.Point(12, 211);
            this.buttonTestDiff.Name = "buttonTestDiff";
            this.buttonTestDiff.Size = new System.Drawing.Size(70, 33);
            this.buttonTestDiff.TabIndex = 12;
            this.buttonTestDiff.Text = "TestDiff";
            this.buttonTestDiff.UseVisualStyleBackColor = true;
            this.buttonTestDiff.Click += new System.EventHandler(this.buttonTestDiff_Click);
            // 
            // pictureBoxTest2
            // 
            this.pictureBoxTest2.Location = new System.Drawing.Point(381, 140);
            this.pictureBoxTest2.Name = "pictureBoxTest2";
            this.pictureBoxTest2.Size = new System.Drawing.Size(141, 104);
            this.pictureBoxTest2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTest2.TabIndex = 13;
            this.pictureBoxTest2.TabStop = false;
            // 
            // textBoxExpendition2
            // 
            this.textBoxExpendition2.Location = new System.Drawing.Point(12, 299);
            this.textBoxExpendition2.Name = "textBoxExpendition2";
            this.textBoxExpendition2.Size = new System.Drawing.Size(64, 21);
            this.textBoxExpendition2.TabIndex = 14;
            // 
            // textBoxExpendition3
            // 
            this.textBoxExpendition3.Location = new System.Drawing.Point(12, 326);
            this.textBoxExpendition3.Name = "textBoxExpendition3";
            this.textBoxExpendition3.Size = new System.Drawing.Size(64, 21);
            this.textBoxExpendition3.TabIndex = 15;
            // 
            // textBoxExpendition4
            // 
            this.textBoxExpendition4.Location = new System.Drawing.Point(12, 353);
            this.textBoxExpendition4.Name = "textBoxExpendition4";
            this.textBoxExpendition4.Size = new System.Drawing.Size(64, 21);
            this.textBoxExpendition4.TabIndex = 16;
            // 
            // buttonExpenditionSet
            // 
            this.buttonExpenditionSet.Location = new System.Drawing.Point(14, 380);
            this.buttonExpenditionSet.Name = "buttonExpenditionSet";
            this.buttonExpenditionSet.Size = new System.Drawing.Size(68, 25);
            this.buttonExpenditionSet.TabIndex = 17;
            this.buttonExpenditionSet.Text = "Set";
            this.buttonExpenditionSet.UseVisualStyleBackColor = true;
            this.buttonExpenditionSet.Click += new System.EventHandler(this.buttonExpenditionSet_Click);
            // 
            // FormBot
            // 
            this.AutoHidePortion = 150D;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(556, 537);
            this.Controls.Add(this.buttonExpenditionSet);
            this.Controls.Add(this.textBoxExpendition4);
            this.Controls.Add(this.textBoxExpendition3);
            this.Controls.Add(this.textBoxExpendition2);
            this.Controls.Add(this.pictureBoxTest2);
            this.Controls.Add(this.buttonTestDiff);
            this.Controls.Add(this.textBoxFilename);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.textBoxBottom);
            this.Controls.Add(this.textBoxRight);
            this.Controls.Add(this.textBoxTop);
            this.Controls.Add(this.textBoxLeft);
            this.Controls.Add(this.pictureBoxTest);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetHWND;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textHWND;
        private System.Windows.Forms.PictureBox pictureBoxTest;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxTop;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.TextBox textBoxBottom;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Button buttonTestDiff;
        private System.Windows.Forms.PictureBox pictureBoxTest2;
        private System.Windows.Forms.TextBox textBoxExpendition2;
        private System.Windows.Forms.TextBox textBoxExpendition3;
        private System.Windows.Forms.TextBox textBoxExpendition4;
        private System.Windows.Forms.Button buttonExpenditionSet;
    }
}