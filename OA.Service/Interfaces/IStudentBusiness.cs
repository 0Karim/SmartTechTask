using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DomainEntities.Entities;

namespace OA.Service.Interfaces
{
    public interface IStudentBusiness
    {
        IEnumerable<Students> GetStudents();
        Students GetStudent(int id);
        bool InsertStudent(Students student);
        bool UpdateStudent(Students student);
        bool DeleteStudent(int id);
    }
}
