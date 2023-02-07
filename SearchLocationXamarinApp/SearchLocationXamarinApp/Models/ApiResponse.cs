namespace SearchLocationXamarinApp.Models
{
    public class ApiResponse<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
    }
}