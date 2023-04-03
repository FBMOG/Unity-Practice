using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public float speed = 10f; // Speed of the grappling hook
    public float maxDistance = 10f; // Maximum distance the grappling hook can travel
    public float retractSpeed = 10f; // Speed of the retracting grappling hook
    public LineRenderer lineRenderer; // Line renderer to draw a line from the boat to the grappling hook
    public Transform boatTransform; // Transform of the boat

    private Vector3 targetPosition; // Position the grappling hook is targeting
    private bool isAttached = false; // Whether the grappling hook is attached to something

    private Vector3 initialPosition; // Initial position of the grappling hook

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the line renderer
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, boatTransform.position);
        lineRenderer.SetPosition(1, transform.position);

        // Save the initial position of the grappling hook
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttached)
        {
            Shoot();
        }

        if (isAttached)
        {
            Retract();
        }
        else
        {
            Move();
        }
    }

    // Shoot the grappling hook
    void Shoot()
    {
        // Calculate the target position based on the position of the grappling hook
        targetPosition = transform.position + Vector3.down * maxDistance;

        // Shoot the grappling hook
        LeanTween.move(gameObject, targetPosition, maxDistance / speed).setOnComplete(() => isAttached = false);
    }

    // Move the grappling hook towards the target position
    void Move()
    {
        transform.position += (targetPosition - transform.position).normalized * speed * Time.deltaTime;

        // Retract if the grappling hook reaches the bottom of the screen
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            Retract();
        }

        // Update the line renderer to draw a line from the boat to the grappling hook
        lineRenderer.SetPosition(0, boatTransform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    // Retract the grappling hook
    void Retract()
    {
        // Retract the grappling hook
        LeanTween.move(gameObject, initialPosition, Vector3.Distance(transform.position, initialPosition) / retractSpeed).setOnComplete(() =>
        {
            // Detach from the attached object
            if (isAttached)
            {
                isAttached = false;
                // Do something here to remove the attached object from the scene or whatever
            }
        });
    }

    // Attach the grappling hook to a colliding object
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Creature") || collision.CompareTag("Trash"))
        {
            // Attach the grappling hook to the colliding object
            isAttached = true;
            // Do something here to attach the object to the grappling hook or whatever
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.CompareTag("Trash"))
        {
            collision.gameObject.transform.position = transform.position;
        }
    }
}

