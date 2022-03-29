using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRifleBehaviour : MonoBehaviour
{   
    public GameObject ammoPrefab;
    public Camera FPCamera;

    public GameObject projectilesUsed;

    public GameObject PositionShoot;



    /* Controlled Stats*/

    public int maxProjectiles;
    public float ShootSpeed;

    public float DurationProjectile;

    // Start is called before the first frame update
    void Start()
    {
        maxProjectiles = 5;
        ShootSpeed = 20.0f;
        DurationProjectile = 3.0f;
    }

    public IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        GameObject projectile = Instantiate(ammoPrefab);
        projectile.transform.SetParent(projectilesUsed.transform);
        projectile.transform.position = this.PositionShoot.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * ShootSpeed;


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(DurationProjectile);

        //After we have waited 5 seconds print the time again.
        Destroy(projectile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}