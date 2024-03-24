using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;
using Cinemachine;

public class InputControl : MonoBehaviour
{

    public bool IsRotating=false;
    public bool RotationActivated=true;


    [SerializeField] private float fieldOfViewMin = 20f;
    [SerializeField] private float fieldOfViewMax = 80f;
    public CinemachineVirtualCamera _vCam;
   

    float _fov = 60f;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !IsRotating && RotationActivated)
        {
            IsRotating = true;
            float targetRotation = transform.eulerAngles.y - 90f;
            //CamRot();
            StartCoroutine(SmoothRotateL(targetRotation));


        } else if (Input.GetMouseButtonDown(1) && !IsRotating && RotationActivated) 
        {
            IsRotating = true;
            float targetRotation = transform.eulerAngles.y + 90f;
            StartCoroutine(SmoothRotateR(targetRotation));
        }
        
        CamZoom();

    }

    private void CamZoom() 
    {
        if (Input.mouseScrollDelta.y < 0 && _fov < fieldOfViewMax)
        {
            //targetFieldOfView += 5f;
            _fov += 5f;

        }

        if (Input.mouseScrollDelta.y > 0 && _fov > fieldOfViewMin)
        {
            //targetFieldOfView -= 5f;
            _fov -= 5f;

        }

        _vCam.m_Lens.FieldOfView = Mathf.Lerp(_vCam.m_Lens.FieldOfView, _fov, Time.deltaTime * 1f);
    }


    IEnumerator SmoothRotateR(float targetRotation)
    {
        
        float currentRotation = transform.eulerAngles.y;

        while (currentRotation < targetRotation)
        {
            float rotationAmount = 90f * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
            currentRotation += rotationAmount;

            yield return null;
        }
        
        // Ensure the exact target rotation is reached
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotation, transform.eulerAngles.z);
        IsRotating = false;
    }
    IEnumerator SmoothRotateL(float targetRotation)
    {

        float currentRotation = transform.eulerAngles.y;

        while (currentRotation > targetRotation)
        {
            float rotationAmount = 90f * Time.deltaTime;
            transform.Rotate(Vector3.up, -rotationAmount);
            currentRotation -= rotationAmount;

            yield return null;
        }

        // Ensure the exact target rotation is reached
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotation, transform.eulerAngles.z);
        IsRotating = false;
    }
}
