﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {

	public List<Transform> Platform;
	private float speed= 0.5f;
	public CharacterController player;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 pMov;
	public float jumpSpeed = 1.0f;
	private float gravity = 10f;
	float playerZposition;
	private bool isGrounded;
	private float pSpeed = 12f;

	Bounds _bounds;
	Transform lastPlatform;

	List<Transform> platforms = new List<Transform>();


	void Start () {

		for(int i = 0;i < 20; i++){

			Transform platform = (Transform)Instantiate(Platform[Random.Range(0,Platform.Count)]);

			if(i > 0){
				Bounds prevbounds = platforms[i - 1].FindChild("Surface").GetComponent<MeshRenderer>().bounds;
				Bounds bounds = platform.FindChild("Surface").GetComponent<MeshRenderer>().bounds;

				platform.transform.position = platforms[i - 1].position + new Vector3(0,0,bounds.extents.z + prevbounds.extents.z); 

				_bounds = bounds;
			}else{
				platform.transform.position = Vector3.zero;
			}


			platforms.Add(platform);
		}
	}


	void FixedUpdate(){

		playerZposition = player.transform.position.z;
		player.transform.position += new Vector3 (0, 0, speed);
		pMov = new Vector3 (Input.GetAxis ("Horizontal") * pSpeed , 0, 0);
		
		if (player.isGrounded) {
			player.SimpleMove (pMov);	
			player.GetComponent<Animation>().Play ("run");
			
		}
		
		if (Input.GetButton ("Jump") && player.isGrounded) {
			isGrounded = false;
			player.GetComponent<Animation> ().Stop ("run");
			player.GetComponent<Animation> ().Play ("jump_pose");
			moveDirection.y = jumpSpeed / 3f;
		}
		
		player.Move (moveDirection);
		moveDirection.y -= gravity * .25f * Time.deltaTime;
		
		if (player.isGrounded)
			isGrounded = true;
		//moveDirection.y -= gravity * Time.deltaTime;
 		//player.Move (moveDirection * Time.deltaTime);


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

		transform.position += transform.forward * .5f;
	}
}