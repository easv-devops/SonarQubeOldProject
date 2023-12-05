using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ApiTests.Enteties;
using Dapper;
using FluentAssertions;
using Newtonsoft.Json;

namespace ApiTests
{
    public class CourseTest
    {
        
        [Test]
        public async Task GetAllCoursesTest()
        {
            //Arrange
            var httpResponse = await new HttpClient().GetAsync($"{ContextConfig.ApiBaseUrl}/Course"); 

             // Act
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            // Deserialize the response using the wrapper class
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<User>>(responseContent);

            // Retrieve the courses from the database
            IEnumerable<Course> coursesFromDatabase;
            await using (var conn = await ContextConfig.DataSource.OpenConnectionAsync())
            {
                    coursesFromDatabase = conn.Query<Course>("SELECT * FROM da_education.courses;");
            }

            // Assert
            apiResponse?.ResponseData.Should()
                .NotBeNull("because courses should be returned from the API")
                .And.BeEquivalentTo(coursesFromDatabase, options => options.ExcludingMissingMembers());
        }

        [Test]
        public async Task GetCourseById()
        {
            //Arrange
            var courseId = 1;

            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ContextConfig.ApiBaseUrl}/Course/{courseId}");

                if(response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    responseContent.Should().NotBeNullOrWhiteSpace("Api response is not empty");
                }
                else
                {
                    response.IsSuccessStatusCode.Should().BeTrue($"Api request failed with status code:{response.StatusCode}");
                }
            }
        }
        
        [Test]
        public async Task CreateCourseTest()
        {
            // Arrange
            var testCourse = new Course()
            {
                Name = "CourseForTest",
                ExperienceLevel = 1,
                Description = "It's for test!",
                OwnerId = 1,
                Price = 20.00M
            };

            // Act
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var httpResponse = await httpClient.PostAsJsonAsync(ContextConfig.ApiBaseUrl + "/Course", testCourse).ConfigureAwait(false);

                    // Assert
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        // Inserted successfully, proceed with database check
                        await using (var conn = await ContextConfig.DataSource.OpenConnectionAsync().ConfigureAwait(false))
                        {
                            var courseFromDb = conn.QueryFirst<Course>($@"SELECT
                                                                                da_education.courses.name AS {nameof(Course.Name)},
                                                                                da_education.courses.experience_level AS {nameof(Course.ExperienceLevel)},
                                                                                da_education.courses.description AS {nameof(Course.Description)},
                                                                                da_education.courses.owner_id AS {nameof(Course.OwnerId)},
                                                                                da_education.courses.price AS {nameof(Course.Price)}
                                                                            FROM da_education.courses WHERE name = 'CourseForTest';");

                            // Check if course is null
                            courseFromDb.Should().NotBeNull();
                            // Check if params are equal to what we inserted
                            courseFromDb.Name.Should().Be("CourseForTest", "because the name should match");
                            courseFromDb.ExperienceLevel.Should().Be(1, "because the exp level should match");
                            courseFromDb.Description.Should().Be("It's for test!", "because the description should match");
                            courseFromDb.OwnerId.Should().Be(1, "because the owner id should match");
                            courseFromDb.Price.Should().Be(20M, "because the price should match");
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
        public async Task DeleteCourseByIdTest()
        {
            //Arrange
            using (var conn = await ContextConfig.DataSource.OpenConnectionAsync())
            {
                var insertedCourse = conn.QueryFirst<Course>($@"Select * from da_education.courses where name='CourseForTest';");

                int courseToDeleteId = insertedCourse.Id;

                 
                    using (HttpClient client = new HttpClient())
                    {

                        HttpResponseMessage response =
                            await client.DeleteAsync($"{ContextConfig.ApiBaseUrl}/Course/{courseToDeleteId}");

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"DELETE request for Course ID {courseToDeleteId} was successful.");
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