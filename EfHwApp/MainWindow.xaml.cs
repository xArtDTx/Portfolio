using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
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
            var financialAccounting = new FinancialAccounting
            {
                Profit = ProfitTxt.CaretIndex,
                Costs = CostsTxt.CaretIndex
            };
            _financialAccounting.FinancialAccountingSet.Attach(financialAccounting);
            _financialAccounting.FinancialAccountingSet.Remove(financialAccounting);
            _financialAccounting.SaveChanges();
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.ShowDialog();
            _financialAccounting.FinancialAccountingSet.AddOrUpdate();
        }
        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            var search = _financialAccounting.FinancialAccountingSet.Find(1);
            search.Name = "The New ADO.NET FinancialAccounting";

            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    _financialAccounting.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    saveFailed = true;
                    var entry = e.Entries.Single();
                    var databaseValues = entry.GetDatabaseValues();
                    var databaseValuesAsFinancialAccounting = (FinancialAccounting)databaseValues.ToObject();
                    var resolvedValuesAsFinancialAccounting = (FinancialAccounting)databaseValues.ToObject();

                    HaveUserResolveConcurrency((FinancialAccounting) entry.Entity, databaseValuesAsFinancialAccounting,
                        resolvedValuesAsFinancialAccounting);
                    entry.OriginalValues.SetValues(databaseValues);
                    entry.CurrentValues.SetValues(resolvedValuesAsFinancialAccounting);
                }
            } while (saveFailed);
        }

        public void HaveUserResolveConcurrency(FinancialAccounting entity, FinancialAccounting databaseValuesAsFinancialAccounting, FinancialAccounting resolvedValuesAsFinancialAccounting)
        {
            
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            Update();
            _financialAccounting.SaveChanges();
        }
    }
}
