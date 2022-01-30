using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FPSShooterTut : MonoBehaviour {

    public Camera cam;
    public GameObject projecile;
    public GameObject muzzle;
    public Transform LHFirePoint, RHFirePoint;
    public float projectileSpeed = 30.0f;
    public float fireRate = 4.0f;
    public float arcRange = 1.0f;

    private Vector3 destination;
    private bool leftHand;
    private float timeToFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);
        if (leftHand)
        {
            leftHand = false;
            InstantiateProjectile(LHFirePoint);
        } 
        else
        {
            leftHand = true;
            InstantiateProjectile(RHFirePoint);
        }
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projecile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectileObj, new Vector3(UnityEngine.Random.Range(-arcRange, arcRange), UnityEngine.Random.Range(-arcRange, arcRange), 0), UnityEngine.Random.Range(0.5f, 2.0f));

        var muzzleObj = Instantiate(muzzle, firePoint.position, Quaternion.identity) as GameObject;
        Destroy(muzzleObj, 2);
    }
}
