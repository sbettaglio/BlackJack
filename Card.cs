namespace BlackJack
{
  public class Card
  {
    public string Rank { get; set; }
    public string Suit { get; set; }

    public string DisplayCard()
    {
      return $"{Rank} of {Suit}";
    }
    public int GetCardValue()
    {
      if (Rank == "ace")
      {
        return 11;
      }
      else if (Rank == "king" || Rank == "queen" || Rank == "jack")
      {
        return 10;
      }
      else
      {
        return int.Parse(Rank);
      }
    }

  }

}