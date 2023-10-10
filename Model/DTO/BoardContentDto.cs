namespace GomokuApp.Model.DTO
{
    public class BoardContentDto
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string Player { get; set; } = string.Empty;
    }
}
