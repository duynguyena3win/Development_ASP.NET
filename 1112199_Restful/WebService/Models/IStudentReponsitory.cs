using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    interface IStudentReponsitory
    {
        IQueryable<Student> GetAll();
        Student Get(string mssv);
        Student Add(Student item);
        void Remove(string mssv);
        bool Update(Student item);
    }
}
