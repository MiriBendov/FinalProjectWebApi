#region Assembly AllModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// H:\webAPI\webApi-project\webApi-project\projectWebApi\AllModels\obj\Debug\net8.0\ref\AllModels.dll
#endregion

#nullable enable

namespace AllModels.Interface;
public interface IWorker{
    public worker GetId(int id);
    public worker GetNmae(string name);
    public bool updateAge(int age,int id);
    public bool addWorker(string name,int age,int id,string role,string password);
    public worker deleteWorker(int id);
}