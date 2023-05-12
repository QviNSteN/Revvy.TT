using Revvy.TT.Core.Data.Abstract;
using System;
namespace Revvy.TT.Core.General;

public static class Note
{
    /// <summary>
    /// Получить номера кабинетов для получения всех необходимых справок в отсортированном порядке посящения.
    /// </summary>
    /// <param name="staff">Список чиновников, необходимых для получения соответствующих справок.</param>
    /// <returns>Отсортированный список пути по кабинетам.</returns>
    public static IEnumerable<int> GetNote(params Staff[] staff)
    {
        var dependenceOn = new Stack<Staff>(staff);
        var result = new List<Staff>();

        while(dependenceOn.Count > 0)
        {
            var dependence = dependenceOn.Pop();

            if (result.Any(x => x == dependence))
                continue;

            if (!dependence.DependencyOn.Any() || dependence.DependencyOn.All(x => result.Any(y => y.Id == x.Id)))
            {
                result.Add(dependence);
                continue;
            }
            else
                dependenceOn.Push(dependence);
            
            foreach(var d in dependence.GetDependence(result))
            {
                dependenceOn.Push(d);
            }
        }

        return result.Select(x => x.Id).AsEnumerable();
    }
}