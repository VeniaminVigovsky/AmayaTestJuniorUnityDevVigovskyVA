using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskSetter : MonoBehaviour
{
    [SerializeField]
    private CardDB _cardBundleDB;

    [SerializeField]
    private CardGrid _grid;

    private CardDataBundle _currentBundle;   

    private Dictionary<CardDataBundle, List<CardData>> _usedAnswers;

    [SerializeField]
    private UnityEvent<string> OnTaskGenerated;
    

    private void Awake()
    {
        _usedAnswers = new Dictionary<CardDataBundle, List<CardData>>();
        foreach (var bundle in _cardBundleDB.CardDataBundleDB)
        {
            _usedAnswers.Add(bundle, new List<CardData>());
        }        
    }


    public void NextTask(int level)
    {
        int cardsCount = GetCardsCount(level);

        if (cardsCount <= 0) return;

        _currentBundle = GetRandomBundle();

        int answerCardID = 0;

        if (_currentBundle != null)
        {
            answerCardID = GetRandomAnswerCardID(_currentBundle);
            if (answerCardID < 0) return;
            _usedAnswers[_currentBundle].Add( _currentBundle.CardDataSet[answerCardID]);
        }
        else
        {
            return;
        }

        CardData[] cardsForTask = new CardData[cardsCount];
        
        List<CardData> closedCardSet = new List<CardData>();

        List<CardData> openCardSet = new List<CardData>();

        foreach (var card in _currentBundle.CardDataSet)
        {
            openCardSet.Add(card);
        }

        int answerR = Random.Range(0, cardsCount);

        cardsForTask[answerR] = _currentBundle.CardDataSet[answerCardID];

        closedCardSet.Add(_currentBundle.CardDataSet[answerCardID]);
        openCardSet.Remove(_currentBundle.CardDataSet[answerCardID]);        

        for (int i = 0; i < answerR; i++)
        {
            if (openCardSet.Count <= 0) break;
            int r = Random.Range(0, openCardSet.Count);

            cardsForTask[i] = openCardSet[r];
            closedCardSet.Add(cardsForTask[i]);
            openCardSet.RemoveAt(r);            
        }
        
        for (int i = answerR + 1; i < cardsForTask.Length; i++)
        {
            if (openCardSet.Count <= 0) break;
            int r = Random.Range(0, openCardSet.Count);

            cardsForTask[i] = openCardSet[r];
            closedCardSet.Add(cardsForTask[i]);
            openCardSet.RemoveAt(r);            
        }

        _grid.InitializeSlots(cardsForTask, cardsForTask[answerR]);

        OnTaskGenerated?.Invoke(cardsForTask[answerR].Identifier);
    }
    

    private CardDataBundle GetRandomBundle()
    {
        int r = 0;

        CardDataBundle bundle = null;

        List<CardDataBundle> openSet = new List<CardDataBundle>();
        foreach (var b in _cardBundleDB.CardDataBundleDB)
        {
            openSet.Add(b);
        }

        while(openSet.Count > 0)
        {
            r = Random.Range(0, openSet.Count);
            if (_usedAnswers[openSet[r]].Count == openSet[r].CardDataSet.Length)
            {
                openSet.RemoveAt(r);
            }
            else
            {
                bundle = openSet[r];
                break;
            }            
        }

        return bundle;
    }

    private int GetCardsCount(int level)
    {
        if (_grid != null)
            return _grid.GridRowLength * level;
        else return 0;
    }

    private int GetRandomAnswerCardID(CardDataBundle bundle)
    {
        int ind = -1;
        List<int> openIds = new List<int>();        
        for (int i = 0; i < bundle.CardDataSet.Length; i++)
        {
            openIds.Add(i);
        }

        while (openIds.Count > 0)
        {
            int r = Random.Range(0, openIds.Count);

            int rInd = openIds[r];

            if (_usedAnswers[bundle].Contains(bundle.CardDataSet[rInd]))
            {
                openIds.RemoveAt(r);
            }
            else
            {
                ind = rInd;
                break;
            }
        }

        return ind;
    }

}
