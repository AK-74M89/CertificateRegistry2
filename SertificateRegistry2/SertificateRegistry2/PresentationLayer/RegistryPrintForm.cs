using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SertificateRegistry2.PresentationLayer
{
    public partial class RegistryPrintForm:Form
    {
        public RegistryPrintForm(string CertificatesTable)
        {
            InitializeComponent();

            this.RegistryPreview.DocumentText = CertificatesTable;
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistryPreview.ShowPrintDialog();
        }

        private void предварительныйПросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryPreview.ShowPrintPreviewDialog();
        }      
    }
}
