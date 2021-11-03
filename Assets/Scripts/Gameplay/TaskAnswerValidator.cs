using UnityEngine;
using UnityEngine.Events;

public class TaskAnswerValidator : MonoBehaviour
{
    private CardSlot _slot;

    [SerializeField]
    private UnityEvent OnCorrectAnswerSubmitted;

    [SerializeField]
    private UnityEvent OnWrongAnswerSubmitted;

    private GameplayHandler _gameplayHandler;

    private void Awake()
    {
        _slot = GetComponent<CardSlot>();
        _gameplayHandler = FindObjectOfType<GameplayHandler>();
        if (_gameplayHandler != null)
        {
            OnCorrectAnswerSubmitted.AddListener(_gameplayHandler.GoToNextLevel);            
        }
    }

    private void OnMouseDown()
    {
        if (_slot.IsAnswerSlot)
        {
            OnCorrectAnswerSubmitted?.Invoke();
        }
        else
        {
            OnWrongAnswerSubmitted?.Invoke();
        }
    }
}
