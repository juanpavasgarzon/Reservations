using Core.Reservations.Create;
using Core.Reservations.Delete;
using Core.Reservations.Get;
using Core.Spaces.Create;
using Core.Spaces.Delete;
using Core.Spaces.Get;
using Core.Users.Login;
using Core.Users.Register;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class DependencyInjection
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        services.AddUserModule();

        services.AddSpaceModule();

        services.AddReservationModule();
    }

    private static void AddUserModule(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();

        services.AddScoped<IRegisterUserService, RegisterUserService>();
    }

    private static void AddSpaceModule(this IServiceCollection services)
    {
        services.AddScoped<ICreateSpaceService, CreateSpaceService>();

        services.AddScoped<IDeleteSpaceService, DeleteSpaceService>();

        services.AddScoped<IGetSpacesService, GetSpacesService>();
    }

    private static void AddReservationModule(this IServiceCollection services)
    {
        services.AddScoped<ICreateReservationService, CreateReservationService>();

        services.AddScoped<IDeleteReservationService, DeleteReservationService>();

        services.AddScoped<IGetReservationsService, GetReservationsService>();
    }
}