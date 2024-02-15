using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    Transform _pTransform;
    Vector2 _dir = Vector2.zero;
    Vector2 _lookAxis = Vector2.up;
    EntityStats _stats;
    float _dot;
    [field: SerializeField] float _visibleDistance = 25;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pTransform = GameManager.GameManagerInstance.PlayerTransform;
        _stats = gameObject.GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateToTarget();
        MoveToTarget();
    }

    private void RotateToTarget()
    {
        _dir = _pTransform.position - transform.position;
        _dot = Vector2.Dot(transform.up, _dir.normalized);
        float angle = Vector2.Angle(transform.up, _dir);
        Vector3 rotAxis = Vector3.Cross(transform.up, _dir);

        int cw = 1;

        if( rotAxis.z < 0)
        {
            cw = -1;
        }
        if(_dot > 0.38f && _dot <= 1 && _dir.magnitude < _visibleDistance)
        {
            transform.Rotate(0, 0, angle * cw * _stats.RotationSpeed);
        }
    }

    private void MoveToTarget()
    {
        if (_dot > 0.38f && _dot <= 1 && Vector2.Distance(transform.position, _pTransform.position) < _visibleDistance && Vector2.Distance(transform.position, _pTransform.position) > 1f)
            transform.position = Vector2.MoveTowards(transform.position, _pTransform.position, Time.deltaTime * _stats.MovementSpeed * Time.deltaTime);

    }
}
