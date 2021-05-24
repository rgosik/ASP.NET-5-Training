using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Commons.DataTransferObjects
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 450, ErrorMessage = "Country Name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Short Country Name is too long")]
        public string ShortName { get; set; }
    }

    public class CountryDTO : CreateCountryDTO
    {
        public string Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }
}
