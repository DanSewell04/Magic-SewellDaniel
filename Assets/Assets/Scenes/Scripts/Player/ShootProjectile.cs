using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile_Ability;
    public float projectile_Speed = 20f;
    public Transform ShootingPoint;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          GameObject CurrentSpell = Instantiate(projectile_Ability, ShootingPoint.position, ShootingPoint.rotation);
          Rigidbody2D rb = CurrentSpell.GetComponent<Rigidbody2D>();
          CurrentSpell.transform.position = ShootingPoint.position;
          rb.AddForce(ShootingPoint.transform.forward * projectile_Speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

}
