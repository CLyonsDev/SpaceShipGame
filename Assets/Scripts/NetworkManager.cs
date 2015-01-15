using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject StandbyCamera;
	SpawnSpot[] spawnSpots;
	
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
		Connect();
	}
	
	
	void Connect() {
		PhotonNetwork.ConnectUsingSettings("0.0.1");
	}
	
	void OnGUI() {
		GUILayout.Label( PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	
	void OnJoinedLobby() {
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed() {
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom(null) ;
	}
	
	
	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer();
	}
	void SpawnMyPlayer() {
		SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
		GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate("FighterShip", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation,0);
		myPlayer.GetComponent<ShipMovement>().enabled = true;
		StandbyCamera.SetActive(false);
		myPlayer.GetComponentInChildren<shootonclick>().enabled = true;
		myPlayer.transform.FindChild("MainCamera").gameObject.SetActive(true);
	}
	
}﻿