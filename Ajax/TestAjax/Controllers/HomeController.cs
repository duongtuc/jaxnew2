using Ajax.Data;
using Ajax.Data.Model;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TestAjax.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext _context;
        public HomeController()
        {
            _context = new EmployeeDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(int page , int pageSize = 3)
        {
            //lay data can hien thi
            var model = _context.Employees.OrderByDescending(x=>x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize);
            //tong so ban ghi
            var totalRow = _context.Employees.Count();
            return Json(new
            {
                data = model,
                total= totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            Employee employee = serializer.Deserialize<Employee>(model);

            bool status = true;
            var entity = _context.Employees.Find(employee.Id);

            entity.Name = employee.Name;
            entity.Age = employee.Age;
            entity.CreateDate = employee.CreateDate;
            entity.Status = employee.Status;
            try
            {
                _context.SaveChanges();
                status = true;
            }
            catch (System.Exception)
            {
                status = false;
                throw;
            }
            return Json(new
            {
                status = true
            });
        }
    }
}