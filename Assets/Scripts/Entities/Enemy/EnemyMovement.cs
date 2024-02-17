using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class EnemyMovement : MonoBehaviour
{
    [Tooltip("Transform representing the target.\nDefaults to the players' transform.")]
    [field: SerializeField] Transform _pTransform;
    internal bool Agro => _agro;
    Vector2 _dir = Vector2.zero;
    EntityStats _stats;
    float _dot;
    bool _agro = false;
    internal float Dot
    {
        get { return _dot; }
        private set { _dot = value; }
    }
    [Tooltip("Represents the distance the enemy can see the target.")]
    [field: SerializeField] float _visibleDistance = 25;

    // Start is called before the first frame update
    void Start()
    {
        if(_pTransform == null)
            _pTransform = GameManager.GameManagerInstance.PlayerTransform;

        _stats = gameObject.GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up * _visibleDistance, Color.green);
        RotateToTarget();
        MoveToTarget();
    }

    private void RotateToTarget()
    {
        _dir = _pTransform.position - transform.position;
        _dot = Vector2.Dot(transform.up, _dir.normalized);
        float angle = Vector2.Angle(transform.up, _dir * _stats.RotationSpeed);
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
        if (_dot > 0.38f && Vector2.Distance(transform.position, _pTransform.position) < _visibleDistance && Vector2.Distance(transform.position, _pTransform.position) > 1f)
        {
            _agro = _dot >= 0.91;
            transform.position = Vector2.MoveTowards(transform.position, _pTransform.position, Time.deltaTime * _stats.MovementSpeed * Time.deltaTime);
        }
    }
}
