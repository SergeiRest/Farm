using Gameplay.Build.ManufacturerModel;
using UnityEngine;

public class ManufacturerBuilding : Building
{
    [SerializeField] private ManufacturerTrigger manufacturerTrigger;
    [SerializeField] private ConstructionType constructionType;

    private ManufacturerModel manufacturerModel;
    
    protected override void Activate()
    {
        base.Activate();
        manufacturerModel = new ManufacturerModel();
        manufacturerTrigger.gameObject.SetActive(true);
        manufacturerTrigger.Enter += ShowManufacturerMenu;
        manufacturerTrigger.Exit += CloseManufacturerMenu;
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        manufacturerTrigger.gameObject.SetActive(false);
    }

    private void ShowManufacturerMenu()
    {
        GUIManager.Open<ManufacturerMenu>();
        GUIManager.GetUI<ManufacturerMenu>().Construct(constructionType, this);
    }

    private void CloseManufacturerMenu()
    {
        GUIManager.Close<ManufacturerMenu>();
        GUIManager.GetUI<ManufacturerMenu>().Clear();
    }
}
