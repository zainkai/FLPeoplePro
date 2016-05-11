using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(BuildingMetaData))]
    public partial class Building
    {
    }

    public class BuildingMetaData
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
