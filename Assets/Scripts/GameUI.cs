using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

	public GameObject allUI;
	public Image fadePlane;
	public GameObject gameOverUI;

	public RectTransform newWaveBanner;
	public Text newWaveTitle;
	public Text newWaveEnemyCount;
	public Text scoreUI;
	public Text gameOverScoreUI;
	public RectTransform healthBar;

	Spawner spawner;
	Player player;

	void Start () {
		
	}

	void Awake() {
		
	}

	void Update() {
		
	}

	void OnNewWave(int waveNumber) {
		
	}
		
	void OnGameOver() {
	
	}

	
	
	

	// UI Input
	public void StartNewGame() {
	
	}

	public void ReturnToMainMenu() {
	
	}
}
