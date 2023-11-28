using ApiTests.Enteties;
using Dapper;
using FluentAssertions;
using Newtonsoft.Json;
using Microsoft.Playwright.NUnit;
using System.Net.Http.Json;

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

            [Test]
            public async Task TestGetUserById()
            {
                //Arrange
                int userId = 1;
                
                using(HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await client.GetAsync($"{ContextConfig.ApiBaseUrl}/Users/{userId}");

                    if(responseMessage.IsSuccessStatusCode)
                    {
                        string responseContent = await responseMessage.Content.ReadAsStringAsync();
                        responseContent.Should().NotBeNullOrWhiteSpace("Api response is not empty");
                    }
                    else
                    {
                        responseMessage.IsSuccessStatusCode.Should().
                        BeTrue($"API request failed with status code: {responseMessage.StatusCode}");
                    }
                }
    
            }

            [Test]
            public async Task TestCreateUser()
            {
                // Arrange
                var testUser = new User()
                {
                    Username = "ForTest",
                    Email = "emailForTest@mail.com",
                    Password = "passwordForTest",
                    ShortDescription = "forTest"
                };

                // Act
                var httpResponse = await new HttpClient().PostAsJsonAsync(ContextConfig.ApiBaseUrl + "/Users/", testUser);


                // Assert
                await using (var conn = await ContextConfig.DataSource.OpenConnectionAsync())
                {
                    var userFromDatabase = conn.QueryFirst<User>("Select * from da_education.users where username='ForTest';");

                    userFromDatabase.Should().NotBeNull(); // Check if userFromDatabase is not null

                    
                    userFromDatabase.Username.Should().Be("ForTest", "because the Username should match");
                    userFromDatabase.Email.Should().Be("emailForTest@mail.com", "because the Email should match");
                    userFromDatabase.Password.Should().NotBeNullOrEmpty(); // Password may be hashed or processed
                    userFromDatabase.ShortDescription.Should().Be("forTest", "because the ShortDescription should match");
                    
                }
            }

            [Test]
            public async Task DeleteUserById()
            {
                 using (var conn = await ContextConfig.DataSource.OpenConnectionAsync())
                {
                    var insertedUser = conn.QueryFirstOrDefault<User>(
                    "Select * from da_education.users where username='ForTest';");

            
                    int UserIdToDelete = insertedUser.Id;

                    Console.WriteLine(UserIdToDelete);
                    
                    using (HttpClient client = new HttpClient())
                    {

                        HttpResponseMessage response =
                            await client.DeleteAsync($"{ContextConfig.ApiBaseUrl}/Users/{UserIdToDelete}");

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"DELETE request for User ID {UserIdToDelete} was successful.");
                        }
                        else
                        {
                            Console.WriteLine($"DELETE request failed with status code: {response.StatusCode}");
                            string responseContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine($"Response content: {responseContent}");
                        }

                        response.IsSuccessStatusCode.Should().BeTrue("DELETE request should return 204 No Content on success.");
            }
            
    }
    }
}
}
