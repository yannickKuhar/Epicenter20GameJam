using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCheck : MonoBehaviour
{
    [SerializeField] private BulletFire ammo = default;
    [SerializeField] private GameObject shuriken1 = default;
    [SerializeField] private GameObject shuriken2 = default;
    [SerializeField] private GameObject shuriken3 = default;
    [SerializeField] private GameObject shuriken4 = default;
    [SerializeField] private GameObject shuriken5 = default;


    void Update()
    {
        
    if (ammo.bulletCount < 5)
        {
            shuriken5.SetActive(false);
            if (ammo.bulletCount < 4)
            {
                shuriken4.SetActive(false);
                if (ammo.bulletCount < 3)
                {
                    shuriken3.SetActive(false);
                    if (ammo.bulletCount < 2)
                    {
                        shuriken2.SetActive(false);
                        if (ammo.bulletCount < 1)
                        {
                            shuriken1.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
