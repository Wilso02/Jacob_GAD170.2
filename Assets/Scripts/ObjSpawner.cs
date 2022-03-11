using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject[] shapes;
    public Material[] mats;
    public string[] tags;
    public int amount;
    public float secDelay = 1.0f;

    private List<GameObject> spawnedObjs = new List<GameObject>();
    private bool canTick = true;


    // Update is called once per frame
    void Update()
    {
       
        if(canTick)
        {

            //check if amount of spawn objects has reached our desired amount
            if (spawnedObjs.Count < amount)
            {

                //define a random position to spawn in
                float randX = Random.Range(-20f, 20f);
                float randZ = Random.Range(-20f, 20f);
                Vector3 pos = new Vector3(transform.position.x + randX,
                                          transform.position.y,
                                          transform.position.z + randZ);

                spawnedObjs.Add(Instantiate(shapes[Random.Range(0, shapes.Length)], pos, transform.rotation));
                int rand = Random.Range(0, mats.Length);
                spawnedObjs[spawnedObjs.Count - 1].GetComponent<MeshRenderer>().material = mats[rand];
                spawnedObjs[spawnedObjs.Count - 1].tag = tags[rand];

            }

            canTick = false;
            StartCoroutine(Timer(secDelay));


        }

        UpdateObjs();

    }

    IEnumerator Timer(float delay)
    {
        //code here runs immediately

        //this line causes a pause
        yield return new WaitForSeconds(delay);
        
        //code here runs after delay
        canTick = true;

        /*
         *int phase;   //phase 0 = beginning of game
                      //phase 1 = select fighters
                     //phase 2 = battle
                    //phase 3 = result
        switch(phase)

        if(phase ==3
        {
            phase = 0

        }
        */
       


    }

    private void UpdateObjs()
    {

        foreach(GameObject obj in spawnedObjs)
        {

            switch(obj.tag)
            {

                case "Red":
                    obj.transform.position += Vector3.forward * Time.deltaTime;
                    break;

                case "Blue":
                    obj.transform.position += Vector3.up * Time.deltaTime;
                    break;

                case "Green":
                    obj.transform.position += Vector3.down * Time.deltaTime;
                    break;

                case "Yellow":
                    obj.transform.localScale += Vector3.one * Time.deltaTime;
                    break;

                case "Pink":
                    obj.transform.localScale -= Vector3.one * Time.deltaTime;
                    break;

               
            }

        }

    }

}
