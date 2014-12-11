using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocoim
{
    class Traductor
    {
        private const int size = 10;
        private string[] englishWords;
        private string[] translatedWords;
        private string language;

        public Traductor(string lang)
        {
            this.config(lang);
        }

        public void config(string lang)
        {
            this.language = lang;

            this.englishWords = new string[size]{
                "Scan",
                "Paths",
                "Language",
                "English",
                "Spanish",
                "Email",
                "Data",
                "Status",
                "Config",
                "Search"
            };

            if (lang == "es")
            {
                this.translatedWords = new string[size]{
                    "Escanear",
                    "Directorios",
                    "Idioma",
                    "Ingles",
                    "Español",
                    "Correo",
                    "Información",
                    "Estatus",
                    "Configuración",
                    "Buscar"
                };
            }
        }

        public string t(string word)
        {   
            if (this.language != "en")
            {                
                int index;
                index = Array.IndexOf(this.englishWords, word);
                if(index >= 0)
                    return this.translatedWords[index];
            }

            return word;
        }
    }
}
