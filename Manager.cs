namespace ProjectManagementSystem;

public class Manager : Employee //inherit from Employee abstract class 
{
    //private list to store tasks assigned to the manager (not needed if List is added to Employee class)
    //private List<Task> _tasks = new List<Task>();
 
    
    //constructor for Manager that takes in name and ID
    //(if contructor in Employee class has a name and ID then manager inherits these, unless we don't make manager an "employee")
    //"base" keyword calls the constructor in the Employee class, initializing these properties
    public Manager(int id, string name) : base(id, name) {}  //nothing needs to be added to base constructor here so empty brakets
 

    //create method that takes in an Employee and a Task so that a manager can assign a task to an employee
    public void AssignTask(Employee employee, Task task)
    {
        //_tasks.Add(task); //add task to manager list of tasks
        
        //in Employee we assume we have an AddTask method with task.Add(task) inside to add a task
        employee.AddTask(task); //add task to an employee (assuming employee has AddTask method to add the task to its list)
        Console.WriteLine($"Manager assigned task'{task.Title}' to {employee.Name}");
    }
    
    //update task status (Manager can do this for any employee). takes params emplyee name and task if
    public void UpdateTaskStatus(Employee employee, int taskId)
    {
        //find the task in employee's task list by matching task Id
        Task task = employee.GetTaskById(taskId);
        if (task != null) //if the id exists for that specific employee
        {
            //show menu to manager to select new task status
            Console.WriteLine("Select a status for the task:");
            Console.WriteLine("1. To Do");
            Console.WriteLine("2. In Progress");
            Console.WriteLine("3. Completed");
            
            //get Manager's input
            string input = Console.ReadLine();
            
            //determine the status based on the input
            TaskStatus selectedStatus; //declare variable to store the status 
            switch (input)
            { //here we assume we created an enum "TaskStatus" in the Task Class that has defined the statuses 
                case "1":
                    selectedStatus = TaskStatus.ToDo; 
                    break;
                case "2":
                    selectedStatus = TaskStatus.InProgress; 
                    break;
                case "3":
                    selectedStatus = TaskStatus.Completed; 
                    break;
                default:
                    Console.WriteLine("Invalid input. Please choose a valid option");
                    return; //return if invalid input
            }

            //update the task status
            task.UpdateStatus(selectedStatus);
            Console.WriteLine($"Manager changed task '{task.Title}' status to {selectedStatus} for {employee.Name}");
        }
        else
        {
            Console.WriteLine($"Task with ID {taskId} not found for {employee.Name}");
        }
    }

    //create method to create a report on the tasks for each employee. Method takes in list of employees as parameter
    public void CreateReport(List<Employee> employees)
    {
        //loop through each employee in teh list to find their tasks
        foreach (var employee in employees)
        {
            //print name of the employee amd then loop through tasks assigned to each employee
            //\n prints in new line
            Console.WriteLine($"\nEmployee: {employee.Name}");
            foreach (var task in employee.GetTask()) //for each task call getter (assuming employee has GetTasks() method
            {
                //print task Id, title and status
                Console.WriteLine($"Task number: {task.id}, Title: {task.description}, Status: {task.status}");
            }
        }
    }
}