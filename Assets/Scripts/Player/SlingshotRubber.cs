using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotRubber : MonoBehaviour
{
    public Transform leftRubber;
    public Transform rightRubber;

    void adjustRubber(Transform bird, Transform rubber)
    {
        // Rotation
        Vector2 dir = rubber.position - bird.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rubber.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Length
        float dist = Vector3.Distance(bird.position, rubber.position);
        dist += bird.GetComponent<Collider2D>().bounds.extents.x;
        rubber.localScale = new Vector2(dist / 8, 1);
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        // Stretch the Rubber between bird and slingshot
        adjustRubber(coll.transform, leftRubber);
        adjustRubber(coll.transform, rightRubber);
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        // Make the Rubber shorter
        leftRubber.localScale = new Vector2(0, 1);
        rightRubber.localScale = new Vector2(0, 1);
    }
}
