// using AllModels;
namespace AllModels;
public class creditCard
{
    public int numCardit{get;set;}
    public int validity{get;set;}
    public int threeNumber{get;set;}

    public creditCard(int numCardit,int validity,int threeNumber)
    {
        this.numCardit=numCardit;
        this.threeNumber=threeNumber;
        this.validity=validity;
    }

}