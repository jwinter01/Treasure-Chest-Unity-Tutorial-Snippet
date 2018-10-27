/*
  
Jonathan Winter

This is a snippet of Unity Project I was working on over the Summer.
The code was developed during a tutorial sponsored by Unity called
Swords and Shovels that I followed and paid for. 

The link to the site for anyone that is interested:
https://unity3d.com/swordsandshovels 

This script is used for a Treasure Chest which searches for a player within
a set proximity. Once the player is within the proximity, a coin can be
spawned for the player everytime the player presses the "Use Key" (Spacebar)

 
 */




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For TreasureChest object in-game
// Make sure the class name TreasureChest matches
// the TreasureChest name in Unity otherwise the
// code will not work
public class TreasureChest : MonoBehaviour
{
    // Keep interactable false by default
    public bool interactable = false;
    private Animator anim;

    // Physics engine to shoot out of chest
    // and bounce on the ground
    public Rigidbody coinPrefab;
    public Transform spawner;


	// Use this for initialization of script
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the player is within the proximity and the player presses the spacebar
		if(interactable == true && Input.GetKeyDown(KeyCode.Space))
        {
            // This animation opens the chest which was provided by the tutorial
            anim.SetBool("openChest", true);

            // Spawns the coin
            Rigidbody coinInstance;
            coinInstance = Instantiate(coinPrefab, spawner.position, spawner.rotation) as Rigidbody;
            coinInstance.AddForce(spawner.up * 100);
        }
	}

/*
    While the player is on the object (loops):
    void OnTriggerStay(Collider other)
*/

// When the player touches it (once)
void OnTriggerEnter(Collider other)
    {

        // Check to see if the collider is Player
        if(other.gameObject.tag == "Player")
        {
            print("Hey! The interactable is now true!");
            interactable = true;
        }
    }

    // If an object exits the trigger
    void OnTriggerExit(Collider other)
    {
        // Check to see if Collider is player
        if(other.gameObject.tag == "Player")
        {
            print("Hey! The interactable is now false!");
            interactable = false;
        }
    }
}
