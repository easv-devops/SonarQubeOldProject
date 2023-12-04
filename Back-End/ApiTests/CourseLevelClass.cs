using System.Net.Http.Json;
using ApiTests.Enteties;
using Dapper;
using FluentAssertions;

namespace ApiTests
{
    public class CourseLevelClass
    {
        [Test]
        public async Task CreateCourseLevelTest()
        {
            // Arrange
            var testCourseLevel = new CourseLevel()
            {
                Level = "Professional"
                
            };

            // Act
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var httpResponse = await httpClient.PostAsJsonAsync(ContextConfig.ApiBaseUrl + "/CourseLevel", testCourseLevel).ConfigureAwait(false);

                    // Assert
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        
                        await using (var conn = await ContextConfig.DataSource.OpenConnectionAsync().ConfigureAwait(false))
                        {
                            var courseLevelFromDb = conn.QueryFirst<CourseLevel>($@"SELECT * from da_education.course_level where level = 'Professional';");

                            // Check if course level is null
                            courseLevelFromDb.Should().NotBeNull();
                            // Check if params are equal to what we inserted
                            courseLevelFromDb.Level.Should().Be("Professional", "Because the name should match");
                            
                        }
                    }
                    else
                    {
                        
                        var errorMessage = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        // Handle the error as needed
                        Console.WriteLine($"HTTP Error: {httpResponse.StatusCode}, {errorMessage}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task CreateCourseLevelTestInvalidData()
        {
            // Arrange
            var testCourseLevel = new CourseLevel()
            {
                // Level is intentionally set to an invalid value
                Level = "InvalidLevel"
            };

            // Act
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var httpResponse = await httpClient.PostAsJsonAsync(ContextConfig.ApiBaseUrl + "/CourseLevel", testCourseLevel).ConfigureAwait(false);

                    // Assert
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        
                        var errorMessage = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        
                        // Assert that the error message contains the expected validation error
                        errorMessage.Should().Contain("The value of the Course Level should be one of the following: ");
                        

                        
                    }
                    else
                    {
                        // If the response is successful, the test should fail
                        Assert.Fail("Expected an unsuccessful HTTP response, but received a success status code.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

    }
}