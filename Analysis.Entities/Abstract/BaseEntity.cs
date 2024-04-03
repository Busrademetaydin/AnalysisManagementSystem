namespace Analysis.Entities.Abstract
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }

}
