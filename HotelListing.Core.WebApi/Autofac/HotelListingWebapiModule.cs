using Autofac;
using HotelListing.Core.BLL.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Core.WebApi.Autofac
{
    public class HotelListingWebapiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<HotelListingServicesModule>();
        }
    }
}
