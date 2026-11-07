using System;
using UnityEngine;

[Serializable]
public enum Owner
{
    Friend,
    Player
}

[Serializable]
public struct DialogueInstance
{
    public RectTransform prefab;
    public Owner owner;
}