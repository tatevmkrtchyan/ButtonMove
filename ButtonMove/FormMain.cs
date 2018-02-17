using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonMove
{
    public partial class FormMain : Form
    {
        int delta = 10;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        Move m;
        
        public FormMain()
        {
            InitializeComponent();

            t.Tick += T_Tick;
            t.Interval = 100;
            this.KeyDown += FormMain_KeyDown;
            this.KeyPreview = true;           
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                        m = ButtonMove.Move.Left;
                        break;
                case Keys.A:
                        m = ButtonMove.Move.Right;
                        break;
                case Keys.W:
                        m = ButtonMove.Move.Up;
                        break;
                case Keys.S:
                        m = ButtonMove.Move.Down;
                        break;
                default:                 
                    break;                    
            }
            t.Start();                                      
        }

        private void T_Tick(object sender, EventArgs e)
        {
            switch (m)
            {
                case ButtonMove.Move.Up:
                    this.btnMove.Location = new Point(this.btnMove.Location.X, this.btnMove.Location.Y - delta);
                    break;
                case ButtonMove.Move.Down:
                    this.btnMove.Location = new Point(this.btnMove.Location.X, this.btnMove.Location.Y + delta);
                    break;
                case ButtonMove.Move.Left:
                    this.btnMove.Location = new Point(this.btnMove.Location.X + delta, this.btnMove.Location.Y);
                    break;
                case ButtonMove.Move.Right:
                    this.btnMove.Location = new Point(this.btnMove.Location.X - delta, this.btnMove.Location.Y);
                    break;
                default:
                    break;
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            t.Start();
        }
    }
}
