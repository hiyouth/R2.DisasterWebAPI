
namespace R2.Disaster.CoreEntities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Book Book { get; set; }
    }
}