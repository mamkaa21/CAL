

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
            label.Text += EntryBox.Text + operation;
        }
        private void CE(object sender, EventArgs e)
        {
          
            EntryBox.Text = "";
          
        }     

        private void PlusAndMinus(object sender, EventArgs e)
        {
            if (EntryBox.Text.StartsWith("-"))
                EntryBox.Text = EntryBox.Text.Remove(0, 1);
            else
                EntryBox.Text = "-" + EntryBox.Text;
            isoperation = false;
        }

        private void C(object sender, EventArgs e)
        {
            operation = ' ';
            x = 0;
            EntryBox.Text = "";
            label.Text = "";
            count = 0;
            isoperation = false;
        }

        private void Koren(object sender, EventArgs e)
        {
            double.TryParse(EntryBox.Text, out double y);
            EntryBox.Text = (Math.Sqrt(y)).ToString();
            isoperation = false;
        }

        private void ClickNumber(object sender, EventArgs e)
        {  
            isoperation = false;
            Button button = (Button)sender;
            EntryBox.Text += button.Text.ToString();
          
        }

        private void Procent(object sender, EventArgs e)
        {
            double procent1 = x / 100;
            double.TryParse(EntryBox.Text, out double y);
            EntryBox.Text = (y * procent1).ToString();
            isoperation = false;
        }

        private void Drob(object sender, EventArgs e)
        {
            double.TryParse(EntryBox.Text, out double y);
            EntryBox.Text = (1 / y).ToString();
            isoperation = false;
        }

        private void Ravno(object sender, EventArgs e)
        {    
            //isoperation = false;
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
            if(sender != null)
            {
                label.Text = "";
                count = 0;               
            } 
         
            x = result;

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
        bool isoperation = false;
        int count;
        private void ClickOperation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text.ToString()[0];                      
            if (!isoperation)
            {
                if (count <= 1)
                { 
                    double.TryParse(EntryBox.Text, out x); 
                }
                count++;
                if (count > 1)
                {
                    Ravno(null, new EventArgs());
                }
                History();
                EntryBox.Text = "";             
                isoperation = true;
            }
         
        }
    }
}
