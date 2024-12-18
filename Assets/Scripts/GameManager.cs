using System;
using Helpers;
using Player;
using Unity.Cinemachine;
using UnityEngine;

namespace Diablo
{
    public class GameManager : MonoSingleton<GameManager>
    {
        //Seriously, what is up with this game manager?
        //I'll do it in a way that makes sense to me.
        
        //public List<SO_State> States;
        
        private PlayerController character;
        [SerializeField] private CinemachineCamera followCamera;

        private void Awake()
        {
            if (followCamera == null)
            {
                followCamera = FindFirstObjectByType<CinemachineCamera>();
            }
            character = FindFirstObjectByType<PlayerController>();
            
        }

        void Start()
        {
            
        }
    }
}
