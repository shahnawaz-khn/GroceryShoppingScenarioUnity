using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//[InitializeOnLoad]

public class registerScript : MonoBehaviour
{
    //private Cashout cashout;
    Text txt;
    GameObject[] allObjects;
    string[] purchasedGoods;
    // Start is called before the first frame update
    void Start()
    {
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            Debug.Log(go.name);
            if (go.name == "Text")
            {
                //purchasedGoods = cashout.purchasedGoods();
                txt = go.GetComponent<Text>();
                //txt.text = purchasedGoods[0];
                Debug.Log("Text Changed");
                //go.SetActive(false);
            }
        }
        foreach (GameObject go in allObjects)
        {
            Debug.Log(go.name);
            if (go.name == "BubbleHolder")
            {
                Debug.Log("Bubble Holder Disabled!");
                go.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse click");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100000.0f))
            {
                Debug.Log("in raycast of register");
                if (hit.collider.CompareTag("register"))
                {
                    Debug.Log("hit of register accepted");
                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "BubbleHolder")
                        {

                            foreach (GameObject g in allObjects)
                            {
                                Debug.Log(g.name);

                                if (g.name == "Text")
                                {
                                    txt = g.GetComponent<Text>();
                                    txt.text = "Text Changed!";
                                    Debug.Log("Text Changed");
                                }
                            }

                            Debug.Log("In BubbleHolder Enabled");
                            go.SetActive(true);
                        }
                    }

                }

            }

        }

    }
}