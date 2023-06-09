using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ASM2_PH26409_AGAIN
{
    public class Services
    {
        ASM2DataContext _context = new ASM2DataContext(@"Data Source=DESKTOP-T9TS290;Initial Catalog=Asm_C#2;Integrated Security=True");
        public void Add()
        {
            Console.WriteLine("----------Y.01---------");
            string nhapLai;
            do
            {
                Console.WriteLine("Moi ban nhap ten Class");
                Class addClass = new Class()
                {
                    NameClass = Console.ReadLine(),
                };
                Console.WriteLine("Ban co muon nhap nua k? N de dung con lai la co");
                nhapLai = Console.ReadLine();
                _context.Classes.InsertOnSubmit(addClass);
                _context.SubmitChanges();
            } while (nhapLai.ToLower() != "n");
            foreach (Class addClass in _context.Classes.ToList())
            {
                Console.WriteLine(addClass.IdClass);
                Console.WriteLine(addClass.NameClass);
            }
            string nhapLaiSinhVien;
            do
            {
                string name;
                do
                {
                    Console.WriteLine("Moi ban nhap ten sinh vien");
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name.Trim()))
                    {
                        Console.WriteLine("Nhập tên đi bạn ơi");
                    }
                    if (_context.Students.Any(c => c.Namesd == name))
                    {
                        Console.WriteLine("Tên này đã trùng vui lòng thử lại");
                    }
                } while (string.IsNullOrEmpty(name.Trim()) || _context.Students.Any(c => c.Namesd == name));
                float diemTB;
                do
                {
                    Console.WriteLine("Moi ban nhap diemTB sinh vien");
                    diemTB = Convert.ToSingle(Console.ReadLine());
                    if (!Regex.IsMatch(diemTB.ToString(), @"^(?:10|[0-9](?:\.[0-9]+)?)$"))
                    {
                        Console.WriteLine("Chi nhap diem tu 0 -10");
                    }
                } while (!Regex.IsMatch(diemTB.ToString(), @"^(?:10|[0-9](?:\.[0-9]+)?)$"));
                string email;
                do
                {
                    Console.WriteLine("Moi ban nhap email sinh vien");
                    email = Console.ReadLine();
                    if (!Regex.IsMatch(email, @"^([\w\.\-]+)@(gmail.com)$"))
                    {
                        Console.WriteLine("Moi ban nhap dung dinh dang @gmail.com");
                    }
                } while (!Regex.IsMatch(email, @"^([\w\.\-]+)@(gmail.com)$"));
                Console.WriteLine("Moi ban nhap id class sinh vien");
                int idClass = Convert.ToInt16(Console.ReadLine());
                if (_context.Classes.Any(c => c.IdClass == idClass))//Any là để kiểm tra xem trong danh sách có thằng nào thỏa mãn điều kiện không nếu có thì nó sẽ trả về là true conf không thì là false
                {
                    Student student = new Student()
                    {
                        IdClass = idClass,
                        Namesd = name,
                        Mark = diemTB,
                        Email = email
                    };
                    _context.Students.InsertOnSubmit(student);
                    _context.SubmitChanges();
                }
                else
                {
                    Console.WriteLine("Khong ton tai ID Class");
                }
                Console.WriteLine("Ban co muon nhap nua k? N de dung con lai la co");
                nhapLaiSinhVien = Console.ReadLine();
            } while (nhapLaiSinhVien.ToLower() != "n");
        }
        public void XuatHocLuc()
        {
            Console.WriteLine("----------Y.02---------");
            foreach (var item in _context.Students.ToList())
            {
                Console.WriteLine(item.Namesd);
                Console.WriteLine(item.Mark);
                Console.WriteLine(item.Email);
                Console.WriteLine(item.IdClass);
                string hocLuc;
                if (item.Mark > 0 && item.Mark < 3)
                {
                    hocLuc = "Kém";
                }
                else if (item.Mark < 5)
                {
                    hocLuc = "Yếu";
                }
                else if (item.Mark < 6.5)
                {
                    hocLuc = "Trung bình";
                }
                else if (item.Mark < 7.5)
                {
                    hocLuc = "Khá";
                }
                else if (item.Mark < 9)
                {
                    hocLuc = "Giỏi";
                }
                else if (item.Mark > 9 && item.Mark <= 10)
                {
                    hocLuc = "Xuất sắc";
                }
                else
                {
                    hocLuc = "Diem nay hoi ao ma";
                }
                Console.WriteLine(hocLuc);
            }
        }
        public void TimKiemHocVien()
        {
            Console.WriteLine("----------Y.03---------");
            double diemMin, diemMax;
            Console.Write("Nhập điểm Min: ");
            diemMin = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhập điểm Max: ");
            diemMax = Convert.ToDouble(Console.ReadLine());

            foreach (var student in _context.Students)
            {
                if (diemMin <= student.Mark && student.Mark <= diemMax)
                {
                    Console.WriteLine(student.Namesd);
                    Console.WriteLine(student.Mark);
                    Console.WriteLine(student.Email);
                    Console.WriteLine(student.IdClass);
                }

            }
        }
        public void CapNhatThongTin()
        {
            Console.WriteLine("----------Y.04---------");
            Console.WriteLine("Moi ban nhap StId: ");
            int stID = Convert.ToInt16(Console.ReadLine());
            if (_context.Students.Any(c => c.StId == stID))
            {
                var updateDatabase = _context.Students.FirstOrDefault(c => c.StId == stID);
                string name;
                do
                {
                    Console.WriteLine("Moi ban nhap ten sinh vien");
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name.Trim()))
                    {
                        Console.WriteLine("Nhập tên đi bạn ơi");
                    }
                    if (_context.Students.Any(c => c.Namesd == name))
                    {
                        Console.WriteLine("Tên này đã trùng vui lòng thử lại");
                    }
                } while (string.IsNullOrEmpty(name.Trim()) || _context.Students.Any(c => c.Namesd == name));
                float diemTB;
                do
                {
                    Console.WriteLine("Moi ban nhap diemTB sinh vien");
                    diemTB = Convert.ToSingle(Console.ReadLine());
                    if (!Regex.IsMatch(diemTB.ToString(), @"^(?:10|[0-9](?:\.[0-9]+)?)$"))
                    {
                        Console.WriteLine("Chi nhap diem tu 0 -10");
                    }
                } while (!Regex.IsMatch(diemTB.ToString(), @"^(?:10|[0-9](?:\.[0-9]+)?)$"));
                string email;
                do
                {
                    Console.WriteLine("Moi ban nhap email sinh vien");
                    email = Console.ReadLine();
                    if (!Regex.IsMatch(email, @"^([\w\.\-]+)@(gmail.com)$"))
                    {
                        Console.WriteLine("Moi ban nhap dung dinh dang @gmail.com");
                    }
                } while (!Regex.IsMatch(email, @"^([\w\.\-]+)@(gmail.com)$"));
                Console.WriteLine("Moi ban nhap id class sinh vien");
                int idClass = Convert.ToInt16(Console.ReadLine());
                if (_context.Classes.Any(c => c.IdClass == idClass))//Any là để kiểm tra xem trong danh sách có thằng nào thỏa mãn điều kiện không nếu có thì nó sẽ trả về là true conf không thì là false
                {
                    updateDatabase.IdClass = idClass;
                    updateDatabase.Namesd = name;
                    updateDatabase.Email = email;
                    _context.SubmitChanges();
                }
                else
                {
                    Console.WriteLine("Khong ton tai ID Class");
                }
            }
            else
            {
                Console.WriteLine("MSV khong ton tai");
            }
        }
        public void XuatDiemTuCaoDenThap()
        {
            Console.WriteLine("----------Y.05---------");
            foreach (var item in _context.Students.OrderByDescending(c => c.Mark))
            {
                Console.WriteLine(item.Namesd);
                Console.WriteLine(item.Mark);
                Console.WriteLine(item.Email);
                Console.WriteLine(item.IdClass);
            }
        }
        public void Xuat5HocVienCoDiemCaoNhat()
        {
            Console.WriteLine("----------Y.06---------");
            foreach (var item in _context.Students.OrderByDescending(c => c.Mark).Take(5))
            {
                Console.WriteLine(item.Namesd);
                Console.WriteLine(item.Mark);
                Console.WriteLine(item.Email);
                Console.WriteLine(item.IdClass);
            }
        }
        public void GhiThongTin()
        {
            using (StreamWriter sw = new StreamWriter("Asm_C#2.txt"))
            {
                var lstStd = _context.Students.ToList();
                var lstClass = _context.Classes.ToList();
                var newList = lstClass.GroupJoin(lstStd, cls => cls.IdClass, std => std.IdClass,
                    (cls, std) => new
                    {
                        cls,
                        std
                    }
                    );
                foreach (var item in newList)
                {

                    if (item.std.Average(c => c.Mark).HasValue)
                    {
                        string result = "Lop " + item.cls.NameClass + " Diem trung binh: " + item.std.Average(c => c.Mark);
                        sw.WriteLine(result);
                    }
                }
            }
        }
    }
}
