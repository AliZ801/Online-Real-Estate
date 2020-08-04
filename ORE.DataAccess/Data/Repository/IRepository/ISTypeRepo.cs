using Microsoft.AspNetCore.Mvc.Rendering;
using ORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORE.DataAccess.Data.Repository.IRepository
{
    public interface ISTypeRepo : IRepository<SType>
    {
        IEnumerable<SelectListItem> GetDropDownListForSType();

        void Update(SType sType);
    }
}
