using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        BankAccount _account;
        public Form1(BankAccount account)
        {
            InitializeComponent();
            _account = account;
            UpdateUi();
        }

        private void UpdateUi()
        {
            this.Text = $"Your account balance is ${_account.GetBalance()}";
        }

        public void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show($"Notifying the feds of your withdrawl of {amountToWithdraw:c}");
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);

        }

        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amount = int.Parse(txtAmount.Text);
                op(amount);
                UpdateUi();
            }
            catch (FormatException)
            {

                MessageBox.Show("Enter a number genius.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(OverdraftException)
            {
                MessageBox.Show("You don't have enough money.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoNegativeTransactionsException)
            {
                MessageBox.Show("Are you dumb? Use Positive Numbers!.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }

        
    }
}
