using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CompositeUIApp
{
   public  class TestViewModel
    {
        public TestViewModel()
        {
            this.OnDeptSelectedCommand =
                new MVVMUtilityLib.DelegateCommand(
                    (object parameter) => {
                        GetAllPatientsByDeptCode(parameter.ToString());
                    },
                    (object parameter) => { return true; });
                 
        }
        public ICommand OnDeptSelectedCommand { get; set; }

        public void GetAllPatientsByDeptCode(string deptCode)
        {

        }
    }
}
