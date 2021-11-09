// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace NMARC
{
    partial class OptionsDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFileExtension = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGroupAdminsSample = new System.Windows.Forms.Label();
            this.lblUsersSample = new System.Windows.Forms.Label();
            this.lblGroupsSample = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutputSeparator = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSeparatorSample = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(101, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(182, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFileExtension
            // 
            this.txtFileExtension.Location = new System.Drawing.Point(121, 6);
            this.txtFileExtension.MaxLength = 10;
            this.txtFileExtension.Name = "txtFileExtension";
            this.txtFileExtension.Size = new System.Drawing.Size(126, 20);
            this.txtFileExtension.TabIndex = 2;
            this.txtFileExtension.Text = ".CSV";
            this.txtFileExtension.ModifiedChanged += new System.EventHandler(this.txtFileExtension_ModifiedChanged);
            this.txtFileExtension.Validating += new System.ComponentModel.CancelEventHandler(this.txtFileExtension_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output file extension";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGroupAdminsSample);
            this.groupBox1.Controls.Add(this.lblUsersSample);
            this.groupBox1.Controls.Add(this.lblGroupsSample);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 88);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample";
            // 
            // lblGroupAdminsSample
            // 
            this.lblGroupAdminsSample.AutoSize = true;
            this.lblGroupAdminsSample.Location = new System.Drawing.Point(23, 64);
            this.lblGroupAdminsSample.Name = "lblGroupAdminsSample";
            this.lblGroupAdminsSample.Size = new System.Drawing.Size(91, 13);
            this.lblGroupAdminsSample.TabIndex = 2;
            this.lblGroupAdminsSample.Text = "groupadmins.CSV";
            // 
            // lblUsersSample
            // 
            this.lblUsersSample.AutoSize = true;
            this.lblUsersSample.Location = new System.Drawing.Point(23, 42);
            this.lblUsersSample.Name = "lblUsersSample";
            this.lblUsersSample.Size = new System.Drawing.Size(56, 13);
            this.lblUsersSample.TabIndex = 1;
            this.lblUsersSample.Text = "users.CSV";
            // 
            // lblGroupsSample
            // 
            this.lblGroupsSample.AutoSize = true;
            this.lblGroupsSample.Location = new System.Drawing.Point(23, 20);
            this.lblGroupsSample.Name = "lblGroupsSample";
            this.lblGroupsSample.Size = new System.Drawing.Size(63, 13);
            this.lblGroupsSample.TabIndex = 0;
            this.lblGroupsSample.Text = "groups.CSV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Output separator";
            // 
            // txtOutputSeparator
            // 
            this.txtOutputSeparator.Location = new System.Drawing.Point(121, 142);
            this.txtOutputSeparator.MaxLength = 4;
            this.txtOutputSeparator.Name = "txtOutputSeparator";
            this.txtOutputSeparator.Size = new System.Drawing.Size(126, 20);
            this.txtOutputSeparator.TabIndex = 6;
            this.txtOutputSeparator.Text = ",";
            this.txtOutputSeparator.ModifiedChanged += new System.EventHandler(this.txtOutputSeparator_ModifiedChanged);
            this.txtOutputSeparator.Validating += new System.ComponentModel.CancelEventHandler(this.txtOutputSeparator_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSeparatorSample);
            this.groupBox2.Location = new System.Drawing.Point(18, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 46);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample";
            // 
            // lblSeparatorSample
            // 
            this.lblSeparatorSample.AutoSize = true;
            this.lblSeparatorSample.Location = new System.Drawing.Point(23, 20);
            this.lblSeparatorSample.Name = "lblSeparatorSample";
            this.lblSeparatorSample.Size = new System.Drawing.Size(100, 13);
            this.lblSeparatorSample.TabIndex = 0;
            this.lblSeparatorSample.Text = "Col1,Col2,Col3,Col4";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(280, 291);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtOutputSeparator);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileExtension);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Options";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFileExtension;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGroupAdminsSample;
        private System.Windows.Forms.Label lblUsersSample;
        private System.Windows.Forms.Label lblGroupsSample;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutputSeparator;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSeparatorSample;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}