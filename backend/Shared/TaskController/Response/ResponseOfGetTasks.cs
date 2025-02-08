namespace Shared.TaskController.Response
{
    public class ResponseOfGetTasks
    {
        public static readonly ResponseOfGetTasks Empty = new();

        public IEnumerable<SingleTask> Task { get; set; } = Enumerable.Empty<SingleTask>();

        public class SingleTask
        {
            public int TaskId { get; set; }
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
            public DateTime DueDate { get; set; }
            public bool IsCompleted { get; set; }
        }
    }
}
