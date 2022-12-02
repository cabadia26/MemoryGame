namespace MemoryGame
{
    public partial class MemoryGame : Form
    {
    //Variables, Bools, Lists, Using Timer

        Random rnd = new Random();
        Button choice1;
        Button choice2;
        bool firstclick;
        bool secondclick;
        List<string> lstletters;
        List<Button> lstbuttons;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MemoryGame()
        {
        //Instantiate memory game with btns, letters for alphabet, function of assigning letters, function for each btn instantiate all buttons clicks

            InitializeComponent();
            lstbuttons = new List<Button>() { btnA1,btnA2, btnB1, btnB2, btnC1, btnC2, btnD1, btnD2, btnE1, btnE2, btnF1, btnF2 };
            lstletters = new List<string>() { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E", "F", "F" };
            AssignLettersToButtons();
            foreach (Button b in lstbuttons)
            {
                b.Click += PickCard_Click;
            }
        }
        private void AssignLettersToButtons()
        {  
        //Set each button's text to a random alphabet letter from the letter list, remove from list as assign to buttons so no repeats, set backcolor and forecolor to pink

            foreach (Button b in lstbuttons)
            {
                int Alphabets = rnd.Next(lstletters.Count-1);
                b.Text = lstletters[Alphabets];
                lstletters.RemoveAt(Alphabets);
                b.BackColor = Color.Pink;
                b.ForeColor = b.BackColor;
            }
        }
    private void Checkmatch()
        {
        //check if 2 cards chose are a match- show "you win" and keep cards showing by changing their backcolor to white(forecolor will show letter)
            if (choice1.Text == choice2.Text)
            {
               // bool filled = CheckIfAllFilled();
            
                
                MessageBox.Show("It's a match!");
                ReFlipCard(Color.White);
            }
            //if cards not a match- hide card by turning backcolor back to pink and clicks set to false to check upcoming new matches
            else if (choice1 != choice2)
                {
                ReFlipCard(Color.Pink);
            }
            //enable buttons
        }
        private void ReFlipCard(Color color)
        {
            choice1.BackColor = color;
            choice2.BackColor = color;
            firstclick = false;
            secondclick = false;
        }
        private void ShowCard(Button btn)
        {

            if (firstclick == true)
            {
                choice2 = btn;
            }

        //Show text of the button. if first match is not chosen then show text and save it as choice1 and firsclick is true
        

            
            if(timer1.Enabled == false && firstclick == false)
            {
                btn.BackColor = Color.White;
                choice1 = btn;
                firstclick = true;

                return;
            }
            //if clicked same button twice as a set
            if (firstclick == true && choice1 == choice2)
            {
                choice1 = btn;
                secondclick = false;
                timer1.Enabled = false;
                return;
            }
            //if chose first choice this show text for second button and saves it as choice2 and timer will start running 
            if(firstclick == true)
            {
                //disable buttons
                btn.BackColor = Color.White;
                choice2 = btn;
                secondclick = true;
                timer1.Start();
            }
        }
        //timer is clicking with interval time set on properties. and calling in function checkmatch() to check  if matching set
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Checkmatch();
        }
        private void PickCard_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ShowCard(btn);
        }
    }
}

//DRAFT 1

//namespace MemoryGame
//{
//    public partial class MemoryGame : Form
//    {
//        Random rnd = new Random();
//        bool chosecards = false;
//        string currentturn = "";
//        Button choice1;
//        Button choice2;
//        List<string> lstletters = new List<string>();
//        List<Button> lstbuttons;
//        //int nextcardincrement = 10;

//        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
//        public MemoryGame()
//        {
//            InitializeComponent();
//            lstbuttons = new List<Button>() { btnA1, btnA2, btnB1, btnB2, btnC1, btnC2, btnD1, btnD2, btnE1, btnE2, btnF1, btnF2 };
//            lstletters = new List<string>() { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E", "F", "F" };
//            AssignLettersToButtons();
//            foreach (Button b in lstbuttons)
//            {
//                b.Click += PickCard_Click;
//            }
//        }
//        private void AssignLettersToButtons()
//        {
//            //set each button's text to a random letter from the letter list
//            foreach (Button b in lstbuttons)
//            {
//                int Index = rnd.Next(0, lstletters.Count - 1);
//                b.Text = lstletters[Index];
//                lstletters.RemoveAt(Index);
//                b.BackColor = Color.Blue;
//                b.ForeColor = b.BackColor;
//            }
//        }
//        private void DisplayWinner()
//        {
//            MessageBox.Show("You win");
//        }
//        private void Checkmatch()
//        {
//            if (choice1.Text != "" && choice2.Text != "")
//            {
//                chosecards = true;

//                if (choice1 == choice2)
//                {
//                    DisplayWinner();
//                }
//                else if (chosecards == true && choice1 != choice2)
//                {
//                    chosecards = false;
//                    choice1.BackColor = Color.Blue;
//                    choice2.BackColor = Color.Blue;
//                }
//            }
//            // return choice1 == choice2;
//        }
//        private void ShowCard(Button btn)
//        {
//            //show text of the button
//            if (btn.Text != "" && choice1.Text == "" && choice2.Text == "")
//            {
//                btn.BackColor = Color.White;
//                choice1.Text = btn.Text;
//                currentturn = choice1.Text;
//                //if (choice1 != "")
//                return;
//            }
//            if (btn.Text != "" && choice1.Text != "" && choice2.Text == "")
//            {
//                btn.BackColor = Color.White;
//                choice2.Text = btn.Text;
//                currentturn = choice2.Text;
//                timer1.Start();
//            }
//            Checkmatch();
//            //if they both not blank check match if match display winner if not match then hide cards and return
//            return;
//        }
//        private void PickCard_Click(object? sender, EventArgs e)
//        {
//            Button btn = (Button)sender;
//            ShowCard(btn);
//        }
//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            timer1.Stop();
//            Checkmatch();

//        }
//    }
//}