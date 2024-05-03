using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private Transform _spawnPoint;

    public void Shoot(Transform parabola)
    {
        Instantiate(_arrowPrefab, _spawnPoint.position, transform.rotation).Init(parabola);
    }
}
