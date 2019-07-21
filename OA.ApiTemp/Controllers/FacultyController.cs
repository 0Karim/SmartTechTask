using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OA.ApiTemp.Controllers
{

    [Route("api/faculty")]
    public class FacultyController : ApiController
    {
        /*
            * there is a mapper should be implemented
            */

        private readonly IFaculty _facultybusiness;

        public FacultyController(IFaculty business)
        {
            this._facultybusiness = business;
        }

        [HttpGet]
        public IHttpActionResult GetAllFaculties()
        {
            try
            {
                var facultyList = _facultybusiness.GetAllFaculties();
                if (facultyList.Any())
                {
                    return Ok(facultyList);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
