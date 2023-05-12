using Revvy.TT.Core.Interfaces;

namespace Revvy.TT.Core.Data.Abstract;

public abstract class Staff : IDependence<Staff>
{
    public int Id { get; private set; }

    public IEnumerable<Staff> DependencyOn { get; private set; } = new List<Staff>();

    public Staff(int id)
    {
        Id = id;
    }

    public Staff(int id, IEnumerable<Staff> dependencyOn)
    {
        Id = id;
        DependencyOn = dependencyOn;
    }

    public abstract IEnumerable<Staff> GetDependence(IEnumerable<Staff> expect);

    public override bool Equals(object? obj)
    {
        return (obj as Staff)?.Id == Id || base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public void SetDependence(IEnumerable<Staff> dependence)
    {
        DependencyOn = dependence;
    }
}
