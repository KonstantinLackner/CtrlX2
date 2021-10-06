﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class Word : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
    {
        private Transform transform;
        private CanvasGroup canvasGroup;
        private GameObject GameStateManagerGameObject;
        private GameStateManager GameStateManagerComponent;
        public Canvas canvas { get; set; }

        private void Awake()
        {
            GameStateManagerGameObject = GameObject.Find("Game State Manager");
            GameStateManagerComponent = GameStateManagerGameObject.GetComponent<GameStateManager>();
            
            transform = GetComponent<Transform>();
            canvasGroup = GetComponent<CanvasGroup>();
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (GameStateManagerComponent.operationMode == OperationMode.Drag)
            {
                // Has to be done for all words to prevent accidentally dropping onto the wrong word
                foreach (var word in GameStateManagerComponent.words)
                {
                    word.GetComponent<CanvasGroup>().blocksRaycasts = false;
                }

                canvasGroup.alpha = 0.6f;
                LinkedListNode<GameObject> targetNode = GameStateManagerComponent.words.Find(gameObject);
                GameStateManagerComponent.words.Remove(targetNode);
                printList(GameStateManagerComponent.words);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            foreach (var word in GameStateManagerComponent.words)
            {
                word.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }

            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            printList(GameStateManagerComponent.words);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (GameStateManagerComponent.operationMode == OperationMode.Drag)
            {
                transform.position += new Vector3(eventData.delta.x, 0, 0) / canvas.scaleFactor;
            }
        }

        private void printList(LinkedList<GameObject> words)
        {
            String print = "";
            foreach (var word in words)
            {
                print += " " + word.name;
            }

            Debug.Log(print);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            switch (GameStateManagerComponent.operationMode)
            {
                case OperationMode.Cut:
                    GameStateManagerComponent.changeOperationMode(OperationMode.Drag);
                    LinkedListNode<GameObject> targetNode = GameStateManagerComponent.words.Find(gameObject);
                    GameStateManagerComponent.words.Remove(targetNode);
                    printList(GameStateManagerComponent.words);
                    Destroy(gameObject);
                    GameStateManagerComponent.AlignWords();
                    break;
                
                case OperationMode.ChangeEnding:
                    // No word has been set to operate on - set this
                    if (GameStateManagerComponent.wordEndingChangeWord == null)
                    {
                        GameStateManagerComponent.wordEndingChangeWord = gameObject;
                    }
                    // This is the word operated on - change its ending
                    if (GameStateManagerComponent.wordEndingChangeWord == gameObject)
                    {
                        GetComponent<WordEndingChange>().changeEnding();
                    }
                    // Another word is operated on and this is finished - switch modes to drag
                    else
                    {
                        GameStateManagerComponent.changeOperationMode(OperationMode.Drag);
                    }

                    break;
            }
        }
    }
}