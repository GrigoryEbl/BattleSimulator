using UnityEngine;

public interface IMovementSource
{
    public Vector3 MovementInput { get; }
    public float Speed { get; }
}