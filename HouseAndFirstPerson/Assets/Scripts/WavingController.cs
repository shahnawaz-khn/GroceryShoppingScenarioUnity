using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavingController : MonoBehaviour
{
    static Animator anim;    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100000.0f))
            {

                if (hit.collider.CompareTag("Player"))
                {
                    anim.SetTrigger("isWaving");
                }

            }

        }
    }
}
