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
            deck = new Deck(deckFile);
            CreateObjectsFromCards();
        }

        private void CreateObjectsFromCards()
        {
            foreach (Card card in deck.Cards)
            {
                var instance = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                instance.GetComponent<SpriteRenderer>().sprite = card.Image;
            }
        }
    }
}
