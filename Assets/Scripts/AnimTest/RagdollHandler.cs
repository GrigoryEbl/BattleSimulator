using System.Collections.Generic;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody _hips;

    private List<Rigidbody> _rigidbodies;
    
    private void Awake()
    {
        _rigidbodies = new List<Rigidbody>(_hips.GetComponentsInChildren<Rigidbody>()); 
        Disable();
    }

    public void Hit(Vector3 force, Vector3 hitPosition)
    {
        _hips.AddForceAtPosition(force, _hips.ClosestPointOnBounds(hitPosition), ForceMode.Impulse);
    }

    public void Enable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    public void Disable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic =  true;
        }
    }
}
