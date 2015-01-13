using UnityEngine;
using System.Collections;

public class MoveProjFwd : MonoBehaviour {


	// Use this for initialization
	void Awake () {
		destroyaftertime();
	}
	
	// Update is called once per frame
	void OnBecameInvisible () {
/*		GameObject mapManager = GameObject.FindGameObjectWithTag("MapManager");
		MapBoundaries MapScript = mapManager.GetComponent<MapBoundaries>();
		if(transform.position.x >= MapScript.mapMaxX || transform.position.x <= MapScript.mapMinX || transform.position.z >= MapScript.mapMaxY || transform.position.z <= MapScript.mapMinY)
		{
			Destroy(GameObject);
*/		}

	IEnumerator destroyaftertime(){
		yield return new WaitForSeconds(3);
		Debug.Log("asd");
		Destroy(gameObject);
	}
}

