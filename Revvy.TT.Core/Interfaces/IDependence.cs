namespace Revvy.TT.Core.Interfaces;

public interface IDependence<T>
{
    IEnumerable<T> GetDependence(IEnumerable<T> expect);

    void SetDependence(IEnumerable<T> dependence);
}
