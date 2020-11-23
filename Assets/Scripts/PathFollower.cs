using DefaultNamespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;

    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalthreshold = 0.1f;

    [SerializeField] private UnityEvent _OnPathComplete;
    [SerializeField] private GameObject _currentObject;
    [SerializeField] private GameObject _prefab;
    public UnityEvent OnPathComplete => _OnPathComplete;

    private int _currentWaypointIndex;

    private void Start()
    {
        _currentWaypointIndex = 0;
        Vector2 position = _currentObject.transform.position;
        
        GameObject waypoint =
        Instantiate(_prefab,
        new Vector2(position.x -0.50f, position.y -1),
        Quaternion.identity) as GameObject;

        if (waypoint.active) Debug.Log("Succesfully instantiated prefab at coords: " + waypoint.transform.position);
        
         else Debug.Log("Cant instantiate prefab");
        
    }

    private void Update()
    {
        Vector2 heightOffsetPosition = new Vector2(_waypoints[_currentWaypointIndex].Position.x,
            _waypoints[_currentWaypointIndex].Position.y); // , _waypoints[_currentWaypointIndex].Position.z
        float distance = Vector2.Distance(transform.position, heightOffsetPosition);
        //pathDrawer();
        if (distance <= _arrivalthreshold)
        {
            if (_currentWaypointIndex == _waypoints.Length - 1)
            {
                print("Ik ben bij het eindpunt");
                _OnPathComplete?.Invoke();
            }
            else
            {
                _currentWaypointIndex++;
            }
        }
        else
        {
            
            transform.LookAt(heightOffsetPosition);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    public void SetPath(Waypoint[] waypoints)
    {
        _waypoints = waypoints;
    }

    public void pathDrawer()
    {
        for (int i = 1; i < _waypoints.Length; i++)
        {
            Vector2 firstLocation = _waypoints[i - 1].Position;
            Vector2 lastLocation = _waypoints[i].Position;

            Handles.DrawLine(firstLocation, lastLocation);
        }
    }
}