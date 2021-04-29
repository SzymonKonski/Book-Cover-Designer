
namespace BookCoverDesigner
{
    partial class NewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heightNumerical = new System.Windows.Forms.NumericUpDown();
            this.spineNumerical = new System.Windows.Forms.NumericUpDown();
            this.widthNumerical = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumerical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spineNumerical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumerical)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.heightNumerical, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.spineNumerical, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.widthNumerical, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Ok, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Cancel, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // heightNumerical
            // 
            resources.ApplyResources(this.heightNumerical, "heightNumerical");
            this.heightNumerical.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heightNumerical.Name = "heightNumerical";
            this.heightNumerical.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // spineNumerical
            // 
            resources.ApplyResources(this.spineNumerical, "spineNumerical");
            this.spineNumerical.Name = "spineNumerical";
            this.spineNumerical.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // widthNumerical
            // 
            resources.ApplyResources(this.widthNumerical, "widthNumerical");
            this.widthNumerical.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthNumerical.Name = "widthNumerical";
            this.widthNumerical.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Ok
            // 
            resources.ApplyResources(this.Ok, "Ok");
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Name = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            resources.ApplyResources(this.Cancel, "Cancel");
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Name = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // NewForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumerical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spineNumerical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumerical)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown widthNumerical;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.NumericUpDown heightNumerical;
        private System.Windows.Forms.NumericUpDown spineNumerical;
    }
}