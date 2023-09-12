using System;
using UnityEngine;

public abstract class AbstractTrigger : MonoBehaviour
{
    public Action Enter;
    public Action Exit;
    
    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void OnTriggerExit(Collider other);
}
