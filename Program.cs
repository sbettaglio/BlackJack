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
      var feelingLucky = true;

      while (feelingLucky)
      {

        var deck = dT.GenerateDeck();
        deck = dT.ShuffleDeck(deck);
        var playerTotal = 0;

        var dealerHand = new List<Card>();
        var playerHand = new List<Card>();

        dealerHand = dealer.DealHand(deck, dealerHand);
        playerHand = dealer.DealHand(deck, playerHand);
        Console.WriteLine(playerHand[0].DisplayCard());
        Console.WriteLine(playerHand[1].DisplayCard());
        playerTotal = playerHand.Sum(c => c.Value);
        if (playerTotal == 21)
        {
          Console.WriteLine($"Black Jack! Player wins!");
        }
        else
        {
          playerTotal = dealer.PlayerHit(deck, playerHand, playerTotal);

          switch (playerTotal)
          {
            case var expression when playerTotal > 21:
              Console.WriteLine($"Bust! Player looses!");
              break;
            default:
              var dealerTotal = dealer.DealerReveal(dealerHand);
              dealerTotal = dealer.DealerHit(dealerHand, deck, dealerTotal);
              dealer.CheckWinner(dealerTotal, playerTotal);
              break;
          }
        }
        Console.WriteLine("Do you want to play again? (Y)/(N)");
        var letItRide = Console.ReadLine().ToLower();
        if (letItRide == "n")
        {
          Console.WriteLine("Thanks for playing!");
          feelingLucky = false;
        }
        else
        {
          Console.WriteLine("Let it ride!");
        }
      }
    }
  }
}







