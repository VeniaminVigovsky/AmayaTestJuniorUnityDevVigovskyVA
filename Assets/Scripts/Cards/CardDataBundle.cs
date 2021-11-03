using UnityEngine;

[CreateAssetMenu(fileName = "New CardData Bundle", menuName = "Cards/CardData Bundle")]
public class CardDataBundle : ScriptableObject
{
    [SerializeField]
    private CardData[] _cardDataSet;    

    public CardData[] CardDataSet
    {
        get => _cardDataSet;
    }
}
