using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Core;
using System;
using UnityEngine.UI; 
public class PlayerController : MonoBehaviour {

    enum State
    {
        RUNNING,
        CHANGING_SIDE,
        JUMPING
    }

    enum Position
    {
        LEFT,
        MID,
        RIGHT
    }

    public float changingSideSpeed = 1;
    public float JumpForce = 10;

	public GameObject vida;
	public Sprite[] sp;
    public Sprite[] setas;
    public GameObject seta;
	private int life;

	public GameObject model;

    private Renderer modelRender;
    public Animator animator;

    public AudioSource plimSound;

    private Vector3 initialPosition;
    private int score;
    private State currentState;
    private Vector3 targetPosition;
    private Rigidbody rigidBody;
    private Position current;

    private Action stateMethod;
    private float time_trocasetas = 2;
    private float time_instructions;
    void Start () {
		life = 3;
        modelRender = model.GetComponent<Renderer>();
        initialPosition = this.transform.position;
        current = Position.MID;
        stateMethod = OnRunning;
        currentState = State.RUNNING;
        rigidBody = this.GetComponent<Rigidbody>();
        time_instructions = time_trocasetas * 4+1;
    }

    
    private float time_contInstructions = 0;
    private float time_setas = 0;
    int qualSeta = -1;
    bool first = true;
  
    void Update () {
		if(life >= 0){
			vida.GetComponent<Image>().sprite =sp [life];
		}

        //time_contInstructions += Time.deltaTime;
        //if(time_contInstructions < time_instructions && seta != null)
        //{
        //    time_setas += Time.deltaTime;
        //    switch (qualSeta)
        //    {
        //        case -1:
        //            if(time_setas > time_trocasetas)
        //            {
        //                time_setas = 0;
        //                qualSeta = 0;
        //            }
        //            break;
        //        case 0:
        //            if (first)
        //            {
        //                first = false;
        //                seta.GetComponent<Image>().sprite = setas[0];
        //                rigidBody.AddForce(new Vector3(0, JumpForce, 0));
        //                currentState = State.JUMPING;
        //                stateMethod = OnJump;
        //            }
        //            if(time_setas > time_trocasetas)
        //            {
        //                first = true;
        //                time_setas = 0;
        //                qualSeta = 1;

        //            }
        //            break;
        //        case 1:
        //            if (first)
        //            {
        //                first = false;
        //                seta.GetComponent<Image>().sprite = setas[1];
        //                current--;
        //                currentState = State.CHANGING_SIDE;
        //                stateMethod = OnChangingSide;
        //                DefinePosition(current);
        //            }
        //            if (time_setas > time_trocasetas)
        //            {
        //                first = true;
        //                time_setas = 0;
        //                qualSeta = 2;
        //            }
        //            break;
        //        case 2:
        //            if (first)
        //            {
        //                first = false;
        //                seta.GetComponent<Image>().sprite = setas[2];
        //                current++;
        //                currentState = State.CHANGING_SIDE;
        //                stateMethod = OnChangingSide;
        //                DefinePosition(current);    

        //            }
        //            if (time_setas > time_trocasetas)
        //            {
        //                first = true;
        //                GameObject.Destroy(seta);
                    
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}else
        //{
            stateMethod();
        //}
                  
	}

    void OnJump()
    {
        
    }

    IEnumerator DamageAnimation() {
        for (int i = 0 ;i < 5 ;i++) {
            yield return StartCoroutine(DecreaseAlfa());
            yield return StartCoroutine(IncreaseAlfa());

        }
    }

    IEnumerator DecreaseAlfa() {
       // for (float i = 1 ; i < 1 ; i -= 0.1f) {
            for (int j = 0 ; j < modelRender.materials.Length ; j++) {
                Color oldColor = modelRender.materials[j].color;
                modelRender.materials[j].color = new Color(oldColor.r , oldColor.g , oldColor.b , 0.2f);
            }
            yield return new WaitForSeconds(.1f);
        // }     
    }


    IEnumerator IncreaseAlfa() {
       // for (float i = 0 ; i < 1 ; i += 0.1f) {
            for (int j = 0 ; j < modelRender.materials.Length ; j++) {
                Color oldColor = modelRender.materials[j].color;
                modelRender.materials[j].color = new Color(oldColor.r , oldColor.g , oldColor.b , 1);
            }
            yield return new WaitForSeconds(.2f);
      //  }
    }

    void OnRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if ((int)current > 0)
            {
                current--;
                currentState = State.CHANGING_SIDE;
                stateMethod = OnChangingSide;
                DefinePosition(current);                
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((int)current < 2)
            {
                current++;
                currentState = State.CHANGING_SIDE;
                stateMethod = OnChangingSide;
                DefinePosition(current);                
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {            
            animator.Play("Jump");
            rigidBody.AddForce(new Vector3(0, JumpForce, 0));
            currentState = State.JUMPING;
            stateMethod = OnJump;
        }
    }

    private void DefinePosition(Position current)
    {
        switch (current)
        {
            case Position.LEFT:
                this.targetPosition = this.initialPosition + new Vector3(-Singleton<GameManager>.Instance.playerOffSet, 0, 0);
                break;
            case Position.MID:
                this.targetPosition = this.initialPosition + new Vector3(0, 0, 0);
                break;
            case Position.RIGHT:
                this.targetPosition = this.initialPosition + new Vector3(Singleton<GameManager>.Instance.playerOffSet, 0, 0);
                break;
        }
    }

    void OnChangingSide()
    {
        this.transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosition.x, changingSideSpeed), this.transform.position.y, this.transform.position.z);
    
        if (Mathf.Abs(this.transform.position.x-targetPosition.x) < ConstantsMap.TOLERANCE)
        {
            this.transform.position = new Vector3(targetPosition.x, this.transform.position.y, this.transform.position.z);
            this.currentState = State.RUNNING;
            this.stateMethod = OnRunning;
        }
    }

    void OnTriggerEnter(Collider coll) {

        if (coll.tag == TagMap.OBSTACLE) {
            
        }

    }

    private void KillObstacle(GameObject obstacle)
    {     
        ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();
        obstacleController.DeathAnimation();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == TagMap.ENEMY)
        {
			life--;
            if (life < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            StartCoroutine(DamageAnimation());
            KillObstacle(coll.gameObject);
        }

        if (coll.collider.tag.Substring(0,4)=="Item")
        {
            int index;
            int.TryParse(coll.collider.tag.Substring(4, 1),out index);
            index--;
            Singleton<GameManager>.Instance.GotItem(index);
            KillObstacle(coll.gameObject);
            plimSound.Play();
        }

        if (coll.collider.tag == TagMap.ITEM_MAGICO)
        {
            plimSound.Play();
            Singleton<GameManager>.Instance.ShowBlackScreen();
            GameObject.Destroy(coll.gameObject);
        }
        
        if (coll.collider.tag == TagMap.GROUND && this.currentState == State.JUMPING )
        {         
            this.currentState = State.RUNNING;
            this.stateMethod = OnRunning;
        }
    }
}
