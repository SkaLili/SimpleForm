using SimpleForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;



namespace SimpleForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Person p = new Person();
            return View(p);
        }
        public ActionResult SetData(Person person)
        {
            string xmlFilePath = "~/Content/XMLFile.xml";//иногда приходиться указывать полный адрес
            XDocument xDoc = XDocument.Load(xmlFilePath);
            XElement xe = xDoc.Element("persons");
            xe.Add( new XElement("person",
                new XAttribute("name",person.Name),
                new XElement("hotman",person.HotMen),
                new XElement("talkative",person.Talkative)));
            xDoc.Save(xmlFilePath);
            person.HotMen = true;
            return View(person);
        }
    }
}