using UnityEngine;
using UnityEngine.Events;

public class GameplayHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnGameStarted;

    [SerializeField]
    private UnityEvent OnGameEnded;

    [SerializeField]
    private UnityEvent<int> OnLevelChanged;

    private int _currentLevel = 1;

    [SerializeField]
    private int _levelCount;

    public int CurrentLevel
    {
        get => _currentLevel;
        private set => _currentLevel = value;
    }

    private void Start()
    {
        OnGameStarted?.Invoke();
    }

    public void GoToNextLevel()
    {        
        CurrentLevel++;
        if (CurrentLevel > _levelCount)
        {
            OnGameEnded?.Invoke();
        }
        else
        {
            OnLevelChanged?.Invoke(CurrentLevel);            
        }
    }
}
