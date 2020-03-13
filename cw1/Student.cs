using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace cw1
{
    [XmlType("student")]
    public class Student
    {
        private string lastName;
        private string email;

        [XmlElement("fname")]
        public string FirstName { get; set; }

        [XmlElement("lname")]
        public string LastName
        {
            get => lastName;
            set => lastName = Regex.Replace(value, @"[\d-]", string.Empty);
        }

        [XmlAttribute("indexNumber")]
        public string Index { get; set; }

        [XmlElement("birthdate")]
        public string Birthdate { get; set; }

        [XmlElement("email")]
        public string Email { 
            get => email;
            set => email = Index + value.Substring(value.IndexOf("@")); 
        }

        [XmlElement("mothersName")]
        public string MothersName { get; set; }

        [XmlElement("fathersName")]
        public string FathersName { get; set; }

        [XmlElement("studies")]
        public Studies _Studies { get; set; }

    }
}
