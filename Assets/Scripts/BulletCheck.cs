using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCheck : MonoBehaviour
{
    [SerializeField] private BulletFire ammo;
    [SerializeField] private GameObject shuriken1, shuriken2, shuriken3, shuriken4, shuriken5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
