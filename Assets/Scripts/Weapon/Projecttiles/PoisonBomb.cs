using UnityEngine;

public class PoisonBomb : Bomb
{   
    [SerializeField] private PoisonField _poisonFieldPrefab;

    protected override void Explode()
    {
        Instantiate(_poisonFieldPrefab, transform.position, Quaternion.identity);
        Push();
    }
}