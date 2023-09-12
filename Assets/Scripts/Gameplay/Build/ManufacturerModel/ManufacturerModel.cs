using System;
using Game.Resources.View;
using UniRx;
using Zenject;

namespace Gameplay.Build.ManufacturerModel
{
    public class ManufacturerModel : IDisposable
    {
        [Inject] private ResourcesViewModel resourcesViewModel;
        
        private int count = 0;
        private ResourceType outputResource;
        private IDisposable timeDisposable;
        private float spendTime = 0;
        
        public Action Update;

        public void StartCraft(int craftTime, int count, ResourceType output)
        {
            this.count = count;
            outputResource = output;

            timeDisposable = Observable.Interval(1.Sec()).TakeWhile(l => spendTime < craftTime).Subscribe(_ =>
            {
                spendTime++;
            });
        }

        public void Dispose()
        {
            
        }
    }
}