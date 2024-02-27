using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    /// <summary>
    /// Abstracts operationsof DDDItem to Application layer.
    /// </summary>
    public interface IDDDService
    {
        public void CreateDDD(DDDItem DDD);
        public bool UpdateDDD(DDDItem DDD);
        public bool DeleteDDD(int id);
        public DDDItem GetDDD(int id);
        public IEnumerable<DDDItem> GetAllDDDs();
    }
}
