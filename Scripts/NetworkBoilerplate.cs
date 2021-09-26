using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkBoilerplate : NetworkBehaviour
{
    // SYNC DATA
    struct MyStruct
    {
        public int myInt;
    }
    class MyStructList : SyncListStruct<MyStruct> { }
 
    [SyncVar]
    int _myInt = 5;

    MyStructList _myStructList = new MyStructList();
    SyncListInt _intList = new SyncListInt();

    static short MESSAGE_CHANNEL = 1002;
    static string MESSAGE_MOVE = "MOVE";

    public void NewGame()
    {
        // Register the server to receive messages
        NetworkServer.RegisterHandler(MESSAGE_CHANNEL, OnServerReceiveMessage);
        if (NetworkServer.active)
        {
            // Start game server logic
            // Fill initial data
        }
    }

    // Client -> Server Message
    public void ClientSendMessage()
    {
        var msg = new StringMessage("MOVE");
        NetworkManager.singleton.client.Send(MESSAGE_CHANNEL, msg);
    }

    void OnServerReceiveMessage(NetworkMessage netMsg)
    {
        var beginMessage = netMsg.ReadMessage<StringMessage>();
        if (beginMessage.value.Equals(MESSAGE_MOVE))
        {
            // Message received from the client, do something here based on its value
        }
    }

    // DRAW GAME
    void OnGUI()
    {
        if (NetworkServer.active)
        {
            // Buttons for Server
        }
        else
        {
            // Buttons for Client
        }
    }
}
