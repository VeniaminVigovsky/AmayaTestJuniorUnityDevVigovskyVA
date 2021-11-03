using UnityEngine;

[CreateAssetMenu(fileName = "New CardDB", menuName = "Cards/Card DataBase")]
public class CardDB : ScriptableObject
{
    [SerializeField]
    private CardDataBundle[] _cardBundleDB;

    public CardDataBundle[] CardDataBundleDB
    {
        get => _cardBundleDB;
    }
}
