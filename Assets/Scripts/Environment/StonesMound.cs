using UnityEngine;

public class StonesMound : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Unit unit))
            Debug.Log("Падение!");
    }
}