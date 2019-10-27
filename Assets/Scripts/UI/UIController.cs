﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    private Image flashLightImage;

    [SerializeField]
    private Image weaponImage;

    private void Start()
    {
        Instance = this;
    }

    public void UpdateFlashLightImage(Sprite image)
    {
        flashLightImage.sprite = image;
    }

    public void UpdateWeaponImage(Sprite image)
    {
        weaponImage.sprite = image;
    }
}