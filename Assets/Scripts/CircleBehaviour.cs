using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _speed;
    private float _oneWayDuration;
    private bool  _isMovingRight;
    private float _currentTime;
    
   private void Start()
   {
       _oneWayDuration = Vector3.Distance(_startPosition.position, _endPosition.position) / _speed;
   }

   
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMovingRight = !_isMovingRight;
        }

        _currentTime += _isMovingRight ? Time.deltaTime : -Time.deltaTime;
        var progress = Mathf.PingPong(_currentTime, _oneWayDuration) / _oneWayDuration;
        transform.position = Vector3.Lerp(_startPosition.position, _endPosition.position, progress);

    }
}
