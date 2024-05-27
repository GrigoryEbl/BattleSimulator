using UnityEngine;

public class CameraInput : MonoBehaviour
{
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    [SerializeField] private Joystick _joystick;

    public Vector3 MoveInput { get; private set; }

    private void Update()
    {
        if (_joystick != null)
        {
            MoveInput = Vector3.right * _joystick.Horizontal + Vector3.forward * _joystick.Vertical;

            if (MoveInput != Vector3.zero)
                return;
        }

        MoveInput = Vector3.right * Input.GetAxis(_horizontal) + Vector3.forward * Input.GetAxis(_vertical);
    }
}