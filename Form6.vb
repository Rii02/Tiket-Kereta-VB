Imports MySql.Data.MySqlClient

Public Class Form6
    Public conn As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet

    Public Sub koneksi()
        Dim strconn As String = "server=localhost;user=root;password=;database=tiket_kereta"
        conn.ConnectionString = strconn
        Try
            conn.Open()
            conn.Close()
        Catch ex As Exception
            MsgBox("Koneksi Gagal: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadData(Optional filter As String = "")
        Call koneksi()

        Try
            conn.Open()

            Dim query As String = "SELECT 
                        p.NAMA AS 'Nama_Pelanggan',
                        k.NAMA_KERETA AS 'Nama_Kereta',
                        t.ID_JADWAL AS 'ID_Jadwal',
                        t.HARGA_TIKET AS 'Harga_Tiket',
                        t.NO_KURSI AS 'No_Kursi',
                        pemb.METODE_PEMBAYARAN AS 'Metode_Pembayaran',
                        pem.TANGGAL_PEMESANAN AS 'Tanggal_Pemesanan'
                    FROM 
                        tiket_pemesanan tp
                    JOIN 
                        tiket t ON tp.ID_TIKET = t.ID_TIKET
                    JOIN 
                        pemesanan pem ON tp.ID_PEMESANAN = pem.ID_PEMESANAN
                    JOIN 
                        pelanggan p ON pem.ID_PELANGGAN = p.ID_PELANGGAN
                    JOIN 
                        kereta k ON t.ID_KERETA = k.ID_KERETA
                    JOIN
                        pembayaran pemb ON pemb.ID_PEMBAYARAN = pem.ID_PEMBAYARAN
                    ORDER BY 
                        pem.TANGGAL_PEMESANAN DESC;"


            If Not String.IsNullOrEmpty(filter) Then
                query &= " WHERE " & filter
            End If

            da = New MySqlDataAdapter(query, conn)
            ds = New DataSet()

            da.Fill(ds, "data")

            DataGridView1.DataSource = ds.Tables("data")
            conn.Close()
        Catch ex As Exception
            MsgBox("Gagal memuat data: " & ex.Message)
        End Try
    End Sub



    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filter As String = ""

        If CheckBox1.Checked Then
            filter &= $"pem.TANGGAL_PEMESANAN = '{DateTimePicker1.Value.ToString("yyyy-MM-dd")}'"
        End If

        If CheckBox2.Checked Then
            Dim bulan As Integer = ComboBox1.SelectedIndex + 1
            If filter <> "" Then filter &= " AND "
            filter &= $"MONTH(pem.TANGGAL_PEMESANAN) = {bulan}"
        End If

        If CheckBox3.Checked Then
            If filter <> "" Then filter &= " AND "
            filter &= $"YEAR(pem.TANGGAL_PEMESANAN) = {TextBox1.Text}"
        End If

        Dim query As String = "SELECT 
                            p.NAMA AS 'Nama_Pelanggan',
                            k.NAMA_KERETA AS 'Nama_Kereta',
                            t.ID_JADWAL AS 'ID_Jadwal',
                            t.HARGA_TIKET AS 'Harga_Tiket',
                            t.NO_KURSI AS 'No_Kursi',
                            pemb.METODE_PEMBAYARAN AS 'Metode_Pembayaran',
                            pem.TANGGAL_PEMESANAN AS 'Tanggal_Pemesanan'
                        FROM 
                            tiket_pemesanan tp
                        JOIN 
                            tiket t ON tp.ID_TIKET = t.ID_TIKET
                        JOIN 
                            pemesanan pem ON tp.ID_PEMESANAN = pem.ID_PEMESANAN
                        JOIN 
                            pelanggan p ON pem.ID_PELANGGAN = p.ID_PELANGGAN
                        JOIN 
                            kereta k ON t.ID_KERETA = k.ID_KERETA
                        JOIN
                            pembayaran pemb ON pemb.ID_PEMBAYARAN = pem.ID_PEMBAYARAN"


        If Not String.IsNullOrEmpty(filter) Then
            query &= " WHERE " & filter
        End If

        query &= " ORDER BY pem.TANGGAL_PEMESANAN DESC;"

        da = New MySqlDataAdapter(query, conn)
        ds = New DataSet()
        da.Fill(ds, "data")
        DataGridView1.DataSource = ds.Tables("data")
        conn.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet1
        Dim dt As New DataTable
        dt = ds.Tables("data")
        For i = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add(DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value,
                        DataGridView1.Rows(i).Cells(2).Value, DataGridView1.Rows(i).Cells(3).Value,
                        DataGridView1.Rows(i).Cells(4).Value, DataGridView1.Rows(i).Cells(5).Value,
                        DataGridView1.Rows(i).Cells(6).Value)

        Next
        With Form7.ReportViewer1.LocalReport
            .ReportPath = "D:\Kuliah\SMT 3\Basis Data\tiket_kereta\Report1.rdlc"
            .DataSources.Clear()
            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
        End With
        Form7.Show()
        Form7.ReportViewer1.RefreshReport()
    End Sub
End Class
