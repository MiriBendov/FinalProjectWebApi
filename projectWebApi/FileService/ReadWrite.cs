using System.Net;
using System.Security.AccessControl;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using FileService.Interfaces;
namespace FileService;


public class ReadWrite<T>: IfileService<T>
{
    private string _path;
    public ReadWrite()
    {
        //  _path = path;
    }
    public List<T> Read(string _path)
    {
        var list = new List<T>();
        var text = File.ReadAllText(_path);
        if (!string.IsNullOrEmpty(text))
        {
            list = JsonConvert.DeserializeObject<List<T>>(text);//העברה מjson ל STRING
        }
        return list;
    }
    public void Write(T obj,string _path)
    {
        var list = Read(_path);
        list.Add(obj);// העברה מ string ל json
        File.WriteAllText(_path, JsonConvert.SerializeObject(list));
    }
}
