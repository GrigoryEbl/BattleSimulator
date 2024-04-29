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

    public void Hit(Vector3 force, Vector3 hitposition)
    {
        Rigidbody strickedRigidbody = _rigidbodies.OrderBy(rigidbody => Vector3.Distance(rigidbody.position, hitposition)).First();

        strickedRigidbody.AddForceAtPosition(force, hitposition, ForceMode.Impulse);
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
