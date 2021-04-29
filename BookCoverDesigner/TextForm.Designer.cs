
namespace BookCoverDesigner
{
    partial class TextForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextForm));
            this.label1 = new System.Windows.Forms.Label();
            this.fontNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rightRadioButton = new System.Windows.Forms.RadioButton();
            this.centerRadioButton = new System.Windows.Forms.RadioButton();
            this.leftRadioButton = new System.Windows.Forms.RadioButton();
            this.textBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fontNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // fontNumericUpDown
            // 
            resources.ApplyResources(this.fontNumericUpDown, "fontNumericUpDown");
            this.fontNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.fontNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontNumericUpDown.Name = "fontNumericUpDown";
            this.fontNumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rightRadioButton);
            this.groupBox1.Controls.Add(this.centerRadioButton);
            this.groupBox1.Controls.Add(this.leftRadioButton);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rightRadioButton
            // 
            resources.ApplyResources(this.rightRadioButton, "rightRadioButton");
            this.rightRadioButton.Name = "rightRadioButton";
            this.rightRadioButton.UseVisualStyleBackColor = true;
            this.rightRadioButton.Click += new System.EventHandler(this.rightRadioButton_Click);
            // 
            // centerRadioButton
            // 
            resources.ApplyResources(this.centerRadioButton, "centerRadioButton");
            this.centerRadioButton.Name = "centerRadioButton";
            this.centerRadioButton.UseVisualStyleBackColor = true;
            this.centerRadioButton.Click += new System.EventHandler(this.centerRadioButton_Click);
            // 
            // leftRadioButton
            // 
            resources.ApplyResources(this.leftRadioButton, "leftRadioButton");
            this.leftRadioButton.Name = "leftRadioButton";
            this.leftRadioButton.UseVisualStyleBackColor = true;
            this.leftRadioButton.Click += new System.EventHandler(this.leftRadioButton_Click);
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // TextForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fontNumericUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextForm";
            ((System.ComponentModel.ISupportInitialize)(this.fontNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton leftRadioButton;
        private System.Windows.Forms.RadioButton centerRadioButton;
        private System.Windows.Forms.RadioButton rightRadioButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.NumericUpDown fontNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}