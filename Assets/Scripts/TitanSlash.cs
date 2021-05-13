using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanSlash : MonoBehaviour
{
    [SerializeField] GameObject particles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject blood = Instantiate(particles, transform.position, transform.rotation);
        Destroy(blood, 1f);
    }

}
