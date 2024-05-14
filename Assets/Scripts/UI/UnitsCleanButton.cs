using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UnitsCleanButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_spawner.Clean);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_spawner.Clean);
    }
}