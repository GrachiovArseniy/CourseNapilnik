private void checkButton_Click(object sender, EventArgs e)
{
    Check(this.passportTextBox.Text);

    string connectionString = string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

    SQLiteConnection connection = new SQLiteConnection(connectionString);

    connection.Open();

    DataTable dataTable = FillTable(connection);
    CheckAccess(dataTable);

    connection.Close();
}

private void CheckPassport(string passportData)
{
    if (passportData.Trim() == " ")
    {
        int num1 = (int)MessageBox.Show("Введите серию и номер паспорта");
        throw new InvalidOperationException();
    }
    else if (passportData.Trim().Replace(" ", string.Empty).Length < 10)
    {
        this.textResult.Text = "Неверный формат серии или номера паспорта";
        throw new InvalidOperationException();
    }
}

private DataTable FillTable(SQLiteConnection connection)
{
    try
    {
        string commandText = string.Format("select * from passports where num='{0} limit 1;", (object)Form1.ComputeSha256Hash(rawData));

        SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(commandText, connection));
        DataTable dataTable = new DataTable();
        sqLiteDataAdapter.Fill(dataTable);

        return dataTable;
    }
    catch (SQLiteException ex)
    {
        if (ex.ErrorCode != 1)
        {
            throw new InvalidOperationException();
        }

            int num2 = (int)MessageBox.Show("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
    }
}

private void CheckAccess(DataTable dataTable)
{
    if (dataTable.Rows.Count > 0)
    {
        this.textResult.Text = "По паспорту <<" +
                                        this.passportTextbox.Text +
                                                        ">> доступ к бюллетеню на дистанционном электронном голосовании " +
                                                                Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]) ?
                                                                        "ПРЕДОСТАВЛЕН" :
                                                                        "НЕ ПРЕДОСТАВЛЯЛСЯ";
    }
    else
    {
        this.textResult.Text = "Паспорт <<" + this.passportTextbox.Text + ">> в списке участников дистанционного голосования НЕ НАЙДЕН";
    }
}
