using Microsoft.AspNetCore.Mvc.Rendering;
using ORE.DataAccess.Data.Repository.IRepository;
using ORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORE.DataAccess.Data.Repository
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForCategory()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.PCategory,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            var cFromDb = _db.Category.FirstOrDefault(i => i.Id == category.Id);

            cFromDb.PCategory = category.PCategory;

            _db.SaveChanges();
        }
    }
}
