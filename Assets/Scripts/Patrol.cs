using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _waypoint;

    private float _patrolTime = 1f;
    private Tweener _tween;

    private void Start()
    {
        _tween = transform.DOMove(_waypoint.position, _patrolTime).SetLoops(-1, LoopType.Yoyo);
        _tween.SetEase(Ease.Linear);
    }
}
