# Hole-Master
> Một tựa game **Casual/Puzzle** được phát triển bằng Unity.
> **Gameplay:** Điều khiển hố đen thu thập vật thể để tăng kích thước, nuốt chửng mọi thứ trên bản đồ.

![Gameplay Demo]()

---

## Links Demo

* **Video Gameplay:** [Xem trên YouTube](https://youtu.be/XV3I5SKgXkk)
* **Chơi thử:** [Chơi trên web itch.io](https://maithuong.itch.io/hole-master)

---

## Tech Stack
* **Engine:** Unity 3D
* **Language:** C#
* **Core Tech:** Custom Shader, Binary Serialization, Physics Optimization.

---

## Key Features

* Áp dụng **Singleton Pattern** cho các hệ thống quản lý trung tâm
(Sound, Level, Data).
* Sử dụng **Custom Shader (ZWrite Off)** để xử lý Depth Buffer, tạo hiệu
ứng thị giác "hố không đáy".
* Xây dựng hệ thống **Binary Serialization** (sử dụng Binary Formatter)
để mã hóa và lưu trữ dữ liệu (Gold, Items, Level).
* Sử dụng kỹ thuật **Culling Physics**: Chỉ kích hoạt Rigidbody cho vật
thể khi nằm trong vùng tương tác.

---

## 📬 Contact
* **Name:** Mai Xuân Thường
* **Email:** maithuong.dev@gmail.com