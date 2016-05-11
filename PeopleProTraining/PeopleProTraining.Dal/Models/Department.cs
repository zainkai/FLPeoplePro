using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {

    }

    public class DepartmentMetaData
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
