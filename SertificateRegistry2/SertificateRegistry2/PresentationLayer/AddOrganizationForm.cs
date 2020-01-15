using System;
using System.Windows.Forms;
using SertificateRegistry2.DomainLayer;

namespace SertificateRegistry2.PresentationLayer
{
    public partial class AddOrganizationForm:Form
    {
        public AddOrganizationForm()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.NameTextBox.Text == "")
                {
                    MessageBox.Show("Поле \"Название\" должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Organization NewOrganization = new Organization();
                    NewOrganization.AddOrganization(this.NameTextBox.Text);
                }
            }
            catch (DomainException CheckError)
            {
                MessageBox.Show(CheckError.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.NameTextBox.Focus();
            }
        }
    }
}
