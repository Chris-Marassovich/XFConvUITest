namespace XFConvUITest.Models
{
    public enum MenuItemType
    {
        Browse,
        Chat,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
