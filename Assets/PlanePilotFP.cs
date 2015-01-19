using UnityEngine;
using System.Collections;

public class PlanePilotFP : MonoBehaviour {
	public float speed = 90.0f;
	// Use this for initialization
	void Start () {
		Debug.Log ("plane pilot script added to: " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		//SETS THE CAMERA TO FOLLOW SMOOTHLY AFTER THE PLANE
		/*
		Vector3 moveCamTo = this.transform.position - this.transform.forward * 10.0f + Vector3.up * 5.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f-bias);
		Camera.main.transform.LookAt (this.transform.position + this.transform.forward * 30.0f);
		*/

		//CHANGES THE SPEED DEPENDING ON WHETHER PLANE IS FACING UP OR DOWN
		this.transform.position += this.transform.forward * Time.deltaTime * speed;
		speed -= transform.forward.y * Time.deltaTime * 50.0f;
		if (speed < 35) {
			speed=35.0f;
		}

		//ROTATES THE PLANE BASED ON THE CONTROLS
		this.transform.Rotate (Input.GetAxis ("Vertical") - Input.GetAxis("RightV"),  Input.GetAxis("Horizontal"), -Input.GetAxis ("RightH"));

		//COMPARES OBJECTS HEIGHT TO TERRAIN HEIGHT TO GENERATE COLLISION WITH ENVIRONMENT
		/*
		float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight (transform.position);
		if (terrainHeightWhereWeAre > transform.position.y) {
			transform.position = new Vector3(transform.position.x,
			                                terrainHeightWhereWeAre,
			                                transform.position.z);
		}
		*/
	}
}
