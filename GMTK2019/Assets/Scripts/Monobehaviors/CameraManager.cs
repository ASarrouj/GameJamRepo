using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private bool interpolating;
    private Vector3 originalPos, targetPos;
    private float transitionTime, originalOrthoSize, targetOrthoSize;
    private const float transitionMaxTime = 0.2f;
    private const float DT = 0.005f;
    private Camera CameraComponent;

    // Start is called before the first frame update
    void Start()
    {
        transitionTime = 0.0f;
        interpolating = false;
        originalPos = transform.position;
        targetPos = new Vector3(8f, 0, -10f);
        CameraComponent = GetComponent<Camera>();
        originalOrthoSize = CameraComponent.orthographicSize;
        targetOrthoSize = 8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (interpolating)
            InterpolateCamera();
    }

    public void BeginInterpolation()
    {
        interpolating = true;
    }

    private void InterpolateCamera()
    {
        transform.position = Vector3.Lerp(originalPos, targetPos, ComputeArcLengthFromTime(transitionTime));
        CameraComponent.orthographicSize = Mathf.Lerp(originalOrthoSize, targetOrthoSize, ComputeArcLengthFromTime(transitionTime));

        if (transitionTime >= transitionMaxTime)
        {
            interpolating = false;
        }

        transitionTime += DT;
    }

    private float ComputeArcLengthFromTime(float time)
    {
        float normalizedTime = time / transitionMaxTime;
        return -2 * (float)Math.Pow(normalizedTime, 3) + 3 * (float)Math.Pow(normalizedTime, 2);
    }
}
