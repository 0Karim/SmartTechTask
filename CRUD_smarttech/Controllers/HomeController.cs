using CRUD_smarttech.ViewModels;
using OA.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUD_smarttech.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> AddStudent()
        {
            List<Faculties> faculty_list = await GetFaculties();
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                ID = 0,
                faculties = faculty_list
            };
            return View(studentViewModel);
        }

        [HttpGet]
        [Route("Home/EditStudent/{id}")]
        public async Task<ActionResult> EditStudent(int id)
        {
            try
            {

                if(id == 0)
                {
                    throw new ArgumentException("There is No Such ID");
                }
                List<Faculties> faculty_list = await GetFaculties();

                Students edit_student = await GetStudent(id);
                if (edit_student == null)
                {
                    throw new ArgumentNullException("There is No Student ID");
                }
                StudentViewModel edit_studentViewModel = new StudentViewModel()
                {
                    ID = id,
                    Name = edit_student.Name,
                    DateOfBirth = edit_student.DateOfBirth,
                    Address = edit_student.Address,
                    Image = edit_student.Image,
                    Phone = edit_student.Phone,
                    FacultyID = edit_student.FacultyID,
                    faculties = faculty_list
                };

                return View(edit_studentViewModel);
            }
            catch(Exception ex)
            {
                return Json("fail" , JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<Students> GetStudent(int id)
        {
            string apiUrl = "http://localhost:53662/api/student/" + id;
            Students edit_student = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Students>();
                    edit_student = data;
                }
            }
            return edit_student;
        }

        public async Task<List<Faculties>> GetFaculties()
        {
            string apiUrl = "http://localhost:53662/api/faculty";

            List<Faculties> faculties = new List<Faculties>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<Faculties>>();
                    faculties = data;
                }
            }
            return faculties;
        }

        public JsonResult UploadFile()
        {
            string folderPath = "~/images/Images";
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                                //Use the following properties to get file's name, size and MIMEType
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    System.IO.Stream fileContent = file.InputStream;

                    fileName = DateTime.Now.ToString("yyyyMMddHHss") + fileName;

                    //To save file, use SaveAs method
                    file.SaveAs(Server.MapPath(folderPath) + fileName); //File will be saved in application root

                    Session["filePath"] = folderPath + fileName;
                }
                return Json("Uploaded " + Request.Files.Count + " files");
            }
            catch(Exception ex)
            {
                Session["filePath"] = null;
                return Json("Failed to Upload");
            }
        }

        public ActionResult getFilePath()
        {
            if (Session["filePath"] != null)
            {
                string filepath = Convert.ToString(Session["filePath"]);
                Session["filePath"] = null;
                return Json(filepath, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("You Should Choose Image" , JsonRequestBehavior.AllowGet);
            }
        }
    }
}