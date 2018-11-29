using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

	public float moveSpeed = 5;

	public Crosshairs crosshairs;

	Camera viewCamera;
	PlayerController controller;
	GunController gunController;
	
	protected override void Start () {
		base.Start ();
	}

	void Awake() {
		controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
		viewCamera = Camera.main;
		FindObjectOfType<Spawner> ().OnNewWave += OnNewWave;
	}

	void OnNewWave(int waveNumber) {
		health = startingHealth;
		gunController.EquipGun (waveNumber - 1);
	}

	void Update () {
		// Movement input
		
		
	}

	public override void Die ()
	{
		//AudioManager.instance.PlaySound ("Player Death", transform.position);
		//base.Die ();
	}
		
}
