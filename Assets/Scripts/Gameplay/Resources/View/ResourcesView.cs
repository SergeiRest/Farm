using TMPro;
using UnityEngine;

public enum ResourceType
{
    Grass = 0,
    Wood = 1,
    WoodenPlank = 2,
}

namespace Game.Resources.View
{
    public class ResourcesView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI count;
        [SerializeField] private ResourceType resourceType;
        
        public void Init(ResourceType type)
        {
            resourceType = type;
        }

        public void UpdateCount(int count) => 
            this.count.text = count.ToString();
    }
}