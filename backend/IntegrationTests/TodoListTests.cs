namespace IntegrationTests
{
    using AutoFixture;
    using Shared.Routing;
    using Shared.TaskController.Request;
    using Shared.TaskController.Response;
    using System.Net.Http.Json;

    public class TodoListTests
    {
        [Fact]
        public async Task WhenCreatingTasks_ShouldInsertTasksInDatabase()
        {
            var application = new TodoListWebApplicationFactory();
            var client = application.CreateClient();

            var response = await CreateNewTaskAsync(client);
            response.EnsureSuccessStatusCode();
            var matchResponse = await response.Content.ReadFromJsonAsync<ResponseOfGetTasks.SingleTask>();

            Assert.NotNull(matchResponse);
            Assert.NotEqual(0, matchResponse!.TaskId);
        }

        [Fact]
        public async Task WhenRequestAllTasks_ShouldReturnAllTasks()
        {
            var application = new TodoListWebApplicationFactory();
            var client = application.CreateClient();

            var addTaskResponse = await CreateNewTaskAsync(client);
            addTaskResponse.EnsureSuccessStatusCode();
            await addTaskResponse.Content.ReadFromJsonAsync<ResponseOfGetTasks.SingleTask>();
            var response = await client.GetFromJsonAsync<ResponseOfGetTasks>($"/{TaskControllerRoutes.Root}");

            Assert.NotNull(response);
            Assert.NotEmpty(response.Tasks);
        }

        [Fact]
        public async Task WhenRequestATask_ShouldReturnASingleTask()
        {
            var application = new TodoListWebApplicationFactory();
            var client = application.CreateClient();

            var tasksResponse = await client.GetFromJsonAsync<ResponseOfGetTasks>($"/{TaskControllerRoutes.Root}");
            var taskId = tasksResponse?.Tasks.First().TaskId;
            var response = await client.GetFromJsonAsync<ResponseOfGetTasks.SingleTask>($"/{TaskControllerRoutes.Root}/{taskId}");

            Assert.NotNull(response);
            Assert.NotEqual(0, response.TaskId);
        }

        [Fact]
        public async Task WhenEditATask_ShouldReturnEditedTask()
        {
            var application = new TodoListWebApplicationFactory();
            var client = application.CreateClient();

            var task = (await client.GetFromJsonAsync<ResponseOfGetTasks>($"/{TaskControllerRoutes.Root}"))!.Tasks.First();
            if (task.TaskId == 0)
            {
                await CreateNewTaskAsync(client);
            }
            var fixture = new Fixture();
            var request = fixture.Create<RequestOfManageTask>();
            request.TaskId = task.TaskId;
            var response = await client.PutAsJsonAsync($"/{TaskControllerRoutes.Root}", request);
            var matchedResponse = await response.Content.ReadFromJsonAsync<ResponseOfGetTasks.SingleTask>();

            Assert.NotNull(matchedResponse);
            Assert.NotEqual(task.Title, matchedResponse.Title);
            Assert.Equal(task.TaskId, matchedResponse.TaskId);
        }

        [Fact]
        public async Task WhenDeleteTask_ShouldRemoveItFromDatabase()
        {
            var application = new TodoListWebApplicationFactory();
            var client = application.CreateClient();

            var task = (await client.GetFromJsonAsync<ResponseOfGetTasks>($"/{TaskControllerRoutes.Root}"))!.Tasks.First();
            var response = await client.DeleteAsync($"/{TaskControllerRoutes.Root}/{task.TaskId}");
            response.EnsureSuccessStatusCode();
            var matchedResponse = await response.Content.ReadAsStringAsync();

            Assert.NotNull(matchedResponse);
            Assert.Equal("Task deleted successfully!", matchedResponse);
        }

        private static async Task<HttpResponseMessage> CreateNewTaskAsync(HttpClient client)
        {
            var fixture = new Fixture();
            var request = fixture.Create<RequestOfManageTask>();
            request.TaskId = 0;

            return await client.PostAsJsonAsync($"{TaskControllerRoutes.Root}", request);
        }
    }
}