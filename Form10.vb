Imports MySql.Data.MySqlClient

Public Class Form10
    Dim conn As New MySqlConnection("server=localhost;user=root;password=;database=tiket_kereta")
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader

    Private Sub LoadDataGridView()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            da = New MySqlDataAdapter("SELECT * FROM feedback", conn)
            ds = New DataSet
            da.Fill(ds, "feedback")
            DataGridView1.DataSource = ds.Tables("feedback")
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    Private Sub LoadComboBox()
        Try
            conn.Open()

            Dim queryPemesanan As String = "SELECT ID_PEMESANAN FROM pemesanan"
            Dim daPemesanan As New MySqlDataAdapter(queryPemesanan, conn)
            Dim dsPemesanan As New DataSet()
            daPemesanan.Fill(dsPemesanan, "pemesanan")
            ComboBox2.DataSource = dsPemesanan.Tables("pemesanan")
            ComboBox2.DisplayMember = "ID_PEMESANAN"
            ComboBox2.ValueMember = "ID_PEMESANAN"

            Dim queryPelanggan As String = "SELECT ID_PELANGGAN, NAMA FROM pelanggan"
            Dim daPelanggan As New MySqlDataAdapter(queryPelanggan, conn)
            Dim dsPelanggan As New DataSet()
            daPelanggan.Fill(dsPelanggan, "pelanggan")
            ComboBox3.DataSource = dsPelanggan.Tables("pelanggan")
            ComboBox3.DisplayMember = "NAMA"
            ComboBox3.ValueMember = "ID_PELANGGAN"

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat data: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function GetComboBoxValue(cb As ComboBox) As String
        If cb.SelectedValue IsNot Nothing Then
            Return cb.SelectedValue.ToString()
        End If
        Return ""
    End Function

    Private Function GetNextID() As Integer
        Dim nextID As Integer = 1
        Try
            conn.Open()
            Dim query As String = "SELECT MAX(ID_FEEDBACK) FROM feedback"
            cmd = New MySqlCommand(query, conn)
            Dim result = cmd.ExecuteScalar()

            If result IsNot DBNull.Value Then
                nextID = Convert.ToInt32(result) + 1
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal mendapatkan ID berikutnya: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        Return nextID
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()
            Dim query As String = "INSERT INTO feedback (ID_FEEDBACK, ID_PEMESANAN, ID_PELANGGAN, RATING, KOMENTAR) " &
                                  "VALUES (@ID_FEEDBACK, @ID_PEMESANAN, @ID_PELANGGAN, @RATING, @KOMENTAR)"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ID_FEEDBACK", TextBox1.Text)
            cmd.Parameters.AddWithValue("@ID_PEMESANAN", GetComboBoxValue(ComboBox2))
            cmd.Parameters.AddWithValue("@ID_PELANGGAN", GetComboBoxValue(ComboBox3))
            cmd.Parameters.AddWithValue("@RATING", ComboBox1.SelectedItem)
            cmd.Parameters.AddWithValue("@KOMENTAR", RichTextBox1.Text)


            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataGridView()
            TextBox1.Text = GetNextID().ToString()
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1
            ComboBox1.SelectedIndex = -1
            RichTextBox1.Clear()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            conn.Open()
            Dim query As String = "DELETE FROM feedback WHERE ID_FEEDBACK=@ID_FEEDBACK"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID_FEEDBACK", TextBox1.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataGridView()
            TextBox1.Text = GetNextID().ToString()
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1
            ComboBox1.SelectedIndex = -1
            RichTextBox1.Clear()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        ComboBox2.SelectedValue = DataGridView1.Item(1, i).Value
        ComboBox3.SelectedValue = DataGridView1.Item(2, i).Value
        ComboBox1.SelectedValue = DataGridView1.Item(3, i).Value
        RichTextBox1.Text = DataGridView1.Item(3, i).Value


    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells("ID_FEEDBACK").Value.ToString()
            ComboBox2.SelectedValue = DataGridView1.SelectedRows(0).Cells("ID_PEMESANAN").Value.ToString()
            ComboBox3.SelectedValue = DataGridView1.SelectedRows(0).Cells("ID_PELANGGAN").Value.ToString()
            ComboBox1.SelectedValue = DataGridView1.SelectedRows(0).Cells("RATING").Value.ToString()
            RichTextBox1.Text = DataGridView1.SelectedRows(0).Cells("KOMENTAR").Value.ToString()
        End If
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBox()
        TextBox1.Text = GetNextID().ToString()
        da = New MySqlDataAdapter("select * from feedback", conn)
        ds = New DataSet
        da.Fill(ds, "tiket_kereta")
        DataGridView1.DataSource = ds.Tables("tiket_kereta")
    End Sub
End Class