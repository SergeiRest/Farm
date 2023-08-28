using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI count;

    public void SetInfo(string description, string count)
    {
        this.description.text = description;
        this.count.text = count;
    }
}
