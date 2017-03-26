using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeckManager
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>();

        /// <summary>
        /// Create a deck from the cards contained in the file provided.
        /// </summary>
        /// <param name="pathToDeckFile"> Filename in "Decks\" directory (i.e. "Season1_Spawn.deck"
        /// or "\Custom\HellOnEarth.deck").</param>
        public Deck(string pathToDeckFile)
        {
            string[] lines = System.IO.File.ReadAllLines("Assets\\Decks\\" + pathToDeckFile);

            var pathToCards = "Assets\\Cards\\" + lines[0];

            for (int i = 1; i < lines.Length; ++i)
            {
                var pathToCard = pathToCards + lines[i] + ".jpg";
                Sprite image = LoadNewSprite(pathToCard);
                Cards.Add(new Card(lines[i], image));
            }
        }

        /// <summary>
        /// Load a PNG or JPG image from disk into a sprite.
        /// </summary>
        /// <param name="FilePath">Filename in "Cards\" (i.e. "Spawn\1 Zombicide\1.jpg").</param>
        /// <param name="PixelsPerUnit">[Optional]</param>
        /// <returns>Sprite with the specified image.</returns>
        private Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
        {
            var sprite = new Sprite();
            var texture = LoadTexture(FilePath);
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                new Vector2(0, 0), PixelsPerUnit);

            return sprite;
        }

        /// <summary>
        /// Load a PNG or JPG file from disk to a Texture2D.
        /// </summary>
        /// <param name="FilePath">Filename in "Cards\" (i.e. "Spawn\1 Zombicide\1.jpg").</param>
        /// <returns>Texture2D with image, or null if operation fails.</returns>
        private Texture2D LoadTexture(string FilePath)
        {
            Texture2D Tex2D;
            byte[] FileData;

            if (System.IO.File.Exists(FilePath))
            {
                FileData = System.IO.File.ReadAllBytes(FilePath);
                Tex2D = new Texture2D(1, 1);

                // Load the imagedata into the texture (size is set automatically).
                if (Tex2D.LoadImage(FileData))
                {
                    return Tex2D;
                }
            }
            return null;
        }
    }
}
