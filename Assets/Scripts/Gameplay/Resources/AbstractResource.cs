using System;
using Game.Resources.View;
using UnityEngine;
using Zenject;

    public abstract class AbstractResource : MonoBehaviour
    {
        [Inject] private ResourcesViewModel viewContainer;

        protected virtual void Take()
        {
            Debug.Log("Take");
            viewContainer.AddResource(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            Take();
        }
    }