using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	private Transform target;
	public float range = 5f;
	public Transform partToRotate;
	public string enemyTag = "Player";
	public float turnSpeed = 0.1f;
	// Use this for initialization
	public float fireRate = 0.1f;
	private float fireCountdown = 0f;
	public GameObject impactEffect;
	//public GameObject bulletPrefab;
	public Transform firePoint;
	GameObject effectIns;
	void Start () {
		target = GameObject.FindGameObjectWithTag (enemyTag).transform;
		//InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		//InvokeRepeating ("Shoot", 0f, 2f);
		//InvokeRepeating ("Shoot", 0f, 0.5f);
		effectIns = (GameObject) Instantiate (impactEffect, transform.position, transform.rotation);
	}
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}
		//Shoot ();
		;
		float distanceToEnemy = Vector3.Distance (transform.position, target.position);
		if (distanceToEnemy < range) {
			//GameObject effectIns = (GameObject) Instantiate (impactEffect, transform.position, transform.rotation);
		//	effectIns.transform.Translate(transform.position, Space.World);
			//Destroy (effectIns, 2f);
			Destroy (target.gameObject);
		}
	
//		Vector3 dir = target.position - transform.position;
//		Quaternion lookRotation = Quaternion.LookRotation (dir);
//		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		//partToRotate.rotation = Quaternion.Euler (0f, 0f, 30f);
		//partToRotate.Rotate(new Vector3(0, 0, 50) * Time.deltaTime);
//		Debug.Log ("part to rotate" + partToRotate.rotation);
//		if (fireCountdown <= 0f) {
//			Shoot ();
//			fireCountdown = 1f / fireRate;
//		}
//		fireCountdown -= Time.deltaTime;
	}
//	void Shoot(){
//		GameObject bulletGo = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
//		Bullet bullet = bulletGo.GetComponent<Bullet> ();
//		if (bullet != null) {
//			bullet.Seek (target);
//		}
//	}
	void UpdateTarget() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		Debug.Log ("shortest distance" + shortestDistance);
		if (shortestDistance < range) {
			Debug.Log ("range" + range);
		}
		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}

	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);

	}


}
