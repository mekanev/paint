using System.Drawing.Imaging;

namespace paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Drawing.Graphics formGraphics;
        Point p = Point.Empty;
        bool isDown = false;
        bool isUcgen = false;
        bool isKare = false;
        bool isCember = false;
        Bitmap bmp;
        Color color;
        int initialX;
        int initialY;
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void draw_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void draw_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void draw_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            isDown = true;
            initialX = e.X;
            initialY = e.Y;
            if (isUcgen==true)
            {
                if (e.Button == MouseButtons.Left && p.IsEmpty)
                {
                    p = e.Location;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isKare==true)
            {
                if (isDown == true)
                {
                    this.Refresh();
                    Pen drwaPen = new Pen(color, 1);
                    Rectangle rect = new Rectangle(Math.Min(e.X, initialX),
                                                   Math.Min(e.Y, initialY),
                                                   Math.Abs(e.X - initialX),
                                                   Math.Abs(e.Y - initialY));
                    formGraphics = this.CreateGraphics();
                    formGraphics.DrawRectangle(drwaPen, rect);
                }
            }
            if (isUcgen==true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int h = Math.Abs(e.Location.Y - p.Y);

                    using (Graphics g = CreateGraphics())
                    {
                        g.Clear(BackColor);
                        Pen pen = new Pen(color);
                        g.DrawLine(pen, p.X, p.Y, p.X + h / 2, e.Location.Y);
                        g.DrawLine(pen, p.X, p.Y, p.X - h / 2, e.Location.Y);
                        g.DrawLine(pen, p.X - h / 2, e.Location.Y, p.X + h / 2, e.Location.Y);
                    }
                }
            }
            if (isCember==true)
            {
                if (isDown == true)
                {
                    this.Refresh();
                    Pen drwaPen = new Pen(color, 1);
                    Rectangle rect = new Rectangle(Math.Min(e.X, initialX),
                                                   Math.Min(e.Y, initialY),
                                                   Math.Abs(e.X - initialX),
                                                   Math.Abs(e.Y - initialY));
                    formGraphics = this.CreateGraphics();
                    formGraphics.DrawEllipse(drwaPen, rect);
                }
            }

            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            if (isUcgen==true)
            {
                p = Point.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isUcgen = true;
            isKare = false;
            isCember = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            isCember = true;
            isKare = false;
            isUcgen = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            isKare = true;
            isUcgen = false;
            isCember = false;
        }

        private void pbRed_Click(object sender, EventArgs e)
        {
            color = pbRed.BackColor;
        }

        private void pbBlue_Click(object sender, EventArgs e)
        {
            color = pbBlue.BackColor;
        }

        private void pbLime_Click(object sender, EventArgs e)
        {
            color = pbLime.BackColor;
        }

        private void pbOrange_Click(object sender, EventArgs e)
        {
            color=pbOrange.BackColor;
        }

        private void pbBlack_Click(object sender, EventArgs e)
        {
            color=pbBlack.BackColor;
        }

        private void pbYellow_Click(object sender, EventArgs e)
        {
            color= pbYellow.BackColor;
        }

        private void pbPurple_Click(object sender, EventArgs e)
        {
            color = pbPurple.BackColor;
        }

        private void pbKahve_Click(object sender, EventArgs e)
        {
            color = pbKahve.BackColor;
        }

        private void pbWhite_Click(object sender, EventArgs e)
        {
            color = pbWhite.BackColor;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            formGraphics.Clear(DefaultBackColor);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Title = "Save Image";
            dlgSave.Filter = "Bitmap Images (*.bmp)|*.bmp|All Files (*.*)|*.*";
            bmp = new Bitmap(this.Width, this.Height);
            if (dlgSave.ShowDialog(this) == DialogResult.OK)
            {
                bmp.Save(dlgSave.FileName);
            }
        }
    }
}