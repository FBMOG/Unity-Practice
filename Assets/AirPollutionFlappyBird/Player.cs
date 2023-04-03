using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;
    private Vector3 direction;
     public bool birdIsAlive = true;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _jump, _dead, _scoreAdded, _winner;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
   
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true) {
            _source.PlayOneShot(_jump);
            direction = Vector3.up * strength;
        }

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }



    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            _source.PlayOneShot(_dead);
            FindObjectOfType<GameManager>().GameOver();
            birdIsAlive = false;
        } else if (other.gameObject.CompareTag("Scoring")) {
            _source.PlayOneShot(_scoreAdded);
            FindObjectOfType<GameManager>().IncreaseScore();
        }

        if( FindObjectOfType<GameManager>().PlayerScore() >= 10){
            _source.PlayOneShot(_winner);
            FindObjectOfType<GameManager>().GameWin();
        }
    }

    public void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

}
