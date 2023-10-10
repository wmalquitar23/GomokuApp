namespace GomokuApp.Model.Entity
{
    public class BoardState : BaseEntity
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string OccupiedBy { get; set; } = string.Empty;

    }
}
