using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public BeatCollision bc;
    public Streak streak;
    public Vector3 Start = new Vector3(0, 0, 30);
    public string Colour;
    public string Key;
    public int LocalScore = 0;

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {

            if (bc.Presswindow == true)
            {
                GameObject.Find(bc.CurrentBeat).SetActive(false);
                LocalScore += 100;
                streak.streak += 1;
                bc.Presswindow = false;

            }
            else
            {
                LocalScore -= 10;
                streak.streak = 0;
            }
        }
    }
}