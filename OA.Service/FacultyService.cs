using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DomainEntities.Entities;
using OA.Repo.UnitOfWork;
using OA.Service.Interfaces;

namespace OA.Service
{
    public class FacultyService : IFaculty
    {
        private readonly IUnitOfWork<Faculties> _unitOfWork;

        public FacultyService(IUnitOfWork<Faculties> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Faculties> GetAllFaculties()
        {
            return _unitOfWork.Repo.GetAll().ToList();
        }
    }
}
