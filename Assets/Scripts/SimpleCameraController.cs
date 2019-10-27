using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 _offset;

    private void Start()
    {
        _offset = new Vector3(0,0,-10);
    }

    private void Update()
    {
        transform.position = target.position + _offset;
    }
}
