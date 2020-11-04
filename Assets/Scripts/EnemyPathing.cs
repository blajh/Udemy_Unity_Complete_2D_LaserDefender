using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
	[SerializeField] private WaveConfigSO _waveConfigSO;
	[SerializeField] private float _moveSpeed = 2f;
	private int _waypointIndex = 0;
	private List<Transform> _waypoints;

	private void Start() {
		_waypoints = _waveConfigSO.GetWayPoints();
		transform.position = _waypoints[_waypointIndex].transform.position;
	}

	private void Update() {
		MoveAlongWaypoints();
	}

	private void MoveAlongWaypoints() {
		if (_waypointIndex <= _waypoints.Count - 1) {
			var _targetPosition = _waypoints[_waypointIndex].transform.position;
			var _movementThisFrame = _moveSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _movementThisFrame);
			if (transform.position == _targetPosition) {
				_waypointIndex++;
			}
		}
		else {
			Destroy(gameObject);
		}
	}
}
 