using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _x;

    private float _speed;
    private Vector3 _targetPosition;
    private bool _isPeek = false;
    private Transform _transform;
    private float _distance;
    private void Awake()
    {
        _transform = transform;
    }

    public void Init(Transform target, float speed)
    {
        _speed = speed;
        _targetPosition = target.position;

        _distance = Vector3.Distance(transform.position, _targetPosition);
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (_transform.position.y >= 5f)
            _isPeek = true;

        if (_isPeek)
            _x -= 0.05f;
        else
            _x += 0.05f;

        _transform.localPosition = new Vector3(_x, Mathf.Pow(_x, 2), 0);
    }
}
