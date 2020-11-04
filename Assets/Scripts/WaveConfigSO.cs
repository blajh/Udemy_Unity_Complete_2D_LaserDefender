using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "EnemyWaveConfigSO")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private GameObject _pathPrefab;
	[SerializeField] private float _spawnTime = 0.5f;
	[SerializeField] private float _spawnTimeOffset = 0.3f;
	[SerializeField] private float _moveSpeed = 2f;
	[SerializeField] private int _enemyCount = 5;

	public GameObject GetEnemyPrefab() { return _enemyPrefab; }
	public float GetSpawnTime() { return _spawnTime; }
	public float GetSpawnTimeOffset() { return _spawnTimeOffset; }
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
