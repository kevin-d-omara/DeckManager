using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeckManager
{
    public class Card
    {
        public string Name { get; private set; }
        public Sprite Image { get; private set; }

        public Card(string name, Sprite image)
        {
            Name = name;
            Image = image;
        }
    }
}
