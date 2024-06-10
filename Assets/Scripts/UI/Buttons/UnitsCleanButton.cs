using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UnitsCleanButton : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_playerSpawner.Clean);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_playerSpawner.Clean);
    }
}