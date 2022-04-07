using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletChargedPrefab;

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void SpecialPower()
    {
        
        Instantiate(bulletChargedPrefab, new Vector3(firePoint.position.x - 1,firePoint.position.y,firePoint.position.z), bulletChargedPrefab.transform.rotation);

    }
}
