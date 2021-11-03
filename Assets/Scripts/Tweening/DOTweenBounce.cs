using UnityEngine;
using DG.Tweening;

public class DOTweenBounce : MonoBehaviour
{
    [SerializeField]
    private float _bounceFactor;

    [SerializeField]
    private float _scaleDuration;

    private Vector3 _initScale;    

    private void Awake()
    {
        _initScale = transform.localScale;
    }

    public void Bounce()
    {
        Vector3 bouncedScale = _initScale * _bounceFactor;

        transform.DOScale(bouncedScale, _scaleDuration).OnComplete(() => transform.DOScale(_initScale, _scaleDuration));
    }

    public void ShakeBounce()
    {
        transform.DOShakePosition(_scaleDuration, _bounceFactor).SetEase(Ease.InBounce);
    }

    public void BounceIn()
    {        
        transform.localScale = Vector3.one * 0.1f;
        Bounce();        
    }

    private void OnDestroy()
    {
        DOTween.Clear();
    }
}
