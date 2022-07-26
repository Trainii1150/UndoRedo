namespace WinFormsApp1
{
    public partial class UndoRedo : Form
    {
        Stack<String> stack = new Stack<String>();
        Stack<String> redoStack = new Stack<String>();
        String tmp;
        String tmpcheck;

        public UndoRedo()
        {
            InitializeComponent();
            tmp = "";
            tmpcheck = "";
            stack.Push("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //show warning when click undo data button is null(Label)
                if (stack.Peek() == "")
                {
                    textwarning.Text = "You can't undo anymore. Please input data!";
                }
                else
                {
                    tmp = stack.Peek();
                    tmpcheck = stack.Peek();
                    redoStack.Push(tmp);
                    stack.Pop();
                    textBox1.Text = stack.Peek();

                }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //show warning when click redo button data is null(Label)
                if (redoStack.Count() == 0)
                {
                    textwarning.Text = "You can't redo anymore. Please input data!";
                }
                else
                {
                    textBox1.Text = redoStack.Peek();
                    stack.Push(redoStack.Peek());
                    redoStack.Pop();
                }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                stack.Push(textBox1.Text);
                //if when input new data after undo one time
                if (!tmpcheck.Equals(stack.Peek()))
                {
                    redoStack.Clear();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textwarning.Text = "";
        }
    }
}