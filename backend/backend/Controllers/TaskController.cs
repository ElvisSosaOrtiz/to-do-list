namespace backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceContracts;
    using Shared.Routing;
    using Shared.TaskController.Request;
    using Shared.TaskController.Response;

    [ApiController]
    [Route(TaskControllerRoutes.Root)]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult ListAllTasks()
        {
            var result = _taskService.ListAllTasks();
            return Ok(result);
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTaskDetails(int taskId)
        {
            var result = _taskService.GetTaskById(taskId);
            if (result is null) return NotFound("Could not find selected task.");

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddNewTask(RequestOfManageTask request)
        {
            var result = _taskService.AddNewTask(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut]
        public IActionResult EditTask(RequestOfManageTask request)
        {
            var result = _taskService.EditTask(request);
            if (result is null) return NotFound("Could not find task to edit.");

            return Ok(result);
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            var result = _taskService.DeleteTask(taskId);
            if (!string.IsNullOrEmpty(result)) return NotFound(result);
            
            return Ok("Task deleted successfully!");
        }
    }
}
