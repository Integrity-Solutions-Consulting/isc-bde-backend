using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.ProfileAccessCodes
{
    public class ProfileAccessCodeService : BackgroundService
    {

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeSpan _intervalo = TimeSpan.FromMinutes(12);
        public ProfileAccessCodeService(
            IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _intervalo = TimeSpan.FromMinutes(12); ;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            using PeriodicTimer timer = new PeriodicTimer(_intervalo);

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {

                try
                {
                    using (IServiceScope scope = _scopeFactory.CreateScope())
                    {
                        var repo = scope.ServiceProvider.GetRequiredService<IProfileAccessCodeRepository>();

                        await ActualizarEstados(repo, stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private async Task ActualizarEstados(
            IProfileAccessCodeRepository repo,
            CancellationToken cancellationToken)
        {
            var expirationLimit = DateTime.UtcNow.Subtract(_intervalo);

            await repo.InactiveCode(expirationLimit, cancellationToken);
        }
    }


}

