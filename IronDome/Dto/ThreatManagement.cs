using IronDome.Models;

namespace IronDome.Dto
{
	public record ThreatManagement
	{
		public int Id { get; set; }
		public ThreatSource ThreatSource { get; set; }
		public ThreatType ThreatType { get; set; }
		public TargetArea TargetArea { get; set; }
		public int MissileAmount { get; set; }
		public bool IsActive { get; set; }
	}
}
