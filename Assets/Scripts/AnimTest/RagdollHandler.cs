using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody _mainBone;
    [SerializeField] private Rigidbody _mainRigidbody;
    [SerializeField] private Collider _hitBox;
    [SerializeField] private AnimControlTest _animControlTest;

    private List<Rigidbody> _rigidbodies;
    private FixedJoint _joint;
    private bool _isEnable;

    public bool IsEnable => _isEnable;
    
    private void Awake()
    {
        _rigidbodies = new List<Rigidbody>(_mainBone.GetComponentsInChildren<Rigidbody>());
        TurnOn(false);
    }

    public void Hit(Vector3 force, Vector3 hitPosition)
    {
        _joint = _mainBone.gameObject.AddComponent<FixedJoint>();
        _joint.connectedBody = _mainRigidbody;

        TurnOn(true);
        _animControlTest.DisabledAnimator();
        _mainBone.AddForceAtPosition(force, _mainBone.ClosestPointOnBounds(hitPosition), ForceMode.Impulse);
    }

    public void TurnOn(bool value)
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = !value;

        _isEnable = value;

        if (!value)
            Destroy(_joint);

        if (value)
        {
            _hitBox.enabled = !value;
        }
    }

    public void TurnOnMainRigidbody(bool value)
    {
        _mainRigidbody.isKinematic = !value;
        _hitBox.enabled = value;
    }

    private void Test()
    {
        _mainRigidbody.isKinematic = false;
    }
}