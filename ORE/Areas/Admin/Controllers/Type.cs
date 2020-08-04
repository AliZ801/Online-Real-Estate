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
    public class Type : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public Type(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddType(int? id)
        {
            AVM = new AdminVM() { SType = new Models.SType() };

            if (id != null)
            {
                AVM.SType = _unitofWork.SType.Get(id.GetValueOrDefault());
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddType()
        {
            if (ModelState.IsValid)
            {
                if (AVM.SType.Id == 0)
                {
                    _unitofWork.SType.Add(AVM.SType);
                }
                else
                {
                    _unitofWork.SType.Update(AVM.SType);
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
            return Json(new { data = _unitofWork.SType.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tFromDb = _unitofWork.SType.Get(id);

            if (tFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Sale Type!" });
            }

            _unitofWork.SType.Remove(tFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Sale Type Deleted Successfully!" });
        }

        #endregion
    }
}
