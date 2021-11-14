using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace TutorialConvertJson
{
    public class ContactManagerTest
    {
        private readonly string _resourcesDir = null;

        public ContactManagerTest()
        {
            string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            _resourcesDir = Path.Combine(projectDir, "Resources");
        }

        [Test]
        public void TestConvertJsonFileToObject()
        {
            string filePath = Path.Combine(_resourcesDir, "contact-1.json");
            ContactManager mgr = new ContactManager();
            Contact contact = mgr.ConvertJsonFileToObject(filePath);
            Assert.IsNotNull(contact);
        }

        [Test]
        public void TestConvertObjectToJsonFile()
        {
            string filePath = Path.Combine(_resourcesDir, "contact-2.json");
            Contact contact = new Contact("Jane", "Doe", "janedoe@somewhere.com");
            ContactManager mgr = new ContactManager();
            mgr.ConvertObjectToJsonFile(contact, filePath);
        }

        [Test]
        public void TestConvertJsonFileToObjectList()
        {
            string filePath = Path.Combine(_resourcesDir, "contacts-1.json");
            ContactManager mgr = new ContactManager();
            List<Contact> contacts = mgr.ConvertJsonFileToObjectList(filePath);
            Assert.AreEqual(2, contacts.Count);
        }

        [Test]
        public void TestConvertObjectListToJsonFile()
        {
            string filePath = Path.Combine(_resourcesDir, "contacts-2.json");
            List<Contact> contacts = new List<Contact>() {
                new Contact("John", "Doe", "johndoe@somewhere.com"),
                new Contact("Jane", "Doe", "janedoe@somewhere.com")
            };
            ContactManager mgr = new ContactManager();
            mgr.ConvertObjectListToJsonFile(contacts, filePath);
        }

        [Test]
        public void TestConvertJsonStringToObject()
        {
            string json = "{\"firstName\": \"John\", \"lastName\": \"Doe\"}";
            ContactManager mgr = new ContactManager();
            Contact contact = mgr.ConvertJsonStringToObject(json);
            Assert.IsNotNull(contact);
        }

        [Test]
        public void TestConvertObjectToJsonString()
        {
            string expected = "{\"firstName\":\"Jane\",\"lastName\":\"Doe\",\"emailAddress\":\"janedoe@somewhere.com\"}";
            Contact contact = new Contact("Jane", "Doe", "janedoe@somewhere.com");
            ContactManager mgr = new ContactManager();
            string actual = mgr.ConvertObjectToJsonString(contact);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestConvertJsonStringToObjectList()
        {
            string json = "[{\"firstName\": \"John\", \"lastName\": \"Doe\", \"emailAddress\":\"johndoe@somewhere.com\"}, {\"firstName\" :\"Jane\", \"lastName\": \"Doe\", \"emailAddress\":\"janedoe@somewhere.com\"}]";
            ContactManager mgr = new ContactManager();
            List<Contact> contacts = mgr.ConvertJsonStringToObjectList(json);
            Assert.AreEqual(2, contacts.Count);
        }

        [Test]
        public void TestConvertObjectListToJsonString()
        {
            string expected = "[{\"firstName\":\"John\",\"lastName\":\"Doe\",\"emailAddress\":\"johndoe@somewhere.com\"},{\"firstName\":\"Jane\",\"lastName\":\"Doe\",\"emailAddress\":\"janedoe@somewhere.com\"}]";
            List<Contact> contacts = new List<Contact>() {
                new Contact("John", "Doe", "johndoe@somewhere.com"),
                new Contact("Jane", "Doe", "janedoe@somewhere.com")
            }; ContactManager mgr = new ContactManager();
            string actual = mgr.ConvertObjectListToJsonString(contacts);
            Assert.AreEqual(expected, actual);
        }
    }
}