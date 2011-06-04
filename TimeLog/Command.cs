namespace TimeLog
{
    public class Command
    {
        public string Root { get; private set; }

        public Command(string root)
        {
            Root = root;
        }
    }
}