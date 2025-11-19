using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public bool useEvents;
    // Message  displayed when player is looking at the object
    [SerializeField]
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }

    public void BaseInteract()
    {
        InteractionEvent interactionEvent = GetComponent<InteractionEvent>();
        interactionEvent.OnInteract.Invoke();
        // if (useEvents)
        // {
        //     Debug.Log("Interacting with " + gameObject.name);
        //     InteractionEvent interactionEvent = GetComponent<InteractionEvent>();
        //     interactionEvent.OnInteract.Invoke();
        // }
        Interact();
    }

    protected virtual void Interact()
    {
        // Debug.Log("Interacting with " + gameObject.name);
    }
}
