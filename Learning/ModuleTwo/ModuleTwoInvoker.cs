using System;

namespace ModuleTwo
{
    public class ModuleTwoInvoker : IModuleTwoInvoker
    {
        public ModuleTwoInvoker()
        {
            _finderService = new FinderService();
            _fileReaderService = new FileReaderService();
            _fileSaverService = new FileSaverService();
        }

        private IFinderService _finderService { get; }
        private IFileReaderService _fileReaderService { get; }
        private IFileSaverService _fileSaverService { get; }

        public string FindFile(string locationToSearch, string fileName)
        {
            var result = string.Empty;

            try
            {
                result = _finderService.FindFile(locationToSearch, fileName);
            }
            catch (Exception e)
            {
                // your code here
            }

            return result;
        }

        public string GetFileContent(string location, string fileName)
        {
            var result = string.Empty;

            try
            {
               result =  _fileReaderService.GetFileContent(location, fileName);
            }
            catch (Exception e)
            {
                // your code here
            }

            return result;
        }

        public bool SaveFile(string content, string location, string fileName)
        {
            var result = false;

            try
            {
                result = _fileSaverService.SaveFile(content, location, fileName);
            }
            catch (Exception e)
            {
                // your code here
            }

            return result;
        }
    }
}