using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManufacturerItem : MonoBehaviour
{
    [SerializeField] private Image fromImage;
    [SerializeField] private Image toImage;
    [SerializeField] private TMP_Text currentCount;
    [SerializeField] private TMP_Text coffiecent;
    [SerializeField] private TMP_Text maxCount;
    [SerializeField] private Slider slider;
    [SerializeField] private Button start;

    private int countForCraft; // Сколько доступно для крафта
    private int craftCount; // Сколько будет крафтиться
    private int craftTime;
    
    public void Construct(Sprite from, Sprite to, int resourceCount, int countForCraft, int craftTime)
    {
        fromImage.sprite = from;
        toImage.sprite = to;
        currentCount.text = 0.ToString();
        coffiecent.text = $"{countForCraft}:1";
        
        this.countForCraft = countForCraft;
        this.craftTime = craftTime;
        
        int maxCraft = resourceCount / countForCraft;
        this.maxCount.text = maxCraft.ToString();
        slider.minValue = 0;
        slider.maxValue = maxCraft;
        slider.onValueChanged.AddListener(SetCountForCraft);
    }

    private void SetCountForCraft(float value)
    {
        craftCount = (int)value;
        currentCount.text = craftCount.ToString();
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(SetCountForCraft);
    }

    private void StartCraft()
    {
        if(craftCount <= 0)
            return;
        
        
    }
}
