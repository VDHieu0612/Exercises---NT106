# QuanLyNguoiDungApp

Ứng dụng quản lý người dùng viết bằng **C# WinForms** và **SQL Server**.  
Chức năng chính bao gồm: đăng ký, đăng nhập, xem thông tin cá nhân (profile).

---

## 🚀 Mô tả bài tập

- **Đăng ký người dùng mới**  
  - Kiểm tra email hợp lệ và không trùng trong cơ sở dữ liệu.  
  - Username chỉ chứa chữ và số.  
  - Mật khẩu có ít nhất 8 ký tự, bao gồm chữ hoa, số và ký tự đặc biệt.  
  - Số điện thoại (nếu nhập) phải có 10 số và bắt đầu bằng 0.  
  - Ngày sinh phải đúng định dạng `dd/MM/yyyy` và người dùng phải trên 12 tuổi.  

- **Đăng nhập**  
  - Kiểm tra email + mật khẩu.  
  - So sánh password đã hash (SHA-512).  
  - Nếu đúng → chuyển vào màn hình **Profile**.  

- **Profile người dùng**  
  - Hiển thị Email, Username, Số điện thoại, Ngày sinh, Ngày tạo tài khoản.  
  - Cho phép **Đăng xuất** quay về màn hình đăng nhập.  

---

## ⚙️ Hướng dẫn cài đặt

1. Cài đặt **SQL Server** và **SQL Server Management Studio (SSMS)**.  
2. Tạo database:
   ```sql
   CREATE DATABASE QUANLYNGUOIDUNG;
   GO

   USE QUANLYNGUOIDUNG;

   CREATE TABLE USERS (
       MaND INT PRIMARY KEY IDENTITY(1,1),
       LoaiUser NVARCHAR(50) NOT NULL,
       Email NVARCHAR(100) NOT NULL,
       UserName NVARCHAR(100) NOT NULL,
       SDT NVARCHAR(20),
       MatKhauHash NVARCHAR(255) NOT NULL,
       NgaySinh DATE NOT NULL,
       NgayTao DATETIME2 DEFAULT GETDATE()
   );
