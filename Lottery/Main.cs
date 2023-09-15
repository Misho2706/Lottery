using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lottery
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        void GenerateTickets()
        {
            listBoxTkt.Items.Clear();
            int[] ticketArray = new int[6];
            StreamWriter getTickets = new StreamWriter(@"C:\Users\1\Desktop\tickets.txt",false);
            
            Random numberGenerator = new Random();
            int randomNumber = 0;
            string ticket = "";
            int tmp = 0;
            for (int i = 0; i < 15120; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    randomNumber = numberGenerator.Next(6, 37);
                    while (ticket.Contains(randomNumber.ToString()))
                    {
                        randomNumber = numberGenerator.Next(6, 37);
                    }
                    ticket += randomNumber.ToString() + " ";
                    ticketArray[j] = randomNumber;

                }
                ticket = "";
                for (int k = 0; k < 6; k++)
                {
                    for (int l = 0; l < 6; l++)
                    {
                        if (ticketArray[k] < ticketArray[l])
                        {
                            tmp = ticketArray[l];
                            ticketArray[l] = ticketArray[k];
                            ticketArray[k] = tmp;
                        }
                    }

                }
                for (int m = 0; m < 6; m++)
                {
                    ticket += ticketArray[m].ToString() + " ";
                }
                listBoxTkt.Items.Add(ticket);
                getTickets.WriteLine(ticket);
                ticket = "";
            }
            getTickets.Close();
            getTickets.Dispose();
        }

        void GetWinner()
        {
            int[] ticketArray = new int[6];
            int tmp = 0;
            StreamReader checkTickets = new StreamReader(@"C:\Users\1\Desktop\tickets.txt");
            string winTicket = "";
            int randomNumber = 0;
            int winners = 0;
            Random numberGenerator = new Random();
            for (int j = 0; j < 6; j++)
            {

                randomNumber = numberGenerator.Next(6, 37);
                while (winTicket.Contains(randomNumber.ToString()))
                {
                    randomNumber = numberGenerator.Next(6, 37);
                }
                ticketArray[j] = randomNumber;
                winTicket += randomNumber.ToString() + " ";
            }
            winTicket = "";
            for (int k = 0; k < 6; k++)
            {
                for (int l = 0; l < 6; l++)
                {
                    if (ticketArray[k] < ticketArray[l])
                    {
                        tmp = ticketArray[l];
                        ticketArray[l] = ticketArray[k];
                        ticketArray[k] = tmp;
                    }
                }

            }
            for (int m = 0; m < 6; m++)
            {
                winTicket += ticketArray[m].ToString() + " ";
            }

            string line = "";
            while ((line = checkTickets.ReadLine()) != null)
            {

                for (int n = 0; n < line.Length; n++)
                {
                    if (line[n] != winTicket[n])
                    {
                        winners--;
                        break;
                    }

                }
                winners++;
            }
            MessageBox.Show("winners: " + winners.ToString());
            checkTickets.Close();
            checkTickets.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateTickets();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetWinner();
        }


    }
}
