using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageWebApp.Models
{
    public class ShowFormViewModel
    {
        /// <summary>
        /// Ülke Id
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Şehir Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// İlçe Id
        /// </summary>
        public int DistrictId { get; set; }
    }
}
