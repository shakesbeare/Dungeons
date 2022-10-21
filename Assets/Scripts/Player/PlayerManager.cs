using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Range(1, 4)]
    public int playerCount;

    public PlayerInputManager inputManager;
    public EventHandler<OnCreatePlayersArgs> onCreatePlayers;

    public class OnCreatePlayersArgs : EventArgs
    {
        public int playerCount;

        public OnCreatePlayersArgs(int playerCount)
        {
            this.playerCount = playerCount;
        }
    }

    void Start() 
    {
        onCreatePlayers?.Invoke(this, new OnCreatePlayersArgs(playerCount));

        inputManager = GetComponent<PlayerInputManager>();

        for (int i = 0; i < playerCount; ++i)
        {
            inputManager.JoinPlayer(-1, -1);
        }
    }

}
