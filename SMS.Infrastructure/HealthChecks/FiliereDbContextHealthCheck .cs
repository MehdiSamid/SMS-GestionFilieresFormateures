using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Infrastructure.HealthChecks
{
    public class FiliereDbContextHealthCheck : IHealthCheck
    {
        private readonly FiliereDbContext _dbContext;

        public FiliereDbContextHealthCheck(FiliereDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                // Check if the DbContext can connect to the database
                var isConnected = await _dbContext.Database.CanConnectAsync(cancellationToken);

                return isConnected
                    ? HealthCheckResult.Healthy("FiliereDbContext is connected to the database.")
                    : HealthCheckResult.Unhealthy("FiliereDbContext connection to database failed.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("FiliereDbContext check failed.", ex);
            }
        }
    }
}
