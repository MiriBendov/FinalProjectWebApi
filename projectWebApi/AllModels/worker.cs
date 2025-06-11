using AllModels;
public class worker
{
    public string name { get; set; }
    public string Role{get;set;}
    public string password{get;set;}
    public int age { get; set; }

    public int id { get; set; }
    
    public worker(string name,int age,int id,string role,string password)
    {
        this.name=name;
        this.age=age;
        this.id=id;
        this.Role=role;
        this.password=password;
    }
}