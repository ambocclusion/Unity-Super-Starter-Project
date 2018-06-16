using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStarterProject
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        public enum GameStates
        {
            RUNNING,
            PAUSED,
            CUTSCENE
        }

        public GameStates CurrentState = GameStates.RUNNING;
        public bool SceneIsPausable = false;
        public GameObject PauseScreen;

        public List<Action> pauseEvents = new List<Action>();
        public List<Action> unpauseEvents = new List<Action>();

        protected override void Awake()
        {
            if (SceneManager.GetActiveScene().name.Contains("Main Menu") == false)
            {
                SceneIsPausable = true;
            }
            else
            {
                SceneIsPausable = false;
            }

            base.Awake();

            PauseScreen.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Pause"))
            {
                TogglePause();
            }

            if (CurrentState == GameStates.PAUSED)
            {
                Time.timeScale = 0f;
                PauseScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                PauseScreen.SetActive(false);
            }
        }

        public void TogglePause()
        {
            if (CurrentState == GameStates.PAUSED)
            {
                UnPauseGame();
            }
            else if (CurrentState == GameStates.RUNNING)
            {
                PauseGame();
            }
        }

        public void PauseGame()
        {
            if (SceneIsPausable)
            {
                CurrentState = GameStates.PAUSED;
                pauseEvents.ForEach(p => p.Invoke());
            }
        }

        public void UnPauseGame()
        {
            CurrentState = GameStates.RUNNING;
            unpauseEvents.ForEach(p => p.Invoke());
            Input.ResetInputAxes();
        }

        public bool IsPaused()
        {
            return CurrentState == GameStates.PAUSED;
        }
    }
}