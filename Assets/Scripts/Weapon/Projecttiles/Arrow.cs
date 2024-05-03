using UnityEngine;

[RequireComponent(typeof(ParabolaController))]
public class Arrow : MonoBehaviour
{
    private ParabolaController _parabolaController;

    private void Awake()
    {
        _parabolaController = GetComponent<ParabolaController>();
    }

    public void Init(Transform parabola)
    {
        _parabolaController.ParabolaRoot = parabola.gameObject;
    }
}
