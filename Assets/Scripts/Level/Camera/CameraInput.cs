using UnityEngine;

public class CameraInput : MonoBehaviour
{
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    [SerializeField] private FloatingJoystick _joystick;

    public Vector3 MoveInput { get; private set; }

    private void Update()
    {
        MoveInput = Vector3.right * _joystick.Horizontal + Vector3.forward * _joystick.Vertical;

        if (MoveInput != Vector3.zero)
            return;

        MoveInput = Vector3.right * Input.GetAxis(_horizontal) + Vector3.forward * Input.GetAxis(_vertical);
    }
}