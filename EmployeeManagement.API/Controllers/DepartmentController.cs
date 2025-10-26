using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
         private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]   
        public IActionResult GetAll() 
        {
             var  department = _departmentRepository.GetDepartments();  
            return Ok(department);  
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var departmentv = _departmentRepository.GetDepartmentById(id);  
            if(departmentv == null)
            {
                return NotFound(new { Message = "Department not found" });  
            }
            else
            {
                return Ok(departmentv);
            }
            
        }

        [HttpPost]

        public IActionResult CreateDepartment([FromBody] Department department )
        {
            if(department == null)
            {
                return BadRequest(new {message = "Invalid Data"});    
            }
            
            var result = _departmentRepository.AddDepartment(department);

            if (result)
            {
                return Ok(new { Message = "Department Created  Successfully" +
                    "" });
            }
            else
            {
                return StatusCode(500, new { Message = "Failed to create department" });
            }
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteEmployee( int id , [FromBody]  Department department)
        {
            var ExistingDept = _departmentRepository.GetDepartmentById(id);

            if(ExistingDept ==  null)
            {
                return NotFound();
            }  
            
            var result = _departmentRepository.deleteDepartment(id); 
            if (result) 
            {
                return Ok(new { message = "Department deleted successfully" });
            }
            else
            {
                return StatusCode(500, new { Message = "Failed to delete department" });
            }

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Department department)
        {
            if (department == null || id != department.DepartmentId)
                return BadRequest(new { Message = "Invalid data" });

            var existing = _departmentRepository.GetDepartmentById(id);
            if (existing == null)
                return NotFound(new { Message = "Department not found" });

            var result = _departmentRepository.UpdateDepartment(department);
            if (result)
                return Ok(new { Message = "Department updated successfully" });

            return StatusCode(500, new { Message = "Failed to update department" });
        }

    }
}
