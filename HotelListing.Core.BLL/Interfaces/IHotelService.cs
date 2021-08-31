using HotelListing.Commons;
using HotelListing.Commons.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.BLL.Interfaces
{
    public interface IHotelService
    {
        Task<IList<HotelDTO>> GetAllHotelsAsync();
        Task<HotelDTO> GetHotelAsync(int id);
        Task<ValidationResult<HotelDTO>> CreateHotelAsync(CreateHotelDTO hotelDTO, bool modelStateIsValid);
    }
}
