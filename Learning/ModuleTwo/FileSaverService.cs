namespace ModuleTwo
{
    public interface IFileSaverService
    {
        bool SaveFile(string content, string lcoation, string fileName);
    }

    public class FileSaverService : IFileSaverService
    {
        public bool SaveFile(string content, string lcoation, string fileName)
        {
            //Your code here
        }
    }

}
