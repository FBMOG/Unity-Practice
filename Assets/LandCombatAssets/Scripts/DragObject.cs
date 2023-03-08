using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 1; // Bring sprite to the front
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        transform.position = newPosition;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 0; // Send sprite to the back

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<SpriteRenderer>().bounds.size, 0f);

        bool isColliding = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject.CompareTag(tag))
            {
                Destroy(gameObject);
                isColliding = true;
                break;
            }
        }

        if (!isColliding)
        {
            transform.position = originalPosition;
        }
    }
}
