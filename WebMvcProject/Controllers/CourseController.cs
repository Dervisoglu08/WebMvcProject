using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMvcProject.Data;
using WebMvcProject.Models;

namespace WebMvcProject.Controllers
{
  public class CourseController : Controller
  {

    ProjectDbContext db = new ProjectDbContext();

    [HttpGet]
    public IActionResult Index(int sayfa , string aranan = "", string fiyatSiralama ="asc")
    {

      var courseList = db.Courses.Include(x => x.CourseTeacher).Include(x => x.CourseStudents).Where(x => x.StartDate.Value > DateTime.Now.Date).Where(x => EF.Functions.Like(x.Name, "%" + aranan + "%")).OrderBy(x => x.StartDate).ToList();

      if (fiyatSiralama == "asc")
      {
        courseList = courseList.OrderBy(x => x.Price).ToList();
      }
      else if (fiyatSiralama == "desc")
      {
        courseList = courseList.OrderByDescending(x => x.Price).ToList();
      }

      courseList = courseList.Skip((sayfa - 1) * 5).Take(5).ToList();

      double kayitSayisi = Convert.ToDouble(db.Courses.Where(x => x.StartDate.Value > DateTime.Now.Date).Where(x => EF.Functions.Like(x.Name, "%" + aranan + "%")).Count());

      int sayfaSayisi = Convert.ToInt32(Math.Ceiling(kayitSayisi / 5));

      ViewBag.SayfaSayisi = sayfaSayisi;
      ViewBag.OncekiSayfa = sayfa == 1 ? 1 : sayfa - 1;
      ViewBag.SonrakiSayfa = sayfa == sayfaSayisi ? sayfaSayisi : sayfa + 1;

      ViewBag.Aranan = aranan;
      ViewBag.Sayfa = sayfa;
      ViewBag.FiyatSiralama = fiyatSiralama;

      return View(courseList);
    }

    [HttpGet]
    public IActionResult AssignTeacherToCourse()
    {
      ViewBag.Teachers = db.Teachers.ToList();//Öğretmenler listesi
      ViewBag.Courses = db.Courses.ToList(); //Kurslar listesi

      return View();
    }
    [HttpPost]
    public IActionResult AssignTeacherToCourse(CourseTeacher courseTeacher)
    {
      ViewBag.Teachers = db.Teachers.ToList();
      ViewBag.Courses = db.Courses.ToList();

      if (ModelState.IsValid)
      {
        Course course  = db.Courses.FirstOrDefault(x => x.Name == courseTeacher.CourseName);
        course.CourseTeacherId = courseTeacher.TeacherId;
    
        db.Courses.Update(course);
        db.SaveChanges();

      }

      return RedirectToAction("Index");
    }


  }


}
