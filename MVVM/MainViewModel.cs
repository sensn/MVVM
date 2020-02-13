using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    public class MainViewModel : MainViewModelBase
    {
        public struct pattern
        {

            // public List<int> int_tempo;

            public int[,] vec_bs1;
            public int[] vec_m_bs1;
            //public List<int> vec_bs1;
            public List<int> vec_bs;
            public List<int> vec_m_bs;
            public List<int> int_vs;
            public List<int> int_bnk;
            public List<int> int_prg;
            public List<int> int_sl2;
        };
        public pattern thepattern = new pattern();

        // private static  MyLogic myLogic_ = null;
        private static  Calculator calculator_ = null;
        private int result_ = 0;
        private int value1_ = 14;
        private int value2_ = 0;
        private bool isAddChecked_ = false;
        private bool isSubChecked_ = false;
        private bool isMulChecked_ = false;
        private bool isDivChecked_ = false;
        private bool isAnyRadioBtnCheck_ = false;
        private string someString_="HUHU";
        private ObservableCollection<string> _myItems = new ObservableCollection<string>(new[] { "test11", "test2", "test3" });
        private ObservableCollection<int> _myChannel = new ObservableCollection<int>(new[] { 0,1,2,3,4,5,6,7,8,9 });
        private ObservableCollection<bool> _myItemsbool = new ObservableCollection<bool>(new[] { true, false, true });
        private ObservableCollection<bool> _myItems_Mute_bool = new ObservableCollection<bool>(new[] { true, false, true });
        
       public MainViewModel()
        {
            calculator_ = new Calculator(Value1, Value2);
            thepattern.vec_bs1 = new int[5, 16];
            thepattern.vec_m_bs1 = new int[5];
            //thepattern.vec_bs1 = new List<int>(5 * 16 * 10);
            thepattern.vec_bs = new List<int>(5 * 16 * 10);
            thepattern.vec_m_bs = new List<int>(5 * 10);
            thepattern.int_bnk = new List<int>(10);
            thepattern.int_prg = new List<int>(10);

            thepattern.int_vs = new List<int>(10);
            thepattern.int_sl2 = new List<int>(10);

            for (int i = 0; i < 10; i++)
            {
                thepattern.int_vs.Add(0);
                thepattern.int_sl2.Add(0);
                thepattern.int_bnk.Add(0);
                thepattern.int_prg.Add(0);

            }
            for (int i = 0; i < 5 * 10; i++)
            {
                thepattern.vec_m_bs.Add(0);
            }

            for (int i = 0; i < (5 * 16 * 10); i++)
            {
                // Debug.WriteLine("LOOP" + i);
                thepattern.vec_bs.Add(0);
                //  thepattern.vec_bs.Add(0);
            }




        }

        public ObservableCollection<string> MyItems
        {
            get { return _myItems; }
            set { _myItems = value; ; }
        }

        public ObservableCollection<bool> MyItemsbool { get { return _myItemsbool; } 
            set 
            {
             
                    _myItemsbool = value; 
            }
        }

        public ObservableCollection<bool> MyItems_Mute_bool { get => _myItems_Mute_bool; set => _myItems_Mute_bool = value; }




        public void fillItems()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 16; j++)
                {
                    {
                        MyItemsbool.Add(false);
                        MyItemsbool[(j) + (i * 16)] = false;
                    }
                }

            for (int i = 0; i < 5; i++) { 
                MyItems_Mute_bool.Add(false);
                MyItems_Mute_bool[i] = false;
        }
            //            for (int i = 0; i < 10; i++)
            //{
            //    MyItemsbool.Add(false);
            //    MyItemsbool[i] = false;
            //}

        }
        public void printItems()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine(MyItemsbool[i]);
            }
            for (int i = 0; i < 10; i++)
            {
              
                 //   MyItemsbool[i] = false;
                
              
            } 
        }
        public string SomeString
        {
            get
            {
                return someString_;
            }
            set
            {
                someString_ = value;
                OnPropertyChanged("SomeString");
            }
        }




        // CALC

        public bool IsAnyRadioBtnCheck { get => isAnyRadioBtnCheck_; set { isAnyRadioBtnCheck_ = value; OnPropertyChanged("IsAnyRadioBtnCheck");}}

        public int Value1 { get => value1_; set { value1_ = value; OnPropertyChanged("Value1"); } }

        public int Value2 { get => value2_; set { value2_ = value; OnPropertyChanged("Value2"); } }

        public int Result
        {
            get => result_; set
            {
                if (value != result_)
                {
                    result_ = value; OnPropertyChanged("Result");
                }
            }
        }

        public bool IsAddChecked
        {
            get => isAddChecked_; set
            {
                if (value != isAddChecked_)
                {
                    isAddChecked_ = value;
                    IsAnyRadioBtnCheck = true;
                    OnPropertyChanged("IsAddChecked");
                }
            }
        }
        public bool IsSubChecked
        {
            get => isSubChecked_; set
            {
                if (value != isSubChecked_)
                {
                    isSubChecked_ = value;
                    IsAnyRadioBtnCheck = true;
                    OnPropertyChanged("IsSubChecked");
                }
            }
        }
        public bool IsMulChecked
        {
            get => isMulChecked_; set
            {
                if (value != isMulChecked_)
                {
                    isMulChecked_ = value;
                    IsAnyRadioBtnCheck = true;
                    OnPropertyChanged("IsMulChecked");
                }
            }
        }
        public bool IsDivChecked
        {
            get => isDivChecked_; set
            {
                if (value != isDivChecked_)
                {
                    isDivChecked_ = value;
                    IsAnyRadioBtnCheck = true;
                    OnPropertyChanged("IsDivChecked");
                }
            }
        }

        //
        public ICommand OKButtonClicked
        {
            get
            {
                
                return new DelegateCommand(printItems);
            }
        }

        public ICommand OKButtonClicked1
        {
            get
            {

                //return new DelegateCommand1(printItems1(int));
               
                return new DelegateCommand1<object>(UpdateDatabase);
            }
        }

        public ObservableCollection<int> MyChannel { get => _myChannel; set => _myChannel = value; }

        public void UpdateDatabase(object parameter)
        {
            BlankPage1.SelChannel((int)parameter);
            Debug.Write(parameter);
        }


        public void FindResult()
        {
           // calculator_ = new Calculator(Value1, Value2);
            Debug.WriteLine("HOHO");
            if (IsAddChecked)
            {
                MyItems[1]= "test5";
                Result = calculator_.Add();
            }
            else if (IsSubChecked)
            {
                Result = calculator_.Sub();
            }
            else if (IsMulChecked)
            {
                Result = calculator_.Mul();
            }
            else if (IsDivChecked)
            {
                Result = calculator_.Div();
            }
        }
        ////  SVAE LOAD PATTERN
         public void pattern_save_struct(int tabentry)
        {
            for (int i = 0; i< 5; i++)
            {
                for (int j = 0; j< 16; j++)
                {             
                    thepattern.vec_bs[(j) + (i * 16) + ((80) * tabentry)] = (MyItemsbool[(j) + (i * 16)])? 1:0; 
                  //  thepattern.vec_bs[(j) + (i * 16) + ((80) * tabentry)] = thepattern.vec_bs1[i, j];   
                   // thepattern.vec_bs[(j) + (i * 16) + ((80) * tabentry)] = thepattern.vec_bs1[i, j];   
                }
}
            for (int i = 0; i< 5; i++)
            {
                thepattern.vec_m_bs[(i) + ((5) * tabentry)] = (MyItems_Mute_bool[i]) ? 1 : 0;
                //thepattern.vec_m_bs[(i) + ((5) * tabentry)] = thepattern.vec_m_bs1[i];
            }
        }

       // public void pattern_load_struct(int tabentry)
        public async void  pattern_load_struct(int tabentry)
        {
          
                   
                    Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                                thepattern.vec_bs1[i, j] = thepattern.vec_bs[(j) + (i * 16) + ((80) * tabentry)];
                                MyItemsbool[(j) + (i * 16)] = thepattern.vec_bs1[i, j] != 0;
                            }
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            thepattern.vec_m_bs1[i] = thepattern.vec_m_bs[(i) + ((5) * tabentry)];
                            MyItems_Mute_bool[i] = thepattern.vec_m_bs1[i] != 0;
                            //mute_bu[i].IsChecked = thepattern.vec_m_bs1[i] != 0;
                        }

                    });
                    // bu[i, j].IsChecked = thepattern.vec_bs1[i, j] != 0;  // INT TO        
                    //bu[i,j].IsChecked = thepattern.vec_bs[(j) + (i * 16) + ((80) * tabentry)] != 0 ;  // INT TO  
         
        }







    }
    }
