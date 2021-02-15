using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crit_section
{
    public partial class Form1 : Form
    {
        List<int> arr; 
        static Create locker = new Create();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arr = new List<int>();
            listBox1.Items.Clear();
            if (textBox1.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 0)
                {
                    if (Convert.ToInt32(textBox1.Text) % 5 == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread myThread = new Thread(Array);
                            myThread.Start();
                        }
                    }
                    else if (Convert.ToInt32(textBox1.Text) % 3 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Thread myThread = new Thread(Array);
                            myThread.Start();
                        }
                    }
                    else if (Convert.ToInt32(textBox1.Text) % 2 == 0)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Thread myThread = new Thread(Array);
                            myThread.Start();
                        }
                    }
                    else if (Convert.ToInt32(textBox1.Text) % 1 == 0)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            Thread myThread = new Thread(Array);
                            myThread.Start();
                        }
                    }
                }
            }
        }
        public void Array()
        {
            lock (locker)
            {
                locker.func(arr, listBox1, textBox1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Counter.count = 0;
            Counter.max = 0;
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(delegate ()
                {
                    for (int j = 0; j < arr.Count; j++)
                    {
                        Interlocked.Add(ref Counter.count, arr[j]);
                        if (Counter.max < arr[j])
                        {
                            Counter.max = arr[j];
                        }
                    }
                });
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            label3.Text = Counter.count.ToString();
            label5.Text = Counter.max.ToString();
        }

        class Counter
        {
            public static int count;
            public static int max;
        }

    }
}
