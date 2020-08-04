using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORE.Models.ViewModel
{
    public class AdminVM
    {
        public Category Category { get; set; }

        //DropDown Lists
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
