using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

[InitializeOnLoad]

public class Cashout : MonoBehaviour
{
    public AudioSource cashRegSound;
    public AudioSource productSound;
    Text txt;
    double bill;
    string[] purchasedItems = new string[5];
    MeshCollider rend;
    GameObject[] allObjects;
    List<Vector3> paths;
    GameObject[] checkout;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        paths = new List<Vector3>(); // empty now
        paths.Add(new Vector3(5.39f, 2.36f, -6.6f));
        paths.Add(new Vector3(5.39f, 2.36f, -5.8f));
        paths.Add(new Vector3(5.39f, 2.36f, -5.4f));
        paths.Add(new Vector3(5.39f, 2.36f, -4.8f));
        paths.Add(new Vector3(5.39f, 2.36f, -4.2f));

        foreach (GameObject go in allObjects)
        {
            Debug.Log(go.name);
            if (go.name == "BubbleHolder")
            {
                go.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(count);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100000.0f))
            {
                if (hit.collider.CompareTag("item1") && count < 5)
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "toblerone")
                        {
                            GameObject item1clone = Instantiate(go) as GameObject;
                            item1clone.transform.position = paths[count];
                            rend = item1clone.GetComponent<MeshCollider>();
                            rend.enabled = false;
                            purchasedItems[count] = "Toblerone: €2.00";
                            bill += 2;
                            productSound.Play();
                        }
                    }
                    count += 1;
                }
                if (hit.collider.CompareTag("item2") && count < 5)
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "cheezIt")
                        {
                            GameObject item2clone = Instantiate(go) as GameObject;
                            item2clone.transform.position = paths[count];
                            rend = item2clone.GetComponent<MeshCollider>();
                            rend.enabled = false;
                            purchasedItems[count] = "CheezIt: €2.50";
                            bill += 2.50;
                            productSound.Play();
                        }
                    }
                    count += 1;
                }
                if (hit.collider.CompareTag("item3") && count < 5)
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "soupCan")
                        {
                            GameObject item3clone = Instantiate(go) as GameObject;
                            item3clone.transform.position = paths[count];
                            rend = item3clone.GetComponent<MeshCollider>();
                            rend.enabled = false;
                            purchasedItems[count] = "Soup Can: €0.99";
                            bill += 0.99;
                            productSound.Play();
                        }
                    }
                    count += 1;
                }
                if (hit.collider.CompareTag("item4") && count < 5)
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "redBullCan")
                        {
                            GameObject item4clone = Instantiate(go) as GameObject;
                            item4clone.transform.position = paths[count];
                            rend = item4clone.GetComponent<MeshCollider>();
                            rend.enabled = false;
                            purchasedItems[count] = "RedBull Can: €1.49";
                            bill += 1.49;
                            productSound.Play();
                        }
                    }
                    count += 1;
                }
                if (hit.collider.CompareTag("item5") && count < 5)
                {
                    count += 1;
                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "beets")
                        {
                            GameObject item5clone = Instantiate(go) as GameObject;
                            item5clone.transform.position = paths[count];
                            rend = item5clone.GetComponent<MeshCollider>();
                            rend.enabled = false;
                            purchasedItems[count] = "Beets: €1.00";
                            bill += 1;
                            productSound.Play();
                        }
                    }
                }
                if (hit.collider.CompareTag("register"))
                {
                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "BubbleHolder")
                        {

                            foreach (GameObject g in allObjects)
                            {
                                Debug.Log(g.name);

                                if (g.name == "Text")
                                {
                                    string seperator = "\n";
                                    string bubble;
                                    string finalBill = "The total cost is: " + bill;
                                    txt = g.GetComponent<Text>();
                                    bubble = string.Join(seperator, purchasedItems);
                                    finalBill = bubble + "\n" + finalBill;
                                    txt.text = finalBill;
                                    cashRegSound.Play();
                                    Debug.Log("Text Changed");
                                    //go.SetActive(false);
                                }
                            }
                            go.SetActive(true);
                        }
                    }
                }


            }
        }
        else
        {
            Debug.Log("Cant Purchase more items");
        }
    }
}
