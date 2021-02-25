using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        public float PlayerSpeed = 0;
        public bool PlayerPositionLeft = false;
        public bool PlayerMove = true;
    }

}
