public class Percon
{
   public string Name {get;set;}
   public int Age {get; set ;}

    public Percon (string name , int age)
    {
        Name=name ;
        Age=age;

    
    }
    public string GetInfo()
    {
        return Name + "(" + Age + ")";  
        
    }
}