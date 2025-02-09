export interface ITaskResponse {
    tasks: ITask[]
}

export interface ITask {
    taskId: number
    title: string
    description: string
    dueDate: string
    isCompleted: boolean
}