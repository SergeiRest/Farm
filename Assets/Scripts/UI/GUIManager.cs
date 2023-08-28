using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private UIMenu[] menus;

    private static Dictionary<Type, UIMenu> menusDictionary = new Dictionary<Type, UIMenu>();

    private void Awake()
    {
        foreach (var menu in menus)
        {
            Type key = menu.GetType();
            if (!menusDictionary.ContainsKey(key))
            {
                menusDictionary.Add(key, menu);
            }
            menu.Init();
        }
    }

    public static T GetUI<T>() where T : UIMenu
    {
        Type key = typeof(T);
        if (!menusDictionary.ContainsKey(key))
        {
            throw new Exception("Net UI");
        }
        else
        {
            return (T)menusDictionary[key];
        }
    }

    public static void Open<T>()
    {
        Type key = typeof(T);
        menusDictionary[key].gameObject.SetActive(true);
    }

    public static void Close<T>()
    {
        Type key = typeof(T);
        menusDictionary[key].gameObject.SetActive(false);
    }
}
