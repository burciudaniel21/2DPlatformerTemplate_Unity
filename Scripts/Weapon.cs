using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 10;

    public void UseWeapon()
    {
        Debug.Log("Weapon used! Dealt " + damage + " damage.");
    }
}
