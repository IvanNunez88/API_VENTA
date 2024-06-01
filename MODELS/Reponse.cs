namespace MODELS
{
    public record Reponse<T>
    {
        public string Status { get; set; } = string.Empty;
        public T Value { get; set; }
        public IEnumerable<string> Msg { get; set; } = [];

    }
}
