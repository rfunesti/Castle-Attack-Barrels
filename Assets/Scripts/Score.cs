using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int threeStars = 3;
    public int twoStars = 5;
    public Text ScoreDisplay;
    public Animator scoreAnimator;
    public int nextLevel = 0;    

    public void EndLevel()
    {
        // FindObjectOfType searches thru scene until it finds the 1st active loaded object
        // matching the provided type
        
        Cannon cannon = FindObjectOfType<Cannon>();
        if (cannon)
        {            
            int numProjectiles = cannon.numProjectiles;

            /* Implement a conditional structure to determine how many stars to give the 
               player based on how many projectiles they fired during the level.
               The fewer projectiles fired, the higher their score.
               Score should be one, two, or three stars. */

            if (numProjectiles < threeStars)
            {
                //print("3 Stars!");
                ScoreDisplay.text = "Three Stars!";
                scoreAnimator.SetInteger("Stars", 3);
            }
            else if (numProjectiles < twoStars) 
            {
                //print("2 Stars!");
                ScoreDisplay.text = "Two Stars!";
                scoreAnimator.SetInteger("Stars", 2);
            }
            else
            {
                //print("1 Star!");
                ScoreDisplay.text = "One Star!";
                scoreAnimator.SetInteger("Stars", 1);
            }            
            Invoke("NextLevel", 3);
        }
    }
    void NextLevel()
    {
        //int current = SceneManager.GetActiveScene().buildIndex;
        //nextLevel = current + 1; 

        //if (nextLevel >= SceneManager.sceneCountInBuildSettings)
        //{
        //    nextLevel = 0;
        //}
       
        SceneManager.LoadScene(nextLevel);
    }
}
