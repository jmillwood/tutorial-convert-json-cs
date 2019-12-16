using System;
using Newtonsoft.Json;

namespace TutorialConvertJson
{
    public class Contact
    {
        public Contact()
        {

        }

        public Contact(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public string MobilePhone { get; set; }
    }
}
