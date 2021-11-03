using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DOTweenFade : MonoBehaviour
{
    private Graphic _graphic;
    [SerializeField]
    private float _fadeDuration;

    private void Awake()
    {       
        _graphic = GetComponent<Graphic>();        
    }

    private void Fade(float endValue)
    {
        _graphic.DOFade(endValue, _fadeDuration);
    }

    public void FadeIn()
    {
        Fade(1);
    }
    public void FadeOut()
    {
        Fade(0);
    }
    private void OnDestroy()
    {
        DOTween.Clear(); 
    }
}
