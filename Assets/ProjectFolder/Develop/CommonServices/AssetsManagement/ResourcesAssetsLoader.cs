using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.CommonServices.AssetsManagement
{
    public class ResourcesAssetsLoader
    {
        public T LoadResource<T>(string resourcePath) where T : Object
            => Resources.Load<T>(resourcePath);
    }
}