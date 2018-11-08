using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public GameObject meteor;
	public GameObject vulcan;
	public GameObject acid;
	public GameObject KahalHead;
	public GameObject KahalLHand;
	public GameObject KahalRHand;

	private float timeEarthquake;
	private float TimeVulcan;
	private float TimeMeteor;
	private float TimeAcid;
	private float TimeHead;
	private float timeHands;

	//private float SkillTime = 3.0f;
	private float Timer = 2.0f;

	private float cdEarthquake = 2.0f;
	private float cdVulcan = 2.0f;
	private float cdMeteor = 2.0f;
	private float cdAcid = 2.0f;
	private float cdHead = 2.0f;
	public float handSpeed = 1.0f;

    public Status status;        //Status do personagem

	private GameObject[] Players;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 leftHandDiference;
	private Vector3 rightHandDiference;
	private Vector3 rotation;
	private bool headPos;
	private Vector3 hpos;

	private int ataque;
	private int maxHP = 1000;
	private int[] playersDamage;

	protected Rigidbody2D rb;   //Referencia o Personagem
    protected SpriteRenderer sprite;
    protected Transform t;
    protected Animator anim;
    protected RuntimeAnimatorController anC;
 
	public GameObject warningEarthquake;

	public AudioClip kahalScream;
	public AudioClip kahalSpit;
	public AudioClip kahalDying;
	public AudioClip fanfare;

    private AudioSource source;

	public Camera camera;

	private bool quaking = false;
	private int n = 0;

	private bool dead;

	void Awake(){
		dead = false;
		source = GetComponent<AudioSource>();
		hpos = KahalHead.transform.position;
	}
	// Use this for initialization
	void Start () {
		
		this.rb = GetComponent<Rigidbody2D>();
		this.sprite = GetComponentInChildren<SpriteRenderer>();
		this.t = GetComponent<Transform>();
		this.anim = GetComponent<Animator>();

		anC = anim.runtimeAnimatorController;

		this.status = new Status(maxHP, 10, 10, 1.5f, 10.0f); //hp, attack, def, speed, respawn time
		headPos = true;
		playersDamage = new int[4];
		for(int i=0; i<4; i++){
			playersDamage[i] = 0;
		}

		//warningEarthquake = GameObject.Find("WarningEarthquake");
	}

	void Update(){
		if(!dead){
			KahalHead.transform.position = hpos;
			if(quaking){
				shakeHead(n);
				n++;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!dead){
			if(Timer<=0){
				ataque = Random.Range(0,6);
				

				if(ataque==0 && timeEarthquake <= 0){
					quaking = true;
					n = 0;
					source.clip = kahalScream;
					source.PlayOneShot(kahalScream, 0.7f);
					timeEarthquake = cdEarthquake;
					anim.SetBool("terremoto", true);
					Invoke("ShowWarningEarthquake", 1.0f);
					Invoke("Earthquake", 2.0f);
				}

				if(ataque==1 && TimeVulcan <= 0){
					TimeVulcan = cdVulcan;
					Vulcan ();
				}

			if(ataque==2 && TimeMeteor <= 0){
				TimeMeteor = cdMeteor;
				anim.SetBool("meteoro", true);
				Invoke("MeteorOff", 1.0f);
				Meteor ();
			}

				if(ataque==3 && TimeAcid <= 0){
					source.clip = kahalSpit;
					source.PlayOneShot(kahalSpit, 0.7f);
					TimeAcid = cdAcid;
					Acid ();
				}

				if(ataque==4 && TimeHead <= 0){
					TimeHead = cdHead;
					if(headPos){
						TeleportHead (3.5f, 0.0f);
						headPos = false;
					}else{
						TeleportHead (3.5f, 3.5f);
						headPos = true;
					}
				}

				if(ataque==5){
					leftHandDiference = MoveHand(KahalLHand);
					rightHandDiference = MoveHand(KahalRHand);
					timeHands = 0.0f;
				}
				if((status.GetHp() - maxHP)/maxHP < 0.3){
					Timer = 2f;
				}else if((status.GetHp() - maxHP)/maxHP < 0.6){
					Timer = 3f;
				}else{
					Timer = 4f;
				}

			}

			if(timeHands <= 1.0f){
				KahalLHand.transform.Translate(leftHandDiference * Time.deltaTime * handSpeed);
				KahalRHand.transform.Translate(rightHandDiference * Time.deltaTime * handSpeed);
				timeHands += Time.deltaTime;
			}

			Timer -= Time.deltaTime;
			timeEarthquake -= Time.deltaTime;
			TimeVulcan -= Time.deltaTime;
			TimeMeteor -= Time.deltaTime;
			TimeAcid -= Time.deltaTime;
			TimeHead -= Time.deltaTime;
		}
	}

	//Metodo que implementa a habilidade terremoto
	void Earthquake(){
		for(int i=0; i<4; i++){
			if(MainMenuController.instance.classesChosen[i] != -1){
				int j = i+1;
				Players = GameObject.FindGameObjectsWithTag("Player" + j);
				if(Players[0].GetComponent<Character>().getOnTheFloor()){
					Players[0].SendMessageUpwards("takeDamage", 10);
					Players[0].SendMessageUpwards("takeStun", 2.0f);
				}
			}
		}
		anim.SetBool("terremoto", false);
		warningEarthquake.SetActive(false);
		Debug.Log("TerremotoParou");
		quaking = false;
	}

	void ShowWarningEarthquake(){
		warningEarthquake.SetActive(true);
	}

	//Metodo que implementa o ataque vulcao
	void Vulcan(){
		startPosition = new Vector3(Random.Range(-5.0f, -4.0f), -1.0f, 0.0f);
		for(int i=0; i<10; i++){
			Instantiate (vulcan, startPosition, Quaternion.Euler (0, 0, 0));
			startPosition.x += 3.5f;
		}
	}

	//Metodo que implementa a habilidade meteoro
	void Meteor(){
		for(int i=0; i<10; i++){
			startPosition = new Vector3(Random.Range(-7.0f, 14.0f), Random.Range(6.0f, 8.0f), 0);
			endPosition = new Vector3(Random.Range(-3.5f, 10.5f), -1, 0);
			Vector3 diference = endPosition - startPosition;
			Vector3 frente = new Vector3(1, 0, 0);
       		float angle = Vector3.Angle(diference, frente);
			Instantiate (meteor, startPosition, Quaternion.Euler (0, 0, -angle));
		}
	}
	
	void MeteorOff(){
		anim.SetBool("meteoro", false);
	}

	//Metodo que implementa o golpe acido
	void Acid(){
		startPosition = KahalHead.transform.position;
		int platform = Random.Range(0,5);

		if(platform==0){
			endPosition = new Vector3(0.2f, 2.5f, 0.0f);
		}else if(platform==1){
			endPosition = new Vector3(6.7f, 2.5f, 0.0f);
		}else if(platform==2){
			endPosition = new Vector3(3.6f, 1.3f, 0.0f);
		}else if(platform==3){
			endPosition = new Vector3(0.2f, 0.0f, 0.0f);
		}else if(platform==4){
			endPosition = new Vector3(6.7f, 0.0f, 0.0f);
		}else{
			endPosition = new Vector3(3.6f, 1.3f, 0.0f);
		}
		Vector3 diference = endPosition - startPosition;
		Vector3 frente = new Vector3(1, 0, 0);
		float angle = Vector3.Angle(diference, frente);
		Instantiate (acid, startPosition, Quaternion.Euler (0, 0, -angle));
	}

	void TeleportHead(float x, float y){
		startPosition = new Vector3(x, y, 0);
		KahalHead.transform.position = startPosition;
	}
	Vector3 MoveHand(GameObject hand){
		startPosition = hand.transform.position;
		endPosition = new Vector3(Random.Range(-1.0f, 8.0f), Random.Range(-1.0f, 4.0f), 0);
		Vector3 diference = endPosition - startPosition;
		return diference;
	}

	public virtual void takeDamage(InfAtk atkInfo){
        if(status.GetHp() > 0){
			status.SetHp(status.GetHp()-atkInfo.damage);
			if(atkInfo.playerTag == "Player1"){
				playersDamage[0] += atkInfo.damage;
			}
			if(atkInfo.playerTag == "Player2"){
				playersDamage[1] += atkInfo.damage;
			}
			if(atkInfo.playerTag == "Player3"){
				playersDamage[2] += atkInfo.damage;
			}
			if(atkInfo.playerTag == "Player4"){
				playersDamage[3] += atkInfo.damage;
			}
			if(status.GetHp() <= 0){
				dead = true;
				var aux = camera.GetComponent<AudioSource>();
				aux.Stop();
				aux.clip = fanfare;
				aux.PlayOneShot(fanfare,0.7f);
				source.Stop();
				source.clip = kahalDying;
				source.PlayOneShot(kahalDying, 0.7f);
				PlayerPrefs.SetInt("Player1", playersDamage[0]);
				PlayerPrefs.SetInt("Player2", playersDamage[1]);
				PlayerPrefs.SetInt("Player3", playersDamage[2]);
				PlayerPrefs.SetInt("Player4", playersDamage[3]);
				
				Invoke("CarregarCenaVitoria", 4.7f);
			}
		}
    }

	void shakeHead(int n){
		Vector3 pos = KahalHead.transform.position;
		pos.x += Mathf.Pow(-1, n)*0.3f;
		KahalHead.transform.position = pos;
	}
	void CarregarCenaVitoria(){
			SceneManager.LoadScene("Vitoria");
	}
}