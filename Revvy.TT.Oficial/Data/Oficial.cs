using Revvy.TT.Core.Data.Abstract;

namespace Revvy.TT.Oficials.Data;

public class Oficial : Staff
{
    public Oficial(int id) : base(id) { }

    public Oficial(int id, IEnumerable<Oficial> dependencyOn) : base(id, dependencyOn) { }

    public override IEnumerable<Staff> GetDependence(IEnumerable<Staff> expect)
    {
        foreach(var d in DependencyOn)
        {
            if (!expect.Any(x => x == d))
                yield return d;
        }
    }
}