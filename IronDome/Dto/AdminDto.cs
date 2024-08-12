using IronDome.Models;

namespace IronDome.Dto
{

    public class LaunchDto
    {
        public List<ThreatManagement> Threats { get; set; }
        public Dictionary<int, CancellationTokenSource> activeLaunch {  get; set; }

    }
}
