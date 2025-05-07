Imports MySql.Data.MySqlClient

Public Class Form1
    Private conn As New MySqlConnection("server=localhost;user=root;password=;database=tiket_kereta")
    Private cmd As MySqlCommand
    Private dr As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text.Trim() = "" Or TextBox2.Text.Trim() = "" Then
            MessageBox.Show("Username dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT * FROM admin WHERE NAMA_ADMIN = @NAMA_ADMIN AND PASSWORD = @PASSWORD"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@NAMA_ADMIN", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@PASSWORD", TextBox2.Text.Trim())

            dr = cmd.ExecuteReader()

            If dr.HasRows Then

                MessageBox.Show("Login berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim mainForm As New Form2()
                mainForm.Show()
                Me.Hide()
            Else

                MessageBox.Show("Username atau Password salah!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
