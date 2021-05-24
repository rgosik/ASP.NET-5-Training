using Autofac;
using HotelListing.Core.BLL.Interfaces;
using HotelListing.Core.BLL.Services;
using HotelListing.Core.DataAccess.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.BLL.Autofac
{
    public class HotelListingServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<HotelListingDataAccessModule>();

            builder.RegisterType<CountryService>()
                .As<ICountryService>();
        }
    }
}
