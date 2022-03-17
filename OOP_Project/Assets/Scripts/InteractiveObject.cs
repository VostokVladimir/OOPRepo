using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject:MonoBehaviour,IInteractable
{
    public bool IsInteractable { get; private set; } = true;
    

    private void OnTriggerEnter(Collider other)
    {
        if (!IsInteractable || !other.CompareTag("Player"))
        {
            return;
        }
        Interaction();
        Destroy(gameObject);
    }
     protected virtual void Interaction()
    { 
        

    }

}
