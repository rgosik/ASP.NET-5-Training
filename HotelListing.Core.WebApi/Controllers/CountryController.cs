using HotelListing.Commons.DataTransferObjects;
using HotelListing.Commons.Enums;
using HotelListing.Core.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync()
        {
            return await _countryService.GetAllCountriesAsync();
        }

        [HttpGet("{id:int}", Name = "GetCountry")]
        [Authorize]
        public async Task<CountryDTO> GetCountryAsync(int id) 
        {
            return await _countryService.GetCountryAsync(id);
        }

        //[HttpPost]
        //[Authorize(Roles = nameof(Roles.Administrator))]

    }
}
