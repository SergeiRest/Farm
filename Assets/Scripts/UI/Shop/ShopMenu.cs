using System;
using System.Collections.Generic;
using Game.Resources.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopMenu : UIMenu
{
    [Inject] private ResourcesViewModel resourcesViewModel;

    [SerializeField] private ResourceInfo resourceInfoPrefab;
    [SerializeField] private Transform resourceParent;
    [SerializeField] private Button buyButton;

    private Action callback;
    private List<ResourceInfo> resources = new List<ResourceInfo>();
    private BuildData[] buildData;
    
    
    public override void Init()
    {
        base.Init();
        buyButton.onClick.AddListener(Buy);
    }

    public void Construct(BuildData[] data, Action callback)
    {
        this.callback = callback;
        buildData = data;
        
        foreach (var item in data)
        {
            ResourceInfo resourceInfo = Instantiate(resourceInfoPrefab, resourceParent);
            resourceInfo.SetInfo(item.Resource.ToString(), item.BuildCount.ToString());
            resources.Add(resourceInfo);
        }

        bool interactable = true;
        foreach (var item in data)
        {
            var model = resourcesViewModel.GetModel(item.Resource);
            if (model.ResourceCount >= item.BuildCount)
            {
                interactable &= true;
                continue;
            }

            interactable &= false;
        }

        buyButton.interactable = interactable;

    }

    public void Clear()
    {
        foreach(var resource in resources)
        {
            Destroy(resource.gameObject);
        }
        
        resources.Clear();
        callback = null;
    }

    private void Buy()
    {
        foreach (var data in buildData)
        {
            resourcesViewModel.RemoveResource(data.Resource, data.BuildCount);
        }
        
        gameObject.SetActive(false);
        callback?.Invoke();
    }
}
