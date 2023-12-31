﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace File_conventer
{


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Human> hum = new List<Human>(); ///конструктор
            Human Timof = new Human("Тимофей", 19);
            hum.Add(Timof);

            Console.WriteLine("Имя файла и путь");
            string path = Console.ReadLine();
            ///тут должна быть функция
            if (path.EndsWith(".txt"))
            {

                if (File.Exists(path)) {
                   var lines = File.ReadAllLines(path);

                    for (int i = 0; i < lines.Length; i+=2)
                    {
                        Human human = new Human(lines[i], Convert.ToInt32(lines[i + 1]));
                        hum.Add(human);
                    }

                }
                else
                {
                    File.Create(path);
                }
               

            }

            else if (path.EndsWith(".json")) {
                string text = File.ReadAllText(path);
                hum = JsonConvert.DeserializeObject<List<Human>>(text);

            }

            else if (path.EndsWith(".xml")) {

                XmlSerializer xml = new XmlSerializer(typeof(List<Human>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {

                    hum = (List<Human>)xml.Deserialize(fs);

                }
            }
        foreach (var item in hum)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Age);
            }
            Console.WriteLine("куда и как сохраняем?");
            path = Console.ReadLine();

            if (path.EndsWith(".txt")) {

                foreach (var chelovek in hum)
                {
                    //сохраняем каждого человека в файл
                }
            
            }

            if (path.EndsWith(".json"))
            {

                string json = JsonConvert.SerializeObject(hum);
                File.WriteAllText(path, json);
                
            }


            if (path.EndsWith(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Human>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {

                    xml.Serialize(fs, hum);

                }
                

            }



        }
    }
}