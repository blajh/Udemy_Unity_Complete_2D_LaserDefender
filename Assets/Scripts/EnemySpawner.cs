using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private List<WaveConfigSO> _waveConfigs;
	private int _startingWave;

	private void Start() {
		var _currentWave = _waveConfigs[_startingWave];
		StartCoroutine(SpawnAllEnemiesInWave(_currentWave));
	}

	IEnumerator SpawnAllEnemiesInWave(WaveConfigSO _waveConfigSO) {
		Instantiate
			(_waveConfigSO.GetEnemyPrefab(),
			_waveConfigSO.GetWayPoints()[0].transform.position,
			Quaternion.identity);

		yield return new WaitForSeconds(_waveConfigSO.GetSpawnPeriod());
	}
}
