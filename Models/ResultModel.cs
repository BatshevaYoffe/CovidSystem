namespace CovidSystem.Models
{
    public class ResultModel<T> where T : class
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Model { get; set; }
    }
}
