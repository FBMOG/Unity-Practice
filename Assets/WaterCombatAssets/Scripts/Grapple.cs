using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Grapple : MonoBehaviour
{
    public GameObject grapplePrefab;   // The game object to be shot
    public float speed;
    public float hSpeed;
    public GameObject boat;               // The speed at which the grapple moves
    public TMP_Text counter;
    public float timeRemaining = 60f; // Initial time value
    public TMP_Text timeText; // Reference to the Text component
    public Canvas endOfLevelCanvas;
    public Canvas retry;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip shoot;

    private GameObject grapple;        // The instantiated grapple game object
    private Vector3 startPosition;     // The start position of the grapple
    private bool isShooting, isRetracting;           // Whether the grapple is shooting or retracting
    private LineRenderer lineRenderer; // The line renderer component of the grapple

    private Vector3[] linePositions;   // The positions of the line renderer
    private int FishCounter = 10;

    void Awake() {
        grapple = Instantiate(grapplePrefab, transform.position, Quaternion.identity);
        grapple.transform.Rotate(180f, 180f, 0f);
        grapple.transform.SetParent(boat.transform);
        lineRenderer = grapple.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.material.color = Color.black;

        startPosition = boat.transform.position;
        counter.text = "Fishes Remaining: " + FishCounter;
        timeText.text = "Time: " + timeRemaining;
    }

    void Update()
    {
        startPosition = boat.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isShooting == false)
            {
                ShootGrapple();
            }
            else
            {
                RetractGrapple();
            }
        }

        if (isShooting)
        {
            MoveGrapple();
        }
        if(isRetracting){
            MoveBackGrapple();
        }

        timeRemaining -= Time.deltaTime; // Subtract the time passed since the last frame

        if (timeRemaining < 0) // Stop the countdown when time runs out
        {
            timeRemaining = 0;
            retry.gameObject.SetActive(true);
        }

        int seconds = Mathf.RoundToInt(timeRemaining); // Convert the remaining time to an integer
        counter.text = "Fishes Remaining: " + FishCounter;
        timeText.text = "Time: " + seconds.ToString(); // Update the Text component's val
        
    }

    void ShootGrapple()
    {
        _source.PlayOneShot(shoot);
        isShooting = true;
        linePositions = new Vector3[2] {startPosition, grapple.transform.position};
        lineRenderer.SetPositions(linePositions);
    }

    void MoveGrapple()
    {
        grapple.transform.parent = null;
        Vector3 currentPosition = grapple.transform.position;
        currentPosition.y -= speed * Time.deltaTime;
        grapple.transform.position = currentPosition;
        if(grapple.transform.position.y < 0){
            isShooting = false;
            RetractGrapple();
        }
        else{
            linePositions[0] = startPosition;
            linePositions[1] = grapple.transform.position;
            lineRenderer.SetPositions(linePositions);
        }

        
    }

    void MoveBackGrapple()
    {
        Vector3 currentPosition = grapple.transform.position;
        currentPosition.y += speed * Time.deltaTime;
        if(currentPosition.x < boat.transform.position.x){
            currentPosition.x += hSpeed * Time.deltaTime;
        }
        else{
            currentPosition.x -= hSpeed * Time.deltaTime;
        }
        grapple.transform.position = currentPosition;
        if(grapple.transform.position.y >= startPosition.y){
            isShooting = false;
            isRetracting = false;
            grapple.GetComponent<BoxCollider2D>().enabled = true;
           if (grapple.transform.childCount > 0)
            {
                GameObject childObject = grapple.transform.GetChild(0).gameObject;
                FishMovement fishMovement = childObject.GetComponent<FishMovement>();
                if (childObject.CompareTag("Trash"))
                {
                    FishCounter --;
                    counter.text = "Fishes Remaining: " + FishCounter;
                    if(FishCounter == 0){
                        endOfLevelCanvas.gameObject.SetActive(true);
                    }

                }
                else{
                    timeRemaining -= 5;
                    counter.text = "Fishes Remaining: " + FishCounter;
                    if(timeRemaining <= 0){
                        retry.gameObject.SetActive(true);
                    }
                }
                childObject.transform.SetParent(null);
                fishMovement.isCaught = false;
                fishMovement.GetComponent<BoxCollider2D>().enabled = true;
                fishMovement.ResetFish();
            }

            grapple.transform.SetParent(boat.transform);
        }
        else{
            linePositions[0] = startPosition;
            linePositions[1] = grapple.transform.position;
            lineRenderer.SetPositions(linePositions);
        }

        
    }


   void RetractGrapple()
    {
        isShooting = false;
        isRetracting = true;
    }

    public void ResetGame(){
        timeRemaining = 30;
        FishCounter = 10;
    }

}



