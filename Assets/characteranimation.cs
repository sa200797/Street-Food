using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characteranimation : MonoBehaviour
{
    

     public float speed;
     public Vector3 destination;
      public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
          SetDestination (character.transform.position);
           character.transform.position = new Vector3(-4.04f, -1.85f, 10.31f);
      //  GetComponent<Animator> ().enabled = true;
    }
     void Update ()
      {
         // If the object is not at the target destination
         if (destination != character.transform.position) {
             // Move towards the destination each frame until the object reaches it
             IncrementPosition ();
        }
     void IncrementPosition ()
        {
            

            // Calculate the next position
            float delta = speed * Time.deltaTime;
            Vector3 currentPosition =character.transform.position;
            Vector3 spawnPosition = Vector3.MoveTowards (currentPosition, destination, delta);

            // Move the object to the next position
            character.transform.position = spawnPosition;

        }

        if(DropCounter.completeordercharacter==true)
        {
            GetComponent<Animator> ().enabled = true;
            DropCounter.completeordercharacter=false;
            StartCoroutine(WaitAndPrint());
        }
          
     }
     // Set the destination to cause the object to smoothly glide to the specified location
     public void SetDestination (Vector3 value) {
         destination = value;
         
     }
      IEnumerator WaitAndPrint()
    {
         yield return new WaitForSeconds(2f);
          gameObject.SetActive(false);
    }
}
