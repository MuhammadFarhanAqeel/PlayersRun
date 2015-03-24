using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject Obstacle;
	public GameObject powerup;
	public GameObject Player;

	float timeElapsed = 0;
	public float spawnCycle=0.5f;
	bool spawnPowerUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeElapsed += Time.deltaTime;
		Vector3 pos = Player.transform.position;

		if (timeElapsed > spawnCycle) {
			GameObject temp;
			if(spawnPowerUp){
				temp = (GameObject)Instantiate(powerup);
				temp.transform.position = new Vector3( Random.Range(-6.4f,6.1f),pos.y ,pos.z + Random.Range(140,150));
			}
				else{
					temp = (GameObject)Instantiate(Obstacle);
				temp.transform.position = new Vector3( Random.Range(-6.4f,6.1f),pos.y ,pos.z + Random.Range(140,150));
			}
			timeElapsed -= spawnCycle;
			spawnPowerUp =! spawnPowerUp;
			}
		}
}