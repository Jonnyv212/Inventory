using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Inventory
{
    class History
    {
        public static void DisplayHistory(DataGridView dGridView)
        {
            string query = "SELECT EVENT.EVENT, HISTORY.HISTORY_DESCRIPTION, HISTORY.HISTORY_DATE FROM HISTORY JOIN EVENT ON EVENT.EVENT_ID = HISTORY.EVENT_ID ORDER BY TO_NUMBER(HISTORY_ID) DESC ";
            dGridView.DataSource = Main.DataTableSQLQuery(query);
        }

        public static void HistoryDataGridAppearance(DataGridView dGridView)
        {
            DataGridViewColumn column1 = dGridView.Columns[0];
            column1.Width = 250;

            DataGridViewColumn column2 = dGridView.Columns[1];
            column2.Width = 500;

            DataGridViewColumn column3 = dGridView.Columns[2];
            column3.Width = 266;
        }

        public static void HistoryManualInsert(ComboBox Equipment, TextBox Quantity, ComboBox Project)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('1', 'Added "+Quantity.Text+" inventory record(s) of "+Equipment.Text+" into "+Project.Text+". ')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryInventoryUpdate(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('2', '" + log + "')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryInventoryDelete(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('4', '" + log + "')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryProjectUpdate(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('23', '" + log + "')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryProjectDelete(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('24', '" + log + "')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryProjectAdd(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('22', '" + log + "')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryBarcodeInsert(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('1', '" + log + "')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryEquipmentEdit(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('21', '" + log + "')";
            Main.RunSQLQuery(query);
        }

        public static void HistoryEquipmentAdd(string log)
        {
            string query = "INSERT INTO HISTORY (EVENT_ID, HISTORY_DESCRIPTION) VALUES ('3', '" + log + "')";
            Main.RunSQLQuery(query);
        }
    }
}
