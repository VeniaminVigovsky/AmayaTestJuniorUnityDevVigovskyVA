using System.Collections;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField]
    private GameObject _particles;

    private float _waitTime;

    private bool _isBursting;

    private void Awake()
    {
        _particles?.SetActive(false);
        _waitTime = 0.5f;
    }

    public void BurstParticles()
    {
        if (_isBursting) return;
        StartCoroutine(BurstAndDeactivate());
    }

    private IEnumerator BurstAndDeactivate()
    {
        _isBursting = true;
        _particles?.SetActive(true);

        yield return new WaitForSeconds(_waitTime);
        _particles?.SetActive(false);
        _isBursting = false;
    }
}
