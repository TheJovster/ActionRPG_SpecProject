using Helpers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

namespace Diablo
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public List<SO_State> States;
        
        private PlayerController character;

        void Start()
        {
            character = FindFirstObjectByType<PlayerController>();
        }
    }
}
