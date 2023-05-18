using Proves1.model;

namespace Proves1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void carregarxml(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File XML (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Lliga.carregarModel(openFileDialog.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}