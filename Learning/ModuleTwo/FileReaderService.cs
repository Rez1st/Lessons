using System;

namespace ModuleTwo
{
    public interface IFileReaderService
    {
        string GetFileContent(string location, string fileName);
    }

    public class FileReaderService : IFileReaderService
    {
        public string GetFileContent(string location, string fileName)
        {
            throw new NotImplementedException();
            //your code here
        }
    }
}