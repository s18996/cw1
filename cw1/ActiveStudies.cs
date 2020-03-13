using System.Xml.Serialization;

namespace cw1
{
    [XmlType("studies")]
    public class ActiveStudies
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("numberOfStudents")]
        public string NumberOfStudents { get; set; }
    }
}
