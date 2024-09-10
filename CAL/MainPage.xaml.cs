

namespace CAL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Back(object sender, EventArgs e)
        {
            if (EntryBox.Text.Length > 0)
                EntryBox.Text = EntryBox.Text.Remove(EntryBox.Text.Length - 1);
        }

        public void History()
        {
            label.Text = EntryBox.Text + operation;
        }
        private void CE(object sender, EventArgs e)
        {
            operation = ' ';
            x = 0;
            EntryBox.Text = null;
            label.Text = null;
        }     

        private void PlusAndMinus(object sender, EventArgs e)
        {
            if (EntryBox.Text.StartsWith("-"))
                EntryBox.Text = EntryBox.Text.Remove(0, 1);
            else
                EntryBox.Text = "-" + EntryBox.Text;
        }

        private void C(object sender, EventArgs e)
        {
            operation = ' ';
            x = 0;
            EntryBox.Text = null;
            label.Text = null;
        }

        private void Koren(object sender, EventArgs e)
        {
            double.TryParse(EntryBox.Text, out double y);
            EntryBox.Text = (Math.Sqrt(y)).ToString();
        }

        private void ClickNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            EntryBox.Text += button.Text.ToString();
        }

        private void Procent(object sender, EventArgs e)
        {
            double procent1 = x / 100;
            double.TryParse(EntryBox.Text, out double y);
            EntryBox.Text = (y * procent1).ToString();
        }

        private void Drob(object sender, EventArgs e)
        {
            double.TryParse(EntryBox.Text, out double y);
            EntryBox.Text = (1 / y).ToString();
        }

        private void Ravno(object sender, EventArgs e)
        {
            double result = 0;
            double.TryParse(EntryBox.Text, out double y);
            switch (operation)
            {
                case '+':
                    result = x + y;
                    break;
                case '-':
                    result = x - y;
                    break;
                case '*':
                    result = x * y;
                    break;
                case '/':
                    result = x / y;
                    break;
                
            }
            EntryBox.Text = result.ToString();
            label.Text = null;
        }

        private void Dot(object sender, EventArgs e)
        {
            if (!EntryBox.Text.Contains(","))
            {
                EntryBox.Text += ",";
            }
        }

        double x = 0;
        char operation = ' ';
        private void ClickOperation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text.ToString()[0];
            double.TryParse(EntryBox.Text, out x);
            History();
            EntryBox.Text = null;
        }
    }
}
