using UnityEngine;

public class Stairs : MonoBehaviour
{
    public bool isInStairs;
    public void OnTriggerStay2D(Collider2D stairs)
    {
        isInStairs = true;
    }

    public void OnTriggerExit2D(Collider2D stairs)
    {
        isInStairs = false;
    }
}
