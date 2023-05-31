using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace FuncLib_ser_deser_
{
    public class SerDeser
    {
        public static void  serialize<T>(T theme)
        {

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText($"{desktop}\\theme.txt", theme.ToString());

        }
        public static T Deserialize<T>()
        {
            T theme;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\theme.txt"))
            {
                string filik = File.ReadAllText($"{desktop}\\theme.txt");
                theme = JsonConvert.DeserializeObject<T>(filik);
                return theme;
            }
            else {
              /*  File.Create($"{desktop}\\theme.txt");
                
                File.WriteAllText($"{desktop}\\theme.txt", "WPB");
                string filik = File.ReadAllText($"{desktop}\\theme.txt");
                theme = JsonConvert.DeserializeObject<T>(filik);*/
              return default(T);
            }
        }
            
            
        

    }
}