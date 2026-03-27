namespace WebApplication1.CherryLab
{
    public class CherryLabFormatter
    {
        public string FormatBeta(CherryLabSettings settings) => $"beta:{settings.BetaTag}";

        public string FormatGamma(CherryLabSettings settings) => $"gamma:{settings.GammaTag}";
    }
}
