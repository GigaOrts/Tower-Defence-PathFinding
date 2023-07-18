using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;

    [SerializeField] private bool _isPlaceable;
    public bool IsPlaceable { get { return _isPlaceable; } }

    private GridManager _gridManager;
    private Pathfinder _pathfinder;
    private Vector2Int _coordinates = new Vector2Int();

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        _pathfinder = FindObjectOfType<Pathfinder>();
    }

    private void Start()
    {
        if (_gridManager != null)
        {
            _coordinates = _gridManager.GetCoordinatesFromPosition(transform.position);

            if (!IsPlaceable)
            {
                _gridManager.BlockNode(_coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (_gridManager.GetNode(_coordinates).isWalkable && !_pathfinder.WillBlockPath(_coordinates) && IsPlaceable)
        {
            bool isSuccessful = _towerPrefab.Create(_towerPrefab, transform.position);

            if (isSuccessful)
            {
                _gridManager.BlockNode(_coordinates);
                _pathfinder.NotifyRecievers();
            }
        }
    }
}
