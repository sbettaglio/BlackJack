using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
  class Program
  {
    static void Main(string[] args)
    {
      var dT = new Deck();
      var dealer = new DealerMethods();

      var deck = dT.GenerateDeck();
      deck = dT.ShuffleDeck(deck);
      var playerTotal = 0;

      var dealerHand = new List<Card>();
      var playerHand = new List<Card>();

      dealerHand = dealer.DealHand(deck, dealerHand);
      playerHand = dealer.DealHand(deck, playerHand);
      Console.WriteLine(playerHand[0].DisplayCard());
      Console.WriteLine(playerHand[1].DisplayCard());
      playerTotal = dealer.PlayerHit(deck, playerHand, playerTotal);

      if (playerTotal > 21)
      {
        Console.WriteLine($"Bust! Player looses!");
      }
      else
      {
        var dealerTotal = dealer.DealerReveal(dealerHand);
        dealer.DealerHit(dealerHand, dealerTotal);
      }
    }
  }
}







