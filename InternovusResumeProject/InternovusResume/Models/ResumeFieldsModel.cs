using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternovusResume.Models
{
    //All fields of the resume that will be send to the view and the controller
    public class ResumeFieldsModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Repository { get; set; }
        public List<string> Skills { get; set; }
        public List<string> WorkLife { get; set; }

        public ResumeFieldsModel()
        {
            this.Skills = new List<string>();
            this.WorkLife = new List<string>();
        }
    }
}