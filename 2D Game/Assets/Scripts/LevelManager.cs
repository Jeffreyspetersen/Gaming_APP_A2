using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D Flaco;

	//Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	//Respawn Delay
	public float RespawnDelay;

	//Point Pentalty on Death
	public int PointPenaltyOnDeath;

	//Sotre Gravity Value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		//Flaco = FindObjectOfType<Rigidbody2D> ();
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo(){
		//Generate Death Particle
		Instantiate (DeathParticle, Flaco.transform.position, Flaco.transform.rotation);
		//Hide Flaco
		//Flaco.enabled = false;
		Flaco.GetComponent<Renderer> ().enabled = false;
		//Gravity Reset
		GravityStore = Flaco.GetComponent<Rigidbody2D>().gravityScale;
		Flaco.GetComponent<Rigidbody2D>().gravityScale = 0f;
		Flaco.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//PointPenalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug Message
		Debug.Log ("Flaco LIVES");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		Flaco.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match Flaco's transform position
		Flaco.transform.position = CurrentCheckPoint.transform.position;
		//Show Flaco
		//Flaco.enabled = true;
		Flaco.GetComponent<Renderer> ().enabled = true;
		//Spawn Flaco
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}