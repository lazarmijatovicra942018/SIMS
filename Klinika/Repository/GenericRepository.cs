using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Klinika.Repository
{
    public class GenericRepository<T> where T : class
    {





        public String filePath { get; set; }




        public ObservableCollection<T> PutListInObservableCollection(List<T> entities)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (T entity in entities)
            {
                collection.Add(entity);
            }

            return collection;
        }


        public void Delete(T entity)
        {
            List<T> enteties = GetAll();
            enteties.Remove(entity);
            Serialize(enteties);



        }



        public List<T> GetAll()
        {
            List<T> outputList;


            using (Stream Stream = new FileStream(@"..\\..\\File\\" + filePath, FileMode.OpenOrCreate))
            using (StreamReader sr = new StreamReader(Stream))
            using (JsonReader jsonReader = new JsonTextReader(sr))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                outputList = jsonSerializer.Deserialize<List<T>>(jsonReader);
            }

            if (outputList == null)
            {
                outputList = new List<T>();
            }
            return outputList;
        }


        public void SaveNewItem(T parameter)
        {
            List<T> parameters = GetAll();
            parameters.Add(parameter);
            Serialize(parameters);

        }



        public void Serialize(List<T> parameter)
        {
            using (StreamWriter file = File.CreateText(@"..\\..\\File\\" + filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, parameter);

            }
        }

    }
}

