using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SertificateRegistry2.DomainLayer;

namespace SertificateRegistry2.PresentationLayer
{
    public partial class CertificateForm:Form
    {
        private IList<OrganizationListItem> OrganizationList;
        private Boolean isEdit;
        private string CurrentOrganization;
        private int ID_Certificate;

        /// <summary>
        /// Конструктор формы по умолчанию (для добавления сертификата)
        /// </summary>
        public CertificateForm()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        /// <summary>
        /// Конструктор формы редактирования сертификата
        /// </summary>
        /// <param name="CertificateToEdit"></param>
        public CertificateForm(CertificatesListItem CertificateToEdit)
        {
            InitializeComponent();

            this.isEdit = true;
            this.CertificateNameTextBox.Text = CertificateToEdit.Name;
            this.CertificateNumberTextBox.Text = CertificateToEdit.Number;
            this.BeginDatePicker.Value = CertificateToEdit.Begin;
            this.EndDatePicker.Value = CertificateToEdit.End;
            this.CurrentOrganization = CertificateToEdit.Organization;
            this.ID_Certificate = CertificateToEdit.ID_Certificate;
        }

        private void FillOrganizationComboBox()
        {
            Organization OrganizationListSource = new Organization();
            this.OrganizationList = OrganizationListSource.GetOrganizationList();

            this.OrganizationComboBox.Items.Clear();
            for (int i = 0; i < this.OrganizationList.Count; i++)
            {
                this.OrganizationComboBox.Items.Add(this.OrganizationList[i].Name);
            }

            if (isEdit)
            {
                this.OrganizationComboBox.SelectedIndex = this.OrganizationComboBox.Items.IndexOf(this.CurrentOrganization);
            }
        }

        private void OrganizationComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OrganizationComboBox.Text = "";
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CertificateNameTextBox.Text == "")
                {
                    MessageBox.Show("Поле \"Название\" должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (CertificateNumberTextBox.Text == "")
                {
                    MessageBox.Show("Поле \"Номер сертификата\" должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (OrganizationComboBox.Text == "")
                {
                    MessageBox.Show("Нужно выбрать организацию", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (this.isEdit)
                    {
                        int ID_CurrentOrganization = this.OrganizationList[this.OrganizationComboBox.SelectedIndex].ID_Organization;

                        Certificate NewCertificate = new Certificate();
                        NewCertificate.EditCertificate(this.ID_Certificate,
                                                        this.CertificateNameTextBox.Text,
                                                        this.CertificateNumberTextBox.Text,
                                                        this.BeginDatePicker.Value,
                                                        this.EndDatePicker.Value,
                                                        ID_CurrentOrganization);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        int ID_CurrentOrganization = this.OrganizationList[this.OrganizationComboBox.SelectedIndex].ID_Organization;

                        Certificate NewCertificate = new Certificate();
                        NewCertificate.AddCertificate(this.CertificateNameTextBox.Text,
                                                        this.CertificateNumberTextBox.Text,
                                                        this.BeginDatePicker.Value,
                                                        this.EndDatePicker.Value,
                                                        ID_CurrentOrganization);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (DomainException CheckError)
            {
                MessageBox.Show(CheckError.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CertificateForm_Load(object sender, EventArgs e)
        {
            FillOrganizationComboBox();

            if (this.OrganizationComboBox.Items.Count == 0)
            {
                MessageBox.Show("Список организаций пуст. Добавьте организацию", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteOrganizationBtn_Click(object sender, EventArgs e)
        {
            string OrganizationName = this.OrganizationList[this.OrganizationComboBox.SelectedIndex].Name;
            if (MessageBox.Show("Вы хотите удалить организацию" + OrganizationName + "?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Organization OrganizationKiller = new Organization();
                int ID_OrganizationToDelete = this.OrganizationList[this.OrganizationComboBox.SelectedIndex].ID_Organization;
                OrganizationKiller.DeleteOrganization(ID_OrganizationToDelete);
            }
        }

        private void AddOrganizationBtn_Click(object sender, EventArgs e)
        {
            AddOrganizationForm AddOrganization = new AddOrganizationForm();
            if (AddOrganization.ShowDialog() == DialogResult.OK)
            {
                FillOrganizationComboBox();
            }
        }
    }
}
