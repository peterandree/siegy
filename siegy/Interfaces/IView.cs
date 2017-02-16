using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siegy.Interfaces
{
    internal interface IView:IObserver
    {
        void SetController(IControl controller);

        void SetModel(IModel view);

        //void Update();

        string WaitForInput(); //"Eventhandler"
    }
}