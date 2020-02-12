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
        private Calculator calculator_ = null;
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
        private ObservableCollection<bool> _myItemsbool = new ObservableCollection<bool>(new[] { true, false, true });

        public ObservableCollection<bool> MyItemsbool { get => _myItemsbool; set => _myItemsbool = value; }
        public ObservableCollection<string> MyItems
        {
            get { return _myItems; }
            set { _myItems = value; }
        }

        public void fillItems()
        {
         
            for (int i = 0; i < 10; i++)
            {
                MyItemsbool.Add(true);
                MyItemsbool[i] = true;
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
                
                return new DelegateCommand(FindResult);
            }
        }

      

        public void FindResult()
        {
            calculator_ = new Calculator(Value1, Value2);
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







    }
    }
