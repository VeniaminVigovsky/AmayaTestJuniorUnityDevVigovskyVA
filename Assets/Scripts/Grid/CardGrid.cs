using UnityEngine;
using UnityEngine.Events;

public class CardGrid : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnSlotsInitialized;

    [SerializeField]
    private UnityEvent OnGridGenerated;

    [SerializeField]
    private GameObject _cardSlotPrefab;

    private CardSlot[] _cardSlots;

    [SerializeField]
    private int _maxSlotCount;

    private int _gridRowLength;

    public CardSlot[] CardSlots
    {
        get => _cardSlots;
    }

    public int GridRowLength
    {
        get => _gridRowLength;
    }

    private void Awake()
    {
        if (_cardSlotPrefab != null)
        {
            _gridRowLength = Mathf.CeilToInt(Mathf.Sqrt(_maxSlotCount));
            GenerateGrid();            
        }
    }

    private void GenerateGrid()
    {
        float slotSizeX = _cardSlotPrefab.GetComponent<BoxCollider2D>().size.x;
        float slotSizeY = _cardSlotPrefab.GetComponent<BoxCollider2D>().size.y;

        float offSetCoof = _gridRowLength - 1;

        Vector2 initPos = (Vector2)transform.position + Vector2.up * slotSizeY * 0.5f * offSetCoof  + Vector2.left * slotSizeX * 0.5f * offSetCoof;        

        _cardSlots = new CardSlot[_maxSlotCount];

        int slotID = 0;

        for (int y = 0; y < _gridRowLength; y++)
        {
            for (int x = 0; x < _gridRowLength && slotID < _maxSlotCount; x++)
            {
                Vector2 slotPosition = initPos + Vector2.right * slotSizeX * x + Vector2.down * slotSizeY * y;
                GameObject slotGO = Instantiate(_cardSlotPrefab, transform);
                slotGO.transform.position = slotPosition;
                _cardSlots[slotID] = slotGO.GetComponent<CardSlot>();
                slotID++;
                slotGO.SetActive(false);
            }
        }

        OnGridGenerated?.Invoke();
    }

    public void InitializeSlots(CardData[] cards, CardData answerCard)
    {
        if (_cardSlots.Length <= 0) return;

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] == null) continue;

            bool isAnswerCard = cards[i].Identifier == answerCard.Identifier;
            _cardSlots[i].InitializeCard(cards[i], isAnswerCard);
            _cardSlots[i].gameObject.SetActive(true);
        }

        OnSlotsInitialized?.Invoke();
    }    

}
