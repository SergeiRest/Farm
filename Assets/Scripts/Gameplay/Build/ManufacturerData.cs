using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ManufacturerData", fileName = "ManufacturerData")]
public class ManufacturerData : ScriptableObject
{
    [field: SerializeField] public ConstructionType ConstructionType { get; private set; }
    [field: SerializeField] public CraftData[] CraftData { get; private set; }
}

[Serializable]
public struct CraftData
{
    [field: SerializeField] public ResourceType InputItem { get; private set; }
    [field: SerializeField] public int CountForCraft { get; private set; }
    [field: SerializeField] public ResourceType OutputItem { get; private set; }
    [field: SerializeField] public int CraftTime;
}
