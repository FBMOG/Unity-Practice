using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public bool shootReady;
    public float shootCD = 1.99f;
    public float shootCDCurrent = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Shooting input

        if(shootCDCurrent >= shootCD){
            shootReady = true;
        }
        
        else{
            shootCDCurrent = shootCDCurrent + Time.deltaTime;
            shootReady = false;
        }

        if(Input.GetButtonDown("Fire1") && shootReady)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            shootCDCurrent = 0.0f;
        }

    }

    
}
