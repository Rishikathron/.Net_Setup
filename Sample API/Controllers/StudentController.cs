using Microsoft.AspNetCore.Mvc;
using Sample_API;
using Sample_API.BusinessLogic;
using Sample_API.DataModel;
using Sample_API.NewFolder;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sample_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        
        private readonly ILogger<StudentController> _logger;
        private readonly DBContext _context;
        
        public StudentController(ILogger<StudentController> logger,DBContext context)
        {
            _logger = logger;
            _context = context;
        }
        BsStudent _bsStudent;


        [HttpGet("GetStudentDetails")]
        
        public ActionResult GetStudentDetails()
        {            
            try
            {
                StudentDetails studentDetails = new StudentDetails();
                
                var result = _context.Students.Where(x => x.IsActive == true).ToList();
                if (result != null)
                {
                    //studentDetails.StudentName = result?.StudentName;
                    //studentDetails.PhoneNumber = result?.PhoneNumber;
                    //studentDetails.Email = result?.EmailId;
                    //studentDetails.Id = result.StudentId;
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        [HttpGet("GetUserDetials")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetUserDetials(int id)
        {
            try
            {
                _bsStudent = new BsStudent(_context);
                var result = _bsStudent.getUserDetails(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}