using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DomainEntities.Entities;


namespace OA.Service.Interfaces
{
    public interface IFaculty
    {
        IEnumerable<Faculties> GetAllFaculties();
    }
}
