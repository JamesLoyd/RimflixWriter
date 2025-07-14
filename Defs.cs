using System.Xml.Serialization;

namespace RimflixShowMaker;

[XmlRoot(ElementName="televisionDefs")]
public class TelevisionDefs { 

    [XmlElement(ElementName="li")] 
    public string Li { get; set; } 
}

[XmlRoot(ElementName="li")]
public class ImageSource { 

    [XmlElement(ElementName="texPath")] 
    public string TexPath { get; set; } 

    [XmlElement(ElementName="graphicClass")] 
    public string GraphicClass { get; set; } 
}

[XmlRoot(ElementName="frames")]
public class Frames { 

    [XmlElement(ElementName="li")] 
    public List<ImageSource> Li { get; set; } 
}

[XmlRoot(ElementName="RimFlix.ShowDef")]
public class RimFlixShowDef { 

    [XmlElement(ElementName="defName")] 
    public string DefName { get; set; } 

    [XmlElement(ElementName="label")] 
    public string Label { get; set; } 

    [XmlElement(ElementName="description")] 
    public string Description { get; set; } 

    [XmlElement(ElementName="televisionDefs")] 
    public TelevisionDefs TelevisionDefs { get; set; } 

    [XmlElement(ElementName="secondsBetweenFrames")] 
    public double SecondsBetweenFrames { get; set; } 

    [XmlElement(ElementName="sound")] 
    public object Sound { get; set; } 

    [XmlElement(ElementName="frames")] 
    public Frames Frames { get; set; } 
}

[XmlRoot(ElementName="Defs")]
public class Defs { 

    [XmlElement(ElementName="RimFlix.ShowDef")] 
    public RimFlixShowDef RimFlixShowDef { get; set; } 
}

