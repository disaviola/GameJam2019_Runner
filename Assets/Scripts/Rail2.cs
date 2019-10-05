using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Booster booster = GetComponentInParent<Booster>();
            booster.setRail2(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Booster booster = GetComponentInParent<Booster>();
            booster.setRail2(false);
        }
    }
}
