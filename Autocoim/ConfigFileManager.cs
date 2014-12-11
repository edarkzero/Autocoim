using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Autocoim
{
    class ConfigFileManager
    {
        private string path, name, extension,fullName;
        public ConfigFileManager()
        {
            extension = "path";
            name = "autocoim";
            fullName = name + "." + extension;
            path = fullName;
            //path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),fullName);

            if (!File.Exists(fullName))
            {
                using (FileStream fs = File.Create(fullName))
                {
                    AddText(fs,"GP:");
                    AddText(fs,"\r\nEmail:");
                    AddText(fs, "\r\nAll:");
                }
            }
            else
            {
                //Console.WriteLine("File \"{0}\" already exists.", fullName);
                using (FileStream fs = File.OpenRead(fullName))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        Console.WriteLine(temp.GetString(b));
                    }
                }
                return;
            }

        }

        private void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
