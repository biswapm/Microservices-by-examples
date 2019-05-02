using System;
using AutoMapper;
using OnlineHotel.Infra.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineHotel.API.Configurations
{
  public static class AutoMapperSetup
  {
      public static void AddAutoMapperSetup(this IServiceCollection services)
      {
          if (services == null) throw new ArgumentNullException(nameof(services));

          services.AddAutoMapperSetup();

          // Registering Mappings automatically only works if the 
          // Automapper Profile classes are in ASP.NET project
          AutoMapperConfig.RegisterMappings();
      }
  }
}