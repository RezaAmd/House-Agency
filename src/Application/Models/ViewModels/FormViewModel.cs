namespace Application.Models.ViewModels
{
    public class TinyFormVM
    {
        #region Constructors
        public TinyFormVM() { }
        public TinyFormVM(string id, string name, string title)
        {
            Id = id;
            Name = name;
            Title = title;
        }
        #endregion

        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}