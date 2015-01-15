using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(photonView.isMine){
			//Do nothing, our own scripts and stuff are already moving us!
		}
		else{
			transform.position = Vector3.Lerp(transform.position,realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp(transform.rotation,realRotation, 0.1f);

		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		if(stream.isWriting){
			//This is us. Send our position to the network.

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}

		else{
			//This is refering to other people. We need to recieve their position as of a few ms ago, and update their position as WE see it.

			realPosition = (Vector3) stream.ReceiveNext();
			realRotation = (Quaternion) stream.ReceiveNext();
		}
	}
}
