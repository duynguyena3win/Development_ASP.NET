using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService_Restfull.Models;

namespace WebService_Restfull.Controllers
{
    public class ProjectController : ApiController
    {
        DataModelDataContext db = new DataModelDataContext();

        [HttpGet]
        public JToken GetAllProjects(string username)
        {
            return JsonHelper.Instance.ParseListObject(db.Projects.Where(p => p.UserProfile.UserName.Trim().ToLower().Equals(username)));
        }

        [HttpGet]
        public JToken GetProjects(int id)
        {
            return JsonHelper.Instance.ParseObject(db.Projects.Single(p => p.ProjectId == id));
        }

        [HttpDelete]
        public bool DeleteProject(int id)
        {
            Project temp = db.Projects.Single(x => x.ProjectId == id);
            if(temp != null)
            {
                db.Projects.DeleteOnSubmit(temp);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        public bool PutEditProject(JToken getString)
        {
            Project myPro = db.Projects.Single(x => x.ProjectId == Convert.ToInt32(getString["pid"]));
            if (myPro != null)
            {
                myPro.Name = getString["name"].ToString();
                myPro.Description = getString["description"].ToString();
                db.SubmitChanges();
                return true;
            }
            return false;
        }


        [HttpPost]
        public bool PostNewProject(JToken getString)
        {
            int idUser = db.UserProfiles.Single(x => x.UserName.Trim().ToLower().Equals(getString["username"].ToString())).UserId;
            Project myPro = new Project();
            myPro.Name = getString["name"].ToString();
            myPro.Description = getString["description"].ToString();
            myPro.TotalTime = 0;
            myPro.UserId = idUser;
            db.Projects.InsertOnSubmit(myPro);
            db.SubmitChanges();
            return false;
        }
    }
}
