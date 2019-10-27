using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] 
    private Camera mainCamera;
    
    [SerializeField]
    private int currentLight;

    [SerializeField]
    private FlashlightContainer[] flashLights;
    
    private Vector3 _mousePos;
    private bool _flashEnabled = true;

    private void Start()
    {
        flashLights[currentLight].flashLightObject.SetActive(true);
        UIController.Instance.UpdateFlashLightImage(flashLights[currentLight].data.icon);
    }

    private void Update()
    {
        _mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        transform.up = (_mousePos - transform.position).normalized;

        if (Input.GetKeyDown(KeyCode.L))
        {
            _flashEnabled = !_flashEnabled;
            if (_flashEnabled)
            {
                flashLights[currentLight].flashLightObject.SetActive(true);
            }
            else
            {
                flashLights[currentLight].flashLightObject.SetActive(false);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeLigth(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeLigth(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeLigth(2);
    }

    public void ChangeLigth(int light)
    {
        if (light < 0 || light >= flashLights.Length)
            return;
        
        flashLights[currentLight].flashLightObject.SetActive(false);
        currentLight = light;
        if (_flashEnabled)
            flashLights[currentLight].flashLightObject.SetActive(true);
        
        UIController.Instance.UpdateFlashLightImage(flashLights[currentLight].data.icon);
    }
}