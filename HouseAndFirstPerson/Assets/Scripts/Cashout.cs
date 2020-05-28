using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

[InitializeOnLoad]

public class Cashout : MonoBehaviour
{
    //Audio Variables
    public AudioSource cashRegSound;
    public AudioSource productSound;
  
    Text txt; //speech bubble text change variable
    double bill; // total product cost variable
    string[] purchasedItems = new string[5]; //array to store name of purchased itmes
    MeshCollider rend; //to turn of cloned objects mesh 
    GameObject[] allObjects; //array to store all gameobjects in the scene
    List<Vector3> paths; //list to store positions of cloned objects(purchased items)
    GameObject[] checkout;
    private int count = 0; //counter to check if the products purchased do not exceed 5

    // Start is called before the first frame update
    void Start()
    {
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        paths = new List<Vector3>(); // empty now
        paths.Add(new Vector3(5.39f, 2.36f, -6.6f)); //1st Location of purchased item
        paths.Add(new Vector3(5.39f, 2.36f, -5.8f)); //2nd Location of purchased item
        paths.Add(new Vector3(5.39f, 2.36f, -5.4f)); //3rd Location of purchased item
        paths.Add(new Vector3(5.39f, 2.36f, -4.8f)); //4th Location of purchased item
        paths.Add(new Vector3(5.39f, 2.36f, -4.2f)); //5th Location of purchased item

        foreach (GameObject go in allObjects)
        {
            //Debug.Log(go.name);
            if (go.name == "BubbleHolder") //Searching for speechBubble in all gameObjects available in scene
            {
                go.SetActive(false); //Disabling it at Start()
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //on mouse click
        {
            //Debug.Log(count);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100000.0f)) //Raycast to hit an object
            {
                if (hit.collider.CompareTag("item1") && count < 5) //item hit
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "toblerone") //name of item
                        {
                            GameObject item1clone = Instantiate(go) as GameObject; //cloning item
                            item1clone.transform.position = paths[count]; // setting position on counter
                            rend = item1clone.GetComponent<MeshCollider>();
                            rend.enabled = false; //turning collider off
                            purchasedItems[count] = "Toblerone: €2.00"; // saving item and its price in array
                            bill += 2; // addition to bill
                            productSound.Play(); //playing added to cart successfully sound 
                        }
                    }
                    count += 1; //increasing counter
                }
                if (hit.collider.CompareTag("item2") && count < 5) //item hit
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "cheezIt") //name of item
                        {
                            GameObject item2clone = Instantiate(go) as GameObject; //cloning item
                            item2clone.transform.position = paths[count]; // setting position on counter
                            rend = item2clone.GetComponent<MeshCollider>();
                            rend.enabled = false; //turning collider off
                            purchasedItems[count] = "CheezIt: €2.50"; // saving item and its price in array
                            bill += 2.50; // addition to bill
                            productSound.Play(); //playing added to cart successfully sound 
                        }
                    }
                    count += 1; //increasing counter
                }
                if (hit.collider.CompareTag("item3") && count < 5) //item hit
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "soupCan") //name of item
                        {
                            GameObject item3clone = Instantiate(go) as GameObject; //cloning item
                            item3clone.transform.position = paths[count]; // setting position on counter
                            rend = item3clone.GetComponent<MeshCollider>();
                            rend.enabled = false; //turning collider off
                            purchasedItems[count] = "Soup Can: €0.99"; // saving item and its price in array
                            bill += 0.99; // addition to bill
                            productSound.Play(); //playing added to cart successfully sound 
                        }
                    }
                    count += 1; //increasing counter
                }
                if (hit.collider.CompareTag("item4") && count < 5) //item hit
                {

                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "redBullCan") //name of item
                        {
                            GameObject item4clone = Instantiate(go) as GameObject; //cloning item
                            item4clone.transform.position = paths[count]; // setting position on counter
                            rend = item4clone.GetComponent<MeshCollider>();
                            rend.enabled = false; //turning collider off
                            purchasedItems[count] = "RedBull Can: €1.49"; // saving item and its price in array
                            bill += 1.49; // addition to bill
                            productSound.Play(); //playing added to cart successfully sound 
                        }
                    }
                    count += 1;
                }
                if (hit.collider.CompareTag("item5") && count < 5) //item hit
                {
                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "beets") //name of item
                        {
                            GameObject item5clone = Instantiate(go) as GameObject; //cloning item
                            item5clone.transform.position = paths[count]; // setting position on counter
                            rend = item5clone.GetComponent<MeshCollider>();
                            rend.enabled = false; //turning collider off
                            purchasedItems[count] = "Beets: €1.00"; // saving item and its price in array
                            bill += 1; // addition to bill
                            productSound.Play(); //playing added to cart successfully sound 
                        }
                    }
                    count += 1;
                }
                if (hit.collider.CompareTag("register")) //click on register
                {
                    foreach (GameObject go in allObjects)
                    {
                        if (go.name == "BubbleHolder") //searching for speechBubble
                        {

                            foreach (GameObject g in allObjects)
                            {
                                Debug.Log(g.name);

                                if (g.name == "Text") // Accessing TextField
                                {
                                    string seperator = "\n";
                                    string bubble;
                                    string finalBill = "The total cost is: " + bill; //Fill total bill
                                    txt = g.GetComponent<Text>();
                                    bubble = string.Join(seperator, purchasedItems); //Combining strings
                                    finalBill = bubble + "\n" + finalBill; // combining strings
                                    txt.text = finalBill; // chaning speechbubble text
                                    cashRegSound.Play(); // playing register sound
                                    Debug.Log("Text Changed");
                                    //go.SetActive(false);
                                }
                            }
                            go.SetActive(true); // Enabling speechBubble
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
