using System.Runtime.CompilerServices;

namespace MonG1WebApp.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //sort arr using Bubble sort alg.
        }
    }
     
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //sort arr using Selection sort alg
        }
    }

    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
    //DIP IOC using DI
    //open for exetn close for modific + lossly couple
    class MyList
    {
        int[] arr;
        ISort sortAl;//abstarct class + interface
        public MyList(ISort _SortAl)
        {
            arr=new int[10];
            sortAl = _SortAl;// new BubbleSort();//dont create but ask (construct,method parameter) "Depndecy inject"
        }

        public void SortArr()
        {
            sortAl.Sort(arr);
        }
    }

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
            MyList l1 = new MyList(new BubbleSort());//create obj
            l1.SortArr();
            MyList l2 = new MyList(new SelectionSort());//
            l2.SortArr();//using bubble
            MyList l3 = new MyList(new ChrisSort());//
            l3.SortArr();


            //Class1 class1 = new Class1();
            //class1.ViewData = "ahmed";//boxing
            //string name = class1.ViewData.ToString(); //unbox
            //class1.ViewBag = 10;
            //int x1 = class1.ViewBag;//unbox runtime








            /*dynamic x = 10; //link dduring runtime
            dynamic   name = "Ahmed";
            dynamic obj = new Student();
            
            x = obj + name; //try execute this line runtime - throw exception
            */
        }
    }
}
