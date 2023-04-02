using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed = 10f; // Adjust speed as needed
    private float minX, maxX;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip move;

    private IEnumerator playAudioCoroutine; // Store the coroutine reference here

    // Start is called before the first frame update
    void Start()
    {
        // Get screen bounds
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float boatWidth = GetComponent<Renderer>().bounds.size.x / 2f;
        minX = -screenBounds.x + boatWidth;
        maxX = screenBounds.x - boatWidth;

        // Start the coroutine to play the audio clip
        playAudioCoroutine = PlayAudio();
        StartCoroutine(playAudioCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the boat left and right using arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);

        // Keep the boat within the screen bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }

    // Coroutine to play the audio clip once per second
    private IEnumerator PlayAudio()
    {
        while (true) // Repeat the loop indefinitely
        {
            _source.PlayOneShot(move); // Play the audio clip
            yield return new WaitForSeconds(2f); // Wait for 1 second before playing again
        }
    }

    // Stop the coroutine when the object is destroyed
    private void OnDestroy()
    {
        StopCoroutine(playAudioCoroutine);
    }
}
