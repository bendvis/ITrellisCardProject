
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandComparitor.Model;

namespace PokerHandUnitTests
{
    [TestClass]
    public class CardConstruction
    {
        [TestMethod]
        public void CardConstructionTest()
        {
            const CardRank ExpectedRank = CardRank.Ace;
            const CardSuit ExpectedSuit = CardSuit.Spade;

            Card created = new Card(CardRank.Ace, CardSuit.Spade);

            Assert.AreEqual(created.Rank, ExpectedRank);
            Assert.AreEqual(created.Suit, ExpectedSuit);
        }
    }

    [TestClass]
    public class CardComparison
    {
        private Card HighRankHighSuit = new Card(CardRank.King, CardSuit.Spade);
        private Card LowRankLowSuit = new Card(CardRank.Three, CardSuit.Heart);

        private Card LowRankHighSuit = new Card(CardRank.Two, CardSuit.Spade);
        private Card HighRankLowSuit = new Card(CardRank.Ace, CardSuit.Heart);

        private Card LowRankSameSuit  = new Card(CardRank.Two, CardSuit.Heart);
        private Card HighRankSameSuit = new Card(CardRank.Ace, CardSuit.Heart);

        private Card SameRankLowSuit = new Card(CardRank.Jack, CardSuit.Diamond);
        private Card SameRankHighSuit = new Card(CardRank.Jack, CardSuit.Club);

        private Card EqualCard1 = new Card(CardRank.Eight, CardSuit.Club);
        private Card EqualCard2 = new Card(CardRank.Eight, CardSuit.Club);

        [TestMethod]
        public void GreaterThanTest()
        {
            Assert.IsTrue(HighRankHighSuit > LowRankLowSuit,  string.Format("Greater Than Failed: {0} > {1}", HighRankHighSuit, LowRankLowSuit  ));
            Assert.IsTrue(HighRankLowSuit  > LowRankHighSuit, string.Format("Greater Than Failed: {0} > {1}", HighRankLowSuit , LowRankHighSuit ));
            Assert.IsTrue(HighRankSameSuit > LowRankSameSuit, string.Format("Greater Than Failed: {0} > {1}", HighRankSameSuit, LowRankSameSuit ));
            Assert.IsTrue(SameRankHighSuit > SameRankLowSuit, string.Format("Greater Than Failed: {0} > {1}", SameRankHighSuit, SameRankLowSuit ));

            Assert.IsFalse(LowRankLowSuit  > HighRankHighSuit, string.Format("Greater Than Failed: {0} > {1}", LowRankLowSuit,  HighRankHighSuit ));
            Assert.IsFalse(LowRankHighSuit > HighRankLowSuit,  string.Format("Greater Than Failed: {0} > {1}", LowRankHighSuit, HighRankLowSuit  ));
            Assert.IsFalse(LowRankSameSuit > HighRankSameSuit, string.Format("Greater Than Failed: {0} > {1}", LowRankSameSuit, HighRankSameSuit ));
            Assert.IsFalse(SameRankLowSuit > SameRankHighSuit, string.Format("Greater Than Failed: {0} > {1}", SameRankLowSuit, SameRankHighSuit ));
            Assert.IsFalse(EqualCard1      > EqualCard2,       string.Format("Greater Than Failed: {0} > {1}", EqualCard1,      EqualCard2 ));
        }

        [TestMethod]
        public void LessThanTest()
        {
            Assert.IsTrue(LowRankLowSuit  < HighRankHighSuit, string.Format("Less Than Failed: {0} < {1}", LowRankLowSuit, HighRankHighSuit));
            Assert.IsTrue(LowRankHighSuit < HighRankLowSuit,  string.Format("Less Than Failed: {0} < {1}", LowRankHighSuit, HighRankLowSuit));
            Assert.IsTrue(LowRankSameSuit < HighRankSameSuit, string.Format("Less Than Failed: {0} < {1}", LowRankSameSuit, HighRankSameSuit));
            Assert.IsTrue(SameRankLowSuit < SameRankHighSuit, string.Format("Less Than Failed: {0} < {1}", SameRankLowSuit, SameRankHighSuit));

            Assert.IsFalse(HighRankHighSuit < LowRankLowSuit,  string.Format("Less Than Failed: {0} < {1}", HighRankHighSuit, LowRankLowSuit  ));
            Assert.IsFalse(HighRankLowSuit  < LowRankHighSuit, string.Format("Less Than Failed: {0} < {1}", HighRankLowSuit , LowRankHighSuit ));
            Assert.IsFalse(HighRankSameSuit < LowRankSameSuit, string.Format("Less Than Failed: {0} < {1}", HighRankSameSuit, LowRankSameSuit ));
            Assert.IsFalse(SameRankHighSuit < SameRankLowSuit, string.Format("Less Than Failed: {0} < {1}", SameRankHighSuit, SameRankLowSuit ));
            Assert.IsFalse(EqualCard1       < EqualCard2,      string.Format("Less Than Failed: {0} < {1}", EqualCard1,      EqualCard2 ));
        }

        [TestMethod]
        public void GreaterThanEqualTest()
        {
            Assert.IsTrue(HighRankHighSuit >= LowRankLowSuit,  string.Format("Greater Than Equal Failed: {0} >= {1}", HighRankHighSuit, LowRankLowSuit  ));
            Assert.IsTrue(HighRankLowSuit  >= LowRankHighSuit, string.Format("Greater Than Equal Failed: {0} >= {1}", HighRankLowSuit , LowRankHighSuit ));
            Assert.IsTrue(HighRankSameSuit >= LowRankSameSuit, string.Format("Greater Than Equal Failed: {0} >= {1}", HighRankSameSuit, LowRankSameSuit ));
            Assert.IsTrue(SameRankHighSuit >= SameRankLowSuit, string.Format("Greater Than Equal Failed: {0} >= {1}", SameRankHighSuit, SameRankLowSuit ));
            Assert.IsTrue(EqualCard1       >= EqualCard2,      string.Format("Greater Than Equal Failed: {0} >= {1}", EqualCard1,      EqualCard2 ));

            Assert.IsFalse(LowRankLowSuit  >= HighRankHighSuit, string.Format("Greater Than Equal Failed: {0} >= {1}", LowRankLowSuit,  HighRankHighSuit ));
            Assert.IsFalse(LowRankHighSuit >= HighRankLowSuit,  string.Format("Greater Than Equal Failed: {0} >= {1}", LowRankHighSuit, HighRankLowSuit  ));
            Assert.IsFalse(LowRankSameSuit >= HighRankSameSuit, string.Format("Greater Than Equal Failed: {0} >= {1}", LowRankSameSuit, HighRankSameSuit ));
            Assert.IsFalse(SameRankLowSuit >= SameRankHighSuit, string.Format("Greater Than Equal Failed: {0} >= {1}", SameRankLowSuit, SameRankHighSuit ));
        }

        [TestMethod]
        public void LessThanEqualTest()
        {
            Assert.IsTrue(LowRankLowSuit  <= HighRankHighSuit, string.Format("Less Than Equal Failed: {0} <= {1}", LowRankLowSuit, HighRankHighSuit));
            Assert.IsTrue(LowRankHighSuit <= HighRankLowSuit,  string.Format("Less Than Equal Failed: {0} <= {1}", LowRankHighSuit, HighRankLowSuit));
            Assert.IsTrue(LowRankSameSuit <= HighRankSameSuit, string.Format("Less Than Equal Failed: {0} <= {1}", LowRankSameSuit, HighRankSameSuit));
            Assert.IsTrue(SameRankLowSuit <= SameRankHighSuit, string.Format("Less Than Equal Failed: {0} <= {1}", SameRankLowSuit, SameRankHighSuit));
            Assert.IsTrue(EqualCard1      <= EqualCard2,       string.Format("Less Than Equal Failed: {0} <= {1}", EqualCard1,      EqualCard2 ));

            Assert.IsFalse(HighRankHighSuit <= LowRankLowSuit,  string.Format("Less Than Equal Failed: {0} <= {1}", HighRankHighSuit, LowRankLowSuit  ));
            Assert.IsFalse(HighRankLowSuit  <= LowRankHighSuit, string.Format("Less Than Equal Failed: {0} <= {1}", HighRankLowSuit , LowRankHighSuit ));
            Assert.IsFalse(HighRankSameSuit <= LowRankSameSuit, string.Format("Less Than Equal Failed: {0} <= {1}", HighRankSameSuit, LowRankSameSuit ));
            Assert.IsFalse(SameRankHighSuit <= SameRankLowSuit, string.Format("Less Than Equal Failed: {0} <= {1}", SameRankHighSuit, SameRankLowSuit ));
        }

        [TestMethod]
        public void EqualTest()
        {
            Assert.IsTrue(EqualCard1 == EqualCard2, string.Format("Not Equal Failed: {0} <= {1}", EqualCard1, EqualCard2));

            Assert.IsFalse(LowRankLowSuit  == HighRankHighSuit, string.Format("Equal Failed: {0} == {1}", LowRankLowSuit, HighRankHighSuit));
            Assert.IsFalse(LowRankHighSuit == HighRankLowSuit,  string.Format("Equal Failed: {0} == {1}", LowRankHighSuit, HighRankLowSuit));
            Assert.IsFalse(LowRankSameSuit == HighRankSameSuit, string.Format("Equal Failed: {0} == {1}", LowRankSameSuit, HighRankSameSuit));
            Assert.IsFalse(SameRankLowSuit == SameRankHighSuit, string.Format("Equal Failed: {0} == {1}", SameRankLowSuit, SameRankHighSuit));

            Assert.IsFalse(HighRankHighSuit == LowRankLowSuit,  string.Format("Equal Failed: {0} == {1}", HighRankHighSuit, LowRankLowSuit));
            Assert.IsFalse(HighRankLowSuit  == LowRankHighSuit, string.Format("Equal Failed: {0} == {1}", HighRankLowSuit, LowRankHighSuit));
            Assert.IsFalse(HighRankSameSuit == LowRankSameSuit, string.Format("Equal Failed: {0} == {1}", HighRankSameSuit, LowRankSameSuit));
            Assert.IsFalse(SameRankHighSuit == SameRankLowSuit, string.Format("Equal Failed: {0} == {1}", SameRankHighSuit, SameRankLowSuit));
        }

        [TestMethod]
        public void NotEqualTest()
        {
            Assert.IsTrue(LowRankLowSuit  != HighRankHighSuit, string.Format("Not Equal Failed: {0} != {1}", LowRankLowSuit, HighRankHighSuit));
            Assert.IsTrue(LowRankHighSuit != HighRankLowSuit,  string.Format("Not Equal Failed: {0} != {1}", LowRankHighSuit, HighRankLowSuit));
            Assert.IsTrue(LowRankSameSuit != HighRankSameSuit, string.Format("Not Equal Failed: {0} != {1}", LowRankSameSuit, HighRankSameSuit));
            Assert.IsTrue(SameRankLowSuit != SameRankHighSuit, string.Format("Not Equal Failed: {0} != {1}", SameRankLowSuit, SameRankHighSuit));

            Assert.IsTrue(HighRankHighSuit != LowRankLowSuit,  string.Format("Not Equal Failed: {0} != {1}", HighRankHighSuit, LowRankLowSuit));
            Assert.IsTrue(HighRankLowSuit  != LowRankHighSuit, string.Format("Not Equal Failed: {0} != {1}", HighRankLowSuit, LowRankHighSuit));
            Assert.IsTrue(HighRankSameSuit != LowRankSameSuit, string.Format("Not Equal Failed: {0} != {1}", HighRankSameSuit, LowRankSameSuit));
            Assert.IsTrue(SameRankHighSuit != SameRankLowSuit, string.Format("Not Equal Failed: {0} != {1}", SameRankHighSuit, SameRankLowSuit));

            Assert.IsFalse(EqualCard1 != EqualCard2, string.Format("Not Equal Failed: {0} != {1}", EqualCard1, EqualCard2));
        }
    }

    [TestClass]
    public class HandScoring
    {
        [TestMethod]
        public void StraightFlushTest()
        {
            HandCategory expectedCategory = HandCategory.StraightFlush;
            Card expectedHighCard = new Card(CardRank.Ace, CardSuit.Spade);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Ten,   CardSuit.Spade),
                                                new Card(CardRank.Jack,  CardSuit.Spade),
                                                new Card(CardRank.Queen, CardSuit.Spade),
                                                new Card(CardRank.King,  CardSuit.Spade),
                                                new Card(CardRank.Ace,   CardSuit.Spade) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void FourOfAKindLowTest()
        {
            HandCategory expectedCategory = HandCategory.FourOfAKind;
            Card expectedHighCard = new Card(CardRank.Jack, CardSuit.Spade);  // High card should *not* be the Ace of Spades.

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Jack, CardSuit.Spade),
                                                new Card(CardRank.Jack, CardSuit.Heart),
                                                new Card(CardRank.Jack, CardSuit.Diamond),
                                                new Card(CardRank.Jack, CardSuit.Club),
                                                new Card(CardRank.Ace,  CardSuit.Spade) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void FourOfAKindHighTest()
        {
            HandCategory expectedCategory = HandCategory.FourOfAKind;
            Card expectedHighCard = new Card(CardRank.Jack, CardSuit.Spade);  // High card should *not* be the Ace of Spades.

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Jack, CardSuit.Spade),
                                                new Card(CardRank.Jack, CardSuit.Heart),
                                                new Card(CardRank.Jack, CardSuit.Diamond),
                                                new Card(CardRank.Jack, CardSuit.Club),
                                                new Card(CardRank.Three,  CardSuit.Spade) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void FullHouse3Low2HighTest()
        {
            HandCategory expectedCategory = HandCategory.FullHouse;
            Card expectedHighCard = new Card(CardRank.Jack, CardSuit.Spade);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Five, CardSuit.Spade),
                                                new Card(CardRank.Five, CardSuit.Heart),
                                                new Card(CardRank.Jack, CardSuit.Diamond),
                                                new Card(CardRank.Jack, CardSuit.Club),
                                                new Card(CardRank.Jack,  CardSuit.Spade) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void FullHouse2Low3HighTest()
        {
            HandCategory expectedCategory = HandCategory.FullHouse;
            Card expectedHighCard = new Card(CardRank.Jack, CardSuit.Spade);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Five, CardSuit.Spade),
                                                new Card(CardRank.Jack, CardSuit.Club),
                                                new Card(CardRank.Five, CardSuit.Heart),
                                                new Card(CardRank.Five, CardSuit.Diamond),
                                                new Card(CardRank.Jack,  CardSuit.Spade) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void FlushTest()
        {
            HandCategory expectedCategory = HandCategory.Flush;
            Card expectedHighCard = new Card(CardRank.Queen, CardSuit.Diamond);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Queen,   CardSuit.Diamond),
                                                new Card(CardRank.Eight, CardSuit.Diamond),
                                                new Card(CardRank.Five,  CardSuit.Diamond),
                                                new Card(CardRank.Three, CardSuit.Diamond),
                                                new Card(CardRank.Seven,  CardSuit.Diamond) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void StraightTest()
        {
            HandCategory expectedCategory = HandCategory.Straight;
            Card expectedHighCard = new Card(CardRank.Six, CardSuit.Diamond);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Two,   CardSuit.Spade),
                                                new Card(CardRank.Five,  CardSuit.Diamond),
                                                new Card(CardRank.Four,  CardSuit.Diamond),
                                                new Card(CardRank.Six,   CardSuit.Diamond),
                                                new Card(CardRank.Three, CardSuit.Diamond) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void ThreeOfAKindTest()
        {
            HandCategory expectedCategory = HandCategory.ThreeOfAKind;
            Card expectedHighCard = new Card(CardRank.Six, CardSuit.Club);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Two,   CardSuit.Spade),
                                                new Card(CardRank.Six,   CardSuit.Club),
                                                new Card(CardRank.Six,   CardSuit.Heart),
                                                new Card(CardRank.Six,   CardSuit.Diamond),
                                                new Card(CardRank.Three, CardSuit.Diamond) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void TwoPairTest()
        {
            HandCategory expectedCategory = HandCategory.TwoPair;
            Card expectedHighCard = new Card(CardRank.Queen, CardSuit.Spade);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Queen, CardSuit.Spade),
                                                new Card(CardRank.Queen, CardSuit.Club),
                                                new Card(CardRank.Six,   CardSuit.Heart),
                                                new Card(CardRank.Six,   CardSuit.Diamond),
                                                new Card(CardRank.Ace,   CardSuit.Diamond) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }

        [TestMethod]
        public void PairTest()
        {
            HandCategory expectedCategory = HandCategory.Pair;
            Card expectedHighCard = new Card(CardRank.Six, CardSuit.Diamond);

            ObservableCollection<Card> cards = new ObservableCollection<Card>{
                                                new Card(CardRank.Two,   CardSuit.Spade),
                                                new Card(CardRank.Queen, CardSuit.Club),
                                                new Card(CardRank.Six,   CardSuit.Heart),
                                                new Card(CardRank.Six,   CardSuit.Diamond),
                                                new Card(CardRank.Three, CardSuit.Diamond) };

            Hand hand = new Hand("TestName", cards);

            Assert.AreEqual(hand.Category, expectedCategory);
            Assert.AreEqual(hand.HighCard, expectedHighCard);
        }
    }
}
