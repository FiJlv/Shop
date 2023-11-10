namespace Shop.DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Image { get; set; } = "";
        public uint Price { get; set; }
        public bool IsFavourite { get; set; }
        public bool Available { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<User> Users { get; set; }
        public Car()
        {
            Users = new List<User>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Car))
                return false;

            return this.Id == ((Car)obj).Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
