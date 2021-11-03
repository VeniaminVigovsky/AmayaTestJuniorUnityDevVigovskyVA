using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotTweener : MonoBehaviour
{
    [SerializeField]
    private GameplayHandler _gameplayHandler;

    private CardGrid _grid;

    private List<DOTweenBounce> _slotBounces = new List<DOTweenBounce>();

    private bool _hasBounced;

    private void Start()
    {
        _hasBounced = false;
    }

    public void GetSlots()
    {
        _grid = GetComponent<CardGrid>();

        if (_slotBounces.Count > 0) return;

        foreach (var card in _grid.CardSlots)
        {
            DOTweenBounce tweenBounce = card.GetComponent<DOTweenBounce>();
            if (tweenBounce != null)
                _slotBounces.Add(tweenBounce);
        }
    }

    public void BounceInCards()
    { 
        if (!_hasBounced)
        {
            StartCoroutine(QueueBounceCards());
            _hasBounced = true;
        }
    }

    private IEnumerator QueueBounceCards()
    {
        float delay = 0.3f;

        List<DOTweenBounce> bounces = new List<DOTweenBounce>();

        foreach (var bounce in _slotBounces)
        {
            if (bounce.gameObject.activeInHierarchy)
            {
                bounce.gameObject.SetActive(false);
                bounces.Add(bounce);
            }
        }

        foreach (var bounce in bounces)
        {
            bounce.gameObject.SetActive(true);
            bounce.BounceIn();
            yield return new WaitForSeconds(delay);
        }
    }
}
