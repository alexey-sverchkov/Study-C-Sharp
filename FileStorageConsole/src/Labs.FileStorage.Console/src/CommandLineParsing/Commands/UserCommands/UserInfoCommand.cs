namespace Labs.FileStorage.Console.CommandLineParsing.Commands.UserCommands
{
    class UserInfoCommand : ICommand
    {        
        public void Run()
        {
            System.Console.WriteLine("login: " + ApplicationContext.User.Login);
            System.Console.WriteLine("creation Date: " + ApplicationContext.User.CreationDate.ToString("d")); // format: yyyy-mm-dd
            System.Console.WriteLine("storage used: " + ApplicationContext.FileStorage.GetSize() + " bytes");
        }
    }
}
