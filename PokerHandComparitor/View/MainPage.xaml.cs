using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PokerHandComparitor.ViewModel;
using PokerHandComparitor.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokerHandComparitor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HandViewModel ViewModel { get; set; } = new HandViewModel(new Model.Hand("Player 1"), new Model.Hand("Player 2"));

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel;
            ViewModel.UpdateWinner();
        }

        private void LeftPlayerRandomize_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RandomizeHand(true);
        }

        private void RightPlayerRandomize_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RandomizeHand(false);
        }

        private void RightPlayerCards_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.ReplaceCard(false, RightPlayerCards.Items.IndexOf(e.ClickedItem), 
                                  (CardRank)ChangeRankMenu.SelectedIndex, (CardSuit)ChangeSuitMenu.SelectedIndex);
        }

        private void LeftPlayerCards_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.ReplaceCard(true, LeftPlayerCards.Items.IndexOf(e.ClickedItem), 
                (CardRank)ChangeRankMenu.SelectedIndex, (CardSuit)ChangeSuitMenu.SelectedIndex);
        }
    }
}
