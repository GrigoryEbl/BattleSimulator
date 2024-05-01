using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stricker : MonoBehaviour
{
    [SerializeField, Range(0, 1000)] private float _force;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                IDamageable damageable = hit.collider.GetComponentInParent<IDamageable>();

                if (damageable != null)
                {
                    Vector3 forceDirection = (hit.point - _camera.transform.position).normalized; 
                    forceDirection.y = 0;

                   // damageable.TakeDamage(forceDirection *_force, hit.point);

                }
            }
        }
    }
}