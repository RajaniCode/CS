using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CS2008SqlAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int currentIndex = 0;

        private void NavigateForward()
        {
            int RowCount = GetRowCount();
            if (RowCount == 0)
            {
                MessageBox.Show("No records.");
                return;
            }
            else if (RowCount == -1)
            {
                return;
            }
            if (currentIndex >= 0 && currentIndex <= RowCount)
            {
                if (currentIndex == RowCount)
                {
                    currentIndex = 0;
                    BindData(currentIndex);
                }
                else
                {
                    BindData(currentIndex);
                }
                currentIndex++;
            }
            if (RowCount > 0)
            {
                textBox5.Text = Convert.ToString(currentIndex);
            }
        }

        private void NavigateBackward()
        {
            int RowCount = GetRowCount();
            if (RowCount == 0)
            {
                MessageBox.Show("No records.");
                return;
            }
            else if (RowCount == -1)
            {
                return;
            }
            if (currentIndex >= 0 && currentIndex <= RowCount)
            {
                if (currentIndex == 0)
                {
                    currentIndex = RowCount;
                    BindData(currentIndex - 1);
                }
                else if (currentIndex == 1)
                {
                    currentIndex = RowCount;
                    BindData(currentIndex - 1);
                }
                else
                {
                    currentIndex--;
                    BindData(currentIndex - 1);
                }
            }
            if (RowCount > 0)
            {
                textBox5.Text = Convert.ToString(currentIndex);
            }
        }

        private void BindData(int index)
        {
            DataTable datTable = SelectRecord();
            int RowCount = GetRowCount();
            if (RowCount > 0)
            {
                textBox1.Text = datTable.Rows[index]["CustomerId"].ToString().Trim();
                textBox2.Text = datTable.Rows[index]["FirstName"].ToString().Trim();
                textBox3.Text = datTable.Rows[index]["LastName"].ToString().Trim();
                textBox4.Text = datTable.Rows[index]["Synonym"].ToString().Trim();
            }
        }

        private int GetRowCount()
        {
            int recordCount = 0;
            DataTable datTable = SelectRecord();
            if (datTable != null && datTable.Rows.Count > 0)
            {
                recordCount = datTable.Rows.Count;
            }
            else
            {
                recordCount = -1;
            }
            return recordCount;
        }

        private DataTable SelectRecord()
        {
            DataTable datTable = null;
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append("Select * FROM Customer;");

                using (SqlCommand commandSql = new SqlCommand(selectQuery.ToString()))
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    datTable = dal.Select(commandSql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return datTable;
        }

        private DataTable SelectRecord(string column)
        {
            DataTable datTable = null;
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append("Select * FROM Customer ");

                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    selectQuery.Append("WHERE ");
                    selectQuery.Append("CustomerId = @CustomerId;");
                }
                else if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    selectQuery.Append("WHERE ");
                    selectQuery.Append("FirstName = @FirstName;");
                }
                else if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                {
                    selectQuery.Append("WHERE ");
                    selectQuery.Append("LastName = @LastName;");
                }
                else if (!string.IsNullOrEmpty(textBox4.Text.Trim()))
                {
                    selectQuery.Append("WHERE ");
                    selectQuery.Append("Synonym = @Synonym;");
                }
                using (SqlCommand commandSql = new SqlCommand(selectQuery.ToString()))
                {

                    if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                    {
                        commandSql.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(textBox1.Text.Trim()));
                    }
                    else if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                    {
                        commandSql.Parameters.AddWithValue("@FirstName", textBox2.Text.Trim());
                    }
                    else if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                    {
                        commandSql.Parameters.AddWithValue("@LastName", textBox3.Text.Trim());
                    }
                    else if (!string.IsNullOrEmpty(textBox4.Text.Trim()))
                    {
                        commandSql.Parameters.AddWithValue("@Synonym", textBox4.Text.Trim());
                    }

                    DataAccessLayer dal = new DataAccessLayer();
                    datTable = dal.Select(commandSql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return datTable;
        }

        private bool Insert(string firstName, string lastName, string synonym)
        {
            bool isInserted = false;
            try
            {
                int rowsAffected = 0;
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append("INSERT INTO Customer ");
                insertQuery.Append("(");
                insertQuery.Append("FirstName, ");
                insertQuery.Append("LastName, ");
                insertQuery.Append("Synonym ");
                insertQuery.Append(") ");
                insertQuery.Append("VALUES ");
                insertQuery.Append("(");
                insertQuery.Append("@FirstName, ");
                insertQuery.Append("@LastName, ");
                insertQuery.Append("@Synonym ");
                insertQuery.Append(");");

                using (SqlCommand commandSql = new SqlCommand(insertQuery.ToString()))
                {
                    commandSql.Parameters.AddWithValue("@FirstName", firstName);
                    commandSql.Parameters.AddWithValue("@LastName", lastName);
                    commandSql.Parameters.AddWithValue("@Synonym", synonym);

                    DataAccessLayer dal = new DataAccessLayer();
                    rowsAffected = dal.Insert(commandSql);
                }

                if (rowsAffected > 0)
                {
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isInserted;
        }


        private bool Update(int custId, string firstName, string lastName, string synonym)
        {
            bool isUpdated = false;
            try
            {
                int rowsAffected = 0;
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append("UPDATE Customer ");
                updateQuery.Append("SET ");
                updateQuery.Append("FirstName = @FirstName, ");
                updateQuery.Append("LastName = @LastName, ");
                updateQuery.Append("Synonym = @Synonym ");
                updateQuery.Append("WHERE ");
                updateQuery.Append("CustomerId = @CustomerId;");
                using (SqlCommand commandSql = new SqlCommand(updateQuery.ToString()))
                {
                    commandSql.Parameters.AddWithValue("@CustomerId", custId);
                    commandSql.Parameters.AddWithValue("@FirstName", firstName);
                    commandSql.Parameters.AddWithValue("@LastName", lastName);
                    commandSql.Parameters.AddWithValue("@Synonym", synonym);
                    DataAccessLayer dal = new DataAccessLayer();
                    rowsAffected = dal.Update(commandSql);
                }

                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isUpdated;
        }

        private bool Delete(int custId)
        {
            bool isDeleted = false;

            try
            {
                int rowsAffected = 0;
                StringBuilder deleteQuery = new StringBuilder();
                deleteQuery.Append("DELETE FROM Customer ");
                deleteQuery.Append("WHERE ");
                deleteQuery.Append("CustomerId = @CustomerId;");
                using (SqlCommand commandSql = new SqlCommand(deleteQuery.ToString()))
                {
                    commandSql.Parameters.AddWithValue("@CustomerId", custId);
                    DataAccessLayer dal = new DataAccessLayer();
                    rowsAffected = dal.Delete(commandSql);
                }

                if (rowsAffected > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isDeleted;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult ResultDialog = MessageBox.Show("Do you want to insert?", "Insert",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultDialog == DialogResult.Yes)
            {
                string firstName = textBox2.Text.Trim();
                string lastName = textBox3.Text.Trim();
                string synonym = textBox4.Text.Trim();
                if (Insert(firstName, lastName, synonym))
                {
                    MessageBox.Show("Insert success.");

                    int RowCount = GetRowCount();
                    int index = RowCount - 1;
                    BindData(index);
                    currentIndex = RowCount;
                    textBox5.Text = Convert.ToString(currentIndex);
                }
            }
            else if (ResultDialog == DialogResult.No)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Select or navigate to update.");
                return;
            }
            DialogResult ResultDialog = MessageBox.Show("Do you want to update?", "Update",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultDialog == DialogResult.Yes)
            {
                int custId = Convert.ToInt32(textBox1.Text.Trim());
                string firstName = textBox2.Text.Trim();
                string lastName = textBox3.Text.Trim();
                string synonym = textBox4.Text.Trim();

                if (Update(custId, firstName, lastName, synonym))
                {
                    MessageBox.Show("Update success.");

                    int index = currentIndex - 1;
                    BindData(index);
                    textBox5.Text = Convert.ToString(currentIndex);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Select or navigate to delete.");
                return;
            }
            DialogResult ResultDialog = MessageBox.Show("Do you want to delete?", "Delete",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultDialog == DialogResult.Yes)
            {
                int custId = Convert.ToInt32(textBox1.Text.Trim());

                if (Delete(custId))
                {
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    MessageBox.Show("Delete success.");
                    int RowCount = GetRowCount();
                    int index = RowCount - 1;
                    BindData(index);
                    currentIndex = RowCount;
                    if (RowCount > 0)
                    {
                        textBox5.Text = Convert.ToString(currentIndex);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim())
             || !string.IsNullOrEmpty(textBox2.Text.Trim())
             || !string.IsNullOrEmpty(textBox3.Text.Trim())
             || !string.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                DataTable datTable = new DataTable();

                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    datTable = SelectRecord(textBox1.Text.Trim());
                }
                else if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    datTable = SelectRecord(textBox2.Text.Trim());
                }
                else if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                {
                    datTable = SelectRecord(textBox3.Text.Trim());
                }
                else if (!string.IsNullOrEmpty(textBox4.Text.Trim()))
                {
                    datTable = SelectRecord(textBox4.Text.Trim());
                }

                if (datTable != null && datTable.Rows.Count > 0)
                {
                    datTable.PrimaryKey = new[] { datTable.Columns["CustomerId"] };

                    //Also
                    //DataRow[] datRows = datTable.Select();
                    //DataRow datRow = datRows[0];
                    DataRow datRow = datTable.Rows[0];

                    DataTable recordDataTable = SelectRecord();

                    if (recordDataTable != null && recordDataTable.Rows.Count > 0)
                    {
                        recordDataTable.PrimaryKey = new[] { recordDataTable.Columns["CustomerId"] };

                        DataRow primaryKeyDataRow = recordDataTable.Rows.Find(datRow["CustomerId"]);
                        int index = recordDataTable.Rows.IndexOf(primaryKeyDataRow);

                        //Also LINQ
                        DataRow linqDataRow = recordDataTable.AsEnumerable().FirstOrDefault(r => r["CustomerId"].Equals(datRow["CustomerId"]));
                        int linqIndex = recordDataTable.Rows.IndexOf(linqDataRow);

                        BindData(index);
                        currentIndex = index + 1;

                        textBox5.Text = Convert.ToString(currentIndex);
                    }
                    else
                    {
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        textBox4.Text = string.Empty;
                        textBox5.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("No record found.");
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please enter First Name or Last Name or Synonym to retrieve the record.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NavigateForward();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NavigateBackward();
        }
    }
}
