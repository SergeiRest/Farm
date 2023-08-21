using System;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private int maxFps;

    private void Start()
    {
        Application.targetFrameRate = maxFps;
    }
}
