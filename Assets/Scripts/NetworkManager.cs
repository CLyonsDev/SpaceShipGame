using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public Camera StandbyCamera;
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
		StandbyCamera.enabled = false;
		SpawnMyPlayer();
	}
	void SpawnMyPlayer() {
		SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
		GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate("FighterShip", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation,0);
		StandbyCamera.enabled = false;
		myPlayer.GetComponent<ShipMovement>().enabled = true;
		myPlayer.GetComponentInChildren<shootonclick>().enabled = true;
		myPlayer.transform.FindChild("MainCamera").gameObject.SetActive(true);
	}
	
}﻿