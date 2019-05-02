using OnlineHotel.Infra.Application.Interfaces;
using OnlineHotel.Infra.Application.Services;
using OnlineHotel.Infra.Domain.CommandHandlers;
using OnlineHotel.Infra.Domain.Commands;
using OnlineHotel.Infra.Domain.Core.Bus;
using OnlineHotel.Infra.Domain.Core.Events;
using OnlineHotel.Infra.Domain.Core.Notifications;
using OnlineHotel.Infra.Domain.EventHandlers;
using OnlineHotel.Infra.Domain.Events;
using OnlineHotel.Infra.Domain.Interfaces;
using OnlineHotel.Infra.CrossCutting.Bus;
using OnlineHotel.Infra.CrossCutting.Identity.Authorization;
using OnlineHotel.Infra.CrossCutting.Identity.Models;
using OnlineHotel.Infra.CrossCutting.Identity.Services;
using OnlineHotel.Infra.Data.Context;
using OnlineHotel.Infra.Data.EventSourcing;
using OnlineHotel.Infra.Data.Repository;
using OnlineHotel.Infra.Data.Repository.EventSourcing;
using OnlineHotel.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineHotel.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<OnlineHotelContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}