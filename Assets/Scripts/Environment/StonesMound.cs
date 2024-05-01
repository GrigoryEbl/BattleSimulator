using UnityEngine;

public class StonesMound : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out FellHandler unit))
            unit.StartFell();
    }
}