using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meetcore.Feature.Events
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<Controllers.EventsController>();
            serviceCollection.AddTransient<Services.IEventRepository, Services.EventRepository>();
        }
    }
}