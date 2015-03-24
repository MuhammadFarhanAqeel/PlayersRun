using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {
	public GameControlScript control;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "powerup") {
			control.powerUpCollected();
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "obstacle") {
			control.obstacleCollected();
			Destroy(other.gameObject);
		}
	}
}
