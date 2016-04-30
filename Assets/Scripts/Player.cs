using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //constantes
    private static int MAXANGULOY=1000;
    private static int MINANGULOY=100;

    //variaveis do codigo
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;
    public int Speed;
    public bool pulando;
    private float anguloY;
    private float anguloX;
    private float forcaPulo;
    private int valorFlecha;
    public int pontuacao;
    public int vida;
    public float timeUltimoDisparo;
    private Touch touch;
    private Ray ray;

    //objetos externos
    public AudioSource flechaSomSource;
	public AudioClip flechaSom;
	public GameObject Flecha;
	public GameObject FlechaGelo;
	public GameObject FlechaFogo;
	public GameObject FlechaEscolhida;
	public GameObject prefPreviaTragetoria;
    public DebugAndroid debug;

    // Use this for initialization
    void Start () {
		flechaSomSource = this.gameObject.GetComponent<AudioSource> ();
		flechaSomSource.clip = flechaSom;
		timeUltimoDisparo = Time.time;
		FlechaEscolhida = Flecha;
		valorFlecha = 1;
		pontuacao = 50;
		pulando = true;
		anguloY = 500;
		anguloX = 1000;
		forcaPulo = 40;
		vida = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {   

        transform.Translate (Vector2.right * Speed * Time.deltaTime);
		if (vida == 0 ) {
			fimJogo();
		}
		if(Time.time>0.3f+timeUltimoDisparo) {
			atkPrevia();
			timeUltimoDisparo = Time.time;
		}

        
        
    }

    void FixedUpdate()
    {
        debug.log("" + anguloY);
        float swipeDistVertical;
        for (int i = 0; i < Input.touches.Length; i++)
        {
            touch = Input.touches[i];
            ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
            Vector3 aux = ray.origin;
            aux.z = 0;
            ray.origin = aux;
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 500) && hit.collider.gameObject.tag == "botoes")
            {

            } else
            {
                //D: meu save do dark souls quebro hoje muito triste
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                        break;

                    case TouchPhase.Moved:
                        swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                        if (swipeDistVertical > minSwipeDistY)

                        {

                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                            if (swipeValue > 0)
                            {
                                UpAngulo();
                            }//up swipe

                            //Jump ();

                            else if (swipeValue < 0)
                            {
                                DonwAngulo();
                            }//down swipe

                            //Shrink ();

                        }
                        break;

                    case TouchPhase.Ended:
                        swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                        if (swipeDistVertical > minSwipeDistY)

                        {

                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                            if (swipeValue > 0)
                            {
                                UpAngulo();
                            }//up swipe

                            //Jump ();

                            else if (swipeValue < 0)
                            {
                                DonwAngulo();
                            }//down swipe

                            //Shrink ();

                        }
                        else
                        {
                            float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                            if (swipeDistHorizontal > minSwipeDistX)

                            {

                                float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                                if (swipeValue > 0)
                                {
                                }//right swipe

                                //MoveRight ();

                                else if (swipeValue < 0)
                                {
                                }//left swipe

                                //MoveLeft ();

                            }
                            else
                            {
                                jump();
                            }
                        }


                        break;
                }
            }
            
            

        }
    }

	public void jump() {
		if (!pulando) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 10 * forcaPulo);
			pulando = true;
		}
	}

	public void atkPrevia() {
		GameObject flechaPrevia = GameObject.Instantiate(prefPreviaTragetoria) as GameObject;
		flechaPrevia.GetComponent<Transform> ().position = this.transform.position;
		flechaPrevia.GetComponent<Rigidbody2D> ().AddForce (new Vector3(anguloX,anguloY,0));
	}

	public void atk() {
		GameObject flecha = GameObject.Instantiate(FlechaEscolhida) as GameObject;
		flecha.GetComponent<Transform> ().position = this.transform.position;
		flecha.GetComponent<Rigidbody2D> ().AddForce (new Vector3(anguloX,anguloY,0));
		flecha.GetComponent<Collider2D> ().isTrigger = true;
		flechaSomSource.Play();
	}

	public void UpAngulo() {
        if (anguloY < MAXANGULOY)
        {
            anguloY += 15;
        }
		
	}

	public void DonwAngulo() {
        if (anguloY > MINANGULOY)
        {
            anguloY -= 15;
        }

		
	}

	public void SlowTime() {
		if (Time.timeScale == 1.0F) {
			Time.timeScale = 0.3F;
			anguloX = anguloX * 3.3F;
			anguloY = anguloY * 3.3F;
			forcaPulo = forcaPulo * 3.2F;
		} else {
			Time.timeScale = 1.0F;
			anguloX = anguloX / 3.3F;
			anguloY = anguloY / 3.3F;
			forcaPulo = forcaPulo / 3.2F;
		}
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "terreno") {
			pulando=false;
		}
		if (collision.gameObject.tag == "guilhotina") {
			fimJogo();
		}
	}

	public void MudarTipoFlecha(int valor) {
		if( valor == 1) {
			FlechaEscolhida = Flecha;
			valorFlecha = 1;
		}
		if (valor == 2) {
			FlechaEscolhida = FlechaGelo;
			valorFlecha = 3;
		}
		if (valor == 3) {
			FlechaEscolhida = FlechaFogo;
			valorFlecha = 5;
		}
	}

	public void receberDano() {
		vida = vida - 1;
	}

	public void incrementarVidas () {
		vida = vida + 1;
	}

	public void fimJogo() {
		GameObject.Destroy(this.gameObject);
	}
}
