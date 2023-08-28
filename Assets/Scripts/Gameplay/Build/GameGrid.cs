using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField] private Building[] buildings;
    [SerializeField] private string gridName;

    public string GridName => gridName;
    
    public void Init()
    {
        gameObject.SetActive(true);
        for (var index = 0; index < buildings.Length; index++)
        {
            string key = $"{gridName} + {index}";
            if (PlayerPrefs.HasKey(key))
            {
                bool isBuilt = Check(key);
                buildings[index].Init(this, isBuilt);

                if (!isBuilt)
                    buildings[index].Save += Save;
            }
            else
            {
                PlayerPrefs.SetInt(key, 0);
                buildings[index].Init(this,false);
                buildings[index].Save += Save;
            }
        }
    }

    private bool Check(string key)
    {
        if (PlayerPrefs.GetInt(key) == 0)
            return false;

        return true;
    }

    private void Save(Building building)
    {
        building.Save -= Save;
        int index = Array.IndexOf(buildings, building);
        string key = $"{gridName} + {index}";
        PlayerPrefs.SetInt(key, 1);
    }
}
