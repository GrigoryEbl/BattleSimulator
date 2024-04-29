using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;

internal interface IDamageable
{
    bool IsEnemy { get; }

    void TakeDamage(int damage);
}
