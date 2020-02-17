// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace BlackJack$"
// {
//   class Program
//   {
//     static void Main(string[] args)
//     {
//       bool play = true;
//       while (play)
//       {


//         Console.WriteLine("Do you want to play BlackJack? Press enter if yes.");
//         var playBlackJack = Console.ReadLine().ToLower();
//         if (playBlackJack == "")
//         {
//           Console.WriteLine("Let's play!");
//           //The game should be played with a standard deck of playing cards 52
//           var suits = new List<string>() { "spades", "clubs", "hearts", "diamonds" };
//           var ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
//           var deck = new List<Card>();
//           for (var i = 0; i < suits.Count; i++)
//           {
//             for (var j = 0; j < ranks.Count; j++)
//             {
//               var card = new Card();
//               card.Suit = suits[i];
//               card.Rank = ranks[j];
//               deck.Add(card);
//             }
//           }
//           //The house should be dealt with two cards, hidden from the player until the house reveals its hand.
//           Random rnd = new Random();
//           for (var i = deck.Count - 1; i >= 0; i--)
//           {
//             var j = rnd.Next(deck.Count);
//             var swap = deck[i];
//             deck[i] = deck[j];
//             deck[j] = swap;
//           }
//           var dealerHand = new List<Card>();
//           var playerHand = new List<Card>();
//           var cardIndex = 0;
//           cardIndex++;


//           dealerHand.Add(deck[0]);
//           dealerHand.Add(deck[1]);
//           Console.WriteLine($"Dealer open card is: {dealerHand[1].DisplayCard()}");
//           //The player should be dealt with two cards, visible to the player
//           playerHand.Add(deck[2]);
//           playerHand.Add(deck[3]);
//           deck.RemoveAt(0);
//           deck.RemoveAt(1);
//           deck.RemoveAt(2);
//           deck.RemoveAt(3);
//           Console.WriteLine($"The player cards are {playerHand[0].DisplayCard()} and {playerHand[1].DisplayCard()}");
//           var playerTotal = (playerHand[0].GetCardValue() + playerHand[1].GetCardValue());
//           Console.WriteLine($"Player's total is {playerTotal} ");
//           if (playerTotal == 21)
//           {
//             Console.WriteLine("BlackJack! Player wins!");
//             play = false;
//           }
//           else if (playerTotal > 21)
//           {

//             Console.WriteLine($"Player drew {playerHand.Last().DisplayCard()}. Player's new total is {playerTotal}. Bust, dealer wins!");
//           }
//           var dealerTotal = (dealerHand[0].GetCardValue() + dealerHand[1].GetCardValue());
//           Console.WriteLine($"Dealer is showing is {dealerHand[1].DisplayCard()}, with a showing count of {dealerHand.Last().GetCardValue()} ");

//           //The player should have a chance to hit (i.e., be dealt another card) until they decide to stop or they bust (i.e., their total is over 21 ).
//           Console.WriteLine("(STAY) or (HIT)");
//           var reveal = Console.ReadLine().ToLower();
//           if (reveal == "hit")
//           {
//             playerHand.Add(deck[0]);
//             deck.RemoveAt(0);
//             playerTotal = (playerTotal + playerHand.Last().GetCardValue());
//             if (playerTotal > 21)
//             {

//               Console.WriteLine($"Player drew {playerHand.Last().DisplayCard()}. Player's new total is {playerTotal}. Bust, dealer wins!");
//             }


//             else if (reveal == "hit")
//             {
//               // playerHand.Add(deck[0]);
//               // deck.RemoveAt(0);
//               // playerTotal = playerTotal + playerHand.Last().GetCardValue();
//               // Console.WriteLine($"Player drew a {playerHand.Last().DisplayCard()} player's new total is {playerTotal}. Dealer is showing is {dealerHand.Last().DisplayCard()}, with a showing count of {dealerHand.Last().DisplayCard()} ");
//               // if (playerTotal > 21)
//               // {
//               //   Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Bust. Dealer wins!");
//               // }
//               bool over = true;
//               over = (playerTotal < 21);
//               while (over)
//               {
//                 playerHand.Add(deck[0]);
//                 deck.RemoveAt(0);
//                 playerTotal = (playerTotal + playerHand.Last().GetCardValue());
//                 Console.WriteLine($"Player drew {playerHand.Last().DisplayCard()}. Player's new total is {playerTotal}. Dealer is showing is {dealerHand.Last().DisplayCard()}, with a showing count of {dealerHand.Last().GetCardValue()}  ");

//                 Console.WriteLine("(STAY) or (Hit)?");
//                 reveal = Console.ReadLine().ToLower();

//               }
//               if (playerTotal == 21)
//               {
//                 if (playerTotal == 21 && dealerTotal == 21)
//                 {
//                   Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Push. It's a tie!");
//                 }

//               }
//               else if (reveal == "stay" && playerTotal > dealerTotal)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Push, its a tie!");
//               }
//               else if (reveal == "stay" && playerTotal < dealerTotal)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Dealer wins!");
//               }
//               if (dealerTotal > 17)
//               {
//                 if (dealerTotal == playerTotal)
//                 {
//                   Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Push. It's a tie!");
//                 }
//                 else if (dealerTotal > playerTotal && dealerTotal <= 21)
//                 {
//                   Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Dealer wins!");
//                 }
//                 else if (dealerTotal > playerTotal && dealerTotal > 21)
//                 {
//                   Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Dealer bust. Player wins!");
//                 }
//                 else if (dealerTotal < playerTotal)
//                 {
//                   Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Player wins!");
//                 }

//               }
//               else if (playerTotal >= 21)
//               {

//                 if (playerTotal == 21 && dealerTotal < 21)
//                 {
//                   Console.WriteLine($"Players total is {playerTotal} ");
//                   Console.WriteLine($"Dealer reveals {dealerHand[0].DisplayCard()}");
//                   Console.WriteLine($"Dealer's hand is {dealerHand[0].DisplayCard()} and {dealerHand[1].DisplayCard()} with a total of {dealerTotal} ");
//                   while (dealerTotal <= 16)
//                   {
//                     dealerHand.Add(deck[0]);
//                     deck.RemoveAt(0);
//                     dealerTotal = dealerTotal + dealerHand.Last().GetCardValue();
//                     Console.WriteLine($"Dealer drew {dealerHand.Last().DisplayCard()}. Dealer's total is {dealerTotal} ");
//                   }
//                   if (dealerTotal > 17)
//                   {
//                     if (dealerTotal == playerTotal)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Push. It's a tie!");
//                     }
//                     else if (dealerTotal > playerTotal && dealerTotal <= 21)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Dealer wins!");
//                     }
//                     else if (dealerTotal > playerTotal && dealerTotal > 21)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Dealer bust. Player wins!");
//                     }
//                     else if (dealerTotal < playerTotal)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Player wins!");
//                     }
//                   }
//                   else if (dealerTotal == 17)
//                   {
//                     if (dealerTotal > playerTotal)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Dealer wins!");
//                     }
//                     else if (dealerTotal == playerTotal)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Push. It's a tie!");
//                     }
//                     else if (dealerTotal < playerTotal)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Player wins!");
//                     }
//                     else if (playerTotal > 21)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Bust. Dealer wins!");
//                     }
//                     else if (reveal == "stay" && playerTotal > dealerTotal)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Push, its a tie!");
//                     }
//                     else if (reveal == "stay" && playerTotal < dealerTotal)
//                     {
//                       Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Dealer wins!");
//                     }

//                   }
//                 }
//               }
//             }
//           }




//           else if (reveal == "stay")
//           {
//             Console.WriteLine($"Dealer reveals {dealerHand[0].DisplayCard()}");
//             Console.WriteLine($"Dealer's hand is {dealerHand[0].DisplayCard()} and {dealerHand[1].DisplayCard()} with a total of {dealerTotal} ");
//             while (dealerTotal <= 16)
//             {
//               dealerHand.Add(deck[0]);
//               deck.RemoveAt(0);
//               dealerTotal = dealerTotal + dealerHand.Last().GetCardValue();
//               Console.WriteLine($"Dealer drew {dealerHand.Last().DisplayCard()}. Dealer's total is {dealerTotal} ");
//             }
//             if (dealerTotal > 17)
//             {
//               if (dealerTotal == playerTotal)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Push. It's a tie!");
//               }
//               else if (dealerTotal > playerTotal && dealerTotal <= 21)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Dealer wins!");
//               }
//               else if (dealerTotal > playerTotal && dealerTotal > 21)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Dealer bust. Player wins!");
//               }
//               else if (dealerTotal < playerTotal)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Player wins!");
//               }
//             }
//             else if (dealerTotal == 17)
//             {
//               if (dealerTotal > playerTotal)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Dealer wins!");
//               }
//               else if (dealerTotal == playerTotal)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}. Push. It's a tie!");
//               }
//               else if (dealerTotal < playerTotal)
//               {
//                 Console.WriteLine($"Dealer's total is {dealerTotal} and the player's total is {playerTotal}.Player wins!");
//               }
//             }


//           }
//         }
//         else
//         {
//           play = false;
//         }



//       }
//       Console.WriteLine("See you later!");


//     }

//   }
// }
