using Microsoft.AspNetCore.Mvc.Rendering;
using ORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORE.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepo : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetDropDownListForCategory();

        void Update(Category category);
    }
}
