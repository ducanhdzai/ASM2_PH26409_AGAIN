using System;
using System.Text;
using System.Threading;

namespace ASM2_PH26409_AGAIN
{
    internal class Program
    {
        static void Menu()
        {
            Services sv = new Services();
            int chon;
            do
            {

                Console.WriteLine("Menu");
                Console.WriteLine("----------------------");
                Console.WriteLine("1.Dùng LinQ to Sql");
                Console.WriteLine("2.Xuất danh sách học viên");
                Console.WriteLine("3.Tìm kiếm học viên theo khoảng Mark");
                Console.WriteLine("4. Tìm học viên theo StId và cập nhật thông tin học viên.");
                Console.WriteLine("5.Xuất học viên ra màn hình theo thứ tự điểm từ cao tới thấp");
                Console.WriteLine("6.Xuất 5 học viên có điểm cao nhất");
                Console.WriteLine("7.Tạo Thread có tên DTB thực hiện tính điểm trung bình theo từng lớp và ghi");
                Console.WriteLine("0.Kết thúc");
                Console.WriteLine("----------------------");
                Console.Write("Mời bạn chọn chức năng? ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        sv.Add();
                        break;
                    case 2:
                        sv.XuatHocLuc();
                        break;
                    case 3:
                        sv.TimKiemHocVien();
                        break;
                    case 4:
                        sv.CapNhatThongTin();
                        break;
                    case 5:
                        sv.XuatDiemTuCaoDenThap();
                        break;
                    case 6:
                        sv.Xuat5HocVienCoDiemCaoNhat();
                        break;
                    case 7:
                        Thread DTB = new Thread(sv.GhiThongTin);
                        DTB.Start();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Vui lòng chọn chức năng từ (0 - 7) pleaseeee");
                        break;
                }
            } while (chon != 0);

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Menu();
        }
    }
}
