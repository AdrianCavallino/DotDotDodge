using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _minRotSpeed, _maxRotSpeed;
    private float currentRotateSpeed;

    [SerializeField] private float _minRotTime, _maxRotTime;
    private float rotateTime;
    private float currentRotateTime;

    private void Awake() 
    {
        currentRotateTime = 0f;
        currentRotateSpeed = _minRotSpeed + (_maxRotSpeed - _minRotSpeed) * 0.1f * Random.Range(0, 11);
        rotateTime = _minRotTime + (_maxRotTime - _minRotTime) * 0.1f * Random.Range(0, 11);
        currentRotateSpeed *= Random.Range(0,2) == 0 ? 1f : -1f;
    }

    private void Update() 
    {
        currentRotateTime += Time.deltaTime;

        if(currentRotateTime > rotateTime)
        {
            currentRotateTime = 0f;
            currentRotateSpeed = _minRotSpeed + (_maxRotSpeed - _minRotSpeed) * 0.1f * Random.Range(0,11);
            rotateTime = _minRotTime + (_maxRotTime - _minRotTime) * 0.1f * Random.Range(0,11);
            currentRotateSpeed *= Random.Range(0,2) == 0 ? 1f : -1f;
        }
    }

    private void FixedUpdate() 
    {
        transform.Rotate(0,0,currentRotateSpeed * Time.deltaTime);
    }
}
