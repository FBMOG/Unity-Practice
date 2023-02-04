using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset, originalPostion;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickupClip, _dropClip;
    [SerializeField] private SpriteRenderer _renderer;

    private PuzzleSlot slot;

    public void Init(PuzzleSlot slot){
        _renderer.sprite = slot.Renderer.sprite;
        this.slot = slot;
    }

    void Awake() {
        originalPostion = transform.position;
    }

    void OnMouseDown()
    {
        _source.PlayOneShot(_pickupClip);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
    
    void  OnMouseUp() {
        transform.position = originalPostion;
    }
}
