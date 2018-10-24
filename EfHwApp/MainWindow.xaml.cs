using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EfHwApp
{

    public partial class MainWindow : Window
    {
        private readonly DataBaseContainer _financialAccounting = new DataBaseContainer();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _financialAccounting;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _financialAccounting.FinancialAccountingSet.Load();
            _financialAccounting.FinancialAccountingSet.Local.ToBindingList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {

            var financialAccounting = new FinancialAccounting
            {
                Profit = Int32.Parse(ProfitTxt.Text),
                Costs = Int32.Parse(CostsTxt.Text)
            };

            _financialAccounting.FinancialAccountingSet.Add(financialAccounting);
            _financialAccounting.SaveChanges();
        }


        private void DelButton_OnClick(object sender, RoutedEventArgs e)
        {
            var financialAccounting = new FinancialAccounting();
            _financialAccounting.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            _financialAccounting.FinancialAccountingSet.Attach(_financialAccounting.FinancialAccountingSet.Local.Last());
            _financialAccounting.FinancialAccountingSet.Remove(_financialAccounting.FinancialAccountingSet.Local.Last());
            
            _financialAccounting.SaveChanges();
        }

        private void AddEnhButton_OnClick(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.ShowDialog();
        }


        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            var financialAccounting = new FinancialAccounting();
            financialAccounting = _financialAccounting.FinancialAccountingSet.Find(1);
            DataContext = new DataBaseContainer();
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    _financialAccounting.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
            } while (saveFailed);
        }
    }
}
