using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private List<WaveConfigSO> _waveConfigs;
	[SerializeField] private int _startingWave;

	private void Start() {
		StartCoroutine(SpawnAllWaves());
	}

	private IEnumerator SpawnAllWaves() {
		for (int _wave = _startingWave; _wave < _waveConfigs.Count; _wave++) {
			var _currentWave = _waveConfigs[_wave];
			yield return StartCoroutine(SpawnAllEnemiesInWave(_currentWave));
		}
	}

	private IEnumerator SpawnAllEnemiesInWave(WaveConfigSO _waveConfigSO) {
		for (int _spawned = 0; _spawned < _waveConfigSO.GetEnemyCount(); _spawned++) {
			var newEnemy = Instantiate
				(_waveConfigSO.GetEnemyPrefab(),
				_waveConfigSO.GetWayPoints()[0].transform.position,
				Quaternion.identity);
			newEnemy.GetComponent<EnemyPathing>().SetWaveCofig(_waveConfigSO);
			yield return new WaitForSeconds(_waveConfigSO.GetSpawnPeriod());
		}

	}
}
