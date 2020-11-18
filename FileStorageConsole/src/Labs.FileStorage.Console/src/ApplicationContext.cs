namespace Labs.FileStorage.Console
{
    public static class ApplicationContext
    {
        public static Users.User         User { get; set; }
        public static Files.FileStorage  FileStorage { get; set; }
        public static Files.Database     Database { get; set; }
    }
}
