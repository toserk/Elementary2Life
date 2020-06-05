using System.Windows.Forms;

namespace Elementary2Life
{
    public partial class MainForm : Form
    {
        private readonly Algorithm _algorithm;

        public MainForm()
        {
            InitializeComponent();
            _algorithm = new Algorithm(333, 187, 3);
            pictureBox1.Image = _algorithm.Screen;
            ruleSelect.Value = _algorithm.Rule;
            cellColorDialog.Color = _algorithm.Color;
        }

        private void timerUpdate_Tick(object sender, System.EventArgs e)
        {
            _algorithm.Transform();
            pictureBox1.Refresh();
        }

        private void buttonChangeRule_Click(object sender, System.EventArgs e)
        {
            _algorithm.ChangeRule((int) ruleSelect.Value);
        }

        private void buttonChangeColor_Click(object sender, System.EventArgs e)
        {
            if (cellColorDialog.ShowDialog() == DialogResult.OK)
                _algorithm.ChangeColor(cellColorDialog.Color);
        }
    }
}
