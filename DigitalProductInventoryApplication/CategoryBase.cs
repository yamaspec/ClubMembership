namespace DigitalProductInventoryApplication
{
    public abstract class CategoryBase : IPrimaryProperties
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }


}
