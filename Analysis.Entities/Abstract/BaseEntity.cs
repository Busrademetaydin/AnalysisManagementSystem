namespace Analysis.Entities.Abstract
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        //public bool IsDelete { get; set; } = false;
    }

}
