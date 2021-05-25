using HotelListing.Commons.DataTransferObjects;
using HotelListing.Core.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IList<HotelDTO>> GetAllHotelsAsync()
        {
            return await _hotelService.GetAllHotelsAsync();
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<HotelDTO> GetHotelAsync(int id)
        {
            return await _hotelService.GetHotelAsync(id);
        }
    }
}
