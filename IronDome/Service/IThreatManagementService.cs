using IronDome.Dto;

namespace IronDome.Service
{
    public interface IThreatManagementService
    {
        Task Launching(CancellationToken token, int seconds, ThreatManagement threat);
    }
}
