using System.Xml.Serialization;

namespace RimflixShowMaker;

[XmlRoot(ElementName="supportedVersions")]
public class SupportedVersions { 

    [XmlElement(ElementName="li")] 
    public List<string> Li { get; set; } 
}

[XmlRoot(ElementName="ModMetaData")]
public class ModMetaData { 

    [XmlElement(ElementName="name")] 
    public string Name { get; set; } 

    [XmlElement(ElementName="packageId")] 
    public string PackageId { get; set; } 

    [XmlElement(ElementName="author")] 
    public string Author { get; set; } 

    [XmlElement(ElementName="supportedVersions")] 
    public SupportedVersions SupportedVersions { get; set; } 

    [XmlElement(ElementName="description")] 
    public string Description { get; set; } 
}
