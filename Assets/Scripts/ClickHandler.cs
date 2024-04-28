using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Soldier _unitPrefab;

    private Camera _camera;
    private RaycastHit _raycastHit;

    public Unit Unit { get; private set; }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetInfoGround() == true)
                CreateUnit(_raycastHit);
        }
    }

    private bool GetInfoGround()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            _raycastHit = hitInfo;

            if (hitInfo.collider.TryGetComponent(out Ground ground))
                return true;
        }

        return false;
    }

    private void CreateUnit(RaycastHit hitInfo)
    {
        Unit = Instantiate(_unitPrefab, hitInfo.point, Quaternion.identity);
    }
}