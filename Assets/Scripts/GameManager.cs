using Helpers;
using Player;

namespace Diablo
{
    public class GameManager : MonoSingleton<GameManager>
    {
        //Seriously, what is up with this game manager?
        //I'll do it in a way that makes sense to me.
        
        //public List<SO_State> States;
        
        private PlayerController character;

        void Start()
        {
            character = FindFirstObjectByType<PlayerController>();
        }
    }
}
