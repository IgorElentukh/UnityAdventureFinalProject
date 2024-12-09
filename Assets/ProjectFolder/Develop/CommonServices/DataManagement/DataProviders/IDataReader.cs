using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ProjectFolder.Develop.CommonServices.DataManagement.DataProviders
{
    public interface IDataReader<TData> where TData : ISaveData
    {
        void ReadFrom(TData data);
    }
}
