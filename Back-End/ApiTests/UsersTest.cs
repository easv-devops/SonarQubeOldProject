using ApiTests.Enteties;
using Dapper;
using FluentAssertions;
using Newtonsoft.Json;
namespace ApiTests
{
    public class UsersTest
    {
        
[Test]
public async Task TestGetUsers()
{
    // Arrange
    var httpResponse = await new HttpClient().GetAsync($"{ContextConfig.ApiBaseUrl}/Users");

    // Act
    var responseContent = await httpResponse.Content.ReadAsStringAsync();
    Console.WriteLine($"Response Content: {responseContent}");

    // Deserialize the response using the wrapper class
    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<User>>(responseContent);

    // Retrieve the users from the database
    IEnumerable<User> usersFromDatabase;
    await using (var conn = await ContextConfig.DataSource.OpenConnectionAsync())
    {
        usersFromDatabase = conn.Query<User>("SELECT * FROM da_education.users;");
    }

    Console.WriteLine($"Users from Database: {JsonConvert.SerializeObject(usersFromDatabase)}");

    // Assert
    apiResponse.ResponseData.Should()
        .NotBeNull("because users should be returned from the API")
        .And.BeEquivalentTo(usersFromDatabase, options => options.ExcludingMissingMembers());
}


        }
    }
