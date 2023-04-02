using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishMovement : MonoBehaviour
{
    public float spawnYMin = 0f; // minimum y position where the fish can spawn
    public float spawnYMax = 4.0f; // maximum y position where the fish can spawn

    private float screenHalfWidth; // half the width of the screen
    private float speed; // speed at which the fish moves horizontally
    private bool moveLeft = false; // flag to determine if the fish should move left or right
    public bool isCaught; // flag to indicate whether the fish has been caught

    private void Start()
    {
        // get the half width of the screen
        float screenHalfHeight = Camera.main.orthographicSize;
        screenHalfWidth = screenHalfHeight * Screen.width / Screen.height;

        // set a random speed for the fish
        speed = Random.Range(1.0f, 3.0f);
    }

    private void Update()
    {
        if (!isCaught)
        {
            // determine the direction in which the fish should move
            Vector2 direction = moveLeft ? Vector2.left : Vector2.right;

            // move the fish horizontally
            transform.Translate(direction * speed * Time.deltaTime);

            // if the fish has gone off the screen, respawn it at a random height and move it again
            if ((moveLeft && transform.position.x < -screenHalfWidth - 3.0f) || (!moveLeft && transform.position.x > screenHalfWidth + 3.0f))
            {
               ResetFish();
            }
        }
    }

    public void ResetFish(){
        moveLeft = Random.value < 0.5f;
        float randomY = Random.Range(spawnYMin, spawnYMax);
        transform.position = new Vector2(moveLeft ? screenHalfWidth + 3.0f : -screenHalfWidth - 3.0f, randomY);

        // set a new random speed for the fish
        speed = Random.Range(1.0f, 3.0f);
        

        // if the fish is moving left, flip its sprite horizontally
        if (moveLeft)
        {
            if(transform.localScale.x > 0){
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
            }
        }
        else
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x);
            transform.localScale = newScale;
        }
    }
}

