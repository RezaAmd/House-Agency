namespace Application.Models
{
    public class SelectItem
    {
        #region Constructors
        public SelectItem() { }
        public SelectItem(string text, string value, bool isSelected = false, bool isDisabled = false)
        {
            Text = text;
            Value = value;
            IsSelected = isSelected;
            IsDisabled = isDisabled;
            Children = new List<SelectItem>();
        }
        #endregion

        public string Text { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDisabled { get; set; }
        public List<SelectItem> Children { get; set; }
    }
}