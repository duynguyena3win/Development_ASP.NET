using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class StudentReponsitory : IStudentReponsitory
    {
        private readonly List<Student> _students = new List<Student>();
        private int _nextId = 1;

        public StudentReponsitory()
        {
            this.Add(new Student() { Name = "Nguyen Duy Nguyen", MSSV = "1112199", Score = 7.2f });
            this.Add(new Student() { Name = "Nguyen Dang Khoa", MSSV = "1112145", Score = 6.8f });
            this.Add(new Student() { Name = "Dang Quoc Phap", MSSV = "1112216", Score = 6.7f });
        }

        public IQueryable<Student> GetAll()
        {
            return _students.AsQueryable();
        }

        public Student Get(string mssv)
        {
            return _students.Find(c => c.MSSV == mssv);
        }

        public Student Add(Student item)
        {
            _students.Add(item);
            return item;
        }

        
        public bool Update(Student item)
        {
            int index = _students.FindIndex(c => c.MSSV == item.MSSV);
            if (index == -1)
            {
                return false;
            }
            _students.RemoveAt(index);
            _students.Add(item);
            return true;
        }


        public void Remove(string mssv)
        {
            Student contact = _students.Find(c => c.MSSV == mssv);
            _students.Remove(contact);
        }
    }
}