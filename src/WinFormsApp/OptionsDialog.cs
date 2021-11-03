// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Windows.Forms;

namespace NMARC
{
    public partial class OptionsDialog : Form
    {
        public string FileExtension { get; set; }
        public string OutputSeparator { get; set; }

        public OptionsDialog(string extension, string separator)
        {
            // Required first in custom constructor. Does the wiring up of design-time components.
            InitializeComponent();

            // This is the first time I recall ever using this assignment syntax to keep properties in sync. Weird?
            FileExtension = txtFileExtension.Text = extension;
            OutputSeparator = txtOutputSeparator.Text = separator;

            // Support "roundtripping" i.e. opening options a second time.
            lblSeparatorSample.Text = GenerateSeparatorSample(separator); 

        }

        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Handle empty separator
            if (txtOutputSeparator.Text == "")
            {
                txtOutputSeparator.Text = OutputSeparator;
                return;
            }

            // Handle empty file extension
            if (txtFileExtension.Text == "")
            {
                txtFileExtension.Text = FileExtension;
            }

            // Add a dot to the extension if none is present
            if (!txtFileExtension.Text.StartsWith("."))
            {
                txtFileExtension.Text = $".{FileExtension}";
            }

            // Done with validation and ready to exit
            DialogResult = DialogResult.OK;
            FileExtension = txtFileExtension.Text;
            OutputSeparator = txtOutputSeparator.Text;
            Close();
        }

        private void txtOutputSeparator_ModifiedChanged(object sender, EventArgs e)
        {
            txtOutputSeparator.Modified = false; // reset the modified status for updates to work
            lblSeparatorSample.Text = GenerateSeparatorSample(txtOutputSeparator.Text);
        }

        private void txtFileExtension_ModifiedChanged(object sender, EventArgs e)
        {
            txtFileExtension.Modified = false; // reset the modified status for updates to work
            lblGroupsSample.Text = GenerateFileExtensionSample("groups", txtFileExtension.Text);
            lblUsersSample.Text = GenerateFileExtensionSample("users", txtFileExtension.Text);
            lblGroupAdminsSample.Text = GenerateFileExtensionSample("groupadmins", txtFileExtension.Text);
        }

        private string GenerateFileExtensionSample(string name, string extension)
        {
            return $"{name}{extension}";
        }

        private string GenerateSeparatorSample(string separator)
        {
            return $"Col1{separator}Col2{separator}Col3{separator}Col4";
        }

        private void txtFileExtension_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateFileExtension(ref txtFileExtension, txtFileExtension.Text);
        }

        private void txtOutputSeparator_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateSeparator(ref txtOutputSeparator, txtOutputSeparator.Text);
        }

        private bool ValidateFileExtension(ref TextBox textBox, string extension)
        {
            bool valid = true;
            if (extension == "")
            {
                errorProvider1.SetError(textBox, "Enter a valid extension like .CSV or .TXT. All output will use the same extension.");
                valid = false;
            }
            else if (!extension.StartsWith("."))
            {
                errorProvider1.SetError(textBox, "The file extension needs to start with a dot.");
                valid = false;
            }
            else if (extension == ".")
            {
                errorProvider1.SetError(textBox, "Enter a valid extension like .CSV or .TXT. All output will use the same extension.");
                valid = false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
            return valid;
        }

        private bool ValidateSeparator(ref TextBox textBox, string separator)
        {
            bool valid = true;
            if (separator == "")
            {
                errorProvider1.SetError(textBox, "Enter a valid separator like a comma.");
                valid = false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
            return valid;
        }
    }
}
