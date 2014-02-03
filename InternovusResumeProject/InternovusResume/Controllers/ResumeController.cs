using InternovusResume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternovusResume.Controllers
{
    public class ResumeController : Controller
    {

        [ActionName("Resume")]
        public ActionResult ReadXml()
        {
            ResumeModel resume = new ResumeModel();
            ResumeFieldsModel resumeData = resume.ReadXmlResumeData();
            return View(resumeData);
        }

        [ActionName("UpdateResume")]
        [HttpPost]
        public ActionResult ReturnXml(ResumeFieldsModel newData)
        {

            ResumeModel resume = new ResumeModel();
            try
            {
                resume.UpdateResumeData(newData);
            }
            catch (Exception ex)
            {
                return Content("Editing failed");
            }

            return Content("Succeesfully edite on " + DateTime.Now.ToString());

        }


    }
}
