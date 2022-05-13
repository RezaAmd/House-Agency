namespace Application.Models.ViewModels
{
    public class PreviewFileVM
    {
        public PreviewFileVM(string id, string fullPath, bool isSuccess)
        {
            Id = id;
            FullPath = fullPath;
            IsSuccess = isSuccess;
        }

        public string Id { get; set; }
        public string FullPath { get; set; }
        public bool IsSuccess { get; set; }
    }
}