using Microsoft.EntityFrameworkCore;
using QLCC.Entities;
using QLCC.Models;
using QLCC.ViewModels;

namespace TestProject
{
    public class Tests
    {
        private DataContext _db;
        private Random _random;
        [SetUp]
        public void Setup()
        {
            _db = new DataContext();
            _random = new Random();
        }

        [Test]
        public void Test1()
        {
            //InsertHistories();
            int month = _random.Next(1, 5);
            for (int i = 1; i <= 5; i++)
            {
                int day = _random.Next(1, 30);

                for (int j = 1; j <= 20; j++)
                {
                    InsertChamCong(i,j);
                }
            }
            Assert.Pass();
        }
        private void InsertHistories()
        {
            var users = _db.Users.ToList();
            foreach (var user in users)
            {
                var days = _random.Next(1, 31);
                for (int i = 1; i <= days; i++)
                {
                    _db.LichSuChamCong.Add(new QLCC.Entities.HISTORY_TIME_KEEP()
                    {
                        NgayChamCong = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i),
                        USER_ID = user.Id,
                        ThoiGianChamCong = _random.NextInt64(10000, 900000),
                    });
                }
            }
            _db.SaveChanges();
        }
        private void InsertChamCong(int month, int day)
        {
            var dateNow = new DateTime(2023, month, day);
            var ngayChamCong = new DateTimeKeep()
            {
                ThoiGianChamCong = dateNow,
                ThoiGianRaVe = dateNow,
                Ten = dateNow.ToString("dd-MM-yyyy"),
                Date = dateNow,
            };

             _db.NgayChamCong.Add(ngayChamCong);
             _db.SaveChanges();
            // Thêm Thời gian chấm công cho người chấm công
            var chamCong = new TIME_KEEP()
            {
                NhanVienId = 1,
                NgayChamCongId = ngayChamCong.Id,
            };
            // Kiểm tra nhân viên và thời gian đó đã tồn tại hay chưa
            var chamCongOl =  _db.ChamCong.FirstOrDefault(x => x.NhanVienId == chamCong.NhanVienId && x.NgayChamCongId == chamCong.NgayChamCongId);
            // Chưa tồn tại
            if (chamCongOl == null)
            {
                // THêm vào db
                _db.ChamCong.Add(chamCong);
                        _db.SaveChanges();
            }
            // Lưu lịch sử cho nhân viên chấm công
            var lichsuChamCong = new HISTORY_TIME_KEEP()
            {
                NgayChamCong = dateNow,
                USER_ID = 1,
                //ThoiGianChamCong = null,
            };
            // Kiểm tra lịch sử chấm công đã tồn tại chưa
            var lichsuChamCongOld = _db.LichSuChamCong.FirstOrDefault(x => x.NgayChamCong.Date == lichsuChamCong.NgayChamCong.Date && x.USER_ID == lichsuChamCong.USER_ID);
            // CHưa tồn tại
            if (lichsuChamCongOld == null)
            {
                _db.LichSuChamCong.Add(lichsuChamCong);
                _db.SaveChanges();
            }
        }
    }
}