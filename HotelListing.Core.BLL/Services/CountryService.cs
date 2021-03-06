using AutoMapper;
using HotelListing.Commons.DataTransferObjects;
using HotelListing.Core.BLL.Interfaces;
using HotelListing.Core.DataAccess.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.BLL.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryService> _logger;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, ILogger<CountryService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();

                return _mapper.Map<IList<CountryDTO>>(countries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured in the {nameof(GetAllCountriesAsync)}");
                throw;
            }
        }

        public async Task<CountryDTO> GetCountryAsync(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries
                    .Get(x => x.Id == id,
                    new List<string> { "Hotels" });

                return _mapper.Map<CountryDTO>(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured in the {nameof(GetCountryAsync)}");
                throw;
            }
        }
    }
}
