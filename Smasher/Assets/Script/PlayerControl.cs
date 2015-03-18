using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
	public List<Transform> Platform;


	Bounds _bounds;
	Transform lastPlatform;

	List<Transform> platforms = new List<Transform>();
	List<Transform> balls = new List<Transform>();
	int waitCount = 0;
	// Use this for initialization
	void Start () {
		for(int i = 0;i < 10; i++){

			Transform platform = (Transform)Instantiate(Platform[Random.Range(0,Platform.Count)]);

			if(i > 0){
				Bounds prevbounds = platforms[i - 1].FindChild("Surface").GetComponent<MeshRenderer>().bounds;
				Bounds bounds = platform.FindChild("Surface").GetComponent<MeshRenderer>().bounds;

				platform.transform.position = platforms[i - 1].position + new Vector3(0,0,bounds.extents.z + prevbounds.extents.z); 

				_bounds = bounds;
			}else{
				platform.transform.position = Vector3.zero;
			}

			//lastPlatform = platform;

			platforms.Add(platform);
		}
	}

	void FixedUpdate(){
		for(int i = 0;i < platforms.Count; i++){
			if(platforms[i].position.z < transform.position.z - _bounds.extents.z){
				Destroy(platforms[i].gameObject);
				platforms.RemoveAt(i);
				
				
				
				Transform platform = (Transform)Instantiate(Platform[Random.Range(0,Platform.Count)]);
				
				Bounds prevbounds = platforms[platforms.Count - 1].FindChild("Surface").GetComponent<MeshRenderer>().bounds;
				Bounds bounds = platform.FindChild("Surface").GetComponent<MeshRenderer>().bounds;
				
				platform.transform.position = platforms[platforms.Count - 1].position + new Vector3(0,0,bounds.extents.z + prevbounds.extents.z); 
				
				_bounds = bounds;
				
				platforms.Add(platform);
				
				break;
				//platforms[i].position = lastPlatform.position + new Vector3(0,0,_bounds.extents.z * 2);
				//lastPlatform = platforms[i];
			}
		}

		for(int i = 0;i < balls.Count; i++){
			if(!balls[i]){
				balls.RemoveAt(i);
				break;
			}
			if(balls[i].position.z < transform.position.z - 0){
				Destroy(balls[i].gameObject);
				balls.RemoveAt(i);
				break;
			}
		}

		transform.position += transform.forward * .3f;
	}

}
