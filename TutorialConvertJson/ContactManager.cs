using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TutorialConvertJson
{
    public class ContactManager
    {

        public Contact ConvertJsonFileToObject(string filePath)
        {
            return JsonConvert.DeserializeObject<Contact>(File.ReadAllText(filePath));
        }

        public void ConvertObjectToJsonFile(Contact contact, string filePath)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(contact, Formatting.Indented));
        }

        public List<Contact> ConvertJsonFileToObjectList(string filePath)
        {
            return JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(filePath));
        }

        public void ConvertObjectListToJsonFile(List<Contact> contacts, string filePath)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(contacts, Formatting.Indented));
        }

        public Contact ConvertJsonStringToObject(string json)
        {
            return JsonConvert.DeserializeObject<Contact>(json);
        }
    }
}
