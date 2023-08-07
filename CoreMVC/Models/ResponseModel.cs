namespace CoreMVC.Models
{
    public class ResponseModel<T>
    {
        public bool status { get; set; } = false;
        public string? message { get; set; } = string.Empty;
        public T? data { get; set; }
    }
}
