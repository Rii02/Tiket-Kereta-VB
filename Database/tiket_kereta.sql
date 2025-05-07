-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 07 Bulan Mei 2025 pada 11.55
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tiket_kereta`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `admin`
--

CREATE TABLE `admin` (
  `ID_ADMIN` int(11) NOT NULL,
  `NAMA_ADMIN` varchar(25) DEFAULT NULL,
  `PASSWORD` varchar(8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `admin`
--

INSERT INTO `admin` (`ID_ADMIN`, `NAMA_ADMIN`, `PASSWORD`) VALUES
(1, 'Rifki', '12345678'),
(2, 'Lenny', '12345678'),
(3, 'Shabrina', '12345678'),
(4, 'Rifda', '12345678');

-- --------------------------------------------------------

--
-- Struktur dari tabel `feedback`
--

CREATE TABLE `feedback` (
  `ID_FEEDBACK` int(11) NOT NULL,
  `ID_PEMESANAN` int(11) DEFAULT NULL,
  `ID_PELANGGAN` int(11) DEFAULT NULL,
  `RATING` varchar(20) DEFAULT NULL,
  `KOMENTAR` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `feedback`
--

INSERT INTO `feedback` (`ID_FEEDBACK`, `ID_PEMESANAN`, `ID_PELANGGAN`, `RATING`, `KOMENTAR`) VALUES
(1, 7, 2, '3', 'kelass'),
(2, 7, 2, '3', 'kelass'),
(3, 7, 2, '3', 'kelass'),
(4, 7, 2, '3', 'kelass'),
(5, 7, 2, '3', 'kelass'),
(6, 8, 6, '5', 'mahallll'),
(7, 5, 6, '3', 'sip'),
(8, 6, 5, '4', 'Mahallll'),
(9, 6, 9, '5', 'p'),
(10, 25, 2, '5', 'mantapp'),
(11, 8, 10, '4', 'keren'),
(13, 4, 13, '1', 'pelayanan kurang'),
(15, 20, 11, '5', 'gscor '),
(16, 25, 17, '4', 'kecintaann'),
(17, 11, 22, '5', 'sangat membantu'),
(18, 17, 24, '5', 'mudah digunakan'),
(19, 10, 25, '5', 'sangat mantulity'),
(20, 13, 3, '4', 'aplikasinya sangat membantu tetapi '),
(21, 7, 4, '4', 'mantul (mantap betul)'),
(22, 14, 5, '3', 'tampilannya kurang besar.'),
(23, 14, 11, '5', 'omo'),
(24, 16, 14, '1', 'kekecilen'),
(25, 4, 7, '5', 'kuerennnnn'),
(26, 7, 1, '3', 'p');

-- --------------------------------------------------------

--
-- Struktur dari tabel `jadwal`
--

CREATE TABLE `jadwal` (
  `ID_JADWAL` int(11) NOT NULL,
  `TANGGAL_BERANGKAT` varchar(25) DEFAULT NULL,
  `WAKTU_BERANGKAT` varchar(25) DEFAULT NULL,
  `WAKTU_TIBA` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `jadwal`
--

INSERT INTO `jadwal` (`ID_JADWAL`, `TANGGAL_BERANGKAT`, `WAKTU_BERANGKAT`, `WAKTU_TIBA`) VALUES
(1, '2024-12-04 19:07:40.33401', '07:00', '09:15'),
(2, '2024-12-10 12:04:03.16885', '10:00', '12:15'),
(3, '2024-12-16 13:46:08', '12.00', '17.00'),
(4, '2024-12-16 13:46:08', '17.00', '20.00'),
(5, '2024-12-16 15:09:31.60452', '08.00', '10.45'),
(6, '2024-12-16 15:09:31.60452', '09.30', '12.00'),
(7, '2024-12-16 15:09:31.60452', '15.30', '21.00'),
(8, '2024-12-16 15:09:31.60452', '16.00', '21.45'),
(9, '2024-12-16 15:09:31.60452', '17.15', '19.50'),
(10, '2024-12-16 15:09:31.60452', '18.00', '21.30'),
(11, '2024-12-16 15:09:31.60452', '20.00', '22.30'),
(12, '2024-12-16 15:09:31.60452', '21.15', '04.00'),
(13, '2024-12-16 15:09:31.60452', '06.15', '11.45'),
(14, '2024-12-16 15:09:31.60452', '10.00', '15.30'),
(15, '2024-12-16 15:09:31.60452', '10.30', '16.00'),
(16, '2024-12-16 15:09:31.60452', '11.00', '13.45'),
(17, '2024-12-16 15:09:31.60452', '12.00', '15.30'),
(18, '2024-12-16 15:09:31.60452', '13.00', '18.30'),
(19, '2024-12-16 15:09:31.60452', '14.00', '18.00'),
(20, '2024-12-16 15:09:31.60452', '15.00', '19.30'),
(21, '2024-12-16 15:09:31.60452', '17.00', '20.30'),
(22, '2024-12-16 15:09:31.60452', '18.00', '21.30'),
(23, '2024-12-16 15:09:31.60452', '19.00', '20.30'),
(24, '2024-12-16 15:09:31.60452', '20.00', '04.30'),
(25, '2024-12-16 15:09:31.60452', '21.00', '23.45');

-- --------------------------------------------------------

--
-- Struktur dari tabel `kereta`
--

CREATE TABLE `kereta` (
  `ID_KERETA` int(11) NOT NULL,
  `NAMA_KERETA` varchar(25) DEFAULT NULL,
  `JENIS_KERETA` varchar(25) DEFAULT NULL,
  `KAPASITAS` varchar(25) DEFAULT NULL,
  `ID_RUTE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `kereta`
--

INSERT INTO `kereta` (`ID_KERETA`, `NAMA_KERETA`, `JENIS_KERETA`, `KAPASITAS`, `ID_RUTE`) VALUES
(1, 'Argo Wilis', 'Eksekutif', '50', 1),
(2, 'Slebew', 'Ekonomi', '20', 2),
(3, 'Argo Bromo ', 'Eksekutif', '400', 7),
(4, 'Sritanjung', 'Ekonomi', '800', 11),
(5, 'Mutiara  Selatan ', 'Eksekutif', '500', 20),
(6, 'Tawang Aun', 'Ekonomi', '1200', 25),
(7, 'Sembrani', 'Eksekutif', '450', 1),
(8, 'Api Gumarang ', 'Ekonomi ', '700', 5),
(9, 'Brantas', 'Eksekutif', '1000', 10),
(10, 'Express Solo', 'Ekonomi', '350', 18),
(11, 'Api Kertajaya ', 'Ekonomi', '750', 20),
(12, 'Malabar', 'Eksekutif', '400', 22),
(13, 'Tegal', 'Ekonomi', '850', 23),
(14, 'Logawa', 'Eksekutif', '1000', 3),
(15, 'Majapahit ', 'Ekonomi', '1000', 14),
(16, 'Siliwangi', 'Eksekutif', '900', 3),
(17, 'Ranggajati', 'Ekonomi', '700', 17),
(18, 'Api Bima ', 'Eksekutif', '400', 19),
(19, 'Kuto Jaya', 'Ekonomi', '1000', 23),
(20, 'Tawang Jaya', 'Eksekutif', '350', 3),
(21, 'Sawunggalih', 'Ekonomi', '450', 3),
(22, 'Kahuripan', 'Eksekutif ', '800', 6),
(23, 'Wijaya Kusuma ', 'Ekonomi', '450', 7),
(24, 'Argo Parahyangan', 'Eksekutif', '400', 8),
(25, 'Prameks', 'Ekonomi', '700', 9),
(26, 'Menyala', 'Ekonomi', '40', 9),
(27, 'Elrich', 'Eksekutif', '400', 23),
(28, 'Damean Jaya', 'Ekonomi', '40', 18);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pelanggan`
--

CREATE TABLE `pelanggan` (
  `ID_PELANGGAN` int(11) NOT NULL,
  `NAMA` varchar(25) DEFAULT NULL,
  `NO_TELEPON` varchar(15) DEFAULT NULL,
  `EMAIL` varchar(25) DEFAULT NULL,
  `ALAMAT` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pelanggan`
--

INSERT INTO `pelanggan` (`ID_PELANGGAN`, `NAMA`, `NO_TELEPON`, `EMAIL`, `ALAMAT`) VALUES
(1, 'Aden', '085234513080', 'aden@gmail.com', 'Gresik'),
(2, 'Erik', '2147483647', 'erik@gmail.com', 'Gresik'),
(3, 'Shabrina', '2147483647', 'shabrina@gmail.com', 'jl. sememi'),
(4, 'Syafira', '2147483647', 'syafira@gmail.com', 'jl. kendung jaya'),
(5, 'olip', '2147483647', 'olip@gmail.com', 'jl. tempel'),
(6, 'rifda ', '2147483647', 'rifda@gmail.com', 'jl. burneh'),
(7, 'lenny', '2147483647', 'lenny@gmail.com', 'jl. klampis'),
(8, 'mufida', '2147483647', 'mufida@gmail.com', 'jl. mbenjeng'),
(9, 'amri', '2147483647', 'amri@gmail.com', 'jl. kemloko'),
(10, 'khanza', '2147483647', 'khanza@gmail.com', 'jl. sememi'),
(11, 'vano', '2147483647', 'vano@gmail.com', 'jl. kendung jaya'),
(12, 'ritsuki', '2147483647', 'ritsuki@gmail.com', 'jl. tunjungan'),
(13, 'natsuki', '2147483647', 'natsuki@gmail.com', 'jl. ngasem'),
(14, 'niken', '2147483647', 'niken@gmail.com', 'jl. klampis'),
(15, 'feiyaz', '2147483647', 'feiyaz@gmail.com', 'jl. meduran'),
(16, 'syfia', '2147483647', 'syifa@gmail.com', 'jl. tempel'),
(17, 'bita', '2147483647', 'bita@gmail.com', 'jl. berneh'),
(18, 'geisa', '2147483647', 'geisa@gmail.com', 'jl. berneh'),
(19, 'lubna', '2147483647', 'lubna@gmail.com', 'jl. berneh'),
(20, 'ayla', '2147483647', 'ayla@gmail.com', 'jl. berneh'),
(21, 'biyan', '081552210830', 'biyan@gmail.com', 'jl. berneh'),
(22, 'Reza', '085236617809', 'reza@gmail.com', 'Sidoarjo'),
(23, 'helmi', '0845269204', 'helmi', 'jl. kendung  jaya'),
(24, 'najwa', '0845269204', 'najwa@gmail.com', 'jl. majapahit'),
(25, 'apin', '0845269204', 'apin@gmail.com', 'jl. tengger raya'),
(26, 'Irul', '0897665513080', 'irul@gmail.com', 'Darjo Pride');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pembayaran`
--

CREATE TABLE `pembayaran` (
  `ID_PEMBAYARAN` int(11) NOT NULL,
  `METODE_PEMBAYARAN` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pembayaran`
--

INSERT INTO `pembayaran` (`ID_PEMBAYARAN`, `METODE_PEMBAYARAN`) VALUES
(0, 'Qris'),
(1, 'Qris'),
(2, 'Qris'),
(3, 'Qris'),
(4, 'Qris'),
(5, 'Qris'),
(6, 'Qris'),
(7, 'Qris'),
(8, 'Qris'),
(9, 'Qris'),
(10, 'Qris'),
(11, 'Qris'),
(12, 'Qris'),
(13, 'Qris'),
(14, 'Qris'),
(15, 'Cash'),
(16, 'Cash'),
(17, 'Cash'),
(18, 'Cash'),
(19, 'Cash'),
(20, 'Qris'),
(21, 'Qris'),
(22, 'Qris'),
(23, 'Cash'),
(24, 'Qris'),
(25, 'Cash'),
(26, 'Qris'),
(27, 'Qris'),
(28, 'Qris');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pemesanan`
--

CREATE TABLE `pemesanan` (
  `ID_PEMESANAN` int(11) NOT NULL,
  `ID_PELANGGAN` int(11) DEFAULT NULL,
  `ID_PEMBAYARAN` int(11) DEFAULT NULL,
  `ID_ADMIN` int(11) DEFAULT NULL,
  `TANGGAL_PEMESANAN` varchar(25) DEFAULT NULL,
  `STATUS_PEMESANAN` varchar(15) DEFAULT NULL,
  `TANGGAL_PEMBAYARAN` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pemesanan`
--

INSERT INTO `pemesanan` (`ID_PEMESANAN`, `ID_PELANGGAN`, `ID_PEMBAYARAN`, `ID_ADMIN`, `TANGGAL_PEMESANAN`, `STATUS_PEMESANAN`, `TANGGAL_PEMBAYARAN`) VALUES
(3, 1, 3, 3, '2024-12-09', 'Selesai', '2024-12-09'),
(4, 1, 4, 3, '2024-12-09', 'Selesai', '2024-12-09'),
(5, 2, 6, 4, '2024-12-10', 'Selesai', '2024-12-10'),
(6, 16, 7, 4, '2024-12-12', 'Selesai', '2024-12-12'),
(7, 5, 8, 1, '2024-12-12', 'Selesai', '2024-12-12'),
(8, 13, 9, 2, '2024-12-12', 'Selesai', '2024-12-12'),
(9, 5, 10, 1, '2024-12-18', 'Selesai', '2024-12-18'),
(10, 18, 11, 2, '2024-12-18', 'Selesai', '2024-12-18'),
(11, 26, 12, 4, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(12, 9, 13, 1, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(13, 24, 14, 1, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(14, 17, 15, 2, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(15, 21, 16, 3, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(16, 16, 17, 3, '2024-12-19', 'Selesai', '2024-12-19'),
(17, 19, 18, 3, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(18, 25, 19, 3, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(19, 8, 20, 1, '2024-12-19', 'Selesai', '2024-12-19'),
(20, 15, 21, 4, '2024-12-19', 'Selesai', '2024-12-19'),
(21, 21, 22, 3, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(22, 3, 23, 4, '2024-12-19', 'Selesai', '2024-12-19'),
(23, 11, 24, 2, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(24, 6, 25, 2, '2024-12-19', 'Belum Selesai', '2024-12-19'),
(25, 23, 26, 4, '2024-12-19', 'Selesai', '2024-12-19'),
(26, 23, 28, 1, '2024-12-23', 'Selesai', '2024-12-23');

-- --------------------------------------------------------

--
-- Struktur dari tabel `rute`
--

CREATE TABLE `rute` (
  `ID_RUTE` int(11) NOT NULL,
  `STASIUN_AWAL` varchar(25) DEFAULT NULL,
  `STASIUN_TUJUAN` varchar(25) DEFAULT NULL,
  `DURASI_PERJALANAN` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `rute`
--

INSERT INTO `rute` (`ID_RUTE`, `STASIUN_AWAL`, `STASIUN_TUJUAN`, `DURASI_PERJALANAN`) VALUES
(1, 'Wonokromo', 'Kertosono', '2 Jam'),
(2, 'Sepanjang', 'Wonokromo', '1 Jam'),
(3, 'Wonokromo', 'Ngadiluwih ', '4 Jam'),
(4, 'Pasar Turi ', 'Mojokerto', '1 Jam'),
(5, 'Gubeng', 'Malang ', '2,5 Jam'),
(6, 'Gubeng ', 'Lamongan ', '1,5 Jam'),
(7, 'Gubeng ', 'Banyuwangi', '6 Jam'),
(8, 'Gubeng ', 'Jember', '4 Jam'),
(9, 'Pasar Turi  ', 'Bitar', '3,5 Jam'),
(10, 'Wonokromo', 'Kediri', '3.5 Jam'),
(11, 'Pasar Turi ', 'Nganjuk', '2 Jam'),
(12, 'Gubeng', 'Probolinggo', '2.5 Jam'),
(13, 'Gubeng', 'Tuban', '2 Jam'),
(14, 'Pasar Turi', 'Cirebon', '7 Jam'),
(15, 'Gubeng', 'Situbondo', '5 Jam'),
(16, 'Wonokromo', 'Jogja', '5.5 Jam'),
(17, 'Wonokromo', 'Semarang', '7.5 Jam'),
(18, 'Pasar Turi  ', 'Ciamis ', '5 Jam'),
(19, 'Gubeng', 'Tegal', '5 Jam'),
(20, 'Pasar  Turi ', 'Purwokerto', '7 Jam'),
(21, 'Gubeng', 'Magetan', '3 Jam'),
(22, 'Wonokromo', 'Kebumen', '6 Jam'),
(23, 'Wonokromo', 'Kebumen', '6 Jam'),
(24, 'Pasar Turi ', 'Blora', '4.5 Jam'),
(25, 'Pasar Turi ', 'Ngawi', '2.5 Jam'),
(26, 'Banjar', 'Garut', '5jam');

-- --------------------------------------------------------

--
-- Struktur dari tabel `stasiun`
--

CREATE TABLE `stasiun` (
  `ID_STASIUN` int(11) NOT NULL,
  `NAMA_STASIUN` varchar(25) DEFAULT NULL,
  `LOKASI_STASIUN` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `stasiun`
--

INSERT INTO `stasiun` (`ID_STASIUN`, `NAMA_STASIUN`, `LOKASI_STASIUN`) VALUES
(1, 'Kertosono', 'Nganjuk'),
(2, 'Wonokromo', 'Surabaya'),
(3, 'Sepanjang', 'Sepanjang'),
(4, 'Gubeng', 'Gubeng'),
(5, 'Solo Balapan', 'Solo '),
(6, 'Gambir', 'Jakarta Pusat '),
(7, 'PasarTuri ', 'Surabaya'),
(8, 'Stasiun Cerme ', 'Gresik'),
(9, 'Stasiun Kandangan', 'Surabaya'),
(10, 'Stasiun Kediri', 'Kediri'),
(11, 'Stasiun Wonoayu', 'Sidoarjo'),
(12, 'Gempol', 'Pasuruan'),
(13, 'Stasiun semarang tawang', 'semarang'),
(14, 'Stasiun Cirebon', 'Cirebon'),
(15, 'Stasiun Solo  Jembres', 'Surakarta'),
(16, 'Stasiun Jatinegara', 'Jakarta Timur '),
(17, 'Stasiun Tawangmas', 'semarang'),
(18, 'Stasiun serang', 'Banten'),
(19, 'Stasiun Ciamis', 'Ciamis'),
(20, 'Stasiun Banyuwangi baru', 'banyuwangi'),
(21, 'Stasiun Tegal', 'Tegal'),
(22, 'Stasiun Cikarang ', 'Bekasi'),
(23, 'Stasiun garut ', 'Garut'),
(24, 'Stasiun Banjar', 'Banjar'),
(25, 'Stasiun Kuningan ', 'Kuningan'),
(26, 'Slebew', 'Gresik Jaya'),
(27, 'Papar', 'Kediri');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tiket`
--

CREATE TABLE `tiket` (
  `ID_TIKET` int(11) NOT NULL,
  `ID_KERETA` int(11) DEFAULT NULL,
  `ID_JADWAL` int(11) DEFAULT NULL,
  `HARGA_TIKET` varchar(20) DEFAULT NULL,
  `NO_KURSI` varchar(3) DEFAULT NULL,
  `TANGGAL_TIKET` varchar(25) DEFAULT NULL,
  `ID_STASIUN` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tiket`
--

INSERT INTO `tiket` (`ID_TIKET`, `ID_KERETA`, `ID_JADWAL`, `HARGA_TIKET`, `NO_KURSI`, `TANGGAL_TIKET`, `ID_STASIUN`) VALUES
(1, 1, 1, '14.000', 'A10', '2024-12-04', 1),
(2, 1, 1, '15000', 'A13', '2024-12-09', 2),
(3, 2, 2, '7000', 'A12', '2024-12-10', 3),
(4, 9, 9, '50000', 'A17', '2024-12-18', 4),
(5, 7, 20, '15000', 'A70', '2024-12-18', 2),
(6, 19, 3, '50000', 'B10', '2024-12-18', 12),
(7, 7, 7, '15.000', 'A05', '2024-12-18', 8),
(8, 13, 8, '17.000', 'C15', '2024-12-18', 5),
(9, 24, 9, '25.000', 'A12', '2024-12-18', 23),
(10, 18, 10, '25.000', 'D14', '2024-12-18', 24),
(11, 25, 11, '13.000', 'D15', '2024-12-18', 19),
(12, 17, 12, '30.000', 'B07', '2024-12-18', 22),
(13, 15, 13, '18.000', 'A08', '2024-12-18', 10),
(14, 19, 14, '15.000', 'A09', '2024-12-18', 22),
(15, 25, 15, '45.000', 'C13', '2024-12-18', 23),
(16, 26, 16, '35.000', 'B05', '2024-12-18', 21),
(17, 14, 17, '20.000', 'A02', '2024-12-18', 5),
(18, 2, 18, '15.000', 'C07', '2024-12-18', 5),
(19, 27, 19, '45.000', 'D12', '2024-12-18', 21),
(20, 4, 20, '17.000', 'E12', '2024-12-18', 10),
(21, 3, 21, '15.000', 'E07', '2024-12-18', 5),
(22, 22, 22, '25.000', 'E02', '2024-12-18', 13),
(23, 19, 23, '25.000', 'E06', '2024-12-18', 8),
(24, 12, 24, '30.000', 'A14', '2024-12-18', 17),
(25, 28, 25, '35.000', 'D12', '2024-12-18', 16),
(26, 1, 1, '', 'a15', '2024-12-23', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tiket_pemesanan`
--

CREATE TABLE `tiket_pemesanan` (
  `ID_TIKET` int(11) DEFAULT NULL,
  `ID_PEMESANAN` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tiket_pemesanan`
--

INSERT INTO `tiket_pemesanan` (`ID_TIKET`, `ID_PEMESANAN`) VALUES
(1, 3),
(1, 4),
(3, 5),
(3, 6),
(1, 7),
(3, 8),
(4, 9),
(2, 10),
(22, 11),
(13, 12),
(4, 13),
(6, 14),
(14, 15),
(25, 16),
(18, 17),
(22, 18),
(17, 19),
(25, 20),
(24, 21),
(12, 22),
(12, 23),
(15, 24),
(11, 25),
(16, 26);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ID_ADMIN`);

--
-- Indeks untuk tabel `feedback`
--
ALTER TABLE `feedback`
  ADD PRIMARY KEY (`ID_FEEDBACK`),
  ADD KEY `FK_REFERENCE_12` (`ID_PELANGGAN`),
  ADD KEY `FK_REFERENCE_13` (`ID_PEMESANAN`);

--
-- Indeks untuk tabel `jadwal`
--
ALTER TABLE `jadwal`
  ADD PRIMARY KEY (`ID_JADWAL`);

--
-- Indeks untuk tabel `kereta`
--
ALTER TABLE `kereta`
  ADD PRIMARY KEY (`ID_KERETA`),
  ADD KEY `FK_REFERENCE_16` (`ID_RUTE`);

--
-- Indeks untuk tabel `pelanggan`
--
ALTER TABLE `pelanggan`
  ADD PRIMARY KEY (`ID_PELANGGAN`);

--
-- Indeks untuk tabel `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD PRIMARY KEY (`ID_PEMBAYARAN`);

--
-- Indeks untuk tabel `pemesanan`
--
ALTER TABLE `pemesanan`
  ADD PRIMARY KEY (`ID_PEMESANAN`),
  ADD KEY `FK_REFERENCE_1` (`ID_ADMIN`),
  ADD KEY `FK_REFERENCE_14` (`ID_PEMBAYARAN`),
  ADD KEY `FK_REFERENCE_2` (`ID_PELANGGAN`);

--
-- Indeks untuk tabel `rute`
--
ALTER TABLE `rute`
  ADD PRIMARY KEY (`ID_RUTE`);

--
-- Indeks untuk tabel `stasiun`
--
ALTER TABLE `stasiun`
  ADD PRIMARY KEY (`ID_STASIUN`);

--
-- Indeks untuk tabel `tiket`
--
ALTER TABLE `tiket`
  ADD PRIMARY KEY (`ID_TIKET`),
  ADD KEY `FK_REFERENCE_11` (`ID_STASIUN`),
  ADD KEY `FK_REFERENCE_15` (`ID_KERETA`),
  ADD KEY `FK_REFERENCE_6` (`ID_JADWAL`);

--
-- Indeks untuk tabel `tiket_pemesanan`
--
ALTER TABLE `tiket_pemesanan`
  ADD KEY `FK_REFERENCE_3` (`ID_TIKET`),
  ADD KEY `FK_REFERENCE_4` (`ID_PEMESANAN`);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `feedback`
--
ALTER TABLE `feedback`
  ADD CONSTRAINT `FK_REFERENCE_12` FOREIGN KEY (`ID_PELANGGAN`) REFERENCES `pelanggan` (`ID_PELANGGAN`),
  ADD CONSTRAINT `FK_REFERENCE_13` FOREIGN KEY (`ID_PEMESANAN`) REFERENCES `pemesanan` (`ID_PEMESANAN`);

--
-- Ketidakleluasaan untuk tabel `kereta`
--
ALTER TABLE `kereta`
  ADD CONSTRAINT `FK_REFERENCE_16` FOREIGN KEY (`ID_RUTE`) REFERENCES `rute` (`ID_RUTE`);

--
-- Ketidakleluasaan untuk tabel `pemesanan`
--
ALTER TABLE `pemesanan`
  ADD CONSTRAINT `FK_REFERENCE_1` FOREIGN KEY (`ID_ADMIN`) REFERENCES `admin` (`ID_ADMIN`),
  ADD CONSTRAINT `FK_REFERENCE_14` FOREIGN KEY (`ID_PEMBAYARAN`) REFERENCES `pembayaran` (`ID_PEMBAYARAN`),
  ADD CONSTRAINT `FK_REFERENCE_2` FOREIGN KEY (`ID_PELANGGAN`) REFERENCES `pelanggan` (`ID_PELANGGAN`);

--
-- Ketidakleluasaan untuk tabel `tiket`
--
ALTER TABLE `tiket`
  ADD CONSTRAINT `FK_REFERENCE_11` FOREIGN KEY (`ID_STASIUN`) REFERENCES `stasiun` (`ID_STASIUN`),
  ADD CONSTRAINT `FK_REFERENCE_15` FOREIGN KEY (`ID_KERETA`) REFERENCES `kereta` (`ID_KERETA`),
  ADD CONSTRAINT `FK_REFERENCE_6` FOREIGN KEY (`ID_JADWAL`) REFERENCES `jadwal` (`ID_JADWAL`);

--
-- Ketidakleluasaan untuk tabel `tiket_pemesanan`
--
ALTER TABLE `tiket_pemesanan`
  ADD CONSTRAINT `FK_REFERENCE_3` FOREIGN KEY (`ID_TIKET`) REFERENCES `tiket` (`ID_TIKET`),
  ADD CONSTRAINT `FK_REFERENCE_4` FOREIGN KEY (`ID_PEMESANAN`) REFERENCES `pemesanan` (`ID_PEMESANAN`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
