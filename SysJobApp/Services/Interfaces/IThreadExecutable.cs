using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysJobApp.Services.Interfaces
{
    public interface IThreadExecutable
    {
        void Execute(CancellationToken token);
    }
}
