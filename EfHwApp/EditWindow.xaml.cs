using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EfHwApp
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly DataBaseContainer _financialAccounting = new DataBaseContainer();
        public EditWindow()
        {
            InitializeComponent();
            DataContext = _financialAccounting;
        }
        

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var financialAccounting = new FinancialAccounting
            {
                Profit = Int32.Parse(ProfitTxt1.Text) + Int32.Parse(ProfitTxt2.Text) + Int32.Parse(ProfitTxt3.Text),
                Costs = Int32.Parse(Costs1.Text) + Int32.Parse(Costs2.Text) + Int32.Parse(Costs3.Text)
            };

            _financialAccounting.FinancialAccountingSet.Add(financialAccounting);
            _financialAccounting.SaveChanges();
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
