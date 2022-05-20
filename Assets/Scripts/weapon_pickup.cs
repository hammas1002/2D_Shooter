using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_pickup : MonoBehaviour
{
    public weapon weaponToEquip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            collision.GetComponent<player>().changeWeapon(weaponToEquip);
            Destroy(this.gameObject);
        }
    }
}
