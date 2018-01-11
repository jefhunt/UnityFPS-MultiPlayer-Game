﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FPSShootingControls : NetworkBehaviour {

    // Use this for initialization

    private Camera mainCam;

    private float fireRate = 15f;
    private float nextTimeToFire = 0f;

    [SerializeField]
    private GameObject concreate_Impact,blood_Impact;

    public float damageAmount = 5f;

	void Start () {
        mainCam = transform.Find("FPS View").Find("FPS Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            RaycastHit hit;

            if(Physics.Raycast(mainCam.transform.position,mainCam.transform.forward,out hit))
            {
                // Instantiate(concreate_Impact, hit.point, Quaternion.LookRotation(hit.normal));
                if (hit.transform.tag == "Enemy")
                {
                    CmdDealDamage(hit.transform.gameObject, hit.point, hit.normal);
                }
                else
                {
                    Instantiate(concreate_Impact, hit.point, Quaternion.LookRotation(hit.normal));
                }

            }
        }
    }
    [Command]
    void CmdDealDamage(GameObject obj,Vector3 pos ,Vector3 rotation)
    {
        obj.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

        Instantiate(blood_Impact, pos, Quaternion.LookRotation(rotation));
    }
}
