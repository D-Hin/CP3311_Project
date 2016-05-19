using UnityEngine;
using System.Collections;

public class StandColliderScript : MonoBehaviour {

	public MeshRenderer entryBlockWall;
	Collider entryCollider;
	public MeshRenderer chalice;
	public Camera standCamera;
	public Transform standPlate;
	public AudioSource standPlateAudio;
	public AudioSource standBaseAudio;
	public Light spotlight;
	public Light eye1;
	public Light eye2;
	public MeshRenderer exitBlockWall;
	Collider exitCollider;
	public Camera characterCamera;
	public Animator character;
	public float timer;
	private bool plateMove;
	private bool alreadyPlayed;
	private bool cameraShaked;
	public CameraShake standCameraShake;
	public AudioSource audioClip1;
	public AudioSource audioClip2;
	private bool audioClip1Played;
	private bool audioClip2Played;

	// Start is called at the beginning of the scene
	void Start () {
		timer = 0f;
		entryCollider = entryBlockWall.GetComponent<Collider> ();
		entryCollider.enabled = false;
		entryBlockWall.GetComponent<MeshRenderer> ();
		entryBlockWall.enabled = false;
		chalice.GetComponent<MeshRenderer> ();
		plateMove = false;
		audioClip1 = standPlateAudio.GetComponent<AudioSource>();
		audioClip2 = standBaseAudio.GetComponent<AudioSource>();
		eye1 = eye1.GetComponent<Light> ();
		eye2 = eye2.GetComponent<Light> ();
		spotlight = spotlight.GetComponent<Light> ();
		exitCollider = exitBlockWall.GetComponent<Collider> ();
		exitCollider.enabled = true;
		exitBlockWall.GetComponent<MeshRenderer> ();
		exitBlockWall.enabled = true;
		characterCamera.enabled = true;
		standCamera.enabled = false;
		alreadyPlayed = false;
		audioClip2Played = false;
		cameraShaked = false;
	}

	// Update is called once per frame
	void Update () {
		if (plateMove == true) {
			timer += Time.deltaTime;
			if (timer >= 0.5) {
				chalice.enabled = false;
				if (timer > 0.8) {
					standCamera.enabled = true;
					characterCamera.enabled = false;
					if (standPlate.position.y > 6.53f) {
						standPlate.Translate (new Vector3 (0, -0.2f * Time.deltaTime, 0));
						if (audioClip1Played == false) {
							audioClip1.Play ();
							audioClip1Played = true;
						}
					}
					if (standPlate.position.y <= 6.53f)  {
						eye1.color = Color.red;
						eye2.color = Color.red; 
						spotlight.color = Color.red;
						if (timer >= 4 & cameraShaked == false) {
							if (audioClip2Played == false) {
								audioClip1.Stop ();
								audioClip2.Play ();
								audioClip2Played = true;
							}
							standCameraShake.Shake (1f, 0.7f);
							cameraShaked = true;
							if (timer >= 7) {
								standCameraShake.Shake (0f, 0f);
							}
						}
						if (timer >= 9) {
							entryBlockWall.enabled = true;
							entryCollider.enabled = true;
							exitBlockWall.enabled = false;
							exitCollider.enabled = false;
							characterCamera.enabled = true;
							standCamera.enabled = false;
							plateMove = false;
						}
					}
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (alreadyPlayed == false) {
			character.SetTrigger ("Punch");
			plateMove = true;
			alreadyPlayed = true;
		}
	}
}