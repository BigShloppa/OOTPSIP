using System.ComponentModel;

namespace lab1
{
    public partial class MainWindow : Form
    {

        private List<Figure>? figures;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {

            figures = new List<Figure>() {
                new Rectangle(5,5),
                new Rectangle(15,10),
                new Rectangle(25,15),
                new Rectangle(50,25),
                new Circle(5),
                new Circle(15),
                new Circle(25),
                new Circle(50),
                new Parallelogram(5, 5, 90),
                new Parallelogram(15,10, 30),
                new Parallelogram(25,15, 45),
                new Parallelogram(50,25, 60),
                new Rhombus(5, 45),
                new Rhombus(15, 30),
                new Rhombus(25,60),
                new Rhombus(50, 45),
                new Squire(5),
                new Squire(15),
                new Squire(25),
                new Squire(50)
            };
            for (int i = 0; i < figures.Count / 4; i++)
                for (int j = 0; j < figures.Count / 5; j++)
                {
                    figures[i * 4 + j].Build(50 + j * 150, 50 + i * 80);
                    Graphics gr = pictureBox.CreateGraphics();
                    if (typeof(Circle).IsInstanceOfType(figures[i * 4 + j]))
                        gr.DrawCurve(new Pen(Color.Red), figures[i * 4 + j].Points);
                    else
                        gr.DrawLines(new Pen(Color.Red), figures[i * 4 + j].Points);
                }
            pictureBox.Invalidate();
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            foreach (var figure in figures)
            {
                if (typeof(Circle).IsInstanceOfType(figure))
                    gr.DrawCurve(new Pen(Color.Red), figure.Points);
                else
                    gr.DrawLines(new Pen(Color.Red), figure.Points);
            }
        }
    }
}