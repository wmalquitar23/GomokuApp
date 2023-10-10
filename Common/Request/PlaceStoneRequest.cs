namespace GomokuApp.Common.Request
{
    public class PlaceStoneRequest
    {
        public int LocationX { get; set; } = 0;
        public int LocationY { get; set; } = 0;
        public string Player { get; set; } = string.Empty;
    }
}
