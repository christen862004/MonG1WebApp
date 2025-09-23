namespace MonG1WebApp.ViewModels
{
    public class EmpNameWithMSgClrTempBrachListViewModel
    {
        //Model
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        //Megre infon from another Moedl
        public string DeptName { get; set; }

        //Extra info
        public string Message { get; set; }
        public int Temp { get; set; }
        public string Color { get; set; }
        public List<string> Branches { get; set; }
    }
}
