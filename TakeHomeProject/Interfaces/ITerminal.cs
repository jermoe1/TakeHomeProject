namespace TakeHomeProject.Interfaces
{
    public interface ITerminal
    {
        void Scan(string item);
        decimal Total();
    }
}
