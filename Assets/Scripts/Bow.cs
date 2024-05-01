using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private float _force;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _speed;

    public void Shoot(Transform target)
    {
        Instantiate(_arrowPrefab, _spawnPoint.position, transform.rotation).Init(target, _speed);
    }
}
