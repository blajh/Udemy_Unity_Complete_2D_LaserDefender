using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "EnemyWaveConfigSO")]
public class WaveConfigSO : ScriptableObject
{
	[Header("Enemy Config")]
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private int _enemyCount = 5;
	[SerializeField] private float _moveSpeed = 2f;
	[SerializeField] private float _spawnPeriod= 0.5f;
	[SerializeField] private float _spawnPeriodOffset = 0.3f;
	[Header("Path")]
	[SerializeField] private GameObject _pathPrefab;

	public GameObject GetEnemyPrefab() { return _enemyPrefab; }
	public float GetSpawnPeriod() { return _spawnPeriod; }
	public float GetSpawnPeriodOffset() { return _spawnPeriodOffset; }
	public float GetMoveSpeed() { return _moveSpeed; }
	public int GetEnemyCount() { return _enemyCount; } 

	public List<Transform> GetWayPoints() {
		var _waveWaypoints = new List<Transform>();
		foreach (Transform _child in _pathPrefab.transform) {
			_waveWaypoints.Add(_child);
		}

		return _waveWaypoints;
	}
}
