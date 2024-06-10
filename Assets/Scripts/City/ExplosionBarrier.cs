using UnityEngine;

internal class ExplosionBarrier : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private GameObject _destructible;
    [SerializeField] private GameObject _dynamite;
    [SerializeField] private AudioSource _audioEffect;

    public void Explode()
    {
        AudioSource.PlayClipAtPoint(_audioEffect.clip, transform.position);
        _explosionEffect.SetActive(true);
        _destructible.SetActive(false);
        _dynamite.SetActive(false);
    }
}