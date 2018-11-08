using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour {

	public CharacterMove Player;

	public bool isFollowing;


	// Camera position offset
	public float xOffset;
	public float yOffset;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<CharacterMove>();

		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing){
			xOffset = Player.GetComponent<Rigidbody2D>().velocity.x / 1;
			yOffset = Player.GetComponent<Rigidbody2D>().velocity.y / 1;
			transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);	
			Debug.Log(xOffset);	
		}
	}
}
