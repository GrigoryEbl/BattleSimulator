using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField] private float _decelerationFactor = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BotMovementSource movementSource))
            movementSource.DivideSpeed(_decelerationFactor);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BotMovementSource movementSource))
            movementSource.ResetSpeed();
    }
}