namespace DigitalProductInventoryApplication
{
    // Used as a template to centralize information from the Product related classes to the Category related classes.
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string CategoryDescription { get; set; }
    }
}
