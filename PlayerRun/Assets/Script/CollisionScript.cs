using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("dasdasdas");
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "powerup") {
			Debug.Log("powerup collected");
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "obstacle") {
			Destroy(other.gameObject);
			Debug.Log("Obstacle Collected");
		}
		if (other.gameObject.name == "Surface") {
			Debug.Log("Bhand detected");
		}
	}

}
