using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int _damage = 3;
    [SerializeField] private float _delay = 0.5f;

    private float _delayCounter;

    private void Update()
    {
        if (_delayCounter > 0)        
            _delayCounter -= Time.deltaTime;        

    }

    private void OnTriggerStay(Collider other)
    {
        if (_delayCounter > 0)
            return;

        if (other.TryGetComponent(out IDamageable unit))
        {
            _delayCounter = _delay;
            unit.TakeDamage(_damage);
        }
    }
}