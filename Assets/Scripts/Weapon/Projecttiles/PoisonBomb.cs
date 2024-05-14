using UnityEngine;

public class PoisonBomb : Weapon
{
    private readonly float _delay = 3f;

    [SerializeField] private PoisonField _poisonFieldPrefab;

    private void OnEnable()
    {
        Invoke(nameof(Explode), _delay);
    }

    private void Explode()
    {
        Instantiate(_poisonFieldPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}