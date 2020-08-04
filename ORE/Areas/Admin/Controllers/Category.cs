using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORE.DataAccess.Data.Repository.IRepository;
using ORE.Models.ViewModel;

namespace ORE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Category : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public Category(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCategory(int? id)
        {
            AVM = new AdminVM() { Category = new Models.Category() };

            if(id != null)
            {
                AVM.Category = _unitofWork.Category.Get(id.GetValueOrDefault());
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory()
        {
            if (ModelState.IsValid)
            {
                if(AVM.Category.Id == 0)
                {
                    _unitofWork.Category.Add(AVM.Category);
                }
                else
                {
                    _unitofWork.Category.Update(AVM.Category);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(AVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Category.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var cFromDb = _unitofWork.Category.Get(id);

            if(cFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Property Category!" });
            }

            _unitofWork.Category.Remove(cFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Property Category Deleted Successfully!" });
        }

        #endregion
    }
}
