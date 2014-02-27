namespace RelTexPacNet
{
    public class Result<T>
    {
        public bool WasSuccessful { get; set; }
        public string ErrorMessage { get; set; }

        public T Value { get; set; }
    }
}