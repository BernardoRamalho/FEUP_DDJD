using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
  private Rigidbody2D m_Rigidbody2D;

  public MoveScript moveScript;
  public JetpackScript jetpackScript;
  public float damage = 10f;

  public bool shieldActive = true;

  public Animator animator;

  public GameObject hudIcon;

  public void activateShield() {
    shieldActive = true;
    animator.SetBool("ShieldActive", true);
    hudIcon.GetComponent<ChangeSprite>().SwitchSprite();
  }

  public void deactivateShield() {
    shieldActive = false;
    animator.SetBool("ShieldActive", false);
    hudIcon.GetComponent<ChangeSprite>().SwitchSprite();
  }

  void OnTriggerEnter2D (Collider2D hitInfo)
    {
      if(hitInfo.name.StartsWith("Floor")){
        return;
      }

      if(hitInfo.name.StartsWith("PowerUp")){
        return;
      }

      if(hitInfo.name.StartsWith("Obstacle")){
        if (shieldActive) {
          deactivateShield();
          return;
        } else {
          EndGame();
          return;
        }
      }

      if(hitInfo.name.StartsWith("Enemy")){
        if (shieldActive) {
          deactivateShield();
          return;
        } else {
          EndGame();
          return;
        }
      }
    }

    public void Move(float move, bool jetpack) {
        moveScript.Move(move);

        if (jetpack) {
            jetpackScript.Activate();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
