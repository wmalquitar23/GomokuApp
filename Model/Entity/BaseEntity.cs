using GomokuApp.Model.Interface;

namespace GomokuApp.Model.Entity
{
    public class BaseEntity : IBaseEntity
    {
        private static DateTime DT { get; } = DateTime.Now;
        public long Id { get; set; }
        public DateTime DateCreated { get; set; } = DT;
        public DateTime DateUpdated { get; set; } = DT;
    }
}
