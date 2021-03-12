using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Game : MonoBehaviour
{
    [SerializeField] private Vector2Int boardSize;
    
    [SerializeField] private GameBoard board;

    private void Start()
    {
        board.Initialize(boardSize);
    }
}
