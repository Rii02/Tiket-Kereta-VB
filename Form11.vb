Imports MySql.Data.MySqlClient

Public Class Form11
    Dim conn As New MySqlConnection("server=localhost;user=root;password=;database=tiket_kereta")
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Public cmd As MySqlCommand

    Private Sub LoadKeretaData()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT * FROM kereta"
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView2.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kereta: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    Private Sub LoadRuteDataGrid()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM rute"
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data rute: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadRuteComboBox()
        Try
            conn.Open()
            Dim query As String = "SELECT ID_RUTE FROM rute"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ComboBox1.Items.Clear()
            While reader.Read()
                ComboBox1.Items.Add(reader("ID_RUTE").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data ke ComboBox: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function GetNextID() As Integer
        Dim nextID As Integer = 1
        Try
            conn.Open()
            Dim query As String = "SELECT MAX(ID_KERETA) FROM kereta"
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
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
           ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Harap isi semua field!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "INSERT INTO kereta (ID_KERETA, NAMA_KERETA, JENIS_KERETA, KAPASITAS, ID_RUTE) " &
                                  "VALUES (@ID_KERETA, @NAMA_KERETA, @JENIS_KERETA, @KAPASITAS, @ID_RUTE)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID_KERETA", TextBox1.Text)
            cmd.Parameters.AddWithValue("@NAMA_KERETA", TextBox2.Text)
            cmd.Parameters.AddWithValue("@JENIS_KERETA", TextBox3.Text)
            cmd.Parameters.AddWithValue("@KAPASITAS", TextBox4.Text)
            cmd.Parameters.AddWithValue("@ID_RUTE", ComboBox1.SelectedItem)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data kereta berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadKeretaData()
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Gagal menambahkan data kereta: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Pilih data untuk diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "UPDATE kereta SET NAMA_KERETA=@NAMA_KERETA, JENIS_KERETA=@JENIS_KERETA, KAPASITAS=@KAPASITAS, ID_RUTE=@ID_RUTE " &
                                  "WHERE ID_KERETA=@ID_KERETA"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID_KERETA", TextBox1.Text)
            cmd.Parameters.AddWithValue("@NAMA_KERETA", TextBox2.Text)
            cmd.Parameters.AddWithValue("@JENIS_KERETA", TextBox3.Text)
            cmd.Parameters.AddWithValue("@KAPASITAS", TextBox4.Text)
            cmd.Parameters.AddWithValue("@ID_RUTE", ComboBox1.SelectedItem)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data kereta berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadKeretaData()
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data kereta: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Pilih data untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()
            Dim query As String = "DELETE FROM kereta WHERE ID_KERETA=@ID_KERETA"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID_KERETA", TextBox1.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Data kereta berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadKeretaData()
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data kereta: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadKeretaData()
        LoadRuteDataGrid()
        LoadRuteComboBox()
        TextBox1.Text = GetNextID().ToString()
    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        If DataGridView2.SelectedRows.Count > 0 Then
            TextBox1.Text = DataGridView2.SelectedRows(0).Cells("ID_KERETA").Value.ToString()
            TextBox2.Text = DataGridView2.SelectedRows(0).Cells("NAMA_KERETA").Value.ToString()
            TextBox3.Text = DataGridView2.SelectedRows(0).Cells("JENIS_KERETA").Value.ToString()
            TextBox4.Text = DataGridView2.SelectedRows(0).Cells("KAPASITAS").Value.ToString()
            ComboBox1.SelectedItem = DataGridView2.SelectedRows(0).Cells("ID_RUTE").Value.ToString()
        End If
    End Sub
End Class
