using System.Runtime.CompilerServices;

namespace MonG1WebApp.Models
{

    class Class1
    {
        object viewdata;

        public object ViewData
        {
            get
            {
                return viewdata;
            }
            set
            {
                viewdata = value;
            }
        }
        //another property wrap the same field
        public dynamic ViewBag
        {
            get
            {
                return viewdata;
            }
            set
            {
                viewdata = value;
            }
        }
    }









    public class TestClass
    {
        public void test()
        {
            Class1 class1 = new Class1();
            class1.ViewData = "ahmed";//boxing
            string name = class1.ViewData.ToString(); //unbox
            class1.ViewBag = 10;
            int x1 = class1.ViewBag;//unbox runtime








            /*dynamic x = 10; //link dduring runtime
            dynamic   name = "Ahmed";
            dynamic obj = new Student();
            
            x = obj + name; //try execute this line runtime - throw exception
            */
        }
    }
}
