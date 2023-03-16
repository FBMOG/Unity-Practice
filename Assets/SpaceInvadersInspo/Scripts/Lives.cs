using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour

{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public Canvas retryScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Waste")
        {
            Destroy(collision.collider.gameObject);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives-=1;

            for(int i = 0; i < livesUI.Length; i++){

                if(i < lives){
                    livesUI[i].enabled = true;
                }

                else{
                    livesUI[i].enabled = false;
                }
            }

            if(lives <= 0){

                retryScreen.gameObject.SetActive(true);
                Destroy(gameObject);

            }
        }
    }
}