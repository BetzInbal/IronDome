namespace IronDome.Models
{
    public class ThreatModel
    {

        public int Id { get; set; }
        public ThreatSource ThreatSource { get; set; }
        public ThreatType ThreatType { get; set; }
        public TargetArea TargetArea { get; set; }
        public int MissileAmount { get; set; }
        public bool IsInterncepted { get; set; }

    }
    public enum ThreatType
    {
        Missile = 880,
        Ballistic = 18000,
        drone = 300
    }
    public enum ThreatSource
    {
        Hamas = 70,
        Hizballa = 100,
        Hutim = 2377,
        Iran = 1600
    }
    public enum TargetArea
    {

        North,
        South,
        Center
    }
}

