using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField] private float _decelerationFactor = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BotInput botInput))
            botInput.DivideSpeed(_decelerationFactor);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BotInput botInput))
            botInput.ResetSpeed();
    }
}