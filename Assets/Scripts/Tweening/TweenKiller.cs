using UnityEngine;
using DG.Tweening;

public class TweenKiller : MonoBehaviour
{
    public void KillTweens()
    {
        DOTween.Clear();
    }
}
