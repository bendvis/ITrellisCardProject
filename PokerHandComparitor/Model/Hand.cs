using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandComparitor.Model
{
    public class Hand : INotifyPropertyChanged
    {
        public static readonly int HAND_SIZE = 5;

        ObservableCollection<Card> _cards;
        private string _playerName;
        private HandCategory _category;
        private Card _highCard;

        private static Random rand = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Card> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cards"));
            }
        }

        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlayerName"));
            }
        }

        public HandCategory Category
        {
            get => _category;
            set
            {
                _category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category"));
            }
        }
        public Card HighCard
        {
            get => _highCard;
            set
            {
                _highCard = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HighCard"));
            }
        }


        public Hand(string Name)
        {
            
            PlayerName = Name;
            Cards = new ObservableCollection<Card>();
            for(int i = 0; i < HAND_SIZE; ++i)
            {
                Cards.Add(new Card(CardRank.Ace, CardSuit.Spade));
            }

            GenerateRandomHand();
            UpdateScoring();
        }

        public Hand(string Name, ObservableCollection<Card> cards)
        {
            PlayerName = Name;

            if(cards.Count() != HAND_SIZE)
            {
                throw new ArgumentException("Invalid Card list size passed to Hand Constructor.");
            }

            Cards = cards;
            UpdateScoring();
        }

        public void GenerateRandomHand()
        {
            foreach(Card c in Cards)
            {
                c.Rank = (CardRank)rand.Next(Enum.GetNames(typeof(CardRank)).Length);
                c.Suit = (CardSuit)rand.Next(Enum.GetNames(typeof(CardSuit)).Length);
            }

            UpdateScoring();
        }
        
        public void ReplaceCard(int index, Card card)
        {
            if(index >= HAND_SIZE)
            {
                throw new ArgumentException("Invalid index passed to ReplaceCard.");
            }

            Cards[index] = card;
            UpdateScoring();
        }

        public void UpdateScoring()
        {
            SortHand();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cards"));

            HighCard = null;

            HighCard = GetStraightFlushHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.StraightFlush;
                return;
            }

            HighCard = GetFourOfAKindHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.FourOfAKind;
                return;
            }

            HighCard = GetFullHouseHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.FullHouse;
                return;
            }

            HighCard = GetFlushHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.Flush;
                return;
            }

            HighCard = GetStraightHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.Straight;
                return;
            }

            HighCard = GetThreeOfAKindHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.ThreeOfAKind;
                return;
            }

            HighCard = GetTwoPairHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.TwoPair;
                return;
            }

            HighCard = GetPairHighCard();
            if (HighCard != null)
            {
                Category = HandCategory.Pair;
                return;
            }

            HighCard = GetSingleHighCard();
            Category = HandCategory.SingleHigh;
        }

        public Card GetStraightFlushHighCard()
        {
            CardSuit suit = Cards[0].Suit;
            CardRank baseRank = Cards[0].Rank;

            for (int i = 0; i < HAND_SIZE; ++i)
            {
                if (Cards[i].Rank != (baseRank + i))
                {
                    return null;
                }
                if (Cards[i].Suit != suit)
                {
                    return null;
                }
            }

            return Cards[HAND_SIZE - 1];
        }

        public Card GetFourOfAKindHighCard()
        {
            if(IsXOfAKind(1, 4))
            {
                return Cards[4];
            }

            if(IsXOfAKind(0, 4))
            {
                return Cards[3];
            }

            return null;
        }

        public Card GetFullHouseHighCard()
        {
            if((IsXOfAKind(0, 2) && IsXOfAKind(2, 3)) ||
               (IsXOfAKind(0, 3) && IsXOfAKind(3, 2)))
            {
                return Cards[4];
            }
            return null;
        }

        public Card GetFlushHighCard()
        {
            CardSuit suit = Cards[0].Suit;

            foreach (Card c in Cards)
            {
                if (c.Suit != suit)
                {
                    return null;
                }
            }

            return Cards[HAND_SIZE - 1];
        }

        public Card GetStraightHighCard()
        {
            CardRank baseRank = Cards[0].Rank;

            for (int i = 0; i < HAND_SIZE; ++i)
            {
                if (Cards[i].Rank != (baseRank + i))
                {
                    return null;
                }
            }

            return Cards[HAND_SIZE - 1];
        }

        public Card GetThreeOfAKindHighCard()
        {
            if (IsXOfAKind(2, 3))
            {
                return Cards[4];
            }

            if (IsXOfAKind(1, 3))
            {
                return Cards[3];
            }

            if (IsXOfAKind(0, 3))
            {
                return Cards[2];
            }

            return null;
        }

        public Card GetTwoPairHighCard()
        {
            if(IsXOfAKind(3, 2) && IsXOfAKind(1, 2))
            {
                return Cards[4];
            }

            if (IsXOfAKind(2, 2) && IsXOfAKind(0, 2))
            {
                return Cards[3];
            }

            return null;
        }

        public Card GetPairHighCard()
        {
            for(int i = 3; i >= 0; --i)
            {
                if (IsXOfAKind(i, 2))
                {
                    return Cards[i+1];
                }
            }

            return null;
        }

        public Card GetSingleHighCard()
        {
            return Cards[4];
        }

        private bool IsXOfAKind(int startIndex, int count)
        {
            CardRank rank = Cards[startIndex].Rank;

            for(int i = startIndex; i < (startIndex + count); ++i)
            {
                if(Cards[i].Rank != rank)
                {
                    return false;
                }
            }

            return true;
        }

        private void SortHand()
        {
            var sortable = new List<Card>(Cards);
            sortable.Sort();

            for (int i = 0; i < sortable.Count; ++i)
            {
                Cards.Move(Cards.IndexOf(sortable[i]), i);
            }
        }
    }
}
