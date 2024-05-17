using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;
using UnityEngine.UIElements;

[RequireComponent(typeof(AnimatorController))]
public class RagdollHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody _mainBone;
    [SerializeField] private Rigidbody _mainRigidbody;
    [SerializeField] private Collider _hitBox;

    private AnimatorController _animatorController;
    private List<Rigidbody> _rigidbodies;
    private FixedJoint _joint;
    private bool _isEnable;

    public bool IsEnable => _isEnable;
    
    private void Awake()
    {
        _animatorController = GetComponent<AnimatorController>();
        _rigidbodies = new List<Rigidbody>(_mainBone.GetComponentsInChildren<Rigidbody>());
    }

    private void Start()
    {
        TurnOn(false);
    }

    public void Hit(Vector3 force, Vector3 position)
    {
        if (!_hitBox.enabled)
            return;

        TurnOn(true);
        _joint = _mainBone.AddComponent<FixedJoint>();
        _joint.connectedBody = _mainRigidbody;
        _mainBone.AddForceAtPosition(force, _mainBone.ClosestPointOnBounds(position), ForceMode.Impulse);
    }

    public void TurnOn(bool value)
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = !value;

        _isEnable = value;
        _animatorController.TurnOnAnimator(!value);

        if (value)
            _hitBox.enabled = !value;
        else
            Destroy(_joint);
    }
}