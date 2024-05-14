using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UnitSelectButton : MonoBehaviour
{
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private Spawner _spawner;

    private Button _button;    

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetUnit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetUnit);
    }

    private void SetUnit()
    {
        _spawner.SelectUnit(_unitPrefab);
    }
}