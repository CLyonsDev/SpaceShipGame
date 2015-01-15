using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	void Start()
	{
		Connect();
	}

	void Connect()
	{
		PhotonNetwork.ConnectUsingSettings("0.0.1");
	}

	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby(){
		Debug.Log("Joined Lobby");
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom(){
		Debug.Log("Joined a Room!");
	}
}
