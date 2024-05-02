using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimControlTest : MonoBehaviour
{
    //[SerializeField] private LayerMask _layerMask;
   // [SerializeField] private Transform _parent;
    //[SerializeField] private Transform _hipsBone;

    private Animator _animator;

    private States State
    {
        get { return (States)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //public void AdjustParentPositionToHipsBone()
    //{
    //    Vector3 initHipsPosition = _hipsBone.position;
    //    _parent.position = initHipsPosition;
    //    AdjustParentPositionRevativeGround();
    //    _hipsBone.position = initHipsPosition;
    //}

    //public void AdjustParentPositionRevativeGround()
    //{
    //    if (Physics.Raycast(_parent.position, Vector3.down, out RaycastHit hit, 5, _layerMask)) //магическое число
    //        _parent.position = new Vector3(_parent.position.x, hit.point.y, _parent.position.z);
    //}

    public void SetAttack()
    {
        State = States.attack;
    }
    public void SetRun()
    {
        State = States.run;
    }
    public void SetIdle()
    {
        State = States.idle;
    }

    public void SetUp()
    {
        State = States.gettingUp;
        //transform.rotation = Quaternion.identity;
    }

    public void EnabledAnimator()
    {
        _animator.enabled = true;
    }

    public void DisabledAnimator()
    {
        _animator.enabled = false;
    }
}

public enum States
{
    idle,
    run,
    attack,
    gettingUp
}
