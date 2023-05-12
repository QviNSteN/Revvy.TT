using Microsoft.VisualBasic;
using Revvy.TT.Core.General;
using Revvy.TT.Oficials.Data;
using Xunit.Abstractions;

namespace Revvy.TT.Tests;
public class GetNotesForOficialTests
{
    private readonly ITestOutputHelper output;
    private readonly Oficial[] OficialsTest = new Oficial[]
    {
        new Oficial(0),
        new Oficial(1),
        new Oficial(2),
        new Oficial(3),
        new Oficial(4),
        new Oficial(5),
        new Oficial(6),
        new Oficial(7),
    };

    public GetNotesForOficialTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Test1()
    {
        var trueResult = new[] { 3, 4, 2, 1 };

        var oficial4 = OficialsTest[4];
        var oficial3 = OficialsTest[3];
        var oficial2 = OficialsTest[2];
        var oficial1 = OficialsTest[1];

        oficial1.SetDependence(new Oficial[] { oficial2 });
        oficial2.SetDependence(new Oficial[] { oficial3, oficial4 });

        var result = Note.GetNote(oficial1, oficial2);

        AllTests(result, trueResult);
    }

    [Fact]
    public void Test2()
    {
        var trueResult = new[] { 3, 4, 2, 1 };

        var oficial4 = OficialsTest[4];
        var oficial3 = OficialsTest[3];
        var oficial2 = OficialsTest[2];
        var oficial1 = OficialsTest[1];

        oficial1.SetDependence(new Oficial[] { oficial2 });
        oficial3.SetDependence(new Oficial[] { oficial4 });

        var result = Note.GetNote(oficial1, oficial3);

        AllTests(result, trueResult);
    }

    [Fact]
    public void Test3()
    {
        var trueResult = new[] { 4, 5, 7, 3, 2, 1 };

        var oficial7 = OficialsTest[7];
        var oficial5 = OficialsTest[5];
        var oficial4 = OficialsTest[4];
        var oficial3 = OficialsTest[3];
        var oficial2 = OficialsTest[2];
        var oficial1 = OficialsTest[1];

        oficial1.SetDependence(new Oficial[] { oficial2 });
        oficial2.SetDependence(new Oficial[] { oficial3, oficial4 });
        oficial3.SetDependence(new Oficial[] { oficial5, oficial7 });

        var result = Note.GetNote(oficial1, oficial2, oficial3);

        AllTests(result, trueResult);
    }

    [Fact]
    public void Test4()
    {
        var trueResult = new[] { 2, 4, 3, 5 };

        var oficial4 = OficialsTest[4];
        var oficial3 = OficialsTest[3];
        var oficial2 = OficialsTest[2];
        var oficial5 = OficialsTest[5];

        oficial3.SetDependence(new Oficial[] { oficial2, oficial4 });
        oficial5.SetDependence(new Oficial[] { oficial3 });

        var result = Note.GetNote(oficial3, oficial5);

        AllTests(result, trueResult);
    }

    [Fact]
    public void Test5()
    {
        var trueResult = new[] { 2, 4, 3, 5 };

        var oficial4 = OficialsTest[4];
        var oficial3 = OficialsTest[3];
        var oficial2 = OficialsTest[2];
        var oficial5 = OficialsTest[5];

        oficial5.SetDependence(new Oficial[] { oficial3 });
        oficial3.SetDependence(new Oficial[] { oficial2, oficial4 });

        var result = Note.GetNote(oficial5, oficial3);

        AllTests(result, trueResult);
    }

    [Fact]
    public void Test6()
    {
        var trueResult = new[] { 3, 4, 2, 1 };

        var oficial4 = OficialsTest[4];
        var oficial3 = OficialsTest[3];
        var oficial2 = OficialsTest[2];
        var oficial1 = OficialsTest[1];

        oficial2.SetDependence(new Oficial[] { oficial3, oficial4 });
        oficial1.SetDependence(new Oficial[] { oficial2 });

        var result = Note.GetNote(oficial2, oficial1);

        AllTests(result, trueResult);
    }

    [Fact]
    public void Test7()
    {
        var trueResult = new[] { 4, 5, 3, 2, 1 };

        var oficial5 = OficialsTest[5];
        var oficial4 = OficialsTest[4];
        var oficial3 = OficialsTest[3];
        var oficial2 = OficialsTest[2];
        var oficial1 = OficialsTest[1];

        oficial2.SetDependence(new Oficial[] { oficial3, oficial4 });
        oficial1.SetDependence(new Oficial[] { oficial2 });
        oficial3.SetDependence(new Oficial[] { oficial5, oficial4 });

        var result = Note.GetNote(oficial2, oficial1, oficial3);

        AllTests(result, trueResult);
    }

    void AllTests(IEnumerable<int> result, IEnumerable<int> trueResult)
    {
        output.WriteLine("Result: " + String.Join(", ", result));
        output.WriteLine("True result: " + String.Join(", ", trueResult));

        Assert.NotEmpty(result);
        Assert.All(result, x => trueResult.Contains(x));
    }
}