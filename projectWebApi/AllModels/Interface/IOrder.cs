using AllModels;
namespace AllModels.Interface;
public interface IOrder{
    public order GetId(int id);
    public order GetOrderId(int orderId);
     public bool updateDate(int id,string data);
     public Task<bool> addOrder(int coustomerId,string date,int idOrder,int numCardit,int validity,int threeNumber);
     public order deleteOrder(int id);
    //   public  Task<bool> processPreparation();
      public Task invoice();
    public  Task makePizza();
      public  Task pay();
     
}