using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class DashboardTeste
{
    [Fact]
    public void GrararDashboardCompleto()
    {
        //arrange
        var Dashes = new List<string> {"Dashboard da Empresa ",
            "Dashboard de Funcionarios",
            "Dashboard de Departamentos",
            "Dashboard de Score"
            
        };
        //act
        foreach (var dash in Dashes)
        {
            Assert.Contains("Dashboard", dash);
        }


        //assert
        Assert.Equal(4, Dashes.Count);
        Assert.Equal(4, Dashes.Count);
    }

    [Fact]
    public void NaoGerarDashboardCompleto() 
    {
        //arrange
        var Dashes = new List<string> {
            "Dashboard da Empresa ",
            "Dashboard de Funcionarios",
            "Dashboard de Departamentos",
            "Dashboard de Score"
        };
        //act
        foreach (var dash in Dashes)
        {
            Assert.Contains("Dash", dash);
        }
        //assert
        Assert.NotEqual(5, Dashes.Count);
    }
}
