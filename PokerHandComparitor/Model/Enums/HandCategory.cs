namespace PokerHandComparitor.Model
{
    public enum HandCategory
    {
        SingleHigh = 0,
        Pair = 1,
        TwoPair = 2,
        ThreeOfAKind = 3,
        Straight = 4,
        Flush = 5,
        FullHouse = 6,
        FourOfAKind = 7,
        StraightFlush = 8,
    }

    public static class HandCategoryExt
    {
        public static string HandCategoryToString(HandCategory cat)
        {
            switch(cat)
            {
                case HandCategory.SingleHigh:
                    return "Single High Card";
                case HandCategory.Pair:
                    return "Pair";
                case HandCategory.TwoPair:
                    return "Two Pair";
                case HandCategory.ThreeOfAKind:
                    return "Three of a Kind";
                case HandCategory.Straight:
                    return "Straight";
                case HandCategory.Flush:
                    return "Flush";
                case HandCategory.FullHouse:
                    return "Full House";
                case HandCategory.FourOfAKind:
                    return "Four of a Kind";
                case HandCategory.StraightFlush:
                    return "Straight Flush";
            }

            return "";
        }
    }
    
}