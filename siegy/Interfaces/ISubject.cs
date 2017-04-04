using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.Interfaces
{
    internal interface ISubject
    {
        void Attach(IObserver p_observer);
        void Detach(IObserver p_observer);
        void Notify();
    }
}
