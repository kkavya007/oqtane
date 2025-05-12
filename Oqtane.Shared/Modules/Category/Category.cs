namespace Oqtane.Modules.Category.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int ModuleId { get; set; }  // Required by Oqtane
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
