using System;
using System.Collections.Generic;
using System.Text;
using SertificateRegistry2.DataSourceLayer;

namespace SertificateRegistry2.DomainLayer
{
    class TemplateHandler
    {
        private TemplateLoader Loader;

        public TemplateHandler()
        {
            Loader = new TemplateLoader();
        }

        public string FillTemplate(IList<CertificatesListItem> CertificateList)
        {
            string Template = Loader.LoadTemplate();
            string[] TemplatePartsSeparator = new string[1];
            TemplatePartsSeparator[0] = "<!-- -->";
            string[] TemplateParts = Template.Split(TemplatePartsSeparator, StringSplitOptions.None); 
            string FilledTemplate = TemplateParts[0];
            for (int i = 0; i < CertificateList.Count; i++)
            {
                string CurrentTableRow = TemplateParts[1].Replace("#Name#", CertificateList[i].Name);
                CurrentTableRow = CurrentTableRow.Replace("#Number#", CertificateList[i].Number);
                CurrentTableRow = CurrentTableRow.Replace("#BeginDate#", CertificateList[i].Begin.ToShortDateString());
                CurrentTableRow = CurrentTableRow.Replace("#EndDate#", CertificateList[i].End.ToShortDateString());
                CurrentTableRow = CurrentTableRow.Replace("#Organization#", CertificateList[i].Organization);
                FilledTemplate += CurrentTableRow;
            }
            FilledTemplate += TemplateParts[2];

            return FilledTemplate;
        }
    }
}