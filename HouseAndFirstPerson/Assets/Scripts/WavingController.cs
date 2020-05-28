using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavingController : MonoBehaviour
{
    static Animator anim; //Animator Variable   
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //On mouse click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out hit, 100000.0f)) // Raycast hit on collider
            {

                if (hit.collider.CompareTag("Player")) // If collider hit is player
                {
                    anim.SetTrigger("isWaving"); //Execute Trigger of waving animation
                }

            }

        }
    }
}
