using UnityEngine;

public enum ObjectType
{
    NPC,
    Object
}

public enum NPCBranchType
{
    Branch1,
    Branch2
}

public enum FragmentType
{
    None,
    Necklace,
    CafeLogo
}

public class NPCInteractable : MonoBehaviour
{
    public ObjectType type;
    public FragmentType fragmentType;
    public BranchType npc_Branch;
    public float detectionRadius = 3f;
    public bool withinRange = false;
    public LayerMask playerLayer;
    [TextArea(2, 4)] public string[] NPCLines;
    public bool branchingDialogue = false;
    public string branchAnswers1;
    public string branchAnswers2;
    [TextArea(2, 4)] public string[] branchingLines1;
    [TextArea(2, 4)] public string[] branchingLines2;

    //Create the Giz1o so you can see the radius
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
