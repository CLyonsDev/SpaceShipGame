using UnityEngine;
using System.Collections;

public class MoveProjFwd : MonoBehaviour {

	
	void Start () {
		StartCoroutine(destroyaftertime());
	}

	void OnCollisionEnter(Collision collision){
		Destroy(gameObject);
		Debug.Log("hit!");
	}

	IEnumerator destroyaftertime(){
		yield return null;
		yield return new WaitForSeconds(10);
		Destroy(gameObject);
	}
}

