using AutoMapper;
using HotelListing.Commons;
using HotelListing.Commons.DataTransferObjects;
using HotelListing.Core.BLL.Interfaces;
using HotelListing.Core.DataAccess.Repository.Interfaces;
using HotelListing.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.BLL.Services
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelService> _logger;
        private readonly IMapper _mapper;

        public HotelService(IUnitOfWork unitOfWork, ILogger<HotelService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IList<HotelDTO>> GetAllHotelsAsync()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();

                return  _mapper.Map<IList<HotelDTO>>(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured in the {nameof(GetAllHotelsAsync)}");
                throw;
            }
        }

        public async Task<HotelDTO> GetHotelAsync(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels
                    .Get(x => x.Id == id);

                return _mapper.Map<HotelDTO>(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured in the {nameof(GetHotelAsync)}");
                throw;
            }
        }

        public async Task<ValidationResult<HotelDTO>> CreateHotelAsync(CreateHotelDTO hotelDTO, bool modelStateIsValid)
        {
            if (!modelStateIsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateHotelAsync)}");
                return new ValidationResult<HotelDTO>(null, 400, false);
            }

            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDTO);
                await _unitOfWork.Hotels.Insert(hotel);
                await _unitOfWork.Save();

                return new ValidationResult<HotelDTO>(_mapper.Map<HotelDTO>(hotel), 200, true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateHotelAsync)}");
                return new ValidationResult<HotelDTO>(null, 500, false, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
