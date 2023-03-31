using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 originalPosition;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickupClip, _dropClip, _errorClip;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        _source.PlayOneShot(_pickupClip);
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
                // _source.PlayOneShot(_dropClip);
                // WaitForOneSecond();
                // Destroy(gameObject);
                // //gameObject.SetActive(false);
                StartCoroutine(WaitAndDestroy(0.5f));
                isColliding = true;
                break;
            }
        }

        if (!isColliding)
        {
            transform.position = originalPosition;
            _source.PlayOneShot(_errorClip);
        }
    }

    private IEnumerator WaitAndDestroy(float waitTime)
    {
        _source.PlayOneShot(_dropClip);
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
