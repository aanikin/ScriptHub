using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptHub.Model.Interfaces
{
    public interface IConfigFile<T>
    {
        T Load();
        void Save(T t);
    }
}
