using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crit_section
{
    public class Create
    {
        public void func(List<int> temp, ListBox listBox1, TextBox textBox1)
        {
            Random rnd = new Random();
            int x = 0;
            if (Convert.ToInt32(textBox1.Text) % 5 == 0)
            {
                x = Convert.ToInt32(textBox1.Text) / 5;
            }
            else if (Convert.ToInt32(textBox1.Text) % 3 == 0)
            {
                x = Convert.ToInt32(textBox1.Text) / 3;
            }
            else if (Convert.ToInt32(textBox1.Text) % 2 == 0)
            {
                x = Convert.ToInt32(textBox1.Text) / 2;
            }
            else if (Convert.ToInt32(textBox1.Text) % 1 == 0)
            {
                x = Convert.ToInt32(textBox1.Text);
            }

            for (int i = 0; i < x; i++)
            {
                temp.Add(rnd.Next());
                listBox1.Invoke((Action)delegate () { listBox1.Items.Add(temp[i]); });
            }
        }
    }
}
