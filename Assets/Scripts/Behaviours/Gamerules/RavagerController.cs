using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavagerController : MonoBehaviour {

    public int[][] Map;
    public bool isGameStarted = false;
    public GameObject menuUI;
    public GameObject gameUI;

    private void UpdateUIActivity() {
        //TODO: Need some sort of awesome effect
        if (isGameStarted) {
            menuUI.SetActive(false);
            gameUI.SetActive(true);
        } else {
            gameUI.SetActive(false);
            menuUI.SetActive(true);
        }

    }

    // Start is called before the first frame update
    void Start() {

    }

    void Update() {
        if (isGameStarted) {
            // Gameplay logic, else is for menu
            if (GetPlayerStats().isDead()) {
                //TODO: Improve
                Debug.Log("Lol you died");
                EndGame();
            }
        } else {
            // Menu logic
        }
    }

    public CharacterStats GetPlayerStats() {
        CharacterStats statsComponent = GetComponent<CharacterStats>();
        return statsComponent ? statsComponent : throw new MissingComponentException("Can't find player character stats in gamerules");
    }

    public void NewGame() {
        isGameStarted = true;
        UpdateUIActivity();
    }
    public void LoadGame() {
        isGameStarted = true;
        UpdateUIActivity();
    }

    public void EndGame() {
        isGameStarted = false;
        UpdateUIActivity();
    }
}
