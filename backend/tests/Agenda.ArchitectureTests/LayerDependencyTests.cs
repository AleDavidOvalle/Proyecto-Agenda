using NetArchTest.Rules;

namespace Agenda.ArchitectureTests;

public class LayerDependencyTests
{
    [Fact]
    public void Domain_ShouldNotDependOnOtherLayers()
    {
        var result = Types.InAssembly(typeof(Agenda.Domain.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny("Agenda.Application", "Agenda.Infrastructure", "Agenda.Api",
                                 "Microsoft.EntityFrameworkCore")
            .GetResult();

        Assert.True(result.IsSuccessful,
            "Tipos que violan la regla: " + string.Join(", ", result.FailingTypeNames ?? []));
    }
}