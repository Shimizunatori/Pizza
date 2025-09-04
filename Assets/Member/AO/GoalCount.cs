using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCount : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform goal;
    [SerializeField]
    private Text distanceText;
    [SerializeField]
    private float goalSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goal.position = Vector2.MoveTowards(goal.position, player.position, goalSpeed * Time.deltaTime);
        float distance = Vector2.Distance(player.position, goal.position);
        distanceText.text = "–Ú“I’n‚Ü‚Å : " + distance.ToString("F0") + "m";

        if (distance <= 0.1f)
        {
            distanceText.text = "‚ ‚Í‚ñ";
        }
    }
}
