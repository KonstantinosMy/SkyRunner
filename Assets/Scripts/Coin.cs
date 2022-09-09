using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour {

    [SerializeField] float turnSpeed = 90f;

    public AudioSource audioSource;
    public AudioClip coinSound;
    public Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore();

       // Play coin sound
        audioSource.PlayOneShot(coinSound);
        rend.enabled = false;
        Destroy(gameObject, coinSound.length);
        // Destroy this coin object
        //Destroy(gameObject);
    }


}