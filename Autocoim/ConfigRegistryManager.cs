using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocoim
{
    class ConfigRegistryManager
    {
        private Microsoft.Win32.RegistryKey key;

        public ConfigRegistryManager()
        {
        }

        public void setGPPath(string path)
        {
            //TODO: Optimizar esto, se crea un subdirectorio siempre
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Autocoim");
            key.SetValue("GP path", path);
            key.Close();
        }

        public string getGPPath()
        {
            string value;

            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Autocoim");

            if (key == null)
                return "";

            value = (string)key.GetValue("GP path");
            key.Close();
            return value;
        }

        public void setEmailPath(string path)
        {
            //TODO: Optimizar esto, se crea un subdirectorio siempre
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Autocoim");
            key.SetValue("Email path", path);
            key.Close();
        }

        public string getEmailPath()
        {
            string value;

            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Autocoim");

            if (key == null)
                return "";

            value = (string)key.GetValue("Email path");
            key.Close();
            return value;
        }

        public void setFolderPath(string path)
        {
            //TODO: Optimizar esto, se crea un subdirectorio siempre
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Autocoim");
            key.SetValue("Folder path", path);
            key.Close();
        }

        public string getFolderPath()
        {
            string value;

            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Autocoim");

            if (key == null)
                return "";

            value = (string)key.GetValue("Folder path");
            key.Close();
            return value;
        }
    }
}
