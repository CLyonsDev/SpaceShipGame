using UnityEngine;
using System.Collections;

public class ShipAttributes : MonoBehaviour {

	public float Health = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Health <=0.0f){
			Destroy(gameObject);
		}
	
	}

	void ApplyDamage(float dmg){
		Debug.Log("OUCH!");
		Health -= dmg;
	}
}
