namespace CSharpRefresh
{
    /*public record Employee(
        string Name,
        int Experience,
        string Department
    );*/
    public class Employee(string name, int experience)
    {
        public string Name =>  name;
        public int Experience => experience;
    }
}