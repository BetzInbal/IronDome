using IronDome.Dto;
using IronDome.Models;

namespace IronDome.Utils
{
    public static class ResponseTime
    {
        public static int CalculateResponseTime(ThreatManagement threat) =>
            ((int)threat.ThreatType / (int)threat.ThreatSource) * 60;
 
    }
    
}
