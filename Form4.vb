Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form4
    Public conn As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As MySqlCommand

    Public Sub koneksi()
        Dim strconn As String
        Try
            strconn = "server=localhost;user=root;password=;database=tiket_kereta"
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.ConnectionString = strconn
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadJadwalData()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT * FROM jadwal"
            da = New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data jadwal: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function GetNextID() As Integer
        Dim nextID As Integer = 1
        Try
            conn.Open()
            Dim query As String = "SELECT MAX(ID_JADWAL) FROM jadwal"
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
        Call koneksi()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "INSERT INTO jadwal (ID_JADWAL, TANGGAL_BERANGKAT, WAKTU_BERANGKAT, WAKTU_TIBA) VALUES (@ID_JADWAL, @TANGGAL_BERANGKAT, @WAKTU_BERANGKAT, @WAKTU_TIBA)"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ID_JADWAL", TextBox1.Text)
            cmd.Parameters.AddWithValue("@TANGGAL_BERANGKAT", DateTimePicker1.Value)
            cmd.Parameters.AddWithValue("@WAKTU_BERANGKAT", TextBox4.Text)
            cmd.Parameters.AddWithValue("@WAKTU_TIBA", TextBox5.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil ditambahkan")
            LoadJadwalData()
            TextBox1.Text = GetNextID().ToString()
            TextBox4.Clear()
            TextBox5.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "UPDATE jadwal SET TANGGAL_BERANGKAT = @TANGGAL_BERANGKAT, WAKTU_BERANGKAT = @WAKTU_BERANGKAT, WAKTU_TIBA = @WAKTU_TIBA WHERE ID_JADWAL = @ID_JADWAL"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ID_JADWAL", TextBox1.Text)
            cmd.Parameters.AddWithValue("@TANGGAL_BERANGKAT", DateTimePicker1.Value)
            cmd.Parameters.AddWithValue("@WAKTU_BERANGKAT", TextBox4.Text)
            cmd.Parameters.AddWithValue("@WAKTU_TIBA", TextBox5.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil diperbarui")
            LoadJadwalData()
            TextBox1.Text = GetNextID().ToString()
            TextBox4.Clear()
            TextBox5.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        Dim confirm As DialogResult
        confirm = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim query As String = "DELETE FROM jadwal WHERE ID_JADWAL = @ID_JADWAL"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID_JADWAL", TextBox1.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil dihapus")
                LoadJadwalData()
                TextBox1.Text = GetNextID().ToString()
                TextBox4.Clear()
                TextBox5.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        LoadJadwalData()
        TextBox1.Text = GetNextID().ToString()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value.ToString()
        DateTimePicker1.Value = Convert.ToDateTime(DataGridView1.Item(1, i).Value)
        TextBox4.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox5.Text = DataGridView1.Item(3, i).Value.ToString()
    End Sub
End Class
