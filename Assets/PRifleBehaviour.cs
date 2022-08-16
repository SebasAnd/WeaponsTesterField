using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRifleBehaviour : MonoBehaviour
{   
    public GameObject ammoPrefab;
    public Camera FPCamera;

    public GameObject projectilesUsed;

    public GameObject PositionShoot;

    public GameObject collideIndicator;

    public string weapon;



    /* Controlled Stats*/

    public float ShootSpeed;

    public float DurationProjectile;

    GameObject player;

    public ParabolicWeapon InitialvaluesParabolicWeapon;

    public GravityWeapon InitialvaluesGravityWeapon;

    public SpellWeapon InitialvaluesSpellWeapon;

    // Start is called before the first frame update
    void Start()
    {

        if(weapon == "Parabolic"){
            ShootSpeed = InitialvaluesParabolicWeapon.velocidad_de_disparo;
            DurationProjectile = InitialvaluesParabolicWeapon.tiempo_de_duracion_del_projectil;
        }

        if(weapon == "Gravity"){
            ShootSpeed = InitialvaluesGravityWeapon.velocidad_de_disparo;
            DurationProjectile = InitialvaluesGravityWeapon.tiempo_de_duracion_del_projectil;
        } 
        if(weapon == "Spell"){
            ShootSpeed = InitialvaluesSpellWeapon.velocidad_de_disparo;
            DurationProjectile = InitialvaluesSpellWeapon.tiempo_de_duracion_del_projectil;
        }          
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public IEnumerator CooldownBehaviour(){
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<CharacterControl>().checkShoot = true;

    }


    public IEnumerator ParabolicBehaviour()
    {
        //Print the time of when the function is first called.
        GameObject projectile = Instantiate(ammoPrefab);
        projectile.transform.SetParent(projectilesUsed.transform);
        projectile.transform.position = this.PositionShoot.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * ShootSpeed;

        
        StartCoroutine(CooldownBehaviour());
        Destroy(projectile,DurationProjectile);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(DurationProjectile);

        //After we have waited 5 seconds print the time again.
        
    }

    public IEnumerator GravityBehaviour()
    {
        //Print the time of when the function is first called.
        GameObject projectile = Instantiate(ammoPrefab);
        projectile.transform.SetParent(projectilesUsed.transform);
        projectile.transform.position = this.PositionShoot.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * ShootSpeed;


        
        StartCoroutine(CooldownBehaviour());
        Destroy(projectile,DurationProjectile);

        yield return new WaitForSeconds(DurationProjectile);

        
    }
    public IEnumerator CastSpell()
    {
        GameObject projectile = Instantiate(ammoPrefab);
        projectile.transform.SetParent(projectilesUsed.transform);
        projectile.transform.position = this.PositionShoot.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * ShootSpeed;

        
        StartCoroutine(CooldownBehaviour());
        Destroy(projectile,DurationProjectile);        

        
        yield return new WaitForSeconds(DurationProjectile);
        
    }

    public void shoot(){

        if(weapon == "Gravity"){
            StartCoroutine(GravityBehaviour());
        }
        if(weapon == "Parabolic"){
            StartCoroutine(ParabolicBehaviour());
        }
        if(weapon == "Spell"){
            StartCoroutine(CastSpell());
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        
        
    }
}
