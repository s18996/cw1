using System.Xml.Serialization;

namespace cw1
{
    public class Studies
    {
        [XmlElement("name")]
        public string StudiesName { get; set; }

        [XmlElement("mode")]
        public string StudiesMode { get; set; }
    }
}
