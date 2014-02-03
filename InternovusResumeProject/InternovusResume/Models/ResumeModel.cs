using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace InternovusResume.Models
{
    public class ResumeModel
    {
        /// <summary>
        /// Reads the xml file on the server and fills the ResumeFieldsModel with data from it.
        /// Returns the filled data to be passed to the view
        /// </summary>
        /// <returns></returns>
        public ResumeFieldsModel ReadXmlResumeData()
        {
            ResumeFieldsModel resume = new ResumeFieldsModel();

            try
            {
                var doc = XDocument.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/CVData.xml"));

                var nodes = doc.Descendants().Where(e => e.Name.LocalName.StartsWith("string")
                    && e.Parent.Name.LocalName.StartsWith("Skill"));
                foreach (var item in nodes)
                {
                    resume.Skills.Add(item.Value);
                }

                var workNodes = doc.Descendants().Where(e => e.Name.LocalName.StartsWith("string")
                    && e.Parent.Name.LocalName.StartsWith("Work"));
                foreach (var workItem in workNodes)
                {
                    resume.WorkLife.Add(workItem.Value);
                }

                resume.Repository = doc.Descendants().Where(e => e.Name.LocalName.StartsWith("Repository"))
                    .FirstOrDefault().Value;

                resume.Email = doc.Descendants().Where(e => e.Name.LocalName.StartsWith("Email"))
                    .FirstOrDefault().Value;

                resume.Name = doc.Descendants().Where(e => e.Name.LocalName.StartsWith("Name"))
               .FirstOrDefault().Value;
            }
            catch (Exception ex)
            {

            }

            return resume;
        }

        /// <summary>
        /// Serializes the class ResumeFieldsModel as xml and
        /// write(overwrites if file exists) the content of the xml data file on the server
        /// </summary>
        /// <param name="newData">passed model from the controller</param>
        public void UpdateResumeData(ResumeFieldsModel newData)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/CVData.xml")))
                {
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(newData.GetType());
                    x.Serialize(sw, newData);
                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}