using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ScriptHub.Model.Interfaces
{
    public interface IXmlConfigEntity
    {
        [XmlElement("Type")]
        string Type { get; set; }

        [XmlElement("Name")]
        string Name { get; set; }
    }
}
