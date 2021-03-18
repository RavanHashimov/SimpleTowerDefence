using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Vector2Int boardSize;
    
        [SerializeField] private GameBoard board;
        
        [SerializeField] private Camera mainCamera;

        [SerializeField] private GameTileContentFactory contentFactory;

        private Ray TouchRay => mainCamera.ScreenPointToRay(Input.mousePosition);

        private void Start()
        {
            board.Initialize(boardSize, contentFactory);
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTouch();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                HandleAlternativeTouch();
            }
        }

        private void HandleTouch()
        {
            GameTile tile = board.GetTile(TouchRay);
            if (tile != null)
            {
                board.ToggleWall(tile);
            }
        }

        private void HandleAlternativeTouch()
        {
            GameTile tile = board.GetTile(TouchRay);
            if (tile != null)
            {
                board.ToggleDestination(tile);
            }
        }
    }
}
