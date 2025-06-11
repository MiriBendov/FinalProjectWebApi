using AllModels;
public class pizzamiri1
{
    public bool gluten { get; set; }

    public string name { get; set; }

    public int id { get; set; }
    
    public pizzamiri1(string name,int id,bool gluten)
    {
        this.name=name;
        this.id=id;
        this.gluten=gluten;
    }
}