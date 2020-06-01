// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace NMARC
{
    partial class FrmNativeModeConc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.BtnLoadYamlFile = new System.Windows.Forms.Button();
            this.txtYamlInputPath = new System.Windows.Forms.TextBox();
            this.BtnSetOutputDir = new System.Windows.Forms.Button();
            this.TxtOutputPath = new System.Windows.Forms.TextBox();
            this.txtResultsBox = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dlgOpenYaml = new System.Windows.Forms.OpenFileDialog();
            this.DlgSelectOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // BtnLoadYamlFile
            // 
            this.BtnLoadYamlFile.Location = new System.Drawing.Point(12, 12);
            this.BtnLoadYamlFile.Name = "BtnLoadYamlFile";
            this.BtnLoadYamlFile.Size = new System.Drawing.Size(124, 23);
            this.BtnLoadYamlFile.TabIndex = 0;
            this.BtnLoadYamlFile.Text = "Select YAML File";
            this.BtnLoadYamlFile.UseVisualStyleBackColor = true;
            this.BtnLoadYamlFile.Click += new System.EventHandler(this.LoadYamlFile_Click);
            // 
            // txtYamlInputPath
            // 
            this.txtYamlInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYamlInputPath.Location = new System.Drawing.Point(142, 14);
            this.txtYamlInputPath.Name = "txtYamlInputPath";
            this.txtYamlInputPath.ReadOnly = true;
            this.txtYamlInputPath.Size = new System.Drawing.Size(649, 20);
            this.txtYamlInputPath.TabIndex = 1;
            // 
            // BtnSetOutputDir
            // 
            this.BtnSetOutputDir.Location = new System.Drawing.Point(13, 42);
            this.BtnSetOutputDir.Name = "BtnSetOutputDir";
            this.BtnSetOutputDir.Size = new System.Drawing.Size(123, 23);
            this.BtnSetOutputDir.TabIndex = 2;
            this.BtnSetOutputDir.Text = "Set Output Folder";
            this.BtnSetOutputDir.UseVisualStyleBackColor = true;
            this.BtnSetOutputDir.Click += new System.EventHandler(this.BtnSetOutputDir_Click);
            // 
            // TxtOutputPath
            // 
            this.TxtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOutputPath.Location = new System.Drawing.Point(143, 44);
            this.TxtOutputPath.Name = "TxtOutputPath";
            this.TxtOutputPath.ReadOnly = true;
            this.TxtOutputPath.Size = new System.Drawing.Size(648, 20);
            this.TxtOutputPath.TabIndex = 3;
            // 
            // txtResultsBox
            // 
            this.txtResultsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultsBox.Location = new System.Drawing.Point(12, 72);
            this.txtResultsBox.Multiline = true;
            this.txtResultsBox.Name = "txtResultsBox";
            this.txtResultsBox.ReadOnly = true;
            this.txtResultsBox.Size = new System.Drawing.Size(779, 408);
            this.txtResultsBox.TabIndex = 4;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(632, 486);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(159, 23);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "Convert Alignment Report";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // dlgOpenYaml
            // 
            this.dlgOpenYaml.FileName = "openFileDialog1";
            this.dlgOpenYaml.InitialDirectory = "" +
    "mples";
            // 
            // FrmNativeModeConc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 521);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtResultsBox);
            this.Controls.Add(this.TxtOutputPath);
            this.Controls.Add(this.BtnSetOutputDir);
            this.Controls.Add(this.txtYamlInputPath);
            this.Controls.Add(this.BtnLoadYamlFile);
            this.Name = "FrmNativeModeConc";
            this.Text = "Native Mode Alignment Report Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadYamlFile;
        private System.Windows.Forms.TextBox txtYamlInputPath;
        private System.Windows.Forms.Button BtnSetOutputDir;
        private System.Windows.Forms.TextBox TxtOutputPath;
        private System.Windows.Forms.TextBox txtResultsBox;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog dlgOpenYaml;
        private System.Windows.Forms.FolderBrowserDialog DlgSelectOutputFolder;
    }
}

