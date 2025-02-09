namespace Shared.TaskController.Response
{
    public class ResponseOfGetTasks
    {
        public static readonly ResponseOfGetTasks Empty = new();

        public IEnumerable<SingleTask> Tasks { get; set; } = Enumerable.Empty<SingleTask>();

        public class SingleTask
        {
            public int TaskId { get; set; }
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string DueDate { get; set; } = null!;
            public bool IsCompleted { get; set; }
        }
    }
}
