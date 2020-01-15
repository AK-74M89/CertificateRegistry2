using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SertificateRegistry2.DomainLayer;
using System.ComponentModel;
using System.Globalization;

namespace SertificateRegistry2.PresentationLayer
{
    public partial class CertificatesListViewForm:Form
    {
        #region Поля
        private Certificate CertificateRegistryHandler;
        private IList<CertificatesListItem> CertificatesList;
        private IList<CertificatesListItem> SelectedCertificatesList;
        private Boolean isFirstSelection = true;
        #endregion Поля

        #region Вспомогательные методы
        private void FillCertificatesTable()
        {
            this.CertificatesList = CertificateRegistryHandler.GetCertificatesRegistry();

            FillTableWithList(CertificatesList);
            this.CertificatesTable.Rows[0].Selected = true;
        }

        private void FillTableWithList(IList<CertificatesListItem> CertificatesList)
        {
            this.CertificatesTable.Rows.Clear();

            for (int i = 0; i < CertificatesList.Count; i++)
            {
                CertificatesListItem CurrentCertificate = CertificatesList[i];
                this.CertificatesTable.Rows.Add();

                this.CertificatesTable.Rows[i].Cells["ID"].Value = CurrentCertificate.ID_Certificate;
                this.CertificatesTable.Rows[i].Cells["CertificateName"].Value = CurrentCertificate.Name;
                this.CertificatesTable.Rows[i].Cells["Number"].Value = CurrentCertificate.Number;
                this.CertificatesTable.Rows[i].Cells["BeginDate"].Value = CurrentCertificate.Begin.ToShortDateString();
                this.CertificatesTable.Rows[i].Cells["EndDate"].Value = CurrentCertificate.End.ToShortDateString();
                this.CertificatesTable.Rows[i].Cells["Organization"].Value = CurrentCertificate.Organization;
            }

            this.CertificatesCount.Text = "Всего в базе: " + Convert.ToString(CertificatesList.Count);
            this.CertificatesTable.Sort(this.CertificatesTable.Columns[1], ListSortDirection.Ascending);
        }

        private void ClearHideSelectedList()
        {
            this.PrintAllBtn.Enabled = true;
            this.SelectedCertificates.Visible = false;
            this.PrintSelectedBtn.Visible = false;
            this.isFirstSelection = true;
            this.Width = 882;
            this.isFirstSelection = true;
            this.SelectedCertificates.Text = "";
        }
        #endregion

        #region Обработчики событий
        public CertificatesListViewForm()
        {
            InitializeComponent();
        }

        private void CertificatesListViewForm_Load(object sender, EventArgs e)
        {
            this.CertificateRegistryHandler = new Certificate();
            FillCertificatesTable();
            this.SelectedCertificatesList = new List<CertificatesListItem>();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            CertificateForm AddCertificate = new CertificateForm();
            if (AddCertificate.ShowDialog() == DialogResult.OK)
            {
                FillCertificatesTable();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            CertificatesListItem CurrentCertificate;
            CurrentCertificate.ID_Certificate = Convert.ToInt32(this.CertificatesTable.SelectedRows[0].Cells[0].Value);
            CurrentCertificate.Name = Convert.ToString(this.CertificatesTable.SelectedRows[0].Cells[1].Value);
            CurrentCertificate.Number = Convert.ToString(this.CertificatesTable.SelectedRows[0].Cells[2].Value);
            CurrentCertificate.Begin = Convert.ToDateTime(this.CertificatesTable.SelectedRows[0].Cells[3].Value);
            CurrentCertificate.End = Convert.ToDateTime(this.CertificatesTable.SelectedRows[0].Cells[4].Value);
            CurrentCertificate.Organization = Convert.ToString(this.CertificatesTable.SelectedRows[0].Cells[5].Value);
            CertificateForm EditCertificate = new CertificateForm(CurrentCertificate);
            if (EditCertificate.ShowDialog() == DialogResult.OK)
            {
                FillCertificatesTable();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string Number = Convert.ToString(this.CertificatesTable.SelectedRows[0].Cells[2].Value);
            if (MessageBox.Show("Хотите удалить сертификат № " + Number + "?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ID_CertificateToDelete = Convert.ToInt32(this.CertificatesTable.SelectedRows[0].Cells[0].Value);
                Certificate CertificateKiller = new Certificate();
                CertificateKiller.DeleteCertificate(ID_CertificateToDelete);
                FillCertificatesTable();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintAllBtn_Click(object sender, EventArgs e)
        {
            Certificate GetCertificates = new Certificate();
            IList<CertificatesListItem> Certificates = GetCertificates.GetCertificatesRegistry();

            TemplateHandler CertificateTemplate = new TemplateHandler();
            string CertificatesTable = CertificateTemplate.FillTemplate(Certificates);

            RegistryPrintForm PrintRegistry = new RegistryPrintForm(CertificatesTable);
            PrintRegistry.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName + ", версия " + Application.ProductVersion + ". \n(c) Суханов Александр, 2011", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Certificate CertificateRegistryHandler = new Certificate();
            IList<CertificatesListItem> CertificatesList = CertificateRegistryHandler.GetCertificatesRegistry();

            int Expired = 0;
            int Today = 0;
            int ThisMonth = 0;
            DateTime CurrentDay = DateTime.Now;

            foreach (CertificatesListItem CurrentCertificate in CertificatesList)
            {
                if (CurrentCertificate.End.Date < CurrentDay.Date)
                {
                    Expired++;
                }
                else if (CurrentCertificate.End.Date == CurrentDay.Date)
                {
                    Today++;
                }
                else if (CurrentCertificate.End.Month == CurrentDay.Month)
                {
                    ThisMonth++;
                }
            }

            MessageBox.Show("Заканчивается срок действия сертификатов:" +
                            "\nСегодня:\t\t\t" + Convert.ToString(Today) +
                            "\nВ этом месяце:\t\t" + Convert.ToString(ThisMonth) +
                            "\nЗакончился:\t\t" + Convert.ToString(Expired) +
                            "\nВсего в базе:\t\t" + Convert.ToString(CertificatesList.Count),
                            "Статистика",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void распечататьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintAllBtn_Click(sender, e);
        }

        private void SearchTBox_TextChanged(object sender, EventArgs e)
        {
            if (this.SearchTBox.Text == "")
            {
                FillTableWithList(this.CertificatesList);
            }
            else
            {
                IList<CertificatesListItem> SearchCertificatesList = new List<CertificatesListItem>();
                for (int j = 0; j < this.CertificatesList.Count; j++)
                {
                    SearchCertificatesList.Add(this.CertificatesList[j]);
                }
                int i = 0;
                while (i < SearchCertificatesList.Count)
                {
                    if (SearchCertificatesList[i].Name.StartsWith(this.SearchTBox.Text, true, CultureInfo.CurrentCulture))
                    {
                        i++;
                    }
                    else
                    {
                        SearchCertificatesList.RemoveAt(i);
                    }
                }
                FillTableWithList(SearchCertificatesList);
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (isFirstSelection)
            {
                this.PrintAllBtn.Enabled = false;
                this.SelectedCertificatesList.Clear();
                this.SelectedCertificates.Visible = true;
                this.PrintSelectedBtn.Visible = true;
                this.isFirstSelection = false;
                this.Width = 977;
            }
            CertificatesListItem SelectedCertificate = new CertificatesListItem();
            SelectedCertificate.ID_Certificate = Convert.ToInt32(this.CertificatesTable.SelectedRows[0].Cells[0].Value);
            SelectedCertificate.Name = Convert.ToString(this.CertificatesTable.SelectedRows[0].Cells[1].Value);
            SelectedCertificate.Number = Convert.ToString(this.CertificatesTable.SelectedRows[0].Cells[2].Value);
            SelectedCertificate.Begin = Convert.ToDateTime(this.CertificatesTable.SelectedRows[0].Cells[3].Value);
            SelectedCertificate.End = Convert.ToDateTime(this.CertificatesTable.SelectedRows[0].Cells[4].Value);
            SelectedCertificate.Organization = Convert.ToString(this.CertificatesTable.SelectedRows[0].Cells[5].Value);
            this.SelectedCertificatesList.Add(SelectedCertificate);
            this.SelectedCertificates.Text += SelectedCertificate.Name + "\n----------\n";
        }

        private void PrintSelectedBtn_Click(object sender, EventArgs e)
        {
            TemplateHandler CertificateTemplate = new TemplateHandler();
            string CertificatesTable = CertificateTemplate.FillTemplate(this.SelectedCertificatesList);

            RegistryPrintForm PrintRegistry = new RegistryPrintForm(CertificatesTable);
            PrintRegistry.ShowDialog();

            this.ClearHideSelectedList();
        }

        private void напечататьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintSelectedBtn_Click(sender, e);
        }

        private void очиститьСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearHideSelectedList();
        }
        
        private void CertificatesTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                AddBtn_Click(sender, e);
            }
        }
        #endregion
    }
}