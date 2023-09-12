using UnityEngine;

[CreateAssetMenu(fileName = "ManufacturerContainer", menuName = "ManufacturerContainer")]
public class ManufacturersContainer : ScriptableObject
{
    [field: SerializeField] public ManufacturerData[] ManufacturersData;
}