using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;

internal interface IDamageable
{
    void TakeDamage(Vector3 force, Vector3 hitpoint);
}
