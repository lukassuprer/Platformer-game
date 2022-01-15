using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Gun
{
    public string gunName;
    public int gunPrice;
    public bool isUnlocked;
    public int gunMagazine;
    public GameObject objGun; 
    public TextMeshProUGUI textWeapon;
    public Image gunImage;
}
