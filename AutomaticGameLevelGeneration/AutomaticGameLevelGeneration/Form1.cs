using System.Windows.Forms;

namespace AutomaticGameLevelGeneration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new ApplicationLogic().Execute();
        }
    }
}

}
