using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Commons.DataTransferObjects
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 450, ErrorMessage = "Hotel Name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 450, ErrorMessage = "Hotel Name is too long")]
        public string Address { get; set; }

        [Required]        
        public string Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

    public class HotelDTO : CreateHotelDTO
    {
        public int id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
