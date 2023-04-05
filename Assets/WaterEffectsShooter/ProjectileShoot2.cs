using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot2 : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] public AudioSource audioSource1;
    private PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            audioSource1.Play();
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
          
          
        }

        
    }
}
