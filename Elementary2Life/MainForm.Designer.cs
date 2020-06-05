namespace Elementary2Life
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.cellColorDialog = new System.Windows.Forms.ColorDialog();
            this.ruleSelect = new System.Windows.Forms.NumericUpDown();
            this.buttonChangeRule = new System.Windows.Forms.Button();
            this.buttonChangeColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ruleSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(999, 561);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 30;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // ruleSelect
            // 
            this.ruleSelect.Location = new System.Drawing.Point(10, 577);
            this.ruleSelect.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ruleSelect.Name = "ruleSelect";
            this.ruleSelect.Size = new System.Drawing.Size(70, 20);
            this.ruleSelect.TabIndex = 1;
            // 
            // buttonChangeRule
            // 
            this.buttonChangeRule.Location = new System.Drawing.Point(86, 576);
            this.buttonChangeRule.Name = "buttonChangeRule";
            this.buttonChangeRule.Size = new System.Drawing.Size(84, 23);
            this.buttonChangeRule.TabIndex = 2;
            this.buttonChangeRule.Text = "Change rule";
            this.buttonChangeRule.UseVisualStyleBackColor = true;
            this.buttonChangeRule.Click += new System.EventHandler(this.buttonChangeRule_Click);
            // 
            // buttonChangeColor
            // 
            this.buttonChangeColor.Location = new System.Drawing.Point(176, 576);
            this.buttonChangeColor.Name = "buttonChangeColor";
            this.buttonChangeColor.Size = new System.Drawing.Size(84, 23);
            this.buttonChangeColor.TabIndex = 3;
            this.buttonChangeColor.Text = "Change color";
            this.buttonChangeColor.UseVisualStyleBackColor = true;
            this.buttonChangeColor.Click += new System.EventHandler(this.buttonChangeColor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 604);
            this.Controls.Add(this.buttonChangeColor);
            this.Controls.Add(this.buttonChangeRule);
            this.Controls.Add(this.ruleSelect);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Elementary2Life";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ruleSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.ColorDialog cellColorDialog;
        private System.Windows.Forms.NumericUpDown ruleSelect;
        private System.Windows.Forms.Button buttonChangeRule;
        private System.Windows.Forms.Button buttonChangeColor;
    }
}

