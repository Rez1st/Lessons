using System;

namespace ModuleTwo
{
    public interface IFinderService
    {
        string FindFile(string locationToSearch, string fileName);
    }

    public class FinderService : IFinderService
    {
        public string FindFile(string locationToSearch, string fileName)
        {
            throw new NotImplementedException();
            //your code here
        }
    }
}