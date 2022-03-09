using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject:MonoBehaviour,IInteractable
{
    public bool IsInteractable { get; private set; } = true;
    protected virtual void Interaction()
    { 
        

    }

    private void OnTriggerEnter(Collider other1)
    {
        if(!IsInteractable|| !other1.CompareTag("Player"))
        {
            return; 
        }

        if (other1.gameObject.CompareTag("Player"))
        {
            
            //Interaction();
           // Destroy(gameObject);
        }
    }

}
