using IronDome.Models;

namespace IronDome.Utils
{
    static class ResponseTime
    {
        public static int CalculateResponseTime(ThreatModel threat) =>
            ((int)threat.ThreatType / (int)threat.ThreatSource) * 60;
 
    }
    
}
