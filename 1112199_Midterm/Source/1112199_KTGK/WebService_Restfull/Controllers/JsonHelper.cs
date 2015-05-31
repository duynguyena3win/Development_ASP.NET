using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebService_Restfull.Models;

namespace WebService_Restfull.Controllers
{
    class JsonHelper
    {
        private static JsonHelper _Instance = new JsonHelper();
        private JsonHelper()
        {

        }

        public static JsonHelper Instance
        {
            get
            {
                return _Instance;
            }
        }

        public JToken ParseListObject(IEnumerable<object> projects)
        {
            List<object> arr = projects.ToList<object>();
            StringBuilder sb = new StringBuilder();
            ParseStringListObject(arr, sb);
            return JArray.Parse(sb.ToString());
        }

        public JToken ParseObject(object obj)
        {
            return JObject.Parse(ParseStringObject(obj));
        }

        private void ParseStringListObject(List<object> arr, StringBuilder sb)
        {
            sb.Append("[");
            for (int i = 0; i < arr.Count(); i++)
            {
                sb.Append(ParseStringObject(arr[i]));
                if (i < arr.Count() - 1)
                    sb.Append(",\n");
            }
            sb.Append("]");
        }

        private string ParseStringObject(object obj)
        {
            if (obj.GetType() == typeof(Project))
            {
                return ParseStringProject((Project)obj);
            }
            if (obj.GetType() == typeof(Time))
            {
                return ParseStringTime((Time)obj);
            }
            if (obj.GetType() == typeof(UserProfile))
            {
                return ParseStringUser((UserProfile)obj);
            }
            return "{}";
        }

        private string ParseStringProject(Project p)
        {
            if (p == null)
            {
                return "{}";
            }
            string body = "{\ndescription:'" + p.Description.Trim()
                + "', \nname:'" + p.Name.Trim()
                + "', \npid:" + p.ProjectId
                + ", \ntotalJob:" + p.TotalTime
                + "\n}";
            return body;
        }
        private string ParseStringUser(UserProfile user)
        {
            if (user == null)
            {
                return "{}";
            }
            string body = "{\nbirthday:'" + ((DateTime)user.Birthday).ToShortDateString()
                + "', \nuid:" + user.UserId
                + ", \nusername:'" + user.UserName.Trim()
                + "'\n}";
            return body;
        }
        private string ParseStringTime(Time time)
        {
            if (time == null)
            {
                return "{}";
            }
            string body = "{\nlid:" + time.TimeId
                + ", \npid:" + time.ProjectId
                + ", \nbegin:'" + ((DateTime)time.TimeBegin)
                + "', \nend:'" + ((DateTime)time.TimeEnd)
                + "'\n}";
            return body;
        }
    }
}
