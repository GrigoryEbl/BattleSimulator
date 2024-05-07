using UnityEngine;

public class Musketeer : Unit
{
    [SerializeField] private Musket _musket;

    private void Start()
    {
        _musket.SetBattleSide(IsEnemy);
    }

    private void Shoot()
    {
        _musket.RaycastShoot();
    }
}