using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParabolaController))]
public abstract class Projectile : MonoBehaviour
{
    public abstract void Init(Transform path);
}
