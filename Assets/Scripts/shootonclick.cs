using UnityEngine;
using System.Collections;

public class shootonclick : MonoBehaviour {

	public Rigidbody laserBolt;
	public GameObject ship;

	public float delay = 1.0f;
	public float timer = 0.0f;
	public bool canFire = true;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && canFire){
			GetComponent<PhotonView>().RPC("ShootLaser", PhotonTargets.All);
		}
	}

	[RPC]
	void ShootLaser(){
		Rigidbody laserClone;
		laserClone = Instantiate(laserBolt,transform.position,transform.rotation) as Rigidbody;
		//laserClone.velocity = ship.rigidbody.velocity;
		laserClone.velocity = transform.TransformDirection(Vector3.down * speed);
		canFire = false;
		StartCoroutine(startDelay());
	}

	private IEnumerator startDelay(){

		yield return new WaitForSeconds(0.1f);
		canFire = true;
	}	
}
