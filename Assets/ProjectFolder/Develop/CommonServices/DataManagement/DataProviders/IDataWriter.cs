﻿namespace Assets.ProjectFolder.Develop.CommonServices.DataManagement.DataProviders
{
    public interface IDataWriter<TData> where TData : ISaveData
    {
        void WriteTo(TData data);
    }
}
