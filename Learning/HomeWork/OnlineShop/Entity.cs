namespace HomeWork.OnlineShop
{
    internal class Entity
    {
        public int Id { get; set; }

        public Category Category { get; set; }
    }

    public enum Category
    {
        electro,
        household,
        mobile
    }

}