using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOAPAKmmReceiver.Interfaces
{
    public interface INetConnection
    {
        public delegate void Execute();

        void StartListen(Execute execute);
        void StopListen();
        void GetConnectionSettings(string sectionKey);
    }
}
