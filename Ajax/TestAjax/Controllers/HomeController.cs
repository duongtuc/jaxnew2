using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TestAjax.Models;

namespace TestAjax.Controllers
{
    public class HomeController : Controller
    {
        List<EmployeeModel> listEmployee = new List<EmployeeModel>()
        {
            new EmployeeModel()
        {

            Id = 1,
                Name = "Nguyen van A",
                Age = 18,
                Status = true

            },
        new EmployeeModel()
        {

            Id = 2,
                Name = "Nguyen van B",
                Age = 18,
                Status = true

            },
            new EmployeeModel()
        {

            Id = 3,
                Name = "Nguyen van C",
                Age = 22,
                Status = true

            },
            new EmployeeModel()
        {

            Id = 4,
                Name = "Nguyen van Cd",
                Age = 22,
                Status = true

            }
        };


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(int page , int pageSize = 3)
        {
            //lay data can hien thi
            var model = listEmployee.Skip((page - 1) * pageSize).Take(pageSize);
            //tong so ban ghi
            var totalRow = listEmployee.Count();
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

            EmployeeModel employee = serializer.Deserialize<EmployeeModel>(model);

            var entity = listEmployee.Single(x => x.Id == employee.Id);

            entity.Age = employee.Age;

            return Json(new
            {
                status = true
            });
        }
    }
}