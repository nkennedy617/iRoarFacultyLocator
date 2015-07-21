namespace VisualFacultyLocator
{
    partial class Form1
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
            this.outputFileBox = new System.Windows.Forms.TextBox();
            this.chooseOutputFileBtn = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.inputFileBox = new System.Windows.Forms.TextBox();
            this.chooseInputFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputFileBox
            // 
            this.outputFileBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFileBox.Location = new System.Drawing.Point(12, 64);
            this.outputFileBox.Name = "outputFileBox";
            this.outputFileBox.Size = new System.Drawing.Size(592, 20);
            this.outputFileBox.TabIndex = 2;
            // 
            // chooseOutputFileBtn
            // 
            this.chooseOutputFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseOutputFileBtn.Location = new System.Drawing.Point(610, 64);
            this.chooseOutputFileBtn.Name = "chooseOutputFileBtn";
            this.chooseOutputFileBtn.Size = new System.Drawing.Size(27, 20);
            this.chooseOutputFileBtn.TabIndex = 3;
            this.chooseOutputFileBtn.Text = "...";
            this.chooseOutputFileBtn.UseVisualStyleBackColor = true;
            this.chooseOutputFileBtn.Click += new System.EventHandler(this.dialogButton_Click);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Location = new System.Drawing.Point(562, 233);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 90);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(544, 166);
            this.textBox1.TabIndex = 5;
            this.textBox1.Visible = false;
            // 
            // inputFileBox
            // 
            this.inputFileBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFileBox.Location = new System.Drawing.Point(12, 25);
            this.inputFileBox.Name = "inputFileBox";
            this.inputFileBox.Size = new System.Drawing.Size(592, 20);
            this.inputFileBox.TabIndex = 6;
            // 
            // chooseInputFileBtn
            // 
            this.chooseInputFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseInputFileBtn.Location = new System.Drawing.Point(610, 24);
            this.chooseInputFileBtn.Name = "chooseInputFileBtn";
            this.chooseInputFileBtn.Size = new System.Drawing.Size(27, 20);
            this.chooseInputFileBtn.TabIndex = 7;
            this.chooseInputFileBtn.Text = "...";
            this.chooseInputFileBtn.UseVisualStyleBackColor = true;
            this.chooseInputFileBtn.Click += new System.EventHandler(this.chooseInputFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Input File (html)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Output File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 268);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseInputFileBtn);
            this.Controls.Add(this.inputFileBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.chooseOutputFileBtn);
            this.Controls.Add(this.outputFileBox);
            this.Name = "Form1";
            this.Text = "Visual Faculty Locator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputFileBox;
        private System.Windows.Forms.Button chooseOutputFileBtn;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox inputFileBox;
        private System.Windows.Forms.Button chooseInputFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

