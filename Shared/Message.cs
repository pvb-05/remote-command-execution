namespace Shared
{
    public class Message
    {
        public string Type { get; set; } = "";
        public string Command { get; set; } = "";
        public bool Success { get; set; }
        public string Output { get; set; } = "";
    }
}