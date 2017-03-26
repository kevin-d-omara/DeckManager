using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeckManager
{
    public class Driver : MonoBehaviour
    {
        public string deckFile;
        private Deck deck;
        public GameObject cardPrefab;

        private void Start()
        {
            Debug.Log("start creating deck");
            deck = new Deck(deckFile);
            Debug.Log("end creating deck");

            CreateObjectsFromCards();
        }

        private void Update()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("start create objects from cards");
                CreateObjectsFromCards();
                Debug.Log("end create objects from cards");
            }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            if (Input.touchCount > 0)
            {
                CreateObjectsFromCards();
            }
#endif
        }

        private void CreateObjectsFromCards()
        {
            var position = new Vector3(-24f, -8f, 0f);
            foreach (Card card in deck.Cards)
            {
                var instance = Instantiate(cardPrefab, position, Quaternion.identity) as GameObject;
                instance.name = card.Name;
                instance.GetComponent<SpriteRenderer>().sprite = card.Image;

                position += new Vector3(1f, 0f, 0f);
            }
        }
    }
}
