using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vrillar;

public class GLight : MonoBehaviour
{
    float _radius = 1000f;
    float _rotationSpeed = 15;
    float _angle;
    public Transform center;
    float time = 0;


    public void Setup()
    {
        this.transform.position = center.transform.position + new Vector3(0, -_radius, 0);
        this.transform.rotation = Quaternion.Euler(-90, 0, 0);
        SetPosSun();
    }

    public void SetPosSun(TimeData data = null)
    {
        if (data != null)
        {
            this.transform.position = center.transform.position + new Vector3(0, -_radius, 0);
            this.transform.rotation = Quaternion.Euler(-90, 0, 0);
            _angle = data.Hour * 15f + data.Minute * 0.25f + data.Second * 0.004f;
            this.transform.RotateAround(center.transform.position, Vector3.right, _angle + Time.deltaTime);
            return;
        }
        _angle = (float)DateTime.Now.Hour * 15f + (float)DateTime.Now.Minute * 0.25f + (float)DateTime.Now.Second * 0.004f;
        this.transform.RotateAround(center.transform.position, Vector3.right, _angle + Time.deltaTime);
    }

    private void Update()
    {
        this.transform.RotateAround(center.transform.position, Vector3.right, 0.00008f);
    }

}
