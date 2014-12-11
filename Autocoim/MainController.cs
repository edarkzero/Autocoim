using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocoim
{
    class MainController
    {
        public MainController(string lang)
        {
            trad = new Traductor(lang);
            form = new MainForm(this);
            cRegistryManager = new ConfigRegistryManager();
            eTransform = new ExcelTransform();
        }

        public void changelanguage(string l)
        {
            trad.config(l);
        }

        public Traductor Trad
        {
            get
            {
                return trad;
            }
        }

        public MainForm Form
        {
            get
            {
                return form;
            }
        }

        public ConfigRegistryManager CRegistryManager
        { 
            get
            {
                return cRegistryManager;
            }
        }

        public ExcelTransform ETransform
        {
            get
            {
                return eTransform;
            }
        }

        private Traductor trad;
        private MainForm form;
        private ConfigRegistryManager cRegistryManager;
        private ExcelTransform eTransform;
    }    
}
