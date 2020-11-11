using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;

    private float _patrolTime = 1f;
    private Tweener _tween;

    private void Start()
    {
        _tween = transform.DOMove(_startPos.position, _patrolTime).SetAutoKill(false);
        _tween.SetEase(Ease.Linear);
    }

    private void Update()
    {
        if (_startPos.position == gameObject.transform.position)
        {
            _tween.ChangeEndValue(_endPos.position, true).Restart();
        }
        else if (_endPos.position == gameObject.transform.position)
        {
            _tween.ChangeEndValue(_startPos.position, true).Restart();
        }
    }
}
