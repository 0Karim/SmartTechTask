using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DomainEntities.Entities;
using OA.Repo.Repository;
using OA.Repo.UnitOfWork;
using OA.Service.Interfaces;


namespace OA.Service
{
    public class StudentService : IStudentBusiness
    {

        private readonly IUnitOfWork<Students> _unitOfWork;

        public StudentService(IUnitOfWork<Students> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Students GetStudent(int id)
        {
            var student = _unitOfWork.Repo.Get(id);
            return student;
        }

        public IEnumerable<Students> GetStudents()
        {
            var students_list = _unitOfWork.Repo.GetAll();
            //Mapping go here later
            return students_list;
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentException("There is no student with this id");

                _unitOfWork.Repo.Delete(id);

                return _unitOfWork.Complete() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertStudent(Students student)
        {
            _unitOfWork.Repo.Insert(student);
            return _unitOfWork.Complete() > 0;
        }

        public bool UpdateStudent(Students student)
        {
            _unitOfWork.Repo.Update(student);
            return _unitOfWork.Complete() > 0;
        }
    }
}
