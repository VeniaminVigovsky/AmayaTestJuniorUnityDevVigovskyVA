using System;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField]
    private string _identifier;

    [SerializeField]
    private Sprite _cardSprite;

    [SerializeField]
    private float _rotationOffset;

    public string Identifier
    {
        get => _identifier;
    }

    public Sprite CardSprite
    {
        get => _cardSprite;
    }

    public float RotationOffset
    {
        get => _rotationOffset;
    }

}
