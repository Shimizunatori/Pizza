using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalCount : MonoBehaviour
{
    [SerializeField]
    private Transform goal;
    [SerializeField]
    private Text distanceText;
    [SerializeField]
    private float goalScaleSpeed;
    [SerializeField]
    private float maxScale;

    private bool isCleared = false;

    void Update()
    {
        if (isCleared) return;

        if (goal.localScale.x < maxScale)
        {
            goal.localScale += Vector3.one * goalScaleSpeed * Time.deltaTime;
        }

        float remaining = Mathf.Max(0, (maxScale - goal.localScale.x) * 10f);
        distanceText.text = "–Ú“I’n‚Ü‚Å : " + remaining.ToString("F0") + "m";

        if (goal.localScale.x >= maxScale)
        {
            isCleared = true;
            distanceText.text = "‚ ‚Í‚ñ";
            SceneManager.LoadScene("Clear");
            SEManager.Instance.StopBgm();
            SEManager.Instance.PlayBgm(BGMType.BGM3);
        }
    }
}
