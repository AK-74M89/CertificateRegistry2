using System.IO;
using System.Text;

namespace SertificateRegistry2.DataSourceLayer
{
    class TemplateLoader
    {
        private string template_path;
            
        public TemplateLoader(string FilePath = "Templates\\registry.html")
        {
            this.template_path = FilePath;
        }

        public string LoadTemplate()
        {
            if (!File.Exists(this.template_path))
            {
                throw (new FileNotFoundException("Файл шаблона \"" + this.template_path + "\" не найден"));
            }
            return File.ReadAllText(this.template_path, Encoding.UTF8);
        }
    }
}