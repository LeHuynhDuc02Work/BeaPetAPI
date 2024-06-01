Dưới đây là tóm tắt về API của website BeaPet:

Quản lý sản phẩm:
API endpoint: /api/products
Các phương thức: GET, POST, PUT, DELETE
Tương tác với CSDL để lấy, thêm, sửa, xóa thông tin sản phẩm

Quản lý đơn hàng:
API endpoint: /api/orders
Các phương thức: GET, POST, PUT, DELETE
Tương tác với CSDL để lấy, thêm, sửa, xóa thông tin đơn hàng

Quản lý khách hàng:
API endpoint: /api/customers
Các phương thức: GET, POST, PUT, DELETE
Tương tác với CSDL để lấy, thêm, sửa, xóa thông tin khách hàng

Thanh toán:
API endpoint: /api/payments
Các phương thức: POST
Kết nối với cổng thanh toán để xử lý giao dịch

Báo cáo thống kê:
API endpoint: /api/reports
Các phương thức: GET
Tương tác với CSDL để lấy dữ liệu thống kê doanh thu, sản phẩm bán chạy, v.v.

Quản lý liên hệ:
API endpoint: /api/contacts
Các phương thức: GET, POST
Tương tác với CSDL để lấy và lưu trữ thông tin liên hệ từ khách hàng

Các API được xây dựng dựa trên các nguyên tắc thiết kế RESTful, sử dụng phương thức HTTP phù hợp, định nghĩa rõ ràng các endpoint và cấu trúc dữ liệu JSON. Chúng được bảo mật và xác thực thông qua token JWT.
