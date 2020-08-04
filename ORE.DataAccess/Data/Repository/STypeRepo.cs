using Microsoft.AspNetCore.Mvc.Rendering;
using ORE.DataAccess.Data.Repository.IRepository;
using ORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORE.DataAccess.Data.Repository
{
    public class STypeRepo : Repository<SType>, ISTypeRepo
    {
        private readonly ApplicationDbContext _db;

        public STypeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForSType()
        {
            return _db.SType.Select(i => new SelectListItem()
            {
                Text = i.Type,
                Value = i.Id.ToString()
            });
        }

        public void Update(SType sType)
        {
            var tFromDb = _db.SType.FirstOrDefault(i => i.Id == sType.Id);

            tFromDb.Type = sType.Type;

            _db.SaveChanges();
        }
    }
}
