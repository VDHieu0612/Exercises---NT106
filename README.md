
# QuanLyNguoiDungApp
Ứng dụng quản lý người dùng viết bằng **C# WinForms** và **SQL Server**.  
Chức năng chính bao gồm: đăng ký, đăng nhập, xem thông tin cá nhân (profile).

---

## 👥 Thành viên nhóm
1. 23520498 - Võ Duy Hiếu
2. 23520837 - Trương Tùng Lâm
3. 23521269 - Quách Trọng Hải Quân
4. 24520759 - Nguyễn Nhan Quốc Khang

## 🚀 Mô tả bài tập

1. **Đăng ký người dùng mới**  
  - Kiểm tra email hợp lệ và không trùng trong cơ sở dữ liệu.  
  - Username chỉ chứa chữ và số và không trùng trong cơ sở dữ liệu.
  - Mật khẩu có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt.  
  - Số điện thoại (nếu nhập) phải có 10 số và bắt đầu bằng 0.  
  - Ngày sinh phải đúng định dạng `dd/MM/yyyy` và người dùng phải trên 12 tuổi.
  - Người dùng phải điền đầy đủ thông tin ở các trường bắt buộc (trừ số điện thoại).
  - Nếu đăng ký thành công → chuyển vào màn hình **Profile**.  

2. **Đăng nhập**  
  - Kiểm tra email + mật khẩu.  
  - So sánh password đã hash (SHA-512).  
  - Nếu đúng email và password đã có trong cơ sở dữ liệu → chuyển vào màn hình **Profile**.  

3. **Profile người dùng**  
  - Hiển thị Email, Username, Số điện thoại, Ngày sinh, Loại người dùng (Admin, Người dùng).  
  - Cho phép **Đăng xuất** quay về màn hình đăng nhập.  

---

## ⚙️ Hướng dẫn cài đặt

1. Cài đặt **SQL Server** và **SQL Server Management Studio (SSMS)**.  
2. Tạo database:
   ```sql
   CREATE DATABASE QUANLYNGUOIDUNG;

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

3. Cấu hình App.config trong project:
   ```
	<connectionStrings>
		<add name="UserDb"
			 connectionString="Server=LENOVO-YOGA-PRO;Database=QUANLYNGUOIDUNG;Trusted_Connection=True;User Id=tester;Password=hieu06122005;" Lưu ý: Tuỳ chỉnh Server, User Id, Password tuỳ theo máy tính cá nhân
			 providerName="System.Data.SqlClient" />
	</connectionStrings>
  
5. Mở solution QuanLyNguoiDungApp.sln trong Visual Studio và chạy.

## ▶️ Hướng dẫn sử dụng

1. Đăng ký

- Nhập đầy đủ thông tin bắt buộc (Email, Username, Ngày sinh, Mật khẩu, Xác nhận mật khẩu) (Số điện thoại nếu có).

- Nếu hợp lệ → tài khoản được tạo trong DB → hiển thị màn hình Profile.

2. Đăng nhập

- Nhập Email + Mật khẩu.

- Nếu đúng → hiển thị màn hình Profile.

3. Profile

- Hiển thị thông tin tài khoản.

- Có thể đăng xuất về màn hình đăng nhập.
## 📌 Công nghệ sử dụng

- C# WinForms (.NET Framework)

- SQL Server

- SHA-512 hashing cho mật khẩu
