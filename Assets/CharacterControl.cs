using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //Stats*************///
    public float sensitivityHorizontal;

    public float sensitivityVertical;

    public float speedWalk;

    public float sensitivity = 2;
    public float smoothing = 1.5f;


    //Stats*************///

    public Animator animator;
    public GameObject Fase2Location;
    public Camera Fase1UI;
    public Camera Fase2UI;

    public Camera UserVisual;



    Vector2 velocity;
    Vector2 frameVelocity;



    public bool CanMove;

    public enum CharacterState 
     {
         idle,
         walking,

         bWalk,    
     }
     
     public CharacterState _state;
     public string idleAnimName;
     public string walkAnimName;
    
    // Start is called before the first frame update
    void Start()
    {
        CanMove = false;
        this.animator = GetComponent<Animator>();
        sensitivityHorizontal = 100.0f;
        sensitivityVertical = 100.0f;
        speedWalk = 10.0f;
    }
    public void ChangePosition(){
        this.transform.position = Fase2Location.transform.position;
        this.animator.Play("Base Layer.Idle",0,0.25f);
        this.Fase1UI.gameObject.SetActive(false);
        this.Fase2UI.gameObject.SetActive(true);
        this.UserVisual.gameObject.SetActive(true);
        CanMove = true;
        
    }

    public void LoadDance(int parameter)
    {

        if(parameter == 1)
        {
            this.animator.Play("Base Layer.Dance1",0,0.25f);
        }
        if(parameter == 2)
        {
            this.animator.Play("Base Layer.Dance2",0,0.25f);
        }
        if(parameter == 3)
        {
            this.animator.Play("Base Layer.Dance3",0,0.25f);
        }
        if(parameter == 0)
        {
            this.animator.Play("Base Layer.Idle",0,0.25f);
        }
    }

    void CheckKey()
     {
         if(Input.GetKeyDown(KeyCode.W) ) {
             _state = CharacterState.walking;
         } else if (Input.GetKeyUp(KeyCode.W)) {
             _state = CharacterState.idle;
         }else{
             if(Input.GetKeyDown(KeyCode.S) ) {
             _state = CharacterState.bWalk;
         } else if ( Input.GetKeyUp(KeyCode.S) ) {
             _state = CharacterState.idle;
         }
         }
         PlayAnimation();
     }

     
     
     void PlayAnimation() 
     {
         switch(_state)
         {
            case CharacterState.idle:
                    this.animator.Play("Base Layer.Idle");
                    break;

            case CharacterState.bWalk:
                    this.animator.Play("Base Layer.BackWalk");
                    break;
         
            case CharacterState.walking:
                    this.animator.Play("Base Layer.Walk");
                    break;    
         }            
     }

    // Update is called once per frame
    void Update()
    {
        
        if(CanMove){


            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            // Rotate camera up-down and controller left-right from velocity.
            this.Fase2UI.transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            this.transform.rotation = Quaternion.AngleAxis(velocity.x, Vector3.up);


            if(Input.GetKey(KeyCode.W)){
                this.transform.Translate(Vector3.forward * Time.deltaTime  *this.speedWalk);                      
            }
            if (Input.GetKey(KeyCode.S)){ 
                    this.transform.Translate(-1 * Vector3.forward * Time.deltaTime * this.speedWalk);
             
            }
            CheckKey();
            
            

            
            

            
            
        
        

                    
        }
         
        
    }
}
