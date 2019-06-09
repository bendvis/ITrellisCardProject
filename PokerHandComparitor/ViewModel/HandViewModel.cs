using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHandComparitor.Model;

namespace PokerHandComparitor.ViewModel
{
    class HandViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Hand _leftHand;
        private Hand _rightHand;
        private string _winnerText;
        private string _winnerName;
        private bool leftPlayerWins = false;
        private string _leftPlayerCategory;
        private string _leftPlayerHighCard;
        private string _rightPlayerCategory;
        private string _rightPlayerHighCard;

        public HandViewModel(Hand leftHand, Hand rightHand)
        {
            _leftHand = leftHand ?? new Hand("Player 1");
            _rightHand = rightHand ?? new Hand("Player 2");
            UpdateWinner();
        }

        public string[] ChangeRankList
        {
            get { return Enum.GetNames(typeof(CardRank)); }
            set{}
        }

        public string[] ChangeSuitList
        {
            get { return Enum.GetNames(typeof(CardSuit)); }
            set {}
        }

        public string LeftPlayerName
        {
            get => _leftHand.PlayerName;
            set
            {
                _leftHand.PlayerName = value;
                UpdateWinner();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftPlayerName"));
            }
        }

        public string RightPlayerName
        {
            get => _rightHand.PlayerName;
            set
            {
                _rightHand.PlayerName = value;
                UpdateWinner();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightPlayerName"));
            }
        }

        public string LeftPlayerCategoryString
        {
            get => _leftPlayerCategory;
            set
            {
                _leftPlayerCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftPlayerCategoryString"));
            }
        }

        public string LeftPlayerHighCardString
        {
            get => _leftPlayerHighCard;
            set
            {
                _leftPlayerHighCard = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftPlayerHighCardString"));
            }
        }

        public string RightPlayerCategoryString
        {
            get => _rightPlayerCategory;
            set
            {
                _rightPlayerCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightPlayerCategoryString"));
            }
        }

        public string RightPlayerHighCardString
        {
            get => _rightPlayerHighCard;
            set
            {
                _rightPlayerHighCard = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightPlayerHighCardString"));
            }
        }

        public string WinnerText
        {
            get => _winnerText;
            set
            {
                _winnerText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WinnerText"));
            }
        }

        public string WinnerName
        {
            get => _winnerName;
            set
            {
                _winnerName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WinnerName"));
            }
        }

        public ObservableCollection<Card> LeftPlayerCards
        {
            get => _leftHand.Cards;
            set
            {
                _leftHand.Cards = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftPlayerCards"));
                UpdateWinner();
            }
        }

        public ObservableCollection<Card> RightPlayerCards
        {
            get => _rightHand.Cards;
            set
            {
                _rightHand.Cards = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightPlayerCards"));
                UpdateWinner();
            }
        }

        public void RandomizeHand(bool isLeftPlayer)
        {
            if(isLeftPlayer)
            {
                _leftHand.GenerateRandomHand();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftPlayerCards"));
            }
            else
            {
                _rightHand.GenerateRandomHand();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightPlayerCards"));
            }
            UpdateWinner();
        }

        public void ReplaceCard(bool isLeftPlayer, int cardIndex, CardRank newRank, CardSuit newSuit)
        {
            if(isLeftPlayer)
            {
                _leftHand.ReplaceCard(cardIndex, new Card(newRank, newSuit));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftPlayerCards"));
            }
            else
            {
                _rightHand.ReplaceCard(cardIndex, new Card(newRank, newSuit));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightPlayerCards"));
            }
            UpdateWinner();
        }

        public void UpdateWinner()
        {
            _leftHand.UpdateScoring();
            _rightHand.UpdateScoring();

            bool hasWinner = true;

            if(_leftHand.Category.CompareTo(_rightHand.Category) > 0)
            {
                UpdateDisplayDetails(true);
            }
            else if(_leftHand.Category.CompareTo(_rightHand.Category) < 0)
            {
                UpdateDisplayDetails(false);
            }
            else
            {
                if(_leftHand.HighCard > _rightHand.HighCard)
                {
                    UpdateDisplayDetails(true);
                }
                else if(_leftHand.HighCard > _rightHand.HighCard)
                {
                    UpdateDisplayDetails(false);
                }
                else
                {
                    WinnerName = "Nobody!";
                    hasWinner = false;
                }
            }

            if(hasWinner)
            {
                WinnerText = string.Format("{0} wins with a {1}, and a high card of {2}.",
                                           leftPlayerWins ? LeftPlayerName : RightPlayerName,
                                           leftPlayerWins ? LeftPlayerCategoryString : RightPlayerCategoryString,
                                           leftPlayerWins ? LeftPlayerHighCardString : RightPlayerHighCardString);
            }
            else
            {
                WinnerText = string.Format("Game ends in a draw.  Both players have a {0} and a high card of {1}.", LeftPlayerCategoryString, LeftPlayerHighCardString);
            }
        }

        private void UpdateDisplayDetails(bool isLeftPlayer)
        {
            leftPlayerWins = isLeftPlayer;

            LeftPlayerHighCardString = _leftHand.HighCard.ToFriendlyString();
            LeftPlayerCategoryString = HandCategoryExt.HandCategoryToString(_leftHand.Category);

            RightPlayerHighCardString = _rightHand.HighCard.ToFriendlyString();
            RightPlayerCategoryString = HandCategoryExt.HandCategoryToString(_rightHand.Category);
        }
    }
}
