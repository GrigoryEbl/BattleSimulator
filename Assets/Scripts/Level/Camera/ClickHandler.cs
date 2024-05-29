using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private Button _startButton;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OffHandler);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))        
            SpawnUnit();        
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OffHandler);
    }

    private void SpawnUnit()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.collider.name);

            if (hitInfo.collider.TryGetComponent(out PlayerGround ground))
                _playerSpawner.Spawn(hitInfo.point);
            else if (hitInfo.collider.TryGetComponent(out Unit unit) && !unit.IsEnemy)
                _playerSpawner.RemoveOneUnit(unit);
        }
    }

    private void OffHandler()
    {
        enabled = false;
    }
}