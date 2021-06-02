using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;

/// <summary>
/// Summary description for OffreDao
/// </summary>
public class OffreDao
{
	public OffreDao()
	{
	}
    public void Create(Offre offre)
    {
        XDocument doc;
        //string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        String strFileName = @"C:\Users\Phoenix\Documents\Visual Studio 2010\WebSites\FreelanceCollector\App_Data\offres.xml";
        if (!File.Exists(strFileName))
        {
            doc = new XDocument(new XDeclaration("1.0", "utf-16", "true"),
            new XElement("Offres"));
            doc.Save(strFileName);
        }
        doc = XDocument.Load(strFileName);  //load the xml file.
        doc.Root.AddFirst(new XElement("Offre",
            new XAttribute("Id", Guid.NewGuid().ToString().Replace("-", "")),
            new XElement("Titre", offre.Titre),
            new XElement("Lien", offre.Lien),
            new XElement("Description", offre.Description),
            new XElement("Prix", offre.Prix),
            new XElement("Categorie", offre.Categorie.Nom),
            new XElement("Image", offre.Img)));
        doc.Save(strFileName);
    }
    public void Delete()
    {
        string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        String strFileName = wanted_path + "/App_Data/offres.xml";
        XDocument doc = XDocument.Load(strFileName);
        doc.Root.Nodes().Remove();
        doc.Save(strFileName);
    }
    public LinkedList<Offre> Select()
    {
        Offre offre = new Offre();
        LinkedList<Offre> list = new LinkedList<Offre>();
        string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        String strFileName = wanted_path + "/App_Data/offres.xml";
        XElement root = XElement.Load(strFileName);
        IEnumerable<XElement> tests =
            from el in root.Elements("Offre")
            where (string)el.Element("Categorie") == "Java"
            select el;
        foreach (XElement el in tests)
        {
            offre.Id = (string)el.Attribute("Id");
            offre.Titre = (string)el.Element("Titre");
            offre.Lien = (string)el.Element("Lien");
            offre.Prix = (string)el.Element("Prix");
            offre.Img = (string)el.Element("Image");
            offre.Categorie = new Categorie((string)el.Element("Categorie"));
            offre.Description = (string)el.Element("Description");
            list.AddLast(offre);
            offre = new Offre();
            /*
            list.AddFirst((string)el.Attribute("Id"));
            list.AddFirst((string)el.Element("Titre"));
            list.AddFirst((string)el.Element("Lien"));
            list.AddFirst((string)el.Element("Prix"));
            list.AddFirst((string)el.Element("Image"));
            list.AddFirst((string)el.Element("Categorie"));
            list.AddFirst((string)el.Element("Description"));
            list.AddFirst("---------------");*/

        }
        return list;
    }
}