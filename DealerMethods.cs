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
    public int DealerHit(List<Card> dealerHand, List<Card> deck, int dealerTotal)
    {
      while (dealerTotal < 17)
      {
        Console.WriteLine($"Dealer hits");
        dealerHand.Add(deck[0]);
        dealerTotal = dealerHand.Sum(c => c.Value);
        deck.RemoveAt(0);
        Console.WriteLine($"Dealer drew: {dealerHand.Last().DisplayCard()} and now has a total of {dealerTotal}");
      }
      return dealerTotal;
    }
    public void CheckWinner(int dealerTotal, int playerTotal)
    {
      if (dealerTotal > 21)
      {
        Console.WriteLine($"Dealer Bust! Player Wins!");
      }
      else if (dealerTotal > playerTotal)
      {
        Console.WriteLine($"Dealer's Total is {dealerTotal} and player's total is {playerTotal}");
        Console.WriteLine($"Dealer wins!");
      }
      else if (dealerTotal < playerTotal)
      {
        Console.WriteLine($"Dealer's Total is {dealerTotal} and player's total is {playerTotal}");
        Console.WriteLine($"Player wins!");
      }
      else
      {
        Console.WriteLine($"Dealer's Total is {dealerTotal} and player's total is {playerTotal}");
        Console.WriteLine($"Push! It's a tie!");
      }
    }
  }
}