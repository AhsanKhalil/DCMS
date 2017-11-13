using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObjects.Linq2SQL.MetaData
{
    public class LocationMetaData
    {
        [Display(Name = "Name")]
        public string NAME { get; set; }

        [Display(Name = "Address")]
        public string ADDRESS { get; set; }

        [Display(Name = "Contact 1")]
        public string CONTACT_1 { get; set; }

        [Display(Name = "Contact 2")]
        public string CONTACT_2 { get; set; }

        [Display(Name = "Contact 3")]
        public string CONTACT_3 { get; set; }

        [Display(Name = "Fax No")]
        public string FAX_NO { get; set; }

        [Display(Name = "City")]
        public string CITY { get; set; }

        [Display(Name = "Email")]
        public string EMAIL { get; set; }

        [Display(Name = "Created User")]
        public string CREATED_USER { get; set; }

        [Display(Name = "Created On")]
        public DateTime CREATED_ON { get; set; }

        [Display(Name = "Modified User")]
        public string MODIFIED_USER { get; set; }

        [Display(Name = "Modified On")]
        public DateTime MODIFIED_ON { get; set; }

    }
}
