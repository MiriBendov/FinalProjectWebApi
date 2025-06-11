
namespace AllModels.Interface;
public interface IPizza{
    public pizzamiri1 GetId(int id);
    public pizzamiri1 GetName(string name);
    public bool updateGluten(int id,bool gluten);
    public bool addPizza(string name,int id,bool gluten);
    public pizzamiri1 deletePizza(int id);
}