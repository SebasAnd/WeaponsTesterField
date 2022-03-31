using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLauncher : MonoBehaviour
{
    public GameObject ammoPrefab;

    public GameObject projectilesUsed;

    public GameObject PositionShoot;

    public float DurationProjectile;

    GameObject player;
    public int maxProjectiles;

    public GameObject collideIndicator;

    public float ShootSpeed;
    // Start is called before the first frame update
    void Start()
    {
        maxProjectiles = 5;
        ShootSpeed = 20.0f;
        DurationProjectile = 3.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    public IEnumerator CooldownBehaviour(){
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<CharacterControl>().checkShoot = true;

    }

    public IEnumerator CastSpell()
    {
        //Print the time of when the function is first called.
        GameObject projectile = Instantiate(ammoPrefab);
        projectile.transform.SetParent(projectilesUsed.transform);
        projectile.transform.position = this.PositionShoot.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * ShootSpeed;

        
        StartCoroutine(CooldownBehaviour());
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(DurationProjectile);

        //After we have waited 5 seconds print the time again.
        Destroy(projectile);
    }
    public void shoot(){
        StartCoroutine(CastSpell());     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
