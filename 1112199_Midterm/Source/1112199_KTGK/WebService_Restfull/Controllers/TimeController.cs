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
    public class TimeController : ApiController
    {
        DataModelDataContext db = new DataModelDataContext();

        [HttpPost]
        public void PostTimer([FromBody]JToken getString)
        {
            Time temp = new Time();
            temp.TimeBegin = Convert.ToDateTime(getString["begin"]);
            temp.TimeEnd = Convert.ToDateTime(getString["end"]);
            temp.ProjectId = Convert.ToInt32(getString["pid"]);
            DateTime dt_begin = new DateTime(temp.TimeBegin.Value.Year, temp.TimeBegin.Value.Month, temp.TimeBegin.Value.Day, temp.TimeBegin.Value.Hour, temp.TimeBegin.Value.Minute, temp.TimeBegin.Value.Second, temp.TimeBegin.Value.Millisecond);
            DateTime dt_end = new DateTime(temp.TimeEnd.Value.Year, temp.TimeEnd.Value.Month, temp.TimeEnd.Value.Day, temp.TimeEnd.Value.Hour, temp.TimeEnd.Value.Minute, temp.TimeEnd.Value.Second, temp.TimeEnd.Value.Millisecond);
            db.Projects.Single(x => x.ProjectId == temp.ProjectId).TotalTime += (dt_end - dt_begin).TotalSeconds;
            db.Times.InsertOnSubmit(temp);
            db.SubmitChanges();
        }

        [HttpGet]
        public JToken GetTimes(int idProject)
        {
            return JsonHelper.Instance.ParseListObject(db.Times.Where(x => x.ProjectId == idProject).OrderBy(x => x.TimeEnd));
        }

        [HttpDelete]
        public bool DeleteTime(int idTime)
        {
            Time temp = db.Times.Single(x => x.TimeId == idTime);
            if (temp != null)
            {
                db.Times.DeleteOnSubmit(temp);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        public void PutTime([FromBody]JToken getString)
        {
            Project currentPro = db.Projects.Single(p => p.ProjectId == Convert.ToInt32(getString["pid"]));
            Time currentTime = db.Times.Single(x => x.TimeId == Convert.ToInt32(getString["lid"]));
            
            DateTime dt_begin = new DateTime(currentTime.TimeBegin.Value.Year, currentTime.TimeBegin.Value.Month, currentTime.TimeBegin.Value.Day, currentTime.TimeBegin.Value.Hour, currentTime.TimeBegin.Value.Minute, currentTime.TimeBegin.Value.Second, currentTime.TimeBegin.Value.Millisecond);
            DateTime dt_end = new DateTime(currentTime.TimeEnd.Value.Year, currentTime.TimeEnd.Value.Month, currentTime.TimeEnd.Value.Day, currentTime.TimeEnd.Value.Hour, currentTime.TimeEnd.Value.Minute, currentTime.TimeEnd.Value.Second, currentTime.TimeEnd.Value.Millisecond);
            currentPro.TotalTime -= (dt_end - dt_begin).TotalSeconds;

            currentTime.TimeBegin = Convert.ToDateTime(getString["begin"]);
            currentTime.TimeEnd = Convert.ToDateTime(getString["end"]);
            dt_begin = new DateTime(currentTime.TimeBegin.Value.Year, currentTime.TimeBegin.Value.Month, currentTime.TimeBegin.Value.Day, currentTime.TimeBegin.Value.Hour, currentTime.TimeBegin.Value.Minute, currentTime.TimeBegin.Value.Second, currentTime.TimeBegin.Value.Millisecond);
            dt_end = new DateTime(currentTime.TimeEnd.Value.Year, currentTime.TimeEnd.Value.Month, currentTime.TimeEnd.Value.Day, currentTime.TimeEnd.Value.Hour, currentTime.TimeEnd.Value.Minute, currentTime.TimeEnd.Value.Second, currentTime.TimeEnd.Value.Millisecond);

            currentPro.TotalTime += (dt_end - dt_begin).TotalSeconds;
            
            db.SubmitChanges();
        }
    }
}
