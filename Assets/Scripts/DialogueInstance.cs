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
    public Dialogue Prefab;
    [TextArea] public string Content;
    public Owner Owner;
}