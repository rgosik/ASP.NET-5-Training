using HotelListing.Commons.DataTransferObjects;
using HotelListing.Commons.Enums;
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

        [HttpGet("{id:int}", Name = "GetHotel")]
        [Authorize]
        public async Task<HotelDTO> GetHotelAsync(int id)
        {
            return await _hotelService.GetHotelAsync(id);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Roles.Administrator))]
        public async Task<IActionResult> CreateHotelAsync([FromBody] CreateHotelDTO hotelDTO)
        {
            var result = await _hotelService.CreateHotelAsync(hotelDTO, ModelState.IsValid);

            if (result.Succesful)
            {
                return CreatedAtRoute("GetHotel", new { id = result.Content.Id }, result.Content);
            }
            return StatusCode(result.StatusCode, result.Message);
        }

    }
}
