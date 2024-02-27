using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    /// <summary>
    /// Individual DDDs aggregated into a recurring location (DDDAggregate).
    /// </summary>
    public class DDDItem
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string JobTitle { get; set; }
        public int JobRank { get; set; }

        public DDDItem(string Name, string Gender, string Phone, string Birthday, string JobTitle, int JobRank)
        {
            this.Name = Name;
            this.Gender = Gender;
            this.Phone = Phone;
            this.Birthday = Birthday;
            this.JobTitle = JobTitle;
            this.JobRank = JobRank;
        }
    }
}
