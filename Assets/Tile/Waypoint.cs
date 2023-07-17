using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;

    [SerializeField] private bool _isPlaceable;
    public bool IsPlaceable { get { return _isPlaceable; } }

    private void OnMouseDown()
    {
        if (_isPlaceable)
        {
            bool isPlaced = _towerPrefab.Create(_towerPrefab, transform.position);

            _isPlaceable = !isPlaced;
        }
    }
}
