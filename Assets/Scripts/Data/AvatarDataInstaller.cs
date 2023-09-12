using UnityEngine;
using System;
using System.Collections.Generic;
using Zenject;

[CreateAssetMenu(fileName = "AvatarData", menuName = "AvatarData")]

public class AvatarDataInstaller : ScriptableObjectInstaller<AvatarDataInstaller>
{
    public ResourceAvatar[] Resources;

    public override void InstallBindings()
    {
        Container.Bind<AvatarData>().FromNew().AsSingle().WithArguments(Resources);
    }
}

[Serializable]
public struct ResourceAvatar
{
    public Sprite Sprite;
    public ResourceType Type;
}

public class AvatarData
{
    private Dictionary<ResourceType, Sprite> avatars = new Dictionary<ResourceType, Sprite>();

    public AvatarData(ResourceAvatar[] resources)
    {
        foreach (var resource in resources)
        {
            if (!avatars.ContainsKey(resource.Type))
            {
                avatars.Add(resource.Type, resource.Sprite);
            }
        }
    }

    public Sprite GetSprite(ResourceType type)
    {
        if (!avatars.ContainsKey(type))
            return null;

        return avatars[type];
    }
}


