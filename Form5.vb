
Imports MySql.Data.MySqlClient

Public Class Form5
    Dim conn As New MySqlConnection("server=localhost;user=root;password=;database=tiket_kereta")
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader

    Private Sub LoadComboBox()
        Try
            conn.Open()

            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox4.Items.Clear()

            Dim queryPelanggan As String = "SELECT ID_PELANGGAN, NAMA FROM pelanggan"
            Dim daPelanggan As New MySqlDataAdapter(queryPelanggan, conn)
            Dim dsPelanggan As New DataSet()
            daPelanggan.Fill(dsPelanggan, "pelanggan")
            ComboBox1.DataSource = dsPelanggan.Tables("pelanggan")
            ComboBox1.DisplayMember = "NAMA"
            ComboBox1.ValueMember = "ID_PELANGGAN"

            Dim queryAdmin As String = "SELECT ID_ADMIN, NAMA_ADMIN FROM admin"
            Dim daAdmin As New MySqlDataAdapter(queryAdmin, conn)
            Dim dsAdmin As New DataSet()
            daAdmin.Fill(dsAdmin, "admin")
            ComboBox2.DataSource = dsAdmin.Tables("admin")
            ComboBox2.DisplayMember = "NAMA_ADMIN"
            ComboBox2.ValueMember = "ID_ADMIN"

            Dim queryTiket As String = "SELECT ID_TIKET FROM tiket"
            Dim daTiket As New MySqlDataAdapter(queryTiket, conn)
            Dim dsTiket As New DataSet()
            daTiket.Fill(dsTiket, "tiket")
            ComboBox4.DataSource = dsTiket.Tables("tiket")
            ComboBox4.DisplayMember = "ID_TIKET"
            ComboBox4.ValueMember = "ID_TIKET"
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

    Private Sub LoadTiketDataGrid()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = "SELECT * FROM tiket"
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

    Private Sub LoadKeretaDataGrid()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = "SELECT * FROM kereta"
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView2.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data rute: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadStasiunDataGrid()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = "SELECT * FROM stasiun"
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView3.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data rute: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadRuteDataGrid()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = "SELECT * FROM rute"
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView4.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data rute: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadPemesananDataGrid()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = "SELECT * FROM pemesanan"
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView5.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pemesanan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function GetNextID(tableName As String, columnName As String) As Integer
        Dim nextID As Integer = 1
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = $"SELECT MAX({columnName}) FROM {tableName}"
            cmd = New MySqlCommand(query, conn)
            Dim result = cmd.ExecuteScalar()

            If result IsNot DBNull.Value Then
                nextID = Convert.ToInt32(result) + 1
            End If
        Catch ex As Exception
            MessageBox.Show($"Gagal mendapatkan ID berikutnya untuk {columnName}: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        Return nextID
    End Function


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBox()
        LoadTiketDataGrid()
        LoadKeretaDataGrid()
        LoadStasiunDataGrid()
        LoadRuteDataGrid()
        LoadPemesananDataGrid()
        TextBox1.Text = GetNextID("pemesanan", "ID_PEMESANAN").ToString()
        TextBox2.Text = GetNextID("pembayaran", "ID_PEMBAYARAN").ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()

            Dim queryPembayaran As String = "INSERT INTO pembayaran (ID_PEMBAYARAN, METODE_PEMBAYARAN) VALUES (@ID_PEMBAYARAN, @METODE_PEMBAYARAN)"
            cmd = New MySqlCommand(queryPembayaran, conn)
            cmd.Parameters.AddWithValue("@ID_PEMBAYARAN", TextBox2.Text)
            cmd.Parameters.AddWithValue("@METODE_PEMBAYARAN", ComboBox5.SelectedItem)
            cmd.ExecuteNonQuery()

            Dim queryPemesanan As String = "INSERT INTO pemesanan (ID_PEMESANAN, ID_PELANGGAN, ID_PEMBAYARAN, ID_ADMIN, TANGGAL_PEMESANAN, STATUS_PEMESANAN, TANGGAL_PEMBAYARAN)" &
                                           "VALUES (@ID_PEMESANAN, @ID_PELANGGAN, @ID_PEMBAYARAN, @ID_ADMIN, @TANGGAL_PEMESANAN, @STATUS_PEMESANAN, @TANGGAL_PEMBAYARAN)"
            cmd = New MySqlCommand(queryPemesanan, conn)
            cmd.Parameters.AddWithValue("@ID_PEMESANAN", TextBox1.Text)
            cmd.Parameters.AddWithValue("@ID_PELANGGAN", GetComboBoxValue(ComboBox1))
            cmd.Parameters.AddWithValue("@ID_PEMBAYARAN", TextBox2.Text)
            cmd.Parameters.AddWithValue("@ID_ADMIN", GetComboBoxValue(ComboBox2))
            cmd.Parameters.AddWithValue("@TANGGAL_PEMESANAN", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@STATUS_PEMESANAN", "Belum Selesai")
            cmd.Parameters.AddWithValue("@TANGGAL_PEMBAYARAN", DateTimePicker2.Value.ToString("yyyy-MM-dd"))
            cmd.ExecuteNonQuery()

            Dim queryTiketPemesanan As String = "INSERT INTO tiket_pemesanan (ID_PEMESANAN, ID_TIKET) VALUES (@ID_PEMESANAN, @ID_TIKET)"
            cmd = New MySqlCommand(queryTiketPemesanan, conn)
            cmd.Parameters.AddWithValue("@ID_PEMESANAN", TextBox1.Text)
            cmd.Parameters.AddWithValue("@ID_TIKET", GetComboBoxValue(ComboBox4))
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadPemesananDataGrid()

            TextBox1.Text = GetNextID("pemesanan", "ID_PEMESANAN").ToString()
            TextBox2.Text = GetNextID("pembayaran", "ID_PEMBAYARAN").ToString()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox4.SelectedIndex = -1
            ComboBox5.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            conn.Open()

            Dim queryUpdateStatus As String = "UPDATE pemesanan SET STATUS_PEMESANAN = 'Selesai' WHERE ID_PEMESANAN = @ID_PEMESANAN"
            cmd = New MySqlCommand(queryUpdateStatus, conn)
            cmd.Parameters.AddWithValue("@ID_PEMESANAN", TextBox1.Text)
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Pembayaran Berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPemesananDataGrid()
            Else
                MessageBox.Show("ID Pemesanan tidak ditemukan atau gagal diubah.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            TextBox1.Text = GetNextID("pemesanan", "ID_PEMESANAN").ToString()
            TextBox2.Text = GetNextID("pembayaran", "ID_PEMBAYARAN").ToString()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox4.SelectedIndex = -1
            ComboBox5.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class