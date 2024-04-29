using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    private List<Rigidbody> _rigidbodies;
    
    private void Awake()
    {
        _rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>()); 
        Disable();
    }

    public void Hit(Vector3 force, Vector3 hitPosition)
    {
        Rigidbody strickedRigidbody = _rigidbodies.OrderBy(rigidbody => Vector3.Distance(rigidbody.position, hitPosition)).First();

        strickedRigidbody.AddForceAtPosition(force, hitPosition, ForceMode.Impulse);
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
