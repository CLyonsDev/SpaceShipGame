using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

	public float dmg = 25.0f;
	
	void Start () {
		StartCoroutine(destroyaftertime());
	}

	void OnCollisionEnter(Collision collision){
		Destroy(gameObject);
		Debug.Log("hit!");

		collider.SendMessageUpwards("Damage",dmg,SendMessageOptions.DontRequireReceiver);
	}

	IEnumerator destroyaftertime(){
		yield return null;
		yield return new WaitForSeconds(10);
		Destroy(gameObject);
	}
}

