using TMPro;
using UnityEngine;

public enum ResourceType
{
    Grass,
    Wood,
}

namespace Game.Resources.View
{
    public class ResourceViewModel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI count;
        [SerializeField] private ResourceType resourceType;

        private int resourceCount = 0;

        public ResourceType ResourceType => resourceType;

        public void Init()
        {
            count.text = resourceCount.ToString();
        }

        public void UpdateCount()
        {
            resourceCount++;
            count.text = resourceCount.ToString();
        }
    }
}