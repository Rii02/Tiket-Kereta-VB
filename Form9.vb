Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form9
    Public conn As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader

    Public Sub koneksi()
        Dim strconn As String
        Try
            strconn = "server=localhost;user=root;password=;database=tiket_kereta"
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.ConnectionString = strconn
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetNextID() As Integer
        Dim nextID As Integer = 1
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim query As String = "SELECT MAX(ID_RUTE) FROM rute"
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
        Dim query As String = "INSERT INTO rute (ID_RUTE, STASIUN_AWAL, STASIUN_TUJUAN, DURASI_PERJALANAN) " &
              "VALUES (@ID_RUTE, @STASIUN_AWAL, @STASIUN_TUJUAN, @DURASI_PERJALANAN)"
        cmd = New MySqlCommand(query, conn)

        cmd.Parameters.AddWithValue("@ID_RUTE", TextBox1.Text)
        cmd.Parameters.AddWithValue("@STASIUN_AWAL", TextBox2.Text)
        cmd.Parameters.AddWithValue("@STASIUN_TUJUAN", TextBox3.Text)
        cmd.Parameters.AddWithValue("@DURASI_PERJALANAN", TextBox4.Text)

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil ditambahkan")
            da = New MySqlDataAdapter("select * from rute", conn)
            ds = New DataSet
            da.Fill(ds, "tiket_kereta")
            DataGridView1.DataSource = ds.Tables("tiket_kereta")
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()

        Dim query As String = "UPDATE rute SET STASIUN_AWAL = @STASIUN_AWAL, STASIUN_TUJUAN = @STASIUN_TUJUAN, DURASI_PERJALANAN = @DURASI_PERJALANAN WHERE ID_STASIUN = @ID_STASIUN"
        cmd = New MySqlCommand(query, conn)

        cmd.Parameters.AddWithValue("@ID_RUTE", TextBox1.Text)
        cmd.Parameters.AddWithValue("@STASIUN_AWAL", TextBox2.Text)
        cmd.Parameters.AddWithValue("@STASIUN_TUJUAN", TextBox3.Text)
        cmd.Parameters.AddWithValue("@DURASI_PERJALANAN", TextBox4.Text)

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil ditambahkan")
            da = New MySqlDataAdapter("select * from rute", conn)
            ds = New DataSet
            da.Fill(ds, "tiket_kereta")
            DataGridView1.DataSource = ds.Tables("tiket_kereta")
            TextBox1.Text = GetNextID().ToString()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        Dim confirm As DialogResult
        confirm = MessageBox.Show("Yakin ingin menghapus data?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then
            Dim query As String = "DELETE FROM rute WHERE ID_RUTE = @ID_RUTE"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ID_RUTE", TextBox1.Text)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil ditambahkan")
                da = New MySqlDataAdapter("select * from rute", conn)
                ds = New DataSet
                da.Fill(ds, "tiket_kereta")
                DataGridView1.DataSource = ds.Tables("tiket_kereta")
                TextBox1.Text = GetNextID().ToString()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        da = New MySqlDataAdapter("select * from rute", conn)
        ds = New DataSet
        da.Fill(ds, "tiket_kereta")
        DataGridView1.DataSource = ds.Tables("tiket_kereta")
        TextBox1.Text = GetNextID().ToString()

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox3.Text = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(3, i).Value

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells("ID_RUTE").Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells("STASIUN_AWAL").Value.ToString()
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells("STASIUN_TUJUAN").Value.ToString()
            TextBox4.Text = DataGridView1.SelectedRows(0).Cells("DURASI_PERJALANAN").Value.ToString()
        End If
    End Sub

End Class