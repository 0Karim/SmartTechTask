using OA.DomainEntities.Entities;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OA.ApiTemp.Controllers
{

    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        /*
            * there is a mapper should be implemented
            */

        private readonly IStudentBusiness _stuentbusiness;

        public StudentController(IStudentBusiness business)
        {
            _stuentbusiness = business;
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddStudent([FromBody]Students entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (entity == null)
                        throw new ArgumentNullException(nameof(entity), "student model can not be null");

                    bool result = _stuentbusiness.InsertStudent(entity);
                    if (result == false)
                    {
                        return NotFound();
                        //return BadRequest();
                    }
                    return Ok("Saved Successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("delete")]
        public IHttpActionResult DeleteStudent(int id)
        {
            try
            {
                var deleted_student = _stuentbusiness.DeleteStudent(id);
                if (deleted_student)
                {
                    return Ok("Deleted Successfully");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Student
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllStudents()
        {
            try
            {
                var studentList = _stuentbusiness.GetStudents();
                if (studentList.Any())
                {
                    return Ok(studentList);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetStudent(int id)
        {
            try
            {
                var student = _stuentbusiness.GetStudent(id);
                if (student != null)
                {
                    return Ok(student);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public IHttpActionResult UpdateStudent([FromBody] Students entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (entity == null)
                        throw new ArgumentNullException(nameof(entity), "Studnt can not be null");
                    if (entity.ID <= 0)
                        throw new ArgumentException("student id must be positive integer.");

                    //var entity_to_update = _stuentbusiness.GetStudent(entity.ID);
                    //if(entity_to_update == null)
                    //    throw new ArgumentException("There is no student with this id.");

                    bool result = _stuentbusiness.UpdateStudent(entity);
                    if (result == false)
                    {
                        return NotFound();
                        //return BadRequest("not updated");
                    }
                    return Ok("Updated Successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest(ModelState);

        }
    }
    
}
