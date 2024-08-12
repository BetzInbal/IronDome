using IronDome.Data;
using IronDome.Dto;
using System.Diagnostics.Metrics;

namespace IronDome.Service
{
    public class ThreatManagementService(ApplicationDbContext context) : IThreatManagementService
    {
        public async Task Launching(CancellationToken token, int seconds, ThreatManagement threat)
        {
            int counter = seconds;
            using PeriodicTimer timer = new(TimeSpan.FromSeconds(seconds));
            while (await timer.WaitForNextTickAsync(token) & counter > 0)
            {
                Console.WriteLine($"Time left {threat.ThreatSource} to {threat.TargetArea} type {threat.ThreatType} incaming at {counter--} seconds");
            }     
        }
    }
}
