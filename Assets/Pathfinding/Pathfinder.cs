using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Node _currentSearchNode;
    
    private Vector2Int[] _directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };

    private Dictionary<Vector2Int, Node> _grid;
    private GridManager _gridManager;

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();

        if (_gridManager != null)
            _grid = _gridManager.Grid;
    }

    void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in _directions)
        {
            Vector2Int neighborCoords = _currentSearchNode.coordinates + direction;

            if(_grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(_grid[neighborCoords]);

                _grid[neighborCoords].isExplored = true;
                _grid[_currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
