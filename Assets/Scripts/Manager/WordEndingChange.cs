using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    // Has to be attached to ever adjective and verb
    public class WordEndingChange : MonoBehaviour
    {
        // You walk over the burning bridge
        // You walking over the burn bridge
        // You burn the bridge
        // The bridge burns you
        // The bridge walks over you

        private Text textComponent;
        private String text;
        private GameStateManager gameStateManager;

        private void Start()
        {
            gameStateManager = GameObject.Find("Canvas").GetComponentInChildren<GameStateManager>();
        }

        // Called by the word OnPointerDown depending on the state
        public void changeEnding()
        {
            // Has to be done here as a call in awaking would be too early
            textComponent = GetComponent<Text>();
            text = textComponent.text;

            if (text.Length > 1)
            {
                if (text.Substring(text.Length - 1).Equals("s"))
                {
                    text = text.Substring(0, text.Length - 1);
                    text += "ing";
                }
                else if (text.Substring(text.Length - 3).Equals("ing"))
                {
                    text = text.Substring(0, text.Length - 3);
                }
                else
                {
                    text += "s";
                }
            }

            textComponent.text = text;

            // Reload variation
            gameStateManager.AlignWords();

            // Make validateButton clickable again
            GameObject.Find("ValidateButton").GetComponent<Image>().color = Color.black;
            GameObject.Find("ValidateButton").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}