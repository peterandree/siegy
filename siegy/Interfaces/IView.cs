using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.Interfaces
{
    internal interface IView:IObserver
    {
        void SetController(IControl controller);

        void SetModel(IModel model);

        //void Update();

        string WaitForInput(); //"Eventhandler"
    }
}