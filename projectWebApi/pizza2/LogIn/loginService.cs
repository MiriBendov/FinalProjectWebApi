
using FileService.Interfaces;

namespace LogIn;
public class LoginServices : ILoginManager
{

    IfileService<worker> _file;
    string path = @"H:\webAPI\webApi-project\webApi-project\projectWebApi\pizza2\WorkerFile.json";

    public LoginServices(IfileService<worker> file)
    {
        _file = file;
    }
    public worker IsExsist(string Name, string Password)
    {
        var workers = _file.Read(@"H:\webAPI\webApi-project\webApi-project\projectWebApi\pizza2\WorkerFile.json");
        foreach (var i in workers)
        {
            if (i.name == Name && i.password==Password)
            {
                return i;
            }

        }
        return null;
    }
}