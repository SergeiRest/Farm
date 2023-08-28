using System;
using UnityEngine;

namespace Game.Resources.View
{
    public class ResourceModel
    {
        private int count;
        private readonly ResourceType resourceType;
        public Action<int> ResourceCountChanged;

        public int ResourceCount => count;
        
        public ResourceModel(ResourceType type)
        {
            if (PlayerPrefs.HasKey(type.ToString()))
            {
                count = PlayerPrefs.GetInt(type.ToString());
            }
            else
            {
                count = 0;
                PlayerPrefs.SetInt(type.ToString(), count);
            }

            resourceType = type;
        }
        
        public void SendEvent() => 
            ResourceCountChanged?.Invoke(count);

        public void AddResource()
        {
            count++;
            Save();
            SendEvent();
        }

        public void Remove(int count)
        {
            this.count -= count;
            Save();
            SendEvent();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(resourceType.ToString(), count);
        }
    }
}