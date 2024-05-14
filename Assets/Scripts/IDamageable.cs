internal interface IDamageable
{
    public void TakeDamage(int damage);

    public int Health { get; }
    public bool IsEnemy { get; }
}
