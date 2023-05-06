using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_2
{
    internal class Convertor
    {
        
        private readonly string Path;

        public Convertor(string path)
        {
            Path = path;
        }


        public static void Ser(ObservableCollection<Model> toDoList)
        {
            string json = JsonConvert.SerializeObject(toDoList);
            File.WriteAllText("D:\\Desktop\\Notes.json", json);
        }

        public ObservableCollection<Model> Deser()
        {
            if (File.Exists(Path))
            {
                string json = File.ReadAllText("D:\\Desktop\\Notes.json");
                ObservableCollection<Model> toDoList = JsonConvert.DeserializeObject<ObservableCollection<Model>>(json);
                return toDoList;
            }
            else
            {
                File.Create("D:\\Desktop\\Notes.json");
                string json = File.ReadAllText("D:\\Desktop\\Notes.json");
                ObservableCollection<Model> toDoList = JsonConvert.DeserializeObject<ObservableCollection<Model>>(json);
                return toDoList;
            }

        }
    }
}

