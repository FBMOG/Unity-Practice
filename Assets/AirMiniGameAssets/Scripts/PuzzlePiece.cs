using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector2 originalPostion;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickupClip, _dropClip;
    [SerializeField] private SpriteRenderer _renderer;

    private PuzzleSlot _currentSlot;
    private bool placed;
    
    public void Init(PuzzleSlot slot){
        _renderer.sprite = slot.Renderer.sprite;
        _currentSlot = slot;
    }

    void Awake() {
        originalPostion = transform.position;
    }

    void OnMouseDown()
    {
        if (placed == true){
            return;
        }
        _source.PlayOneShot(_pickupClip);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        curPosition += (Vector2)offset;
        transform.position = curPosition;
    }
    
    void  OnMouseUp() {

        if(Vector2.Distance(transform.position, _currentSlot.transform.position) < 3)
        {
            transform.position = _currentSlot.transform.position;
            _currentSlot.Placed();
            placed = true;
        }
        else
        {
            transform.position = originalPostion;
        }
            
        
    }

    public bool IsInCorrectSlot {
        get {
            return _currentSlot != null && _currentSlot.transform.position == transform.position;
        }
    }
}
