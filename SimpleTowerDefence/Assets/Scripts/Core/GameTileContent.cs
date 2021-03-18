using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class GameTileContent : MonoBehaviour
    {
        [SerializeField] private GameTileContentType type;

        public GameTileContentType Type => type;

        public GameTileContentFactory OriginFactory { get; set; }
        
        public void Recycle()
        {
            OriginFactory.Reclaim(this);
        }
    }

    public enum GameTileContentType
    {
        Empty,
        Destination,
        Wall
    }
}
