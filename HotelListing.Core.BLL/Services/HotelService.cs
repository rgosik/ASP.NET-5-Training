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
    }
}
