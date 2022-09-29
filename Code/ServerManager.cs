using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ServerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
    //Server Baglantisi
     PhotonNetwork.ConnectUsingSettings();   
    }


    public override void OnConnectedToMaster(){
        //Server Baglantısı saglanırsa
        base.OnConnectedToMaster();
        Debug.Log("Connected to server");
        Debug.Log("Connecting to lobby");
        PhotonNetwork.JoinLobby();//Lobbye baglantı saglama
    }

    public override void OnJoinedLobby()
    {
        //Lobbye baglanılırsa
        base.OnJoinedLobby();
        Debug.Log("Joined to Lobby");
        Debug.Log("Connecting to Room");
        
        //Oda ayarları
        PhotonNetwork.JoinOrCreateRoom("Room",new Photon.Realtime.RoomOptions{
            IsOpen = true,
            MaxPlayers = 5,
            IsVisible = true
        },Photon.Realtime.TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        //Odaya baglantı saglanırsa
        base.OnJoinedRoom();
        Debug.Log("Joined to room");
        Debug.Log("Character Creating...");

        PhotonNetwork.Instantiate("player",new Vector2(0,5),Quaternion.Normalize(Quaternion.identity));   
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
