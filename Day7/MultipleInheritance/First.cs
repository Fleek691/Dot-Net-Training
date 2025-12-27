/// <summary>
/// Interface for Bird
/// </summary>
public interface Peacock
{
    void Dance();
    void Feed();

}
/// <summary>
/// Interface for Birds
/// </summary>
public interface KingFisher
{
    
    void Swim();
    void Fish();
}
/// <summary>
/// Multiple inheritance using interface
/// </summary>
public class WatchBird: Peacock, KingFisher
{
    public void Swim(){
        System.Console.WriteLine("Kingfisher class");
    }
    public void Dance()
    {
        System.Console.WriteLine("Peacock");
    }
    public void Feed()
    {
        System.Console.WriteLine("Feeding");
    }
    public void Fish()
    {
        System.Console.WriteLine("Fishy");
    }
}