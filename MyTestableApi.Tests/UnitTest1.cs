namespace MyTestableApi.Tests;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net;

// Feature : Récupération des codes pays

// Si le pays est bon je peux demander uniquement le code alpha-2 en string.
// Si le pays est bon je peux demander uniquement le code alpha-3 en string.
// Si le pays n'est pas trouvé alors il renvoit un message en string tel que "le pays rentré n'est pas dans la bdd".

public class UnitTest1
{

//     Scenario : Je récupère le code alpha-2 d'un pays

// GIVEN : Le pays que je demande est "FRANCE" 
// WHEN : Je demande le code alpha-2 du pays
// THEN : Je récupère "FR"

    [Fact]
    public async Task GetAlpha2ForFrance_ReturnsFR()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("CodePays/GetAlpha2/France");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("FR", content);
    }

//     Scenario : Je récupère le code alpha-3 d'un pays

// GIVEN : Le pays que je demande est "FRANCE" 
// WHEN : Je demande le code alpha-2 du pays
// THEN : Je récupère "FRA"

    [Fact]
    public async Task GetAlpha3ForFrance_ReturnsFRA()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("CodePays/GetAlpha3/France");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("FRA", content);
    }

    //     Scenario : J'essaye de récupérer le code alpha-2 mais la donnée est inexistante 

    // GIVEN : Le pays que je demande est "Fransse" 
    // WHEN : Je demande le code alpha-2 du pays
    // THEN : Je récupère "Le code alpha-2 demandé n'as pas pu être trouvé"

    [Fact]
    public async Task GetAlpha2ForFrance_Returns404()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("CodePays/GetAlpha2/Fransse");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    //     Scenario : J'essaye de récupérer le code alpha-3 mais la donnée est inexistante 

    // GIVEN : Le pays que je demande est "Fransse" 
    // WHEN : Je demande le code alpha-3 du pays
    // THEN : Je récupère "Le code alpha-3 demandé n'as pas pu être trouvé"

    [Fact]
    public async Task GetAlpha3ForFrance_Returns404()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("CodePays/GetAlpha3/Fransse");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}