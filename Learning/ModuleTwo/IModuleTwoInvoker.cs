namespace ModuleTwo
{
    public interface IModuleTwoInvoker
    {
        string FindFile(string locationToSearch, string fileName);

        string GetFileContent(string location, string fileName);

        bool SaveFile(string content, string lcoation, string fileName);
    }
}