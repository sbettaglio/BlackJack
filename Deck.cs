using System;
using System.Collections.Generic;

namespace BlackJack
{
  public class Deck
  {
    public List<Card> GenerateDeck()
    {
      var suits = new List<string>() { "spades", "clubs", "hearts", "diamonds" };
      var ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
      var deck = new List<Card>();
      for (var i = 0; i < suits.Count; i++)
      {
        for (var j = 0; j < ranks.Count; j++)
        {
          var card = new Card();
          card.Rank = ranks[j];
          card.Suit = suits[i];
          card.Value = card.GetCardValue();
          if (card.Suit == "diamonds" || card.Suit == "hearts")
          {
            card.ColorOfTheCard = "red";
          }
          else
          {
            card.ColorOfTheCard = "black";
          }
          deck.Add(card);
        }
      }
      return deck;
    }

    public List<Card> ShuffleDeck(List<Card> deck)
    {
      Random rnd = new Random();
      for (var i = deck.Count - 1; i >= 0; i--)
      {
        var j = rnd.Next(deck.Count);
        var swap = deck[i];
        deck[i] = deck[j];
        deck[j] = swap;
      }
      return deck;
    }
  }
}