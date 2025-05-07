
Imports MySql.Data.MySqlClient

Public Class Form8
    Dim conn As New MySqlConnection("server=localhost;user=root;password=;database=tiket_kereta")
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public Sub LoadTiketData()
        Try
            conn.Open()

            Dim query As String = "SELECT * FROM tiket"
            da = New MySqlDataAdapter(query, conn)
            ds = New DataSet()
            da.Fill(ds, "tiket")

            DataGridView1.DataSource = ds.Tables("tiket")
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data tiket: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
    Public Sub LoadJadwalData()
        Try
            conn.Open()

            Dim query As String = "SELECT * FROM jadwal"
            da = New MySqlDataAdapter(query, conn)
            ds = New DataSet()
            da.Fill(ds, "jadwal")

            DataGridView2.DataSource = ds.Tables("jadwal")
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data jadwal: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadComboBox()
        Try
            conn.Open()

            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()

            Dim queryJadwal As String = "SELECT ID_JADWAL FROM jadwal"
            Dim daJadwal As New MySqlDataAdapter(queryJadwal, conn)
            Dim dsJadwal As New DataSet()
            daJadwal.Fill(dsJadwal, "jadwal")
            ComboBox1.DataSource = dsJadwal.Tables("jadwal")
            ComboBox1.DisplayMember = "ID_JADWAL"
            ComboBox1.ValueMember = "ID_JADWAL"

            Dim queryKereta As String = "SELECT ID_KERETA, NAMA_KERETA FROM kereta"
            Dim daKereta As New MySqlDataAdapter(queryKereta, conn)
            Dim dsKereta As New DataSet()
            daKereta.Fill(dsKereta, "kereta")
            ComboBox2.DataSource = dsKereta.Tables("kereta")
            ComboBox2.DisplayMember = "NAMA_KERETA"
            ComboBox2.ValueMember = "ID_KERETA"

            Dim queryStasiun As String = "SELECT ID_STASIUN, NAMA_STASIUN FROM stasiun"
            Dim daStasiun As New MySqlDataAdapter(queryStasiun, conn)
            Dim dsStasiun As New DataSet()
            daStasiun.Fill(dsStasiun, "stasiun")
            ComboBox3.DataSource = dsStasiun.Tables("stasiun")
            ComboBox3.DisplayMember = "NAMA_STASIUN"
            ComboBox3.ValueMember = "ID_STASIUN"
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
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If
            Dim query As String = "SELECT MAX(ID_TIKET) FROM tiket"
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

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBox()
        LoadTiketData()
        LoadJadwalData()
        TextBox1.Text = GetNextID().ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()
            Dim query As String = "INSERT INTO tiket (ID_TIKET, ID_JADWAL, ID_KERETA, HARGA_TIKET, NO_KURSI, TANGGAL_TIKET, ID_STASIUN) " &
                                  "VALUES (@ID_TIKET, @ID_JADWAL, @ID_KERETA, @HARGA_TIKET, @NO_KURSI, @TANGGAL_TIKET, @ID_STASIUN)"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ID_TIKET", TextBox1.Text)
            cmd.Parameters.AddWithValue("@ID_JADWAL", GetComboBoxValue(ComboBox1))
            cmd.Parameters.AddWithValue("@ID_KERETA", GetComboBoxValue(ComboBox2))
            cmd.Parameters.AddWithValue("@HARGA_TIKET", TextBox2.Text)
            cmd.Parameters.AddWithValue("@NO_KURSI", TextBox3.Text)
            cmd.Parameters.AddWithValue("@TANGGAL_TIKET", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ID_STASIUN", GetComboBoxValue(ComboBox3))

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            conn.Open()
            Dim query As String = "UPDATE tiket SET ID_JADWAL=@ID_JADWAL, ID_KERETA=@ID_KERETA, HARGA_TIKET=@HARGA_TIKET, " &
                                  "NO_KURSI=@NO_KURSI, TANGGAL_TIKET=@TANGGAL_TIKET, ID_STASIUN=@ID_STASIUN WHERE ID_TIKET=@ID_TIKET"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ID_TIKET", TextBox1.Text)
            cmd.Parameters.AddWithValue("@ID_JADWAL", GetComboBoxValue(ComboBox1))
            cmd.Parameters.AddWithValue("@ID_KERETA", GetComboBoxValue(ComboBox2))
            cmd.Parameters.AddWithValue("@HARGA_TIKET", TextBox2.Text)
            cmd.Parameters.AddWithValue("@NO_KURSI", TextBox3.Text)
            cmd.Parameters.AddWithValue("@TANGGAL_TIKET", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ID_STASIUN", GetComboBoxValue(ComboBox3))

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            conn.Open()
            Dim query As String = "DELETE FROM tiket WHERE ID_TIKET=@ID_TIKET"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID_TIKET", TextBox1.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox3.SelectedIndex = -1
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
        ComboBox1.SelectedValue = DataGridView1.Item(1, i).Value
        ComboBox2.SelectedValue = DataGridView1.Item(2, i).Value
        TextBox2.Text = DataGridView1.Item(3, i).Value
        TextBox3.Text = DataGridView1.Item(4, i).Value
        DateTimePicker1.Value = DataGridView1.Item(5, i).Value
        ComboBox3.SelectedValue = DataGridView1.Item(6, i).Value

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells("ID_TIKET").Value.ToString()
            ComboBox1.SelectedValue = DataGridView1.SelectedRows(0).Cells("ID_JADWAL").Value.ToString()
            ComboBox2.SelectedValue = DataGridView1.SelectedRows(0).Cells("ID_KERETA").Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells("HARGA_TIKET").Value.ToString()
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells("NO_KURSI").Value.ToString()
            DateTimePicker1.Value = DataGridView1.SelectedRows(0).Cells("TANGGAL_TIKET").Value.ToString()
            ComboBox3.SelectedValue = DataGridView1.SelectedRows(0).Cells("ID_STASIUN").Value.ToString()
        End If
    End Sub
End Class
