namespace FirstProject.ViewModel
{
    public class EmployeeWithMessageAndBranchListViewModel
    {
       public List<string> branches { get; set; }
       public int Temp { get; set; }
        // properties i want from db to display in view
       public string EmpName { get; set; }
       public int Salary { get; set; }

    }
}
