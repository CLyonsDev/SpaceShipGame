using UnityEngine;
using System.Collections;

public class shootonclick : MonoBehaviour {

	public Rigidbody laserBolt;

	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Rigidbody laserClone;
			laserClone = Instantiate(laserBolt,transform.position,transform.rotation) as Rigidbody;
			laserClone.velocity = transform.TransformDirection(Vector3.down * speed);
		}
		//Debug.Log("hue");
		//laserBolt.rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,speed*Time.deltaTime));
		//laserClone.rigidbody.AddRelativeForce(0,0,speed*Time.deltaTime);
	}
}
