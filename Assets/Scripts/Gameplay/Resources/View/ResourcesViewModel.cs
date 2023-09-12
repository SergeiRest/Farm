using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Resources.View
{
    public class ResourcesViewModel : MonoBehaviour
    {
        [SerializeField] private ResourcesView[] resourcesViews;

        private Dictionary<ResourceType, ResourceModel> resources = new Dictionary<ResourceType, ResourceModel>();

        [Inject]
        public void Init()
        {
            int typesCount = Enum.GetValues(typeof(ResourceType)).Length;
            for (int i = 0; i < typesCount; i++)
            {
                ResourceType resourceType = (ResourceType)i;
                ResourceModel model = new ResourceModel(resourceType);
                resources.Add(resourceType, model);
                
                if (i < resourcesViews.Length)
                {
                    ResourcesView view = resourcesViews[i];
                    view.Init(resourceType);
                    model.ResourceCountChanged += view.UpdateCount;
                }

                model.SendEvent();
                
            }
        }

        public void AddResource<T>(T resource) where T : AbstractResource
        {
            var model = GetModel(resource.GetType().ToString());
            model.AddResource();
        }

        public void RemoveResource(ResourceType type, int count)
        {
            resources.TryGetValue(type, out ResourceModel model);
            model.Remove(count);
        }
        
        public ResourceModel GetModel(ResourceType type)
        {
            if (resources.TryGetValue(type, out ResourceModel model))
                return model;

            throw new Exception("Нет ресурса");
            return null;
        }

        private ResourceModel GetModel(string type)
        {
            if (Enum.TryParse(type, out ResourceType key))
            {
                if(resources.TryGetValue(key, out ResourceModel model))
                {
                    return model;
                }
            }

            return null;
        }
    }
}