using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Resources.View
{
    public class ResourcesViewContainer : MonoBehaviour
    {
        [SerializeField] private ResourceViewModel[] resourcesViewModels;

        private Dictionary<ResourceType, ResourceViewModel> resources = new Dictionary<ResourceType, ResourceViewModel>();

        [Inject]
        public void Init()
        {
            foreach (var viewModel in resourcesViewModels)
            {
                resources.Add(viewModel.ResourceType, viewModel);
                viewModel.Init();
            }
            
        }

        public void AddResource<T>(T resource) where T : AbstractResource
        {
            Debug.Log(resource.GetType());
            GetView(resource.GetType().ToString());
        }

        private ResourceViewModel GetView(string type)
        {
            if (Enum.TryParse(type, out ResourceType key))
            {
                if(resources.TryGetValue(key, out ResourceViewModel view))
                {
                    view.UpdateCount();
                }
            }

            return null;
        }
    }
}