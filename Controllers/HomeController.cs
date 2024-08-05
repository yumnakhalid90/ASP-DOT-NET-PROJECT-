using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using prac_demo_enitity_framework.Models;

namespace prac_demo_enitity_framework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDatabaseContext _applicationDb;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public HomeController(ApplicationDatabaseContext applicationDb, IWebHostEnvironment Whe)
        {
            this._applicationDb = applicationDb;
            this._WebHostEnvironment = Whe;
        }

        public IActionResult AddEmployee()
        {

            //var data = _applicationDb.Admins.ToList();
            return View();
        }
        [HttpPost]

        // to increase file limit 1024bytes x 1024kb x 1000mb = 1GB
        [RequestFormLimits(MultipartBodyLengthLimit = 1048576000)]
        [RequestSizeLimit(1048576000)]
        public IActionResult AddEmployee(Admin admin)
        {
            //if (ModelState.IsValid) {   
            string filename = "";
            if (admin.AdminProfile != null)
            {
                string uploadFolder = Path.Combine(
                    _WebHostEnvironment.WebRootPath,
                    "Content/Images");
                filename = Guid.NewGuid().ToString() + " " + admin.AdminProfile.FileName;  // creating filename
                string filepath = Path.Combine(uploadFolder, filename);
                string extension = Path.GetExtension(admin.AdminProfile.FileName);
                //TempData["success"] = filename;
                //if (extension.ToLower() == ".jfif" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                //{
                admin.AdminProfile.CopyTo(new FileStream(filepath, FileMode.Create));
                if (admin.AdminProfile.Length <= 1048576000)
                {
                    Admin adm = new Admin()
                    {
                        AdminName = admin.AdminName,
                        AdminEmail = admin.AdminEmail,
                        AdminContact = admin.AdminContact,
                        AdminAge = admin.AdminAge,
                        AdminDept = admin.AdminDept,
                        AdminImg = filename
                    };

                    _applicationDb.Admins.Add(adm);  //LINQ query
                    _applicationDb.SaveChanges();
                    TempData["success"] = "Record inserted successfully...";
        
                    return RedirectToAction("Index", "Home");
                }
                //else
                //    {
                //        TempData["Error"] = "File size is not valid...";
                //    }
                //}
            }
            //}
            return View();
        }

        public IActionResult Index()

        {

            var data = _applicationDb.Admins.ToList();
            return View(data);
        }

        public IActionResult Delete(int id)

        {
           var fetch_employee_delete = _applicationDb.Admins.Find(id);
           return View(fetch_employee_delete);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)

        {
            var emp_data = _applicationDb.Admins.Find(id);
           if (emp_data != null)
           {
               _applicationDb.Admins.Remove(emp_data);
               _applicationDb.SaveChanges();
        TempData["success"] = "Employee Deleted Successfully";
               return RedirectToAction("Index", "Home");
            }
           return View();
        }

        public IActionResult Edit(int id)
        {
            var editdetails = _applicationDb.Admins.Find(id);
   
            return View(editdetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, Admin admin)
        {
            var data = _applicationDb.Admins.Find(id);
            string filename = "";
            if (admin.AdminProfile != null)
            {


                string uploadFolder = Path.Combine(_WebHostEnvironment.WebRootPath, "Content/Images");
                filename = Guid.NewGuid().ToString() + " " + admin.AdminProfile.FileName;  // creating filename
                string filepath = Path.Combine(uploadFolder, filename);
                string extension = Path.GetExtension(admin.AdminProfile.FileName);
                //TempData["success"] = filename;
                //if (extension.ToLower() == ".jfif" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                //{
                admin.AdminProfile.CopyTo(new FileStream(filepath, FileMode.Create));
                if (admin.AdminProfile.Length <= 1048576000)
                {

                    data.AdminName = admin.AdminName;
                    data.AdminEmail = admin.AdminEmail;
                    data.AdminContact = admin.AdminContact;
                    data.AdminAge = admin.AdminAge;
                    data.AdminDept = admin.AdminDept;
                    data.AdminImg = filename;


                }
                //if (ModelState.IsValid)
                //{
                _applicationDb.Admins.Update(data);  //LINQ query
                _applicationDb.SaveChanges();
                TempData["success"] = "Record updated successfully...";
                return RedirectToAction("Index", "Home");
                //}

            }
            return View(admin);
        }


        public IActionResult Detail(int id)

        {
            var specific_data = _applicationDb.Admins.Find(id);
            return View(specific_data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}