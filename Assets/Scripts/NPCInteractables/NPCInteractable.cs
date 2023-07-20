using UnityEngine;

public enum ObjectType
{
    NPC,
    Object
}

public class NPCInteractable : MonoBehaviour
{
    public ObjectType type;
    public float detectionRadius = 3f;
    public bool withinRange = false;
    public LayerMask playerLayer;
    public string[] NPCLines;

    //Create the Gizmo so you can see the radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer); // Used to check if the player is in the Gizmo

        //Used to return true or false if the player is within range of the object
        if (colliders.Length > 0)
        {
            withinRange = true;
        }

        if (colliders.Length < 0)
        {
            withinRange = false;
        }
    }
}
