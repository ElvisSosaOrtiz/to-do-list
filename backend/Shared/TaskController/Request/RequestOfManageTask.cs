namespace Shared.TaskController.Request
{
    public class RequestOfManageTask
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
