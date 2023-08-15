using Microsoft.AspNetCore.Mvc;
using WebMvcProject.Data;

namespace WebMvcProject.Controllers
{
  public class TeacherController : Controller
  {

    //Ödev üstünden Not verilicek.
    //Create Action 
    //Update Action
    //Delete Action Yazılcak. Ekranlarıda oluşturulucak(View Sayfaları.)
    [HttpGet]
    public IActionResult Index()
    {

      ProjectDbContext db = new ProjectDbContext(); 

      List<Teacher> teacherList = db.Teachers.ToList(); 

      return View(teacherList);
    }
  }
}
