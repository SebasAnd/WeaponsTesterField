using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceControl : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        print(animator);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
