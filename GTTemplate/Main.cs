using System;
using BepInEx;
using UnityEngine;
using static GTTemplate.Info;

namespace GTTemplate
{
    [BepInPlugin(GTTemplate.Info.Guid, Name, GTTemplate.Info.Version)]
    public class Main : BaseUnityPlugin
    {
        private bool allowed;
        private void Awake()
        {
            GorillaTagger.OnPlayerSpawned(Init);
        }

        void Init()
        {
            // you on game start functions here
            
            Debug.Log("game initialized");
            
            // subscribe to join/leave room events
            NetworkSystem.Instance.OnMultiplayerStarted += JoinedRoom;
            NetworkSystem.Instance.OnReturnedToSinglePlayer += OnLeaveRoom;
        }

        void FixedUpdate()
        {
            if (!allowed) return;
            // this method will run 50 times per second
        }

        void JoinedRoom()
        {
            allowed = NetworkSystem.Instance.GameModeString.Contains("MODDED");
            if (allowed)
            {
                // enable your mod here
            }
        }

        void OnLeaveRoom()
        {
            allowed = false;
            // disable/cleanup your mod here
        }
    }
}