using UnityEngine;

internal class ExplosionBarrier : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private GameObject _destructible;
    [SerializeField] private GameObject _dynamite;

    public void Explode()
    {
        _explosionEffect.SetActive(true);
        _destructible.SetActive(false);
        _dynamite.SetActive(false);
    }
}