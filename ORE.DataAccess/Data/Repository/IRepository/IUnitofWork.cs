using System;
using System.Collections.Generic;
using System.Text;

namespace ORE.DataAccess.Data.Repository.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        ICategoryRepo Category { get; }

        void Save();
    }
}
