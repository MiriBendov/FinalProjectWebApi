using System;
using AllModels;
public class order
{
    public int coustomerId { get; set; }
    public string data { get; set; }

    public int idOrder { get; set; }
    public creditCard cc{get;set;}

    
    public order(int coustomerId,string data,int idOrder,int numCardit,int validity,int threeNumber)
    {
        this.coustomerId=coustomerId;
        this.data=data;
        this.idOrder=idOrder;
        this.cc=new creditCard(numCardit,validity,threeNumber);
    }
}