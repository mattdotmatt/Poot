namespace Poot.Models
{
    public interface IModel
    {
        string Name { get; }
        string ETag { get; }
    }
}