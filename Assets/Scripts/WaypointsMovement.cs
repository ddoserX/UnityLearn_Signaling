using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private Transform _pathRoot;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start() 
    {
        _points = new Transform[_pathRoot.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _pathRoot.GetChild(i);
        }
    }

    private void Update() 
    {
        Move();
    }

    private void Move() 
    {
        Transform target = _points[_currentPoint];

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z),
        new Vector3(target.position.x, transform.position.y, target.position.z), _speed * Time.deltaTime);
        //transform.position += new Vector3(direction.x, 0, direction.z) * _speed * Time.deltaTime;

        if (transform.position.x == target.position.x && transform.position.z == target.position.z) 
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length) 
            {
                _points = ArrayReverce(_points);
                _currentPoint = 0;
            }
        }
    }

    private Transform[] ArrayReverce(Transform[] array)
    {
        Transform[] reverceArray = new Transform[array.Length];

        for(int i = 1; i <= array.Length; i++)
        {
            reverceArray[array.Length - i] = array[i - 1];
        }

        return reverceArray;
    }
}
