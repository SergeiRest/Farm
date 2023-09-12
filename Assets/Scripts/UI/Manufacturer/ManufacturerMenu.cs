using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Resources.View;
using UnityEditor;
using UnityEngine;
using Zenject;

public class ManufacturerMenu : UIMenu
{
    [Inject] private ResourcesViewModel resourcesViewModel;
    [Inject] private AvatarData avatarData;
    
    [SerializeField] private ManufacturerItem prefab;
    [SerializeField] private Transform parent;
    private const string PATH = "ManufacturerContainer";
    private List<ManufacturerItem> items = new List<ManufacturerItem>();
    
    public void Construct(ConstructionType constructionType, ManufacturerBuilding building)
    {
        ManufacturersContainer container = Resources.Load<ManufacturersContainer>(PATH);
        ManufacturerData data = container.ManufacturersData.First(type => type.ConstructionType == constructionType);
        foreach (var item in data.CraftData)
        {
            ManufacturerItem manufacturerItem = Instantiate(prefab, parent);
            items.Add(manufacturerItem);
            manufacturerItem.Construct(avatarData.GetSprite(item.InputItem),
                avatarData.GetSprite(item.OutputItem),
                resourcesViewModel.GetModel(item.InputItem).ResourceCount,
                item.CountForCraft,
                item.CraftTime);
        }
    }

    public void Clear()
    {
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
        
        items.Clear();
    }
}
