namespace FileService.Interfaces;
public interface IfileService<T>{
    List<T> Read(string _path);
    void Write (T obj,string _path);
}    