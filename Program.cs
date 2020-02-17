using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
  class Program
  {
    static void Main(string[] args)
    {
      var play = true;
      while (play)
      {

        //The game should be played with a standard deck of playing cards 52
        var suits = new List<string>() { "spades", "clubs", "hearts", "diamonds" };
        var ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        var deck = new List<Card>();
        for (var i = 0; i < suits.Count; i++)
        {
          for (var j = 0; j < ranks.Count; j++)
          {
            var card = new Card();
            card.Suit = suits[i];
            card.Rank = ranks[j];
            deck.Add(card);
          }
        }
        //The house should be dealt with two cards, hidden from the player until the house reveals its hand.
        Random rnd = new Random();
        for (var i = deck.Count - 1; i >= 0; i--)
        {
          var j = rnd.Next(deck.Count);
          var swap = deck[i];
          deck[i] = deck[j];
          deck[j] = swap;
        }
        var dealerHand = new List<Card>();
        var playerHand = new List<Card>();
        var cardIndex = 0;
        cardIndex++;


        dealerHand.Add(deck[0]);
        dealerHand.Add(deck[1]);
        // for (var i = 0; i < dealerHand.Count; i++)
        // {
        //   Console.WriteLine("Dealer is holding");
        //   Console.WriteLine($"{dealerHand[i].DisplayCard()}");
        // }

        //The player should be dealt with two cards, visible to the player
        playerHand.Add(deck[2]);
        playerHand.Add(deck[3]);
        deck.RemoveAt(0);
        deck.RemoveAt(1);
        deck.RemoveAt(2);
        deck.RemoveAt(3);
        Console.WriteLine("Player is Holding.");
        for (var i = 0; i < playerHand.Count; i++)
        {
          Console.WriteLine($"{playerHand[i].DisplayCard()}");
        }
        var playerTotal = playerHand[0].GetCardValue() + playerHand[1].GetCardValue();
        var dealerTotal = dealerHand[0].GetCardValue() + dealerHand[1].GetCardValue();
        Console.WriteLine($"Player's total is {playerTotal}");

        if (playerTotal == 21)
        {
          Console.WriteLine("BlackJack! Player wins!");
          Console.WriteLine("Do you want to play again? (YES) or (NO)");
          var playAgain = Console.ReadLine().ToLower();
          if (playAgain == "no")
          {
            Console.WriteLine("Thanks for playing!");
            play = false;
          }
          else
          {
            play = true;
          }

        }
        else if (playerTotal > 21)
        {
          Console.WriteLine("Bust! Players loses!");
          Console.WriteLine("Do you want to play again? (YES) or (NO)");
          var playAgain = Console.ReadLine().ToLower();
          if (playAgain == "no")
          {
            Console.WriteLine("Thanks for playing!");
            play = false;
          }
          else
          {
            play = true;
          }
        }
        //The player should have a chance to hit (i.e., be dealt another card) until they decide to stop or they bust (i.e., their total is over 21 ).
        else
        {
          Console.WriteLine("Do you want to (HIT) or (STAY)?");
          var nextCard = Console.ReadLine().ToLower();
          if (nextCard == "hit")
          {
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            playerTotal += playerHand.Last().GetCardValue();
            Console.WriteLine($"Player drew {playerHand.Last().DisplayCard()}");
            Console.WriteLine("Player is now holding:");
            for (var i = 0; i < playerHand.Count; i++)
            {
              Console.WriteLine($"{playerHand[i].DisplayCard()}");
            }
            Console.WriteLine($"With a current total of {playerTotal}");
            if (playerTotal == 21)
            {
              while (dealerTotal < 17)
              {
                Console.WriteLine("Dealer is holding:");
                for (var i = 0; i < dealerHand.Count; i++)
                {
                  Console.WriteLine($"{dealerHand[i].DisplayCard()}");
                }
                Console.WriteLine($"Dealer's current total is: {dealerTotal}");
                dealerHand.Add(deck[0]);
                deck.RemoveAt(0);
                dealerTotal += dealerHand.Last().GetCardValue();
                Console.WriteLine($"Dealer drew {dealerHand.Last().DisplayCard()}");
                Console.WriteLine($"With a current total of {dealerTotal}");
              }
              if (dealerTotal > 21)
              {
                Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Player wins! ");

                Console.WriteLine("Do you want to play again? (YES) or (NO)");
                var playAgain = Console.ReadLine().ToLower();
                if (playAgain == "no")
                {
                  Console.WriteLine("Thanks for playing!");
                  play = false;
                }
              }
              else if (dealerTotal == 21)
              {
                Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Push, it's a tie!");
                Console.WriteLine("Do you want to play again? (YES) or (NO)");
                var playAgain = Console.ReadLine().ToLower();
                if (playAgain == "no")
                {
                  Console.WriteLine("Thanks for playing!");
                  play = false;
                }
              }
            }
            else if (playerTotal > 21)
            {
              Console.WriteLine("Bust! Player went over 21!");
              Console.WriteLine("Do you want to play again? (YES) or (NO)");
              var playAgain = Console.ReadLine().ToLower();
              if (playAgain == "no")
              {
                Console.WriteLine("Thanks for playing!");
                play = false;
              }
            }
            bool bust = true;
            while (playerTotal < 21 && bust)
            {
              Console.WriteLine("Do you want to (STAY) or (HIT)?");
              nextCard = Console.ReadLine().ToLower();
              if (nextCard == "stay")
              {
                Console.WriteLine($"Player stays at a count of {playerTotal}");
                //bool total = true;
                while (dealerTotal < 17)
                {
                  Console.WriteLine("Dealer is holding:");
                  for (var i = 0; i < dealerHand.Count; i++)
                  {
                    Console.WriteLine($"{dealerHand[i].DisplayCard()}");
                  }
                  Console.WriteLine($"Dealer's current total is: {dealerTotal}");
                  dealerHand.Add(deck[0]);
                  deck.RemoveAt(0);
                  dealerTotal += dealerHand.Last().GetCardValue();
                  Console.WriteLine($"Dealer drew {dealerHand.Last().DisplayCard()}");
                  Console.WriteLine($"With a current total of {dealerTotal}");

                }
                if (dealerTotal >= 17)
                {
                  if (dealerTotal > playerTotal && dealerTotal <= 21)
                  {
                    Console.WriteLine($"Dealer has a total of {dealerTotal} and player has total of {playerTotal}. Dealer wins!");


                    Console.WriteLine("Do you want to play again? (YES) or (NO)");
                    var playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "no")
                    {
                      Console.WriteLine("Thanks for playing!");
                      play = false;
                      bust = false;
                    }
                    else
                    {
                      bust = false;
                    }

                  }
                  else if (dealerTotal < playerTotal && dealerTotal <= 21)
                  {
                    Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Player wins! ");

                    //bust = false;
                    Console.WriteLine("Do you want to play again? (YES) or (NO)");
                    var playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "no")
                    {
                      Console.WriteLine("Thanks for playing!");
                      play = false;
                      bust = false;
                    }
                    else
                    {
                      bust = false;
                    }

                  }
                  else if (dealerTotal == playerTotal)
                  {
                    Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Push, it's a a tie!");

                    Console.WriteLine("Do you want to play again? (YES) or (NO)");
                    var playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "no")
                    {
                      Console.WriteLine("Thanks for playing!");
                      play = false;

                      bust = false;
                    }
                    else
                    {
                      bust = false;
                    }

                  }
                  else if (dealerTotal > 21)
                  {
                    Console.WriteLine($"Dealer has a total of {dealerTotal}. Bust, dealer went over 21!");

                    Console.WriteLine("Do you want to play again? (YES) or (NO)");
                    var playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "no")
                    {
                      Console.WriteLine("Thanks for playing!");
                      play = false;
                      bust = false;
                    }
                    else
                    {
                      bust = false;
                    }

                  }
                  else if (playerTotal > 21)
                  {
                    Console.WriteLine($"Player has a total of {playerTotal}. Bust, player went over 21!");

                    //bust = false;
                    Console.WriteLine("Do you want to play again? (YES) or (NO)");
                    var playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "no")
                    {
                      Console.WriteLine("Thanks for playing!");
                      play = false;
                      bust = false;
                    }
                    else
                    {
                      bust = false;
                    }
                  }

                }
              }
              else if (nextCard == "hit")
              {
                playerHand.Add(deck[0]);
                deck.RemoveAt(0);
                playerTotal += playerHand.Last().GetCardValue();
                Console.WriteLine($"Player drew {playerHand.Last().DisplayCard()}");
                Console.WriteLine("Player is now holding:");
                for (var i = 0; i < playerHand.Count; i++)
                {
                  Console.WriteLine($"{playerHand[i].DisplayCard()}");
                }
                Console.WriteLine($"With a current total of {playerTotal}");
                if (playerTotal > 21)
                {
                  Console.WriteLine("Bust!. Player went over 21!");
                  //bust = false;
                  Console.WriteLine("Do you want to play again? (YES) or (NO)");
                  var playAgain = Console.ReadLine().ToLower();
                  if (playAgain == "no")
                  {
                    Console.WriteLine("Thanks for playing!");
                    bust = false;

                    play = false;
                  }
                  else
                  {
                    bust = false;
                  }
                  Console.WriteLine("Do you want to (STAY) or (HIT)?");
                  nextCard = Console.ReadLine().ToLower();
                  if (nextCard == "stay")
                  {
                    Console.WriteLine($"Player stays at a count of {playerTotal}");

                    //bool total = true;
                    while (dealerTotal < 17)
                    {
                      Console.WriteLine("Dealer is holding:");
                      for (var i = 0; i < dealerHand.Count; i++)
                      {
                        Console.WriteLine($"{dealerHand[i].DisplayCard()}");
                      }
                      Console.WriteLine($"Dealer's current total is: {dealerTotal}");
                      deck.RemoveAt(0);
                      dealerHand.Add(deck[0]);
                      Console.WriteLine($"Dealer drew {dealerHand.Last().DisplayCard()}");
                      dealerTotal += dealerHand.Last().GetCardValue();
                      Console.WriteLine($"With a current total of {dealerTotal}");
                      if (dealerTotal >= 17)
                      {
                        if (dealerTotal > playerTotal && dealerTotal <= 21)
                        {
                          Console.WriteLine($"Dealer has a total of {dealerTotal} and player has total of {playerTotal}. Dealer wins!");

                          Console.WriteLine("Do you want to play again? (YES) or (NO)");
                          playAgain = Console.ReadLine().ToLower();
                          if (playAgain == "no")
                          {
                            Console.WriteLine("Thanks for playing!");
                            play = false;
                            bust = false;
                          }
                          else
                          {
                            bust = false;
                          }
                        }
                        else if (dealerTotal < playerTotal && playerTotal <= 21)
                        {
                          Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Player wins! ");

                          Console.WriteLine("Do you want to play again? (YES) or (NO)");
                          playAgain = Console.ReadLine().ToLower();
                          if (playAgain == "no")
                          {
                            Console.WriteLine("Thanks for playing!");
                            play = false;
                            bust = false;
                          }
                          else
                          {
                            bust = false;
                          }
                        }
                        else if (dealerTotal == playerTotal)
                        {
                          Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Push, it's a a tie!");

                          Console.WriteLine("Do you want to play again? (YES) or (NO)");
                          playAgain = Console.ReadLine().ToLower();
                          if (playAgain == "no")
                          {
                            Console.WriteLine("Thanks for playing!");
                            play = false;
                            bust = false;
                          }
                          else
                          {
                            bust = false;
                          }
                        }
                        else if (dealerTotal > 21)
                        {
                          Console.WriteLine($"Dealer has a total of {dealerTotal}. Bust, dealer went over 21!");

                          Console.WriteLine("Do you want to play again? (YES) or (NO)");
                          playAgain = Console.ReadLine().ToLower();
                          if (playAgain == "no")
                          {
                            Console.WriteLine("Thanks for playing!");
                            play = false;
                            bust = false;
                          }
                          else
                          {
                            bust = false;
                          }
                        }
                        else if (playerTotal > 21)
                        {
                          Console.WriteLine($"Player has a total of {playerTotal}. Bust, player went over 21!");

                          Console.WriteLine("Do you want to play again? (YES) or (NO)");
                          playAgain = Console.ReadLine().ToLower();
                          if (playAgain == "no")
                          {
                            Console.WriteLine("Thanks for playing!");
                            play = false;
                            bust = false;
                          }
                          else
                          {
                            bust = false;
                          }
                        }
                      }

                    }
                    if (dealerTotal >= 17)
                    {
                      if (dealerTotal > playerTotal && dealerTotal <= 21)
                      {
                        Console.WriteLine($"Dealer has a total of {dealerTotal} and player has total of {playerTotal}. Dealer wins!");
                        Console.WriteLine("Do you want to play again? (YES) or (NO)");
                        playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "no")
                        {
                          Console.WriteLine("Thanks for playing!");
                          play = false;
                        }
                      }
                      else if (dealerTotal < playerTotal && playerTotal <= 21)
                      {
                        Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Player wins! ");
                        Console.WriteLine("Do you want to play again? (YES) or (NO)");
                        playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "no")
                        {
                          Console.WriteLine("Thanks for playing!");
                          play = false;
                        }
                      }
                      else if (dealerTotal == playerTotal)
                      {
                        Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Push, it's a a tie!");
                        Console.WriteLine("Do you want to play again? (YES) or (NO)");
                        playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "no")
                        {
                          Console.WriteLine("Thanks for playing!");
                          play = false;
                        }
                      }
                      else if (dealerTotal > 21)
                      {
                        Console.WriteLine($"Dealer has a total of {dealerTotal}. Bust, dealer went over 21!");
                        Console.WriteLine("Do you want to play again? (YES) or (NO)");
                        playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "no")
                        {
                          Console.WriteLine("Thanks for playing!");
                          play = false;
                        }
                      }
                      else if (playerTotal > 21)
                      {
                        Console.WriteLine($"Player has a total of {playerTotal}. Bust, player Went over 21!");
                        Console.WriteLine("Do you want to play again? (YES) or (NO)");
                        playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "no")
                        {
                          Console.WriteLine("Thanks for playing!");
                          play = false;
                        }
                      }
                    }
                  }


                }

              }
            }
          }
          else if (nextCard == "stay")
          {
            Console.WriteLine($"Player stays at a count of {playerTotal}");
            while (dealerTotal <= 16)
            {
              Console.WriteLine("Dealer is holding:");
              for (var i = 0; i < dealerHand.Count; i++)
              {
                Console.WriteLine($"{dealerHand[i].DisplayCard()}");
              }
              Console.WriteLine($"Dealer's current total is: {dealerTotal}");
              dealerHand.Add(deck[1]);
              deck.RemoveAt(1);

              Console.WriteLine($"Dealer drew {dealerHand.Last().DisplayCard()}");
              dealerTotal += dealerHand.Last().GetCardValue();
              Console.WriteLine($"With a current total of {dealerTotal}");
              
            }
            if (dealerTotal >= 17)
            {
              if (dealerTotal > playerTotal && dealerTotal <= 21)
              {
                Console.WriteLine("Dealer is holding:");
                for (var i = 0; i < dealerHand.Count; i++)
                {
                  Console.WriteLine($"{dealerHand[i].DisplayCard()}");
                }
                Console.WriteLine($"Dealer has a total of {dealerTotal} and player has total of {playerTotal}. Dealer wins!");
                Console.WriteLine("Do you want to play again? (YES) or (NO)");
                var playAgain = Console.ReadLine().ToLower();
                if (playAgain == "no")
                {
                  Console.WriteLine("Thanks for playing!");
                  play = false;
                }
              }
              else if (dealerTotal < playerTotal)
              {
                Console.WriteLine("Dealer is holding:");
                for (var i = 0; i < dealerHand.Count; i++)
                {
                  Console.WriteLine($"{dealerHand[i].DisplayCard()}");
                }
                Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Player wins! ");
                Console.WriteLine("Do you want to play again? (YES) or (NO)");
                var playAgain = Console.ReadLine().ToLower();
                if (playAgain == "no")
                {
                  Console.WriteLine("Thanks for playing!");
                  play = false;
                }
              }
              else if (dealerTotal == playerTotal)
              {
                Console.WriteLine("Dealer is holding:");
                for (var i = 0; i < dealerHand.Count; i++)
                {
                  Console.WriteLine($"{dealerHand[i].DisplayCard()}");
                }
                Console.WriteLine($"Dealer has a total of {dealerTotal} and player has a total of {playerTotal}. Push, it's a a tie!");
                Console.WriteLine("Do you want to play again? (YES) or (NO)");
                var playAgain = Console.ReadLine().ToLower();
                if (playAgain == "no")
                {
                  Console.WriteLine("Thanks for playing!");
                  play = false;
                }
              }
              else if (dealerTotal > 21)
              {
                Console.WriteLine("Dealer is holding:");
                for (var i = 0; i < dealerHand.Count; i++)
                {
                  Console.WriteLine($"{dealerHand[i].DisplayCard()}");
                }
                Console.WriteLine($"Dealer has a total of {dealerTotal}. Bust, dealer went over 21!");
                Console.WriteLine("Do you want to play again? (YES) or (NO)");
                var playAgain = Console.ReadLine().ToLower();
                if (playAgain == "no")
                {
                  Console.WriteLine("Thanks for playing!");
                  play = false;
                }
              }

            }

          }
        }

      }

    }
  }
}







