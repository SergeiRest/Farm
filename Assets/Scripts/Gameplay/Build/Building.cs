using UnityEngine;
using System;
using Gameplay.Build;

public class Building : MonoBehaviour
{
    [SerializeField] private BuildData[] buildData;
    [SerializeField] private BuildTrigger buildTrigger;
    [SerializeField] private GameObject model;
    
    public Action<Building> Save;

    public void Init(GameGrid parent, bool isBuilt)
    {
        if(isBuilt)
            Activate();
        else
        {
            Deactivate();
            buildTrigger.Enter += OpenBuildMenu;
            buildTrigger.Exit += CloseBuildMenu;
        }
    }
    
    private void Activate()
    {
        model.SetActive(true);
        buildTrigger.gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        model.SetActive(false);
        buildTrigger.gameObject.SetActive(true);
    }

    private void OpenBuildMenu()
    {
        GUIManager.GetUI<ShopMenu>().Construct(buildData, () =>
        {
            Activate();
            Save?.Invoke(this);
        });
        GUIManager.Open<ShopMenu>();
    }
    
    private void CloseBuildMenu()
    {
        GUIManager.GetUI<ShopMenu>().Clear();
        GUIManager.Close<ShopMenu>();
    }
}

[Serializable]
public struct BuildData
{
    [field: SerializeField] public ResourceType Resource { get; private set; }
    [field: SerializeField] public int BuildCount { get; private set; }
}
