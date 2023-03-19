using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Grapple : MonoBehaviour
{
    public GameObject grapplePrefab;   // The game object to be shot
    public float speed;
    public float hSpeed;
    public GameObject boat;                // The speed at which the grapple moves

    private GameObject grapple;        // The instantiated grapple game object
    private Vector3 startPosition;     // The start position of the grapple
    private bool isShooting, isRetracting;           // Whether the grapple is shooting or retracting
    private LineRenderer lineRenderer; // The line renderer component of the grapple

    private Vector3[] linePositions;   // The positions of the line renderer

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
        
    }

    void ShootGrapple()
    {
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

}



