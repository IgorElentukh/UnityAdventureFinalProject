using Assets.ProjectFolder.Develop.CommonServices.DataManagement.DataProviders;
using System;
using System.Collections.Generic;

namespace Assets.ProjectFolder.Develop.CommonServices.DataManagement
{
    public static class SaveDataKeys
    {
        private static Dictionary<Type, string> Keys = new Dictionary<Type, string>()
        {
            {typeof(PlayerData), "PlayerData" }
        };

        public static string GetKeyFor<TData>() where TData : ISaveData
            => Keys[typeof(TData)];
    }
}
