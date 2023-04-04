using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{

    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
     private PointManager pointManager;

    public Canvas gameOver;


    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "NonEffect" || collision.collider.gameObject.tag == "Effect")
        {
            Destroy(collision.collider.gameObject);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives = lives -1;
            for(int i = 0; i < livesUI.Length; i++){

                if(i < lives){
                    livesUI[i].enabled = true;
                }

                else{
                    livesUI[i].enabled = false;
                }
            }

            if(lives<=0){
                Destroy(gameObject); 
                pointManager.GameOver();
                gameOver.gameObject.SetActive(true);
               
            }
            

        }

        if(collision.collider.gameObject.tag =="LastEnemy" || collision.gameObject.tag == "LastEnemy")
        {
                Destroy(gameObject);
                pointManager.GameOver();
                gameOver.gameObject.SetActive(true);
                

        }


        // if(collision.collider.gameObject.tag == "NonEffect" ||collision.collider.gameObject.tag == "LastNonEffect" )
        // {
        //     Destroy(collision.collider.gameObject);
        // }

        // if(collision.collider.gameObject.tag == "LastNonEffect"){

        // }

    }
    
}
