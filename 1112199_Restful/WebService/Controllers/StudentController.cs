using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class StudentController : ApiController
    {
        //
        // GET: /Student/

        static readonly IStudentReponsitory _repository = new StudentReponsitory();


        // Get Student
        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Student GetStudent(string mssv)
        {
            Student student = _repository.Get(mssv);
            if (student == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return student;
        }

        public HttpResponseMessage PostStudent(Student item)
        {
            item = _repository.Add(item);
            
            var response = Request.CreateResponse<Student>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.MSSV });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutStudent(string mssv, Student student)
        {
            student.MSSV = mssv;
            if (!_repository.Update(student))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage DeleteStudent(string mssv)
        {
            _repository.Remove(mssv);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


    }
}
