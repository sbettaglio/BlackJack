using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
  public class DealerMethods
  {
    public List<Card> DealHand(List<Card> deck, List<Card> hand)
    {
      hand.Add(deck[0]);
      hand.Add(deck[1]);
      deck.RemoveRange(0, 2);
      return hand;
    }


    public int PlayerHit(List<Card> deck, List<Card> playerHand, int playerTotal)
    {
      var keepHitting = true;
      playerTotal = playerHand.Sum(c => c.Value);
      if (playerTotal == 21)
      {
        Console.WriteLine("Black Jack! Player wins!");
        return playerTotal;
      }
      else
      {
        Hit(deck, playerHand, playerTotal, keepHitting);
        playerTotal = playerHand.Sum(c => c.Value);
        return playerTotal;
      }
    }

    public void Hit(List<Card> deck, List<Card> playerHand, int playerTotal, bool keepHitting)
    {
      while (keepHitting && playerTotal < 21)
      {
        Console.WriteLine("Do you want to hit or stay? (H)/(S) ");
        var hit = Console.ReadLine().ToLower();
        if (hit == "h")
        {
          playerHand.Add(deck[0]);
          playerTotal = playerHand.Sum(c => c.Value);
          Console.WriteLine($"Player drew: {playerHand.Last().DisplayCard()} and now has a total of {playerTotal}");
          deck.RemoveAt(0);
        }
        else
        {
          keepHitting = false;
        }

      }
    }
    public int DealerReveal(List<Card> dealerHand)
    {
      Console.WriteLine($"Dealer reveals");
      foreach (var card in dealerHand)
      {
        Console.WriteLine(card.DisplayCard());
      }
      return dealerHand.Sum(c => c.Value);
    }
    public void DealerHit(List<Card> dealerHand, int dealerTotal)
    {
      while (dealerTotal < 17)
      {

      }
    }
  }
}