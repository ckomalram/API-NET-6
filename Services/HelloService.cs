public class HelloService : IHello
{

    public string GetHello(){
        return "Hello Carlyle!";
    }
    
}

public interface IHello{
    string GetHello();
}