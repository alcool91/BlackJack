using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        Image[] cardFaces = new Image[53];
        PictureBox[] DealerCards = new PictureBox[7];
        PictureBox[] PlayerCards = new PictureBox[9];
        Player player1 = new Player();
        hand player = new hand();
        hand dealer = new hand();
        deck gameDeck = new deck();
        int k = 2, d=2;
        int state = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void deal_cards()
        {
            player.done();
            dealer.done();
            k = 2;
            d = 2;
            foreach (PictureBox i in PlayerCards) i.Visible = false;
            foreach (PictureBox i in DealerCards) i.Visible = false;
            player.add(gameDeck.deal());
            player.add(gameDeck.deal());
            dealer.add(gameDeck.deal());
            dealer.add(gameDeck.deal());
            for (int i = 0; i < player.cards.Count; i++)
            {
                PlayerCards[i].Image = cardFaces[player.cards[i].lookup];
                PlayerCards[i].BringToFront();
                PlayerCards[i].Visible = true;
            }
            for (int i = 0; i < dealer.cards.Count; i++)
            {
                if (i == 0) DealerCards[i].Image = cardFaces[52];
                else DealerCards[i].Image = cardFaces[dealer.cards[i].lookup];
                DealerCards[i].BringToFront();
                DealerCards[i].Visible = true;
            }

            Refresh();
        }
        public void interpret_state()
        {
            switch (state)
            {
                case 0: //pre-deal
                    lblResults.Visible = false;
                    btnDeal.Enabled = true;
                    btnHit.Enabled = false;
                    btnStand.Enabled = true;
                    btnShuffle.Enabled = true;
                    break;
                case 1: //Game in Play
                    lblResults.Visible = false;
                    btnDeal.Enabled = false;
                    btnHit.Enabled = true;
                    btnShuffle.Enabled = false;
                    break;
                case 2: //Bust
                    lblResults.Text = "BUST!";
                    lblResults.ForeColor = Color.Red;
                    lblResults.Visible = true;
                    btnDeal.Enabled = true;
                    btnHit.Enabled = false;
                    btnStand.Enabled = false;
                    btnShuffle.Enabled = true;
                    player1.evaluateBet("loss");
                    break;
                case 3: //BlackJack
                    lblResults.Text = "BlackJack!";
                    lblResults.ForeColor = Color.Gold;
                    lblResults.Visible = true;
                    btnDeal.Enabled = true;
                    btnHit.Enabled = false;
                    btnShuffle.Enabled = true;
                    player1.evaluateBet("BJ");
                    break;
                case 4: //evaluate hands
                    if (dealer.getValue() > 21)
                    {
                        lblResults.Text = "Player Wins!";
                        player1.evaluateBet("win");
                    }
                    else if (player.getValue() > dealer.getValue())
                    {
                        lblResults.Text = "Player Wins!";
                        player1.evaluateBet("win");
                    }
                    else if (player.getValue() == dealer.getValue())
                    {
                        lblResults.Text = "Push!";
                        player1.evaluateBet("push");
                    }
                    else if (player.getValue() < dealer.getValue())
                    {
                        lblResults.Text = "Dealer Wins!";
                        player1.evaluateBet("loss");
                    }
                    lblResults.ForeColor = Color.Black;
                    lblResults.Visible = true;
                    btnHit.Enabled = false;
                    btnDeal.Enabled = true;
                    btnShuffle.Enabled = true;
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gameDeck.populate();
            gameDeck.shuffle();
            cardFaces[0] = WindowsFormsApplication1.Properties.Resources.AD;
            cardFaces[1] = WindowsFormsApplication1.Properties.Resources.AH;
            cardFaces[2] = WindowsFormsApplication1.Properties.Resources.AS;
            cardFaces[3] = WindowsFormsApplication1.Properties.Resources.AC;
            cardFaces[4] = WindowsFormsApplication1.Properties.Resources._2D;
            cardFaces[5] = WindowsFormsApplication1.Properties.Resources._2H;
            cardFaces[6] = WindowsFormsApplication1.Properties.Resources._2S;
            cardFaces[7] = WindowsFormsApplication1.Properties.Resources._2C;
            cardFaces[8] = WindowsFormsApplication1.Properties.Resources._3D;
            cardFaces[9] = WindowsFormsApplication1.Properties.Resources._3H;
            cardFaces[10] = WindowsFormsApplication1.Properties.Resources._3S;
            cardFaces[11] = WindowsFormsApplication1.Properties.Resources._3C;
            cardFaces[12] = WindowsFormsApplication1.Properties.Resources._4D;
            cardFaces[13] = WindowsFormsApplication1.Properties.Resources._4H;
            cardFaces[14] = WindowsFormsApplication1.Properties.Resources._4S;
            cardFaces[15] = WindowsFormsApplication1.Properties.Resources._4C;
            cardFaces[16] = WindowsFormsApplication1.Properties.Resources._5D;
            cardFaces[17] = WindowsFormsApplication1.Properties.Resources._5H;
            cardFaces[18] = WindowsFormsApplication1.Properties.Resources._5S;
            cardFaces[19] = WindowsFormsApplication1.Properties.Resources._5C;
            cardFaces[20] = WindowsFormsApplication1.Properties.Resources._6D;
            cardFaces[21] = WindowsFormsApplication1.Properties.Resources._6H;
            cardFaces[22] = WindowsFormsApplication1.Properties.Resources._6S;
            cardFaces[23] = WindowsFormsApplication1.Properties.Resources._6C;
            cardFaces[24] = WindowsFormsApplication1.Properties.Resources._7D;
            cardFaces[25] = WindowsFormsApplication1.Properties.Resources._7H;
            cardFaces[26] = WindowsFormsApplication1.Properties.Resources._7S;
            cardFaces[27] = WindowsFormsApplication1.Properties.Resources._7C;
            cardFaces[28] = WindowsFormsApplication1.Properties.Resources._8D;
            cardFaces[29] = WindowsFormsApplication1.Properties.Resources._8H;
            cardFaces[30] = WindowsFormsApplication1.Properties.Resources._8S;
            cardFaces[31] = WindowsFormsApplication1.Properties.Resources._8C;
            cardFaces[32] = WindowsFormsApplication1.Properties.Resources._9D;
            cardFaces[33] = WindowsFormsApplication1.Properties.Resources._9H;
            cardFaces[34] = WindowsFormsApplication1.Properties.Resources._9S;
            cardFaces[35] = WindowsFormsApplication1.Properties.Resources._9C;
            cardFaces[36] = WindowsFormsApplication1.Properties.Resources._10D;
            cardFaces[37] = WindowsFormsApplication1.Properties.Resources._10H;
            cardFaces[38] = WindowsFormsApplication1.Properties.Resources._10S;
            cardFaces[39] = WindowsFormsApplication1.Properties.Resources._10C;
            cardFaces[40] = WindowsFormsApplication1.Properties.Resources.JD;
            cardFaces[41] = WindowsFormsApplication1.Properties.Resources.JH;
            cardFaces[42] = WindowsFormsApplication1.Properties.Resources.JS;
            cardFaces[43] = WindowsFormsApplication1.Properties.Resources.JC;
            cardFaces[44] = WindowsFormsApplication1.Properties.Resources.QD;
            cardFaces[45] = WindowsFormsApplication1.Properties.Resources.QH;
            cardFaces[46] = WindowsFormsApplication1.Properties.Resources.QS;
            cardFaces[47] = WindowsFormsApplication1.Properties.Resources.QC;
            cardFaces[48] = WindowsFormsApplication1.Properties.Resources.KD;
            cardFaces[49] = WindowsFormsApplication1.Properties.Resources.KH;
            cardFaces[50] = WindowsFormsApplication1.Properties.Resources.KS;
            cardFaces[51] = WindowsFormsApplication1.Properties.Resources.KC;
            cardFaces[52] = WindowsFormsApplication1.Properties.Resources.card_back_red;
            PlayerCards[0] = picPlayer1;
            PlayerCards[1] = picPlayer2;
            PlayerCards[2] = picPlayer3;
            PlayerCards[3] = picPlayer4;
            PlayerCards[4] = picPlayer5;
            PlayerCards[5] = picPlayer6;
            PlayerCards[6] = picPlayer7;
            PlayerCards[7] = picPlayer8;
            PlayerCards[8] = picPlayer9;
            DealerCards[0] = picDealer1;
            DealerCards[1] = picDealer2;
            DealerCards[2] = picDealer3;
            DealerCards[3] = picDealer4;
            DealerCards[4] = picDealer5;
            DealerCards[5] = picDealer6;
            DealerCards[6] = picDealer7;
            interpret_state();
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            state = 0;
            interpret_state();
            player1.placeBet(5);
            deal_cards();
            lblPCount.Text = player1.money.ToString();
            if (player.getValue() == 21) state = 3;
            else state = 1;
            interpret_state();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            player.add(gameDeck.deal());
            PlayerCards[k].Image = cardFaces[player.cards[k].lookup];
            PlayerCards[k].BringToFront();
            PlayerCards[k].Visible = true;
            k++;
            if (player.getValue() > 21) state = 2;
            interpret_state();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            gameDeck.shuffle();
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            btnHit.Enabled = false;
            btnDeal.Enabled = false;
            btnStand.Enabled = false;
            DealerCards[0].Image = cardFaces[dealer.cards[0].lookup];
            while(dealer.getValue() < 17)
            {
                Application.DoEvents();
                Thread.Sleep(850);
                dealer.add(gameDeck.deal());
                DealerCards[d].Image = cardFaces[dealer.cards[d].lookup];
                DealerCards[d].BringToFront();
                DealerCards[d].Visible = true;
                d++;
                lblDCount.Text = dealer.getValue().ToString();
            }
            state = 4;
            interpret_state();
        }
    }
    class card
    {
        public card() { }
        public card(string value, string suit)
        {
            this.value = value;
            this.suit = suit;
            lookup = 4 * lookups[value] + lookups[suit];
        }
        Dictionary<string, int> lookups = new Dictionary<string, int>()
        {
            {"A", 0 },
            {"2", 1 },
            {"3", 2 },
            {"4", 3 },
            {"5", 4 },
            {"6", 5 },
            {"7", 6 },
            {"8", 7 },
            {"9", 8 },
            {"10", 9 },
            {"J", 10 },
            {"Q", 11 },
            {"K", 12 },
            {"D", 0 },
            {"H", 1 },
            {"S", 2 },
            {"C", 3 }
        };
        protected string value;
        protected string suit;
        public int lookup;
        public bool aceHigh = false;
        public void setValue(string v) { value = v; }
        public void setSuit(string s) { suit = s; }
        public string getValue() { return value; }
        public string getSuit() { return suit; }
    }
    class deck
    {
        string backName;
        int currentIndex;
        card[] cards = new card[52];
        public deck()
        {
            
        }
        public void populate()
        {
            cards[0] = new card("2", "C");
            cards[1] = new card("2", "D");
            cards[2] = new card("2", "H");
            cards[3] = new card("2", "S");
            cards[4] = new card("3", "C");
            cards[5] = new card("3", "D");
            cards[6] = new card("3", "H");
            cards[7] = new card("3", "S");
            cards[8] = new card("4", "C");
            cards[9] = new card("4", "D");
            cards[10] = new card("4", "H");
            cards[11] = new card("4", "S");
            cards[12] = new card("5", "C");
            cards[13] = new card("5", "D");
            cards[14] = new card("5", "H");
            cards[15] = new card("5", "S");
            cards[16] = new card("6", "C");
            cards[17] = new card("6", "D");
            cards[18] = new card("6", "H");
            cards[19] = new card("6", "S");
            cards[20] = new card("7", "C");
            cards[21] = new card("7", "D");
            cards[22] = new card("7", "H");
            cards[23] = new card("7", "S");
            cards[24] = new card("8", "C");
            cards[25] = new card("8", "D");
            cards[26] = new card("8", "H");
            cards[27] = new card("8", "S");
            cards[28] = new card("9", "C");
            cards[29] = new card("9", "D");
            cards[30] = new card("9", "H");
            cards[31] = new card("9", "S");
            cards[32] = new card("J", "C");
            cards[33] = new card("J", "D");
            cards[34] = new card("J", "H");
            cards[35] = new card("J", "S");
            cards[36] = new card("Q", "C");
            cards[37] = new card("Q", "D");
            cards[38] = new card("Q", "H");
            cards[39] = new card("Q", "S");
            cards[40] = new card("K", "C");
            cards[41] = new card("K", "D");
            cards[42] = new card("K", "H");
            cards[43] = new card("K", "S");
            cards[44] = new card("10", "C");
            cards[45] = new card("10", "D");
            cards[46] = new card("10", "H");
            cards[47] = new card("10", "S");
            cards[48] = new card("A", "C");
            cards[49] = new card("A", "D");
            cards[50] = new card("A", "H");
            cards[51] = new card("A", "S");

            currentIndex = 0;
        }
        public void setBackName(string backName) { this.backName = backName; }
        public void shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < 52; i++)
            {
                int randCard = rnd.Next(52);
                card temp = cards[i];
                cards[i] = cards[randCard];
                cards[randCard] = temp;
            }
            currentIndex = 0;
        }
        public card deal()
        {
            if (currentIndex > 36) shuffle();
            return cards[currentIndex++];
        }
    }
    class hand
    {
        public List<card> cards = new List<card>();
        int value;
        public hand() { value = 0; }

        public int getValue() {  return value;  }
        public void recomputeValue()
        {
            foreach (card a in cards)
            {
                if((a.getValue().Equals("A")) && (a.aceHigh))
                {
                    a.aceHigh = false;
                    value -= 10;
                    break;
                }
            }
        }
        public void add(card newCard)
        {
            string valToAdd = newCard.getValue();
            cards.Add(newCard);
            if (valToAdd.All(char.IsDigit))
            {
                value += Int32.Parse(valToAdd);
            }
            else if ((valToAdd.Equals("Q")) || (valToAdd.Equals("K")) || (valToAdd.Equals("J")))
            {
                value += 10;
            }
            else if (valToAdd.Equals("A"))
            {
                if (value + 11 <= 21)
                {
                    value += 11;
                    newCard.aceHigh = true;
                }
                else
                {
                    value += 1;
                    newCard.aceHigh = false;
                }
            }
            if (value > 21) recomputeValue();
        }
        public void done()
        {
            cards.Clear();
            value = 0;
        }
    }
    class Player
    {
        string name;
        public int money, bet;
        hand myHand;
        public Player () { name = "default"; money = 1000; }
        public Player (string name, int money)
        {
            this.name = name;
            this.money = money;
        }
        public int placeBet(int amt)
        {
            if (money < amt) return 0;
            else
            {
                money -= amt;
                bet = amt;
                return amt;
            }
        }
        public void evaluateBet(string type)
        {
            if (type.Equals("win"))  money += 2 * bet;
            if (type.Equals("BJ"))   money += (3 * bet) / 2;
            if (type.Equals("push")) money += bet;
            bet = 0;
        }
    }
}
