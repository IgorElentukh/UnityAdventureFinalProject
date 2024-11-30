﻿using Assets.ProjectFolder.Develop.CommonServices.LoadingScreen;
using Assets.ProjectFolder.Develop.DI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.EntryPoint
{
    internal class Bootstrap : MonoBehaviour
    {
        public IEnumerator Run(DIContainer container)
        {
            ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();
            loadingCurtain.Show();
            
            Debug.Log("Начинается инициализация сервисов");

            yield return new WaitForSeconds(1.5f);

            Debug.Log("Завершается инициализация сервисов проекта, начинается переход на сцену");
            loadingCurtain.Hide();
        }
    }
}