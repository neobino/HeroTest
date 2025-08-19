namespace Application.Models.HeroUpgrade
{
    public class UpgradeResult
    {
        public bool Success {get; }
        public HeroSnapshot Snapshot { get; }
        public string? Error { get; }

        public UpgradeResult(bool success, HeroSnapshot snapshot, string? error = null)
        {
            Success = success;
            Snapshot = snapshot;
            Error = error;
        }
    }
}