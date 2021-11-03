using UnityEngine;

public class CardSlot : MonoBehaviour
{
    private CardData _cardData;

    private bool _isAnswerSlot;

    public bool IsAnswerSlot
    {
        get => _isAnswerSlot;
    }

    [SerializeField]
    private SpriteRenderer _slotSpriteRender;

    public CardData CardData
    {
        get => _cardData;
        private set => _cardData = value;
    }

    public void InitializeCard(CardData cardData, bool isAnswerSlot)
    {
        transform.rotation = Quaternion.identity;
        CardData = cardData;
        _slotSpriteRender.sprite = cardData.CardSprite;
        _isAnswerSlot = isAnswerSlot;
        transform.Rotate(Vector3.forward, cardData.RotationOffset);
    }
}
