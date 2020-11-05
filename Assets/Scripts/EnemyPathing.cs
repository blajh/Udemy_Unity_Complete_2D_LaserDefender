using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
	private WaveConfigSO _waveConfigSO;
	private int _waypointIndex = 0;
	private List<Transform> _waypoints;

	private void Start() {
		_waypoints = _waveConfigSO.GetWayPoints();
		transform.position = _waypoints[_waypointIndex].transform.position;
	}

	private void Update() {
		MoveAlongWaypoints(); 
	}

	public void SetWaveCofig(WaveConfigSO _waveConfigSO) {
		this._waveConfigSO = _waveConfigSO;
	}

	private void MoveAlongWaypoints() {
		if (_waypointIndex <= _waypoints.Count - 1) {
			var _targetPosition = _waypoints[_waypointIndex].transform.position;
			var _movementThisFrame = _waveConfigSO.GetMoveSpeed() * Time.deltaTime;
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
 