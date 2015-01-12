using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public string Forward = "Horizontal";
	public string Turn = "Vertical";

	public float forwardSpeed = 1.0f;
	public float maxForwardSpeed = 1.0f;
	
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;
	
	
	
	// Use this for initialization
	void Start () {
		//rigidbody.drag = 0;

	}
	
	// Update is called once per frame
	void Update () {

		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		float v = verticalSpeed * Input.GetAxis("Mouse Y");
		transform.Rotate(-v, h, 0);
		
		if(Input.GetKey(KeyCode.W))
		{
			rigidbody.AddRelativeForce(Vector3.forward*forwardSpeed*Time.deltaTime);
		}
	}
}
