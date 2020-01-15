namespace SertificateRegistry2.PresentationLayer
{
    partial class CertificatesListViewForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificatesListViewForm));
            this.CertificatesTable = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertificateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CertificateStatus = new System.Windows.Forms.StatusStrip();
            this.CertificatesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.CertificatesMainMenu = new System.Windows.Forms.MenuStrip();
            this.сертификатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.распечататьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбраныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.напечататьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.PrintAllBtn = new System.Windows.Forms.Button();
            this.SearchTBox = new System.Windows.Forms.TextBox();
            this.SearchLbl = new System.Windows.Forms.Label();
            this.SelectedCertificates = new System.Windows.Forms.RichTextBox();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.PrintSelectedBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CertificatesTable)).BeginInit();
            this.CertificateStatus.SuspendLayout();
            this.CertificatesMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CertificatesTable
            // 
            this.CertificatesTable.AllowUserToAddRows = false;
            this.CertificatesTable.AllowUserToDeleteRows = false;
            this.CertificatesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CertificatesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CertificateName,
            this.Number,
            this.BeginDate,
            this.EndDate,
            this.Organization});
            this.CertificatesTable.Location = new System.Drawing.Point(5, 25);
            this.CertificatesTable.MultiSelect = false;
            this.CertificatesTable.Name = "CertificatesTable";
            this.CertificatesTable.ReadOnly = true;
            this.CertificatesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CertificatesTable.Size = new System.Drawing.Size(750, 520);
            this.CertificatesTable.TabIndex = 0;
            this.CertificatesTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CertificatesTable_KeyDown);            
            // 
            // ID
            // 
            this.ID.HeaderText = "Идентификатор";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 5;
            // 
            // CertificateName
            // 
            this.CertificateName.HeaderText = "Название";
            this.CertificateName.Name = "CertificateName";
            this.CertificateName.ReadOnly = true;
            this.CertificateName.Width = 150;
            // 
            // Number
            // 
            this.Number.HeaderText = "Номер";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 150;
            // 
            // BeginDate
            // 
            this.BeginDate.HeaderText = "Дата выдачи";
            this.BeginDate.Name = "BeginDate";
            this.BeginDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "Действует до";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // Organization
            // 
            this.Organization.HeaderText = "Орган, выдавший сертификат";
            this.Organization.Name = "Organization";
            this.Organization.ReadOnly = true;
            this.Organization.Width = 200;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(765, 30);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(100, 35);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CertificateStatus
            // 
            this.CertificateStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CertificatesCount});
            this.CertificateStatus.Location = new System.Drawing.Point(0, 575);
            this.CertificateStatus.Name = "CertificateStatus";
            this.CertificateStatus.Size = new System.Drawing.Size(876, 22);
            this.CertificateStatus.SizingGrip = false;
            this.CertificateStatus.TabIndex = 3;
            // 
            // CertificatesCount
            // 
            this.CertificatesCount.Name = "CertificatesCount";
            this.CertificatesCount.Size = new System.Drawing.Size(77, 17);
            this.CertificatesCount.Text = "Всего в базе:";
            // 
            // CertificatesMainMenu
            // 
            this.CertificatesMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сертификатыToolStripMenuItem,
            this.выбраныеToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.CertificatesMainMenu.Location = new System.Drawing.Point(0, 0);
            this.CertificatesMainMenu.Name = "CertificatesMainMenu";
            this.CertificatesMainMenu.Size = new System.Drawing.Size(876, 24);
            this.CertificatesMainMenu.TabIndex = 4;
            this.CertificatesMainMenu.Text = "menuStrip1";
            // 
            // сертификатыToolStripMenuItem
            // 
            this.сертификатыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.распечататьВсеToolStripMenuItem,
            this.статистикаToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.сертификатыToolStripMenuItem.Name = "сертификатыToolStripMenuItem";
            this.сертификатыToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.сертификатыToolStripMenuItem.Text = "Сертификаты";
            // 
            // распечататьВсеToolStripMenuItem
            // 
            this.распечататьВсеToolStripMenuItem.Name = "распечататьВсеToolStripMenuItem";
            this.распечататьВсеToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.распечататьВсеToolStripMenuItem.Text = "Распечатать все";
            this.распечататьВсеToolStripMenuItem.Click += new System.EventHandler(this.распечататьВсеToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            this.статистикаToolStripMenuItem.Click += new System.EventHandler(this.статистикаToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // выбраныеToolStripMenuItem
            // 
            this.выбраныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.напечататьToolStripMenuItem,
            this.очиститьСписокToolStripMenuItem});
            this.выбраныеToolStripMenuItem.Name = "выбраныеToolStripMenuItem";
            this.выбраныеToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.выбраныеToolStripMenuItem.Text = "Выбраные";
            // 
            // напечататьToolStripMenuItem
            // 
            this.напечататьToolStripMenuItem.Name = "напечататьToolStripMenuItem";
            this.напечататьToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.напечататьToolStripMenuItem.Text = "Напечатать";
            this.напечататьToolStripMenuItem.Click += new System.EventHandler(this.напечататьToolStripMenuItem_Click);
            // 
            // очиститьСписокToolStripMenuItem
            // 
            this.очиститьСписокToolStripMenuItem.Name = "очиститьСписокToolStripMenuItem";
            this.очиститьСписокToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.очиститьСписокToolStripMenuItem.Text = "Очистить список";
            this.очиститьСписокToolStripMenuItem.Click += new System.EventHandler(this.очиститьСписокToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(765, 75);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(100, 35);
            this.EditBtn.TabIndex = 5;
            this.EditBtn.Text = "Редактировать";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(765, 120);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(100, 35);
            this.DeleteBtn.TabIndex = 6;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // PrintAllBtn
            // 
            this.PrintAllBtn.Location = new System.Drawing.Point(765, 165);
            this.PrintAllBtn.Name = "PrintAllBtn";
            this.PrintAllBtn.Size = new System.Drawing.Size(100, 35);
            this.PrintAllBtn.TabIndex = 7;
            this.PrintAllBtn.Text = "Напечатать реестр";
            this.PrintAllBtn.UseVisualStyleBackColor = true;
            this.PrintAllBtn.Click += new System.EventHandler(this.PrintAllBtn_Click);
            // 
            // SearchTBox
            // 
            this.SearchTBox.Location = new System.Drawing.Point(50, 550);
            this.SearchTBox.Name = "SearchTBox";
            this.SearchTBox.Size = new System.Drawing.Size(705, 20);
            this.SearchTBox.TabIndex = 8;
            this.SearchTBox.TextChanged += new System.EventHandler(this.SearchTBox_TextChanged);
            // 
            // SearchLbl
            // 
            this.SearchLbl.AutoSize = true;
            this.SearchLbl.Location = new System.Drawing.Point(5, 555);
            this.SearchLbl.Name = "SearchLbl";
            this.SearchLbl.Size = new System.Drawing.Size(39, 13);
            this.SearchLbl.TabIndex = 9;
            this.SearchLbl.Text = "Поиск";
            // 
            // SelectedCertificates
            // 
            this.SelectedCertificates.BulletIndent = 5;
            this.SelectedCertificates.DetectUrls = false;
            this.SelectedCertificates.Location = new System.Drawing.Point(765, 300);
            this.SelectedCertificates.Name = "SelectedCertificates";
            this.SelectedCertificates.ReadOnly = true;
            this.SelectedCertificates.Size = new System.Drawing.Size(200, 265);
            this.SelectedCertificates.TabIndex = 10;
            this.SelectedCertificates.Text = "";
            this.SelectedCertificates.Visible = false;
            // 
            // SelectBtn
            // 
            this.SelectBtn.Location = new System.Drawing.Point(765, 210);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(100, 35);
            this.SelectBtn.TabIndex = 11;
            this.SelectBtn.Text = "Выбрать";
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // PrintSelectedBtn
            // 
            this.PrintSelectedBtn.Location = new System.Drawing.Point(765, 255);
            this.PrintSelectedBtn.Name = "PrintSelectedBtn";
            this.PrintSelectedBtn.Size = new System.Drawing.Size(100, 35);
            this.PrintSelectedBtn.TabIndex = 12;
            this.PrintSelectedBtn.Text = "Напечатать выбранные";
            this.PrintSelectedBtn.UseVisualStyleBackColor = true;
            this.PrintSelectedBtn.Visible = false;
            this.PrintSelectedBtn.Click += new System.EventHandler(this.PrintSelectedBtn_Click);
            // 
            // CertificatesListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 597);
            this.Controls.Add(this.PrintSelectedBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.SelectedCertificates);
            this.Controls.Add(this.SearchLbl);
            this.Controls.Add(this.SearchTBox);
            this.Controls.Add(this.CertificatesTable);
            this.Controls.Add(this.PrintAllBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.CertificateStatus);
            this.Controls.Add(this.CertificatesMainMenu);
            this.Controls.Add(this.AddBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.CertificatesMainMenu;
            this.MaximizeBox = false;
            this.Name = "CertificatesListViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Реестр сертификатов 2";
            this.Load += new System.EventHandler(this.CertificatesListViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CertificatesTable)).EndInit();
            this.CertificateStatus.ResumeLayout(false);
            this.CertificateStatus.PerformLayout();
            this.CertificatesMainMenu.ResumeLayout(false);
            this.CertificatesMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CertificatesTable;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.StatusStrip CertificateStatus;
        private System.Windows.Forms.MenuStrip CertificatesMainMenu;
        private System.Windows.Forms.ToolStripMenuItem сертификатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem распечататьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button PrintAllBtn;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel CertificatesCount;
        private System.Windows.Forms.TextBox SearchTBox;
        private System.Windows.Forms.Label SearchLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertificateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization;
        private System.Windows.Forms.RichTextBox SelectedCertificates;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button PrintSelectedBtn;
        private System.Windows.Forms.ToolStripMenuItem выбраныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem напечататьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьСписокToolStripMenuItem;
    }
}