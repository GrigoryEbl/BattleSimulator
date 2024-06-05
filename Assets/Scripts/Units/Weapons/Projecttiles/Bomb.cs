using UnityEngine;

public abstract class Bomb : Projectile
{
    [SerializeField] private AudioSource _audioEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
            Explode();
    }

    protected abstract void Explode();

    protected void PlayExlodeEffcet()
    {
        AudioSource.PlayClipAtPoint(_audioEffect.clip, transform.position);
    }
}