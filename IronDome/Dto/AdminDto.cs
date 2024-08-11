using IronDome.Models;

namespace IronDome.Dto
{

    public class AdminDto
    {
        public int MissileAmount { get; set; } = 200;
        public Queue<ThreatModel> ActiveThreats { get; set; } = [];


    }
}
