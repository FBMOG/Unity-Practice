using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject explosionPrefab;

    private PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Effect")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.updateScore(50);
            pointManager.updateCorrect(1);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "NonEffect" )
        {
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(collision.gameObject);
            pointManager.updateWrong(1);
            Destroy(gameObject);
        }

        // if(collision.gameObject.tag == "LastEffect"){
        //     Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //     Destroy(collision.gameObject);
        //     pointManager.updateScore(50);
        //     pointManager.updateCorrect(1);
        //     pointManager.GameOver();
        // }
        

        if(collision.gameObject.tag == "ProjectileBoundary")
        {
            Destroy(gameObject);
        }

    }
}
