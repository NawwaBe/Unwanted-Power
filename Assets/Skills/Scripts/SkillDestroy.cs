using UnityEngine;

public class SkillDestroy : MonoBehaviour
{
    private bool pickUp;
    private void OnTriggerStay2D(Collider2D other)
    {
        pickUp = Input.GetKeyDown(KeyCode.E);
        if (other.gameObject.tag == "Player" && pickUp)
        {
            Destroy(gameObject);
        }
    }
}
