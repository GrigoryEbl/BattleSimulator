using UnityEngine;

public abstract class Bomb : Projectile
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
            Explode();
    }

    protected abstract void Explode();
}