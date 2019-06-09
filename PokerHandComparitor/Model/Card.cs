using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandComparitor.Model
{
    public class Card : IComparable
    {
        public Card(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
        
        private CardRank _rank;
        private CardSuit _suit;

        public CardRank Rank { get => _rank; set => _rank = value; }
        public CardSuit Suit { get => _suit; set => _suit = value; }

        public int CompareTo(object obj)
        {
            if(obj is Card)
            {
                return Compare(this, (Card)obj);
            }

            throw new ArgumentException("Cannot compare Card to unknown type.");
        }

        public static bool operator <(Card left, Card right)
        {
            return Compare(left, right) < 0;
        }

        public static bool operator >(Card left, Card right)
        {
            return Compare(left, right) > 0;
        }

        public static bool operator <=(Card left, Card right)
        {
            return Compare(left, right) <= 0;
        }

        public static bool operator >=(Card left, Card right)
        {
            return Compare(left, right) >= 0;
        }

        public static bool operator ==(Card left, Card right)
        {
            if(ReferenceEquals(left, null) && ReferenceEquals(right, null) )
            {
                return true;
            }
            else if(ReferenceEquals(left, null))
            {
                return false;
            }
            else if (ReferenceEquals(right, null))
            {
                return false;
            }

            return Compare(left, right) == 0;
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Card))
            {
                return false;
            }

            return Compare(this, (Card)obj) == 0;
        }

        public override int GetHashCode()
        {
            return ((int)this.Rank) * 4 + (int)(this.Suit);
        }

        private static int Compare(Card left, Card right)
        {
            if (left.Rank == right.Rank)
            {
                if (left.Suit == right.Suit)
                {
                    return 0;
                }
                
                return left.Suit - right.Suit;
            }

            return left.Rank - right.Rank;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", RankToChar(this.Rank), SuitToChar(this.Suit));
        }

        public static char RankToChar(CardRank rank)
        {
            switch(rank)
            {
                case CardRank.Two:
                    return '2';
                case CardRank.Three:
                    return '3';
                case CardRank.Four:
                    return '4';
                case CardRank.Five:
                    return '5';
                case CardRank.Six:
                    return '6';
                case CardRank.Seven:
                    return '7';
                case CardRank.Eight:
                    return '8';
                case CardRank.Nine:
                    return '9';
                case CardRank.Ten:
                    return 'T';
                case CardRank.Jack:
                    return 'J';
                case CardRank.Queen:
                    return 'Q';
                case CardRank.King:
                    return 'K';
                case CardRank.Ace:
                    return 'A';
            }

            throw new ArgumentException("Invalid CardRank passed in to RankToChar.");
        }

        public static char SuitToChar(CardSuit suit)
        {
            switch(suit)
            {
                case CardSuit.Heart:
                    return 'H';
                case CardSuit.Diamond:
                    return 'D';
                case CardSuit.Club:
                    return 'C';
                case CardSuit.Spade:
                    return 'S';
            }

            throw new ArgumentException("Invalid CardSuit passed in to SuitToChar.");
        }

        public static char SuitToSymbol(CardSuit suit)
        {
            switch (suit)
            {
                case CardSuit.Heart:
                    return '♥';
                case CardSuit.Diamond:
                    return '♦';
                case CardSuit.Club:
                    return '♣';
                case CardSuit.Spade:
                    return '♠';
            }

            throw new ArgumentException("Invalid CardSuit passed in to SuitToChar.");
        }

        public string ToFriendlyString()
        {
            return string.Format("{0} of {1}s", Rank.ToString(), Suit.ToString());
        }
    }
}
