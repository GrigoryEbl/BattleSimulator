using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class PlayerAnimatorController : MonoBehaviour
{
    private AnimatorController _animatorController;

    private void Awake()
    {
        _animatorController = GetComponent<AnimatorController>();
    }

    public void SetState(bool isMoving)
    {
        if (isMoving)
            _animatorController.SetState(UnitAnimatorStates.run);
        else
            _animatorController.SetState(UnitAnimatorStates.idle);

    }
}