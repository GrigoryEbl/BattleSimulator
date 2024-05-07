using UnityEngine;
using UnityEngine.UIElements;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))        
            SpawnUnit();        
    }

    private void SpawnUnit()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out Ground ground))
                _playerSpawner.Spawn(hitInfo.point);
            else if (hitInfo.collider.TryGetComponent(out Unit unit))
                _playerSpawner.RemoveOneUnit(unit);
        }
    }
}